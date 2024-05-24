using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using BEEKP.Helper;
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
    public class AdminEnergyTechnologiesController : AdminBaseController
    {
        public async Task<ActionResult> Index()
        {
            try
            {

                AdminEnergyTechnologiesViewModel objAdminEnergyTechnologiesViewModel = new AdminEnergyTechnologiesViewModel();
                objAdminEnergyTechnologiesViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminEnergyTechnologies", "Admin");
                if (objAdminEnergyTechnologiesViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                else
                {
                    return View(objAdminEnergyTechnologiesViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        public async Task<JsonResult> GetActiveRecord(DataTablesParam param)
        {
            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }
            AdminEnergyTechnologiesViewModel model = new AdminEnergyTechnologiesViewModel();
            model = await GetEnergyTechnologiesList(Class.Constants.STATUS_ACTIVE, 0, pageNo, param.iDisplayLength, param.sSearch);

            return Json(new
            {
                aaData = model.ListEnergyTechnologyActive,
                sEcho = param.sEcho,
                iTotalDisplayRecords = model.TotalCount,
                iTotalRecords = model.TotalCount
            }, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> GetInActiveRecord(DataTablesParam param)
        {
            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }
            AdminEnergyTechnologiesViewModel model = new AdminEnergyTechnologiesViewModel();
            model = await GetEnergyTechnologiesList(Class.Constants.STATUS_INACTIVE, 0, pageNo, param.iDisplayLength, param.sSearch);

            return Json(new
            {
                aaData = model.ListEnergyTechnologyActive,
                sEcho = param.sEcho,
                iTotalDisplayRecords = model.TotalCount,
                iTotalRecords = model.TotalCount
            }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> ManageEnergyTechnologies(String sEE_technology_id)
        {
            try
            {
                Int32 iEE_technology_id = Convert.ToInt32(Encryption.Decrypt(sEE_technology_id, true));

                EnergyTechnologiesManageModel objEnergyTechnologiesManageModel = new EnergyTechnologiesManageModel();

                //AdminClusterDetailsController objClusterDetailsController = new AdminClusterDetailsController();
                //objEnergyTechnologiesManageModel.ListCluster = await objClusterDetailsController.GetClusterDetailsList();
                //objEnergyTechnologiesManageModel.ListCluster.Insert(0, new Cluster() { cluster_id = 0, cluster_name = "---Select---", fuel_used = "", location = "", number_of_units = 0, overall_turnover = 0, products_manufactured = "" });

                objEnergyTechnologiesManageModel.ListCategoryMeasure = await GetCategoryMeasureList();
                objEnergyTechnologiesManageModel.ListCategoryMeasure.Insert(0, new CategoryMeasure() { category_measure_id = 0, category_measure_name = "---Select---" });
                objEnergyTechnologiesManageModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageEnergyTechnologies", "AdminEnergyTechnologies", "Admin");
                if (objEnergyTechnologiesManageModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                else
                {
                    if (iEE_technology_id == 0)
                    {
                        objEnergyTechnologiesManageModel.EnergyTechnology = new EnergyTechnology();
                    }
                    else
                    {

                        objEnergyTechnologiesManageModel.EnergyTechnology = await GetEnergyTechnologiesById(iEE_technology_id);
                    }


                    return View(objEnergyTechnologiesManageModel);
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
        public async Task<ActionResult> ManageEnergyTechnologies(EnergyTechnologiesManageModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }


                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<EnergyTechnologiesManageModel>("api/API_EnergyTechnologies/SaveEnergyTechnologies/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminEnergyTechnologies"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageEnergyTechnologies", "AdminEnergyTechnologies"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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

        public async Task<AdminEnergyTechnologiesViewModel> GetEnergyTechnologiesList(Int32 _status,Int32 _category_measure_id, Int32 page_no = 1, Int32 page_size = 10, string Search = null)

        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_category_measure_id.ToString());
            ListParameter.Add(page_no.ToString());
            ListParameter.Add(page_size.ToString());
            ListParameter.Add(Search);


            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_EnergyTechnologies/GetEnergyTechnologiesList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                AdminEnergyTechnologiesViewModel model = await response.Content.ReadAsAsync<AdminEnergyTechnologiesViewModel>();
                return (model);
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<EnergyTechnology> GetEnergyTechnologiesById(Int32 iEE_technology_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_EnergyTechnology/GetEnergyTechnologiesById/" + iEE_technology_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<EnergyTechnology>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ActionResult> DeleteEnergyTechnologies(String sEE_technology_id)
        {
            try
            {
                Int32 iEE_technology_id = Convert.ToInt32(Encryption.Decrypt(sEE_technology_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_EnergyTechnologies/DeleteEnergyTechnologies/" + iEE_technology_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminEnergyTechnologies");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminEnergyTechnologies");
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

    }
}