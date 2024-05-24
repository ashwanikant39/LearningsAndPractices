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
    public class ManufacturersController : AdminBaseController
    {
        // GET: Admin/Manufacturers
        public async Task<ActionResult> Index()
        {
            try
            {
                AdminManufacturersViewModel objAdminManufacturersViewModel = new AdminManufacturersViewModel();
                //objAdminManufacturersViewModel.ListManufacturers = await GetManufacturersList(Constants.STATUS_NOT_COMPARE, Constants.APPROVAL_STATUS_NOT_COMPARE);
                // objAdminManufacturersViewModel.ListManufacturersApproved = await GetManufacturersList(Constants.STATUS_ACTIVE, Constants.APPROVAL_STATUS_APPROVED);
                objAdminManufacturersViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "Manufacturers", "Admin");
                if (objAdminManufacturersViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                else
                {
                    return View(objAdminManufacturersViewModel);
                }
            }

            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }


        public async Task<JsonResult> GetManufacturersActiveRecord(DataTablesParam param)
        {

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }
            AdminManufacturersViewModel adminManufacturers = new AdminManufacturersViewModel();
            adminManufacturers = await GetManufacturersList(Constants.STATUS_ACTIVE, Constants.APPROVAL_STATUS_APPROVED, pageNo, param.iDisplayLength, param.sSearch);

            return Json(new
            {
                aaData = adminManufacturers.ListManufacturers,
                sEcho = param.sEcho,
                iTotalDisplayRecords = adminManufacturers.TotalCount,
                iTotalRecords = adminManufacturers.TotalCount
            }, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> GetManufacturersInActiveRecord(DataTablesParam param)
        {
            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }
            AdminManufacturersViewModel adminManufacturers = new AdminManufacturersViewModel();
            adminManufacturers = await GetManufacturersList(Constants.STATUS_NOT_COMPARE, Constants.APPROVAL_STATUS_NOT_COMPARE, pageNo, param.iDisplayLength, param.sSearch);

            return Json(new
            {
                aaData = adminManufacturers.ListManufacturers,
                sEcho = param.sEcho,
                iTotalDisplayRecords = adminManufacturers.TotalCount,
                iTotalRecords = adminManufacturers.TotalCount
            }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> ManageManufacturers(String smanufacturer_id)
        {
            try
            {
                Int32 imanufacturer_id = Convert.ToInt32(Encryption.Decrypt(smanufacturer_id, true));

                ManufacturersManageModel objManufacturersManageModel = new ManufacturersManageModel();
                objManufacturersManageModel.ListEE_equipment = await GetEE_equipmentList();
                objManufacturersManageModel.ListEE_equipment.Insert(0, new EE_equipment() { EE_equipment_id = 0, EE_equipment_name = "--Select--" });
                objManufacturersManageModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageManufacturers", "Manufacturers", "Admin");
                if (objManufacturersManageModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                else
                {
                    if (imanufacturer_id == 0)
                    {
                        objManufacturersManageModel.Manufacturers = new Manufacturers();

                    }
                    else
                    {
                        objManufacturersManageModel.Manufacturers = await GetManufacturersById(imanufacturer_id);
                    }

                    return View(objManufacturersManageModel);
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
        public async Task<ActionResult> ManageManufacturers(ManufacturersManageModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<ManufacturersManageModel>("api/API_Manufacturers/SaveManufacturers/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "Manufacturers");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageManufacturers", "Manufacturers");
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

        public async Task<ActionResult> DeleteManufacturers(String smanufacturer_id)
        {
            try
            {
                Int32 imanufacturer_id = Convert.ToInt32(Encryption.Decrypt(smanufacturer_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_Manufacturers/DeleteManufacturers/" + imanufacturer_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "Manufacturers");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "Manufacturers");
                    }

                    return RedirectToAction("Index", "Manufacturers", new { smanufacturer_id = smanufacturer_id });
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

        public async Task<AdminManufacturersViewModel> GetManufacturersList(Int32 _status, Int32 _approvedStatus, Int32 page_no = 1, Int32 page_size = 10, string Search = null)
        {

            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_approvedStatus.ToString());
            ListParameter.Add(page_no.ToString());
            ListParameter.Add(page_size.ToString());
            ListParameter.Add(Search);

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Manufacturers/GetManufacturersList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<AdminManufacturersViewModel>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<Manufacturers> GetManufacturersById(Int32 imanufacturer_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Manufacturers/GetManufacturersById/" + imanufacturer_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<Manufacturers>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
    }
}