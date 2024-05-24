using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using BEEKP.Helper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Areas.Admin.Controllers
{
    public class AdminMSMEController : AdminBaseController
    {
        // GET: Admin/MSME
        //public async Task<ActionResult> Index()
        //{
        //    try
        //    {
        //        //ClearError();
        //        //Int32 file_id = Convert.ToInt32(Encryption.Decrypt(sfile_id, true));

        //        AdminMSMEViewModel objAdminMSMEViewModel = new AdminMSMEViewModel();
        //        //objAdminMSMEViewModel.ListMSMEActive = await GetMSMEList(Constants.STATUS_ACTIVE,Constants.APPROVAL_STATUS_APPROVED);
        //       // objAdminMSMEViewModel.ListMSMEInactive = await GetMSMEList(Constants.STATUS_NOT_COMPARE, Constants.APPROVAL_STATUS_NOT_COMPARE);

        //        objAdminMSMEViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminMSME", "Admin");
        //        if (objAdminMSMEViewModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
        //        {
        //            return RedirectToAction("HttpError403", "Error");
        //        }
        //        else
        //        {
        //            return View(objAdminMSMEViewModel);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
        //        PopulateError(objErrorMessage);
        //        return RedirectToAction("GeneralError", "Error");
        //    }
        //}
        public async Task<ActionResult> Index()
        {
            try
            {
                //ClearError();
                //Int32 file_id = Convert.ToInt32(Encryption.Decrypt(sfile_id, true));

                AdminMSMEViewModel objAdminMSMEViewModel = new AdminMSMEViewModel();
                //objAdminMSMEViewModel.ListMSMEActive = await GetMSMEList(Constants.STATUS_ACTIVE,Constants.APPROVAL_STATUS_APPROVED);
                // objAdminMSMEViewModel.ListMSMEInactive = await GetMSMEList(Constants.STATUS_NOT_COMPARE, Constants.APPROVAL_STATUS_NOT_COMPARE);

                objAdminMSMEViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminMSME", "Admin");
                if (objAdminMSMEViewModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                else
                {
                    return View(objAdminMSMEViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        public async Task<JsonResult> GetMSMEActiveRecord(DataTablesParam param)
        {

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            AdminMSMEViewModel objAdminMSMEViewModel = new AdminMSMEViewModel();
            objAdminMSMEViewModel = await GetMSMEList(Constants.STATUS_ACTIVE, Constants.APPROVAL_STATUS_APPROVED,pageNo, param.iDisplayLength,param.sSearch);

            return Json(new
            {
                aaData = objAdminMSMEViewModel.ListMSMEActive,
                sEcho = param.sEcho,
                iTotalDisplayRecords = objAdminMSMEViewModel.TotalCount,
                iTotalRecords = objAdminMSMEViewModel.TotalCount

            }
               , JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> GetMSMEInActiveRecord(DataTablesParam param)
        {

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            AdminMSMEViewModel objAdminMSMEViewModel = new AdminMSMEViewModel();
            objAdminMSMEViewModel = await GetMSMEList(Constants.STATUS_NOT_COMPARE, Constants.APPROVAL_STATUS_NOT_COMPARE, pageNo, param.iDisplayLength, param.sSearch);

            return Json(new
            {
                aaData = objAdminMSMEViewModel.ListMSMEActive,
                sEcho = param.sEcho,
                iTotalDisplayRecords = objAdminMSMEViewModel.TotalCount,
                iTotalRecords = objAdminMSMEViewModel.TotalCount

            }
               , JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> ManageMSME(String sMSMEID)
        {
            try
            {
                Int32 iMSMEID = Convert.ToInt32(Encryption.Decrypt(sMSMEID, true));
                ViewBag.ActionName=TempData["ActionName"];
                TempData["ActionName"] = ViewBag.ActionName;
                TempData.Keep("ActionName");

                AdminClusterDetailsController objClusterDetailsController = new AdminClusterDetailsController();
                AdminMSMEManageModel model = new AdminMSMEManageModel();
                AdminSectorController objAdminSectorController = new AdminSectorController();
                model.ListSector = await objAdminSectorController.GetSectorList();
                model.ListSector.Insert(0, new Sector() { sector_id = 0, sector_name = "--Select--" });

                model.ListCluster = await objClusterDetailsController.GetClusterDetailsList();
                model.ListCluster.Insert(0, new Cluster() { cluster_id = 0, cluster_name = "--Select--", fuel_used = "", location = "", number_of_units = 0, overall_turnover = 0, products_manufactured = "" });

                model.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageMSME", "AdminMSME", "Admin");

                if (model.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                else
                {
                    if (iMSMEID == 0)
                    {
                        model.MSME = new MSME();
                        //model.ListSector = new List<Sector>();
                        //model.ListSector.Insert(0, new Sector() { sector_id = 0, sector_name = "--Select--" });
                    }
                    else
                    {
                        model.MSME = await GetMSMEById(iMSMEID);
                        //model.ListSector = await GetSectorList(Convert.ToString(model.MSME.cluster_id));
                    }


                    return View(model);
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
        public async Task<ActionResult> ManageMSME(AdminMSMEManageModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    AdminClusterDetailsController objClusterDetailsController = new AdminClusterDetailsController();
                    AdminSectorController objAdminSectorController = new AdminSectorController();
                    model.ListSector = await objAdminSectorController.GetSectorList();
                    model.ListSector.Insert(0, new Sector() { sector_id = 0, sector_name = "--Select--" });

                    model.ListCluster = await objClusterDetailsController.GetClusterDetailsList();
                    model.ListCluster.Insert(0, new Cluster() { cluster_id = 0, cluster_name = "--Select--", fuel_used = "", location = "", number_of_units = 0, overall_turnover = 0, products_manufactured = "" });
                    return View(model);
                }


                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<AdminMSMEManageModel>("api/API_MSME/SaveMSME/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminMSME"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageMSME", "AdminMSME", new { sMSMEID = BEEKP.Class.Encryption.Encrypt(model.MSME.msme_id.ToString(), true) });
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
        public async Task<AdminMSMEViewModel> GetMSMEList(Int32 _status, Int32 _approvedStatus,Int32 page_no=1,Int32 page_size=10,string Search=null)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_approvedStatus.ToString());
            ListParameter.Add(page_no.ToString());
            ListParameter.Add(page_size.ToString());
            ListParameter.Add(Search);

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_MSME/GetMSMEList/",ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<AdminMSMEViewModel>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<ActionResult> DeleteMSME(String sMSMEID)
        {
            try
            {
                Int32 iMSMEID = Convert.ToInt32(Encryption.Decrypt(sMSMEID, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_MSME/DeleteMSME/" + iMSMEID.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminMSME");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminMSME");
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
        public async Task<MSME> GetMSMEById(Int32 iMSMEID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_MSME/GetMSMEById/" + iMSMEID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<MSME>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
    }
}