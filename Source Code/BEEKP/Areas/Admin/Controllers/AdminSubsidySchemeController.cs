using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Areas.Admin.Controllers
{
    public class AdminSubsidySchemeController : AdminBaseController
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                ClearError();
                AdminSubsidySchemeViewModel objAdminFAQViewModel = new AdminSubsidySchemeViewModel();
                objAdminFAQViewModel.ListSubsidySchemeActive = await GetSubsidySchemeList(Constants.STATUS_ACTIVE);
                objAdminFAQViewModel.ListSubsidySchemeInactive = await GetSubsidySchemeList(Constants.STATUS_INACTIVE);
                objAdminFAQViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminSubsidyScheme", "Admin");

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
        public async Task<ActionResult> ManageSubsidyScheme(String sSubsidySchemeID)
        {
            try
            {
                Int32 iSubsidySchemeID = Convert.ToInt32(Encryption.Decrypt(sSubsidySchemeID, true));

                SubsidySchemeManageModel objSubsidySchemeViewAddEditModel = new SubsidySchemeManageModel();
                objSubsidySchemeViewAddEditModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageSubsidyScheme", "AdminSubsidyScheme", "Admin");
                if (objSubsidySchemeViewAddEditModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (iSubsidySchemeID == 0)
                    {
                        objSubsidySchemeViewAddEditModel.SubsidyScheme = new SubsidyScheme();
                    }
                    else
                    {
                        objSubsidySchemeViewAddEditModel.SubsidyScheme = await GetSubsidySchemeById(iSubsidySchemeID);
                        // objAnnouncementViewAddEditModel.Event.listEventImage = await GetEventImageListByEventId(iEventID);
                        //return View(model);
                    }
                    return View(objSubsidySchemeViewAddEditModel);
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
        public async Task<ActionResult> ManageSubsidyScheme(SubsidySchemeManageModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);
                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<SubsidySchemeManageModel>("api/API_SubsidyScheme/SaveSubsidyScheme/", model).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminSubsidyScheme"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageSubsidyScheme", "AdminSubsidyScheme"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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
        public async Task<SubsidyScheme> GetSubsidySchemeById(Int32 iSubsidyScheme_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_SubsidyScheme/GetLoanSchemeById/" + iSubsidyScheme_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<SubsidyScheme>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<ActionResult> DeleteSubsidySchemee(String sSubsidyScheme_id)
        {
            try
            {
                Int32 iSubsidyScheme_id = Convert.ToInt32(Encryption.Decrypt(sSubsidyScheme_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_SubsidyScheme/DeleteSubsidyScheme/" + iSubsidyScheme_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminSubsidyScheme");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminSubsidyScheme");
                    }

                    return RedirectToAction("Index", "AdminSubsidyScheme", new { sSubsidyScheme_id = sSubsidyScheme_id });
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
        public async Task<List<SubsidyScheme>> GetSubsidySchemeList(Int32 _status)

        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_SubsidyScheme/GetSubsidySchemeList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<SubsidyScheme>>());
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
                 AdminSubsidySchemeViewModel objAdminSubsidySchemeViewModel = new AdminSubsidySchemeViewModel();
                 objAdminSubsidySchemeViewModel.ListSubsidySchemeActive = await GetSubsidySchemeList(Class.Constants.STATUS_ACTIVE, 0);
                 objAdminSubsidySchemeViewModel.ListSubsidySchemeInactive = await GetSubsidySchemeList(Class.Constants.STATUS_INACTIVE, 0);
                 objAdminSubsidySchemeViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminSubsidyScheme", "Admin");
                 if (objAdminSubsidySchemeViewModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                 {
                     return RedirectToAction("HttpError403", "Error");
                 }
                 if (HasError())
                 {
                     return RedirectToAction("GeneralError", "Error");
                 }
                 else
                 {
                     return View(objAdminSubsidySchemeViewModel);
                 }
             }
             catch (Exception ex)
             {
                 ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                 PopulateError(objErrorMessage);
                 return RedirectToAction("GeneralError", "Error");
             }

         }

         public async Task<ActionResult> ManageSubsidyScheme(String ssubsidy_scheme_id)
         {
             try
             {
                 Int32 isubsidy_scheme_id = Convert.ToInt32(Encryption.Decrypt(ssubsidy_scheme_id, true));


                 SubsidySchemeManageModel objSubsidySchemeManageModel = new SubsidySchemeManageModel();


                 objSubsidySchemeManageModel.ListSubsidySchemeCtaegory = await GetSubsidySchemeCategoryList();
                 objSubsidySchemeManageModel.ListSubsidySchemeCtaegory.Insert(0, new SubsidySchemeCtaegory() { subsidy_scheme_category_id = 0, subsidy_scheme_category_name = "--Select--" });


                 objSubsidySchemeManageModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageSubsidyScheme", "AdminSubsidyScheme", "Admin");
                 if (objSubsidySchemeManageModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                 {
                     return RedirectToAction("HttpError403", "Error");
                 }
                 if (HasError())
                 {
                     return RedirectToAction("GeneralError", "Error");
                 }
                 else
                 {
                     if (isubsidy_scheme_id == 0)
                     {
                         objSubsidySchemeManageModel.SubsidyScheme = new SubsidyScheme();
                     }
                     else
                     {
                         objSubsidySchemeManageModel.SubsidyScheme = await GetSubsidySchemeById(isubsidy_scheme_id);

                     }


                     return View(objSubsidySchemeManageModel);
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
         [ValidateInput(false)] 
         public async Task<ActionResult> ManageSubsidyScheme(SubsidySchemeManageModel model)
         {
             try
             {
                 if (ModelState.IsValid == false)
                 {
                     return View(model);
                 }


                 model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                 HttpClient httpClient = GenerateHttpClient();
                 HttpResponseMessage response = httpClient.PostAsJsonAsync<SubsidySchemeManageModel>("api/API_SubsidyScheme/SaveSubsidyScheme/", model).Result;



                 if (response.StatusCode == HttpStatusCode.OK)
                 {
                     OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                     if (objOutputMessage.MessageId > 0)
                     {
                         ToastrMessage_Success(objOutputMessage.Message);
                         return RedirectToAction("Index", "AdminSubsidyScheme");
                     }
                     else
                     {
                         ToastrMessage_Error(objOutputMessage.Message);
                         return RedirectToAction("ManageSubsidyScheme", "AdminSubsidyScheme");
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

         public async Task<List<SubsidyScheme>> GetSubsidySchemeList(Int32 _status, Int32 _subsidy_scheme_category_id)
         {
             List<String> ListParameter = new List<String>();
             ListParameter.Add(_status.ToString());
             ListParameter.Add(_subsidy_scheme_category_id.ToString());

             HttpClient httpClient = GenerateHttpClient();
             HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_SubsidyScheme/GetSubsidySchemeList/", ListParameter).Result;
             if (response.StatusCode == HttpStatusCode.OK)
             {
                 return (await response.Content.ReadAsAsync<List<SubsidyScheme>>());
             }
             else
             {
                 ErrorMessage _ErrorMessage = await CheckResponse(response);
                 throw new Exception(_ErrorMessage.ErrorMessages);
             }
         }

         public async Task<SubsidyScheme> GetSubsidySchemeById(Int32 isubsidy_scheme_id)
         {
             HttpClient httpClient = GenerateHttpClient();
             HttpResponseMessage response = await httpClient.GetAsync("api/API_SubsidyScheme/GetSubsidySchemeById/" + isubsidy_scheme_id.ToString() + "/");
             if (response.StatusCode == HttpStatusCode.OK)
             {
                 return (await response.Content.ReadAsAsync<SubsidyScheme>());
             }
             else
             {
                 ErrorMessage _ErrorMessage = await CheckResponse(response);
                 throw new Exception(_ErrorMessage.ErrorMessages);
             }
         }

         public async Task<ActionResult> DeleteSubsidyScheme(String ssubsidy_scheme_id)
         {
             try
             {
                 Int32 isubsidy_scheme_id = Convert.ToInt32(Encryption.Decrypt(ssubsidy_scheme_id, true));

                 HttpClient httpClient = GenerateHttpClient();
                 HttpResponseMessage response = await httpClient.GetAsync("api/API_SubsidyScheme/DeleteSubsidyScheme/" + isubsidy_scheme_id.ToString() + "/");
                 if (response.StatusCode == HttpStatusCode.OK)
                 {
                     OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                     if (objOutputMessage.MessageId > 0)
                     {
                         ToastrMessage_Success(objOutputMessage.Message);
                         return RedirectToAction("Index", "AdminSubsidyScheme");
                     }
                     else
                     {
                         ToastrMessage_Error(objOutputMessage.Message);
                         return RedirectToAction("Index", "AdminSubsidyScheme");
                     }

                     return RedirectToAction("Index", "AdminSubsidyScheme", new { ssubsidy_scheme_id = ssubsidy_scheme_id });
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
    }
}