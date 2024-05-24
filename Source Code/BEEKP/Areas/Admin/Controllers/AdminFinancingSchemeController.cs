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
    public class AdminFinancingSchemeController : AdminBaseController
    {
        // GET: Admin/AdminFinancingScheme
        public async Task<ActionResult> Index()
        {
            try
            {
                AdminFinancingSchemeViewModel objAdminFinancingSchemeViewModel = new AdminFinancingSchemeViewModel();
                objAdminFinancingSchemeViewModel.ListFinancingSchemeActive = await GetFinancingSchemeList(Class.Constants.STATUS_ACTIVE,0);
                objAdminFinancingSchemeViewModel.ListFinancingSchemeInactive = await GetFinancingSchemeList(Class.Constants.STATUS_INACTIVE,0);
                objAdminFinancingSchemeViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminFinancingScheme", "Admin");
                if (objAdminFinancingSchemeViewModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminFinancingSchemeViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
            
        }

        public async Task<ActionResult> ManageFinancingScheme(String sfinancing_scheme_id)
        {
            try
            {
                Int32 ifinancing_scheme_id = Convert.ToInt32(Encryption.Decrypt(sfinancing_scheme_id, true));


                FinancingSchemeManageModel objFinancingSchemeManageModel = new FinancingSchemeManageModel();


                objFinancingSchemeManageModel.ListFinancingSchemeCtaegory = await GetFinancingSchemeCategoryList();
                objFinancingSchemeManageModel.ListFinancingSchemeCtaegory.Insert(0, new FinancingSchemeCtaegory() { financing_scheme_category_id = 0, financing_scheme_category_name = "--Select--"});


                objFinancingSchemeManageModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageFinancingScheme", "AdminFinancingScheme", "Admin");
                if (objFinancingSchemeManageModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (ifinancing_scheme_id == 0)
                    {
                        objFinancingSchemeManageModel.FinancingScheme = new FinancingScheme();
                    }
                    else
                    {
                        objFinancingSchemeManageModel.FinancingScheme = await GetFinancingSchemeById(ifinancing_scheme_id);
                        //objFAQManageModel.ListFAQCategory = await GetFAQCategoryListByClusterId(objFAQManageModel.FAQ.cluster_id);
                        //objFAQManageModel.ListFAQCategory.Insert(0, new FAQCategory { category_id = 0, category_name = "--Select--" });

                    }


                    return View(objFinancingSchemeManageModel);
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
        public async Task<ActionResult> ManageFinancingScheme(FinancingSchemeManageModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }


                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<FinancingSchemeManageModel>("api/API_FinancingScheme/SaveFinancingScheme/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminFinancingScheme"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageFinancingScheme", "AdminFinancingScheme"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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

        public async Task<List<FinancingScheme>> GetFinancingSchemeList(Int32 _status,Int32 _financing_scheme_category_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_financing_scheme_category_id.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_FinancingScheme/GetFinancingSchemeList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<FinancingScheme>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<FinancingScheme> GetFinancingSchemeById(Int32 ifinancing_scheme_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_FinancingScheme/GetFinancingSchemeById/" + ifinancing_scheme_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<FinancingScheme>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ActionResult> DeleteFinancingScheme(String sfinancing_scheme_id)
        {
            try
            {
                Int32 ifinancing_scheme_id = Convert.ToInt32(Encryption.Decrypt(sfinancing_scheme_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_FinancingScheme/DeleteFinancingScheme/" + ifinancing_scheme_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminFinancingScheme");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminFinancingScheme");
                    }

                    return RedirectToAction("Index", "AdminFinancingScheme", new { sfinancing_scheme_id = sfinancing_scheme_id });
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
    }
}