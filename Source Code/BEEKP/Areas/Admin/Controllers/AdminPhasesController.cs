using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BEEKP.Areas.Admin.Controllers
{
    public class AdminPhasesController : AdminBaseController
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                ClearError();
                AdminPhasesViewModel objAdminFAQViewModel = new AdminPhasesViewModel();
                objAdminFAQViewModel.ListPhasesActive = await GetPhasesList(Constants.STATUS_ACTIVE);
                objAdminFAQViewModel.ListPhasesInactive = await GetPhasesList(Constants.STATUS_INACTIVE);
                objAdminFAQViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminPhases", "Admin");

                if (objAdminFAQViewModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminFAQViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        public async Task<ActionResult> PhasesAddEdit(String sPhasesID)
        {
            try
            {
                Int32 iPhasesID = Convert.ToInt32(Encryption.Decrypt(sPhasesID, true));

                AdminPhasesViewModel objPhasesViewAddEditModel = new AdminPhasesViewModel();
                objPhasesViewAddEditModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "PhasesAddEdit", "AdminPhases", "Admin");
                if (objPhasesViewAddEditModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (iPhasesID == 0)
                    {
                        objPhasesViewAddEditModel.Phases = new Phases();
                    }
                    else
                    {
                        objPhasesViewAddEditModel.Phases = await GetPhasesById(iPhasesID);
                    }
                    return View(objPhasesViewAddEditModel);
                }

            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] // for ckeditor
        public async Task<ActionResult> PhasesAddEdit(PhasesViewAddEditModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);
                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<PhasesViewAddEditModel>("api/API_Phase/SavePhases/", model).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminPhases"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("PhasesAddEdit", "AdminPhases"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
                    }
                }
                else
                {
                    ErrorMessage _ErrorMessage = await CheckResponse(response);
                    throw new Exception(_ErrorMessage.ErrorMessages);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        public async Task<Phases> GetPhasesById(Int32 iPhases_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Phase/GetPhasesById/" + iPhases_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<Phases>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<ActionResult> DeletePhases(String sPhases_id)
        {
            try
            {
                Int32 iPhases_id = Convert.ToInt32(Encryption.Decrypt(sPhases_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_Phase/DeletePhases/" + iPhases_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminPhases");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminPhases");
                    }

                    return RedirectToAction("Index", "AdminPhases", new { sPhases_id = sPhases_id });
                }

                else
                {
                    ErrorMessage _ErrorMessage = await CheckResponse(response);
                    throw new Exception(_ErrorMessage.ErrorMessages);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        public async Task<List<Phases>> GetPhasesList(Int32 _status)

        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Phase/GetPhasesList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Phases>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        /* public async Task<ActionResult> Index()
         {
             try
             {
                 ClearError();
                 AdminPhasesViewModel objAdminFAQViewModel = new AdminPhasesViewModel();
                 objAdminFAQViewModel.ListPhasesActive = await GetPhasesList(Constants.STATUS_ACTIVE);
                 objAdminFAQViewModel.ListPhasesInactive = await GetPhasesList(Constants.STATUS_INACTIVE);
                 objAdminFAQViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminPhases", "Admin");

                 if (objAdminFAQViewModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                 {
                     return RedirectToAction("HttpError403", "Error");
                 }
                 if (HasError())
                 {
                     return RedirectToAction("GeneralError", "Error");
                 }
                 else
                 {
                     return View(objAdminFAQViewModel);
                 }
             }
             catch (Exception ex)
             {
                 ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                 PopulateError(objErrorMessage);
                 return RedirectToAction("GeneralError", "Error");
             }
         }*/
        /* public async Task<ActionResult> PhasesAddEdit(String sPhasesID)
         {
             try
             {
                 Int32 iPhasesID = Convert.ToInt32(Encryption.Decrypt(sPhasesID, true));

                 AdminPhasesViewModel objPhasesViewAddEditModel = new AdminPhasesViewModel();
                 objPhasesViewAddEditModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "PhasesAddEdit", "AdminPhases", "Admin");
                 if (objPhasesViewAddEditModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                 {
                     return RedirectToAction("HttpError403", "Error");
                 }
                 if (HasError())
                 {
                     return RedirectToAction("GeneralError", "Error");
                 }
                 else
                 {
                     if (iPhasesID == 0)
                     {
                         objPhasesViewAddEditModel.Phases = new Phases();
                     }
                     else
                     {
                         objPhasesViewAddEditModel.Phases = await GetPhasesById(iPhasesID);
                     }
                     return View(objPhasesViewAddEditModel);
                 }

             }
             catch (Exception ex)
             {
                 ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                 PopulateError(objErrorMessage);
                 return RedirectToAction("GeneralError", "Error");
             }
         }*/
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> PhasesAddEdit(PhasesViewAddEditModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }
                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);
                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<PhasesViewAddEditModel>("api/API_Phase/SavePhases/", model).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminPhases");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("PhasesAddEdit", "AdminPhases");
                    }

                }
                else
                {
                    ErrorMessage _ErrorMessage = await CheckResponse(response);
                    throw new Exception(_ErrorMessage.ErrorMessages);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }*/

        /*public async Task<Phases> GetPhasesById(Int32 iPhasesID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Phases/GetPhasesById/" + iPhasesID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<Phases>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<ActionResult> DeletePhases(String sPhases_id)
        {
            try
            {
                Int32 iPhases_id = Convert.ToInt32(Encryption.Decrypt(sPhases_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_Phase/DeletePhases/" + iPhases_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminPhases");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminPhases");
                    }

                    return RedirectToAction("Index", "AdminPhases", new { sPhases_id = sPhases_id });
                }

                else
                {
                    ErrorMessage _ErrorMessage = await CheckResponse(response);
                    throw new Exception(_ErrorMessage.ErrorMessages);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        public async Task<List<Phases>> GetPhasesList(Int32 _status)

        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Phase/GetPhasesList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Phases>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }*/
    }
}