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
    public class AdminLoanSchemeController : AdminBaseController
    {
        /*public async Task<ActionResult> Index()
        {
            try
            {
                AdminLoanSchemeViewModel objAdminLoanSchemeViewModel = new AdminLoanSchemeViewModel();
                objAdminLoanSchemeViewModel.ListLoanSchemeActive = await GetLoanSchemeList(Class.Constants.STATUS_ACTIVE, 0);
                objAdminLoanSchemeViewModel.ListLoanSchemeInactive = await GetLoanSchemeList(Class.Constants.STATUS_INACTIVE, 0);
                objAdminLoanSchemeViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminLoanScheme", "Admin");
                if (objAdminLoanSchemeViewModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminLoanSchemeViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }

        }*/

        /*public async Task<ActionResult> ManageLoanScheme(String sloan_scheme_id)
        {
            try
            {
                Int32 iloan_scheme_id = Convert.ToInt32(Encryption.Decrypt(sloan_scheme_id, true));


                LoanSchemeManageModel objLoanSchemeManageModel = new LoanSchemeManageModel();


                objLoanSchemeManageModel.ListLoanSchemeCtaegory = await GetLoanSchemeCategoryList();
                objLoanSchemeManageModel.ListLoanSchemeCtaegory.Insert(0, new LoanSchemeCtaegory() { loan_scheme_category_id = 0, loan_scheme_category_name = "--Select--" });


                objLoanSchemeManageModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageLoanScheme", "AdminLoanScheme", "Admin");
                if (objLoanSchemeManageModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (iloan_scheme_id == 0)
                    {
                        objLoanSchemeManageModel.LoanScheme = new LoanScheme();
                    }
                    else
                    {
                        objLoanSchemeManageModel.LoanScheme = await GetLoanSchemeById(iloan_scheme_id);
                        //objFAQManageModel.ListFAQCategory = await GetFAQCategoryListByClusterId(objFAQManageModel.FAQ.cluster_id);
                        //objFAQManageModel.ListFAQCategory.Insert(0, new FAQCategory { category_id = 0, category_name = "--Select--" });

                    }


                    return View(objLoanSchemeManageModel);
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
        public async Task<ActionResult> ManageLoanScheme(LoanSchemeManageModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }


                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<LoanSchemeManageModel>("api/API_LoanScheme/SaveLoanScheme/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminLoanScheme");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageLoanScheme", "AdminLoanScheme");
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

        public async Task<List<LoanScheme>> GetLoanSchemeList(Int32 _status, Int32 _loan_scheme_category_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_loan_scheme_category_id.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_LoanScheme/GetLoanSchemeList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<LoanScheme>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<LoanScheme> GetLoanSchemeById(Int32 iLoan_scheme_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_LoanScheme/GetLoanSchemeById/" + iLoan_scheme_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<LoanScheme>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ActionResult> DeleteLoanScheme(String sloan_scheme_id)
        {
            try
            {
                Int32 iloan_scheme_id = Convert.ToInt32(Encryption.Decrypt(sloan_scheme_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_LoanScheme/DeleteLoanScheme/" + iloan_scheme_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminLoanScheme");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminLoanScheme");
                    }

                    return RedirectToAction("Index", "AdminLoanScheme", new { sloan_scheme_id = sloan_scheme_id });
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
        public async Task<ActionResult> Index()
        {
            try
            {
                ClearError();
                AdminLoanSchemeViewModel objAdminFAQViewModel = new AdminLoanSchemeViewModel();
                objAdminFAQViewModel.ListLoanSchemeActive = await GetLoanSchemeList(Constants.STATUS_ACTIVE);
                objAdminFAQViewModel.ListLoanSchemeInactive = await GetLoanSchemeList(Constants.STATUS_INACTIVE);
                objAdminFAQViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminLoanScheme", "Admin");

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
        public async Task<ActionResult> ManageLoanScheme(String sLoanSchemeID)
        {
            try
            {
                Int32 iLoanSchemeID = Convert.ToInt32(Encryption.Decrypt(sLoanSchemeID, true));

                LoanSchemeManageModel objLoanSchemeViewAddEditModel = new LoanSchemeManageModel();
                objLoanSchemeViewAddEditModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageLoanScheme", "AdminLoanScheme", "Admin");
                if (objLoanSchemeViewAddEditModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (iLoanSchemeID == 0)
                    {
                        objLoanSchemeViewAddEditModel.LoanScheme = new LoanScheme();
                    }
                    else
                    {
                        objLoanSchemeViewAddEditModel.LoanScheme = await GetLoanSchemeById(iLoanSchemeID);
                        // objAnnouncementViewAddEditModel.Event.listEventImage = await GetEventImageListByEventId(iEventID);
                        //return View(model);
                    }
                    return View(objLoanSchemeViewAddEditModel);
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
        public async Task<ActionResult> ManageLoanScheme(LoanSchemeManageModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);
                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<LoanSchemeManageModel>("api/API_Loan/SaveLoanScheme/", model).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminLoanScheme"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageLoanScheme", "AdminLoanScheme"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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
        public async Task<LoanScheme> GetLoanSchemeById(Int32 iLoanScheme_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Loan/GetLoanSchemeById/" + iLoanScheme_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<LoanScheme>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<ActionResult> DeleteLoanScheme(String sLoanScheme_id)
        {
            try
            {
                Int32 iLoanScheme_id = Convert.ToInt32(Encryption.Decrypt(sLoanScheme_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_Loan/DeleteLoanScheme/" + iLoanScheme_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminLoanScheme");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminLoanScheme");
                    }

                    return RedirectToAction("Index", "AdminLoanScheme", new { sLoanScheme_id = sLoanScheme_id });
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
        public async Task<List<LoanScheme>> GetLoanSchemeList(Int32 _status)

        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Loan/GetLoanSchemeList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<LoanScheme>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
    }
}