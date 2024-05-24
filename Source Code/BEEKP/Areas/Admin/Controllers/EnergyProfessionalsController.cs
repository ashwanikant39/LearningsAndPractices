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
    public class EnergyProfessionalsController : AdminBaseController
    {
        // GET: Admin/EnergyProfessionals
        public async Task<ActionResult> Index()
        {
            try
            {
                //ClearError();
                //Int32 file_id = Convert.ToInt32(Encryption.Decrypt(sfile_id, true));

                AdminEnergyProfessionalsViewModel objAdminEnergyProfessionalsViewModel = new AdminEnergyProfessionalsViewModel();
                objAdminEnergyProfessionalsViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]),"Index","EnergyProfessionals","Admin");

                if (objAdminEnergyProfessionalsViewModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                else
                {
                    return View(objAdminEnergyProfessionalsViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        public async Task<JsonResult> GetEnergyProfessionalsActiveRecord(DataTablesParam param)
        {
            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }
            AdminEnergyProfessionalsViewModel model = new AdminEnergyProfessionalsViewModel();
            model = await GetEnergyProfessionalList(Constants.STATUS_ACTIVE, Constants.APPROVAL_STATUS_APPROVED, pageNo, param.iDisplayLength, param.sSearch);

            return Json(new
            {
                aaData = model.ListEnergyProfessionalsActive,
                sEcho = param.sEcho,
                iTotalDisplayRecords = model.TotalCount,
                iTotalRecords = model.TotalCount
            }, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> GetEnergyProfessionalsInActiveRecord(DataTablesParam param)
        {
            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }
            AdminEnergyProfessionalsViewModel model = new AdminEnergyProfessionalsViewModel();
            model = await GetEnergyProfessionalList(Constants.STATUS_NOT_COMPARE, Constants.APPROVAL_STATUS_NOT_COMPARE, pageNo, param.iDisplayLength, param.sSearch);

            return Json(new
            {
                aaData = model.ListEnergyProfessionalsActive,
                sEcho = param.sEcho,
                iTotalDisplayRecords = model.TotalCount,
                iTotalRecords = model.TotalCount
            }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> ManageEnergyProfessional(String senergy_professional_id)
        {
            try
            {
               Int32 ienergy_professional_id = Convert.ToInt32(Encryption.Decrypt(senergy_professional_id, true));
                


                
                EnergyProfessionalsManageModel objEnergyProfessionalsManageModel = new EnergyProfessionalsManageModel();
                objEnergyProfessionalsManageModel.ListAreaSpecialization = await GetAreaSpecializationList();
                objEnergyProfessionalsManageModel.ListAreaSpecialization.Insert(0, new AreaSpecialization() { area_specialization_id = 0, area_specialization_name = "--Select--" });
                objEnergyProfessionalsManageModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageEnergyProfessional", "EnergyProfessionals", "Admin");

                if (objEnergyProfessionalsManageModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                else
                {
                    if (ienergy_professional_id == 0)
                    {
                        objEnergyProfessionalsManageModel.EnergyProfessionals = new EnergyProfessionals();
                        //model.Event.event_id = iEventID;
                    }
                    else
                    {
                        objEnergyProfessionalsManageModel.EnergyProfessionals = await GetEnergyProfessionalById(ienergy_professional_id);
                        
                    }


                    return View(objEnergyProfessionalsManageModel);
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
        public async Task<ActionResult> ManageEnergyProfessional(EnergyProfessionalsManageModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }


                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<EnergyProfessionalsManageModel>("api/API_EnergyProfessionals/SaveEnergyProfessional/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "EnergyProfessionals"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageEnergyProfessional", "EnergyProfessional"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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
        public async Task<AdminEnergyProfessionalsViewModel> GetEnergyProfessionalList(Int32 _status, Int32 _approvedStatus, Int32 page_no = 1, Int32 page_size = 10, string Search = null)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_approvedStatus.ToString());
            ListParameter.Add(page_no.ToString());
            ListParameter.Add(page_size.ToString());
            ListParameter.Add(Search);

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_EnergyProfessionals/GetEnergyProfessionalList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<AdminEnergyProfessionalsViewModel>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<EnergyProfessionals> GetEnergyProfessionalById(Int32 ienergy_professional_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_EnergyProfessionals/GetEnergyProfessionalById/" + ienergy_professional_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<EnergyProfessionals>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ActionResult> DeleteEnergyProfessional(String senergy_professional_id)
        {
            try
            {
                Int32 ienergy_professional_id = Convert.ToInt32(Encryption.Decrypt(senergy_professional_id, true));


                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_EnergyProfessionals/DeleteEnergyProfessional/" + ienergy_professional_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "EnergyProfessionals");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "EnergyProfessionals");
                    }

                    return RedirectToAction("Index", "EnergyProfessionals", new { senergy_professional_id = senergy_professional_id });
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