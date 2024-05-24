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
    public class AdminFAQController : AdminBaseController
    {
        // GET: Admin/FAQ
        public async Task<ActionResult> Index()
        {
            try
            {
                ClearError();
                AdminFAQViewModel objAdminFAQViewModel = new AdminFAQViewModel();
                objAdminFAQViewModel.ListFAQActive = await GetFAQList(Constants.STATUS_ACTIVE);
                objAdminFAQViewModel.ListFAQInactive = await GetFAQList(Constants.STATUS_INACTIVE);
                objAdminFAQViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminFAQ", "Admin");

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

        public async Task<ActionResult> ManageFAQ(String sFAQ_id)
        {
            try
            {
                Int32 iFAQ_id = Convert.ToInt32(Encryption.Decrypt(sFAQ_id, true));


                //FAQ objFAQ = new FAQ();
                AdminClusterDetailsController objClusterDetailsController = new AdminClusterDetailsController();
                FAQCategoryController objFAQCategoryController = new FAQCategoryController();
                FAQManageModel objFAQManageModel = new FAQManageModel();
               
              
                objFAQManageModel.ListCluster = await objClusterDetailsController.GetClusterDetailsList();
                objFAQManageModel.ListCluster.Insert(0, new Cluster() { cluster_id = 0, cluster_name = "--Select--", fuel_used = "", location = "", number_of_units = 0, overall_turnover = 0, products_manufactured = "" });

               
                objFAQManageModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageFAQ", "AdminFAQ", "Admin");
                if (objFAQManageModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (iFAQ_id == 0)
                    {
                        objFAQManageModel.FAQ = new FAQ();
                        objFAQManageModel.ListFAQCategory = await objFAQCategoryController.GetFAQCategoryList();
                        objFAQManageModel.ListFAQCategory.Insert(0, new FAQCategory { category_id = 0, category_name = "--Select--" });

                    }
                    else
                    {
                        objFAQManageModel.FAQ = await GetFAQById(iFAQ_id);
                        objFAQManageModel.ListFAQCategory = await GetFAQCategoryListByClusterId(objFAQManageModel.FAQ.cluster_id);
                        objFAQManageModel.ListFAQCategory.Insert(0, new FAQCategory { category_id = 0, category_name = "--Select--" });

                    }


                    return View(objFAQManageModel);
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
        public async Task<ActionResult> ManageFAQ(FAQManageModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }


                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<FAQManageModel>("api/API_FAQ/SaveFAQ/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminFAQ"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageFAQ", "AdminFAQ"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<List<FAQCategory>> GetFAQCategoryListByClusterId(Int32 _cluster_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_cluster_id.ToString());
           

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_FAQCategory/GetFAQCategoryListByClusterId/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<FAQCategory>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> PopulateFAQCategoryList(String _cluster_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_cluster_id.ToString());

            List<FAQCategory> lstFAQCategory = await GetFAQCategoryListByClusterId(Convert.ToInt32(_cluster_id));
            lstFAQCategory.Insert(0, new FAQCategory() { category_id = 0, category_name = "--Select--" });
            return Json(lstFAQCategory, JsonRequestBehavior.AllowGet);


            //HttpClient httpClient = GenerateHttpClient();
            //HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Base/GetSectorListByClusterId/", ListParameter).Result;
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    lstFAQCategory = await response.Content.ReadAsAsync<List<FAQCategory>>();
            //    lstFAQCategory.Insert(0, new FAQCategory() { category_id = 0, category_name = "--Select--" });
            //    return Json(lstFAQCategory, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    ErrorMessage _ErrorMessage = await CheckResponse(response);
            //    throw new Exception(_ErrorMessage.ErrorMessages);
            //}

        }

        public async Task<FAQ> GetFAQById(Int32 iFAQ_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_FAQ/GetFAQById/" + iFAQ_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<FAQ>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }


        public async Task<ActionResult> DeleteFAQ(String sFAQ_id)
        {
            try
            {
                Int32 iFAQ_id = Convert.ToInt32(Encryption.Decrypt(sFAQ_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_FAQ/DeleteFAQ/" + iFAQ_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminFAQ");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminFAQ");
                    }

                    return RedirectToAction("Index", "AdminFAQ", new { sFAQ_id = sFAQ_id });
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
        public async Task<List<FAQ>> GetFAQList(Int32 _status)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_FAQ/GetFAQList/",ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<FAQ>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
    }
}