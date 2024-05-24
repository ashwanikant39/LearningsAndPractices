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
using BEEKP.Helper;

namespace BEEKP.Areas.Admin.Controllers
{
    public class AdminAnnouncementsController : AdminBaseController
    {
        public async Task<ActionResult> Index() 
        {
            try
            {
                ClearError();
                AdminAnnouncementsViewModel objAdminFAQViewModel = new AdminAnnouncementsViewModel();
                objAdminFAQViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminAnnouncements", "Admin");

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

        public async Task<JsonResult> GetActiveRecord(DataTablesParam param)
        {
            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }
            AdminAnnouncementsViewModel model = new AdminAnnouncementsViewModel();
            model = await GetAnnouncementsList(Constants.STATUS_ACTIVE, pageNo, param.iDisplayLength, param.sSearch);

            return Json(new
            {
                aaData = model.ListAnnouncementsActive,
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
            AdminAnnouncementsViewModel model = new AdminAnnouncementsViewModel();
            model = await GetAnnouncementsList(Constants.STATUS_INACTIVE, pageNo, param.iDisplayLength, param.sSearch);

            return Json(new
            {
                aaData = model.ListAnnouncementsActive,
                sEcho = param.sEcho,
                iTotalDisplayRecords = model.TotalCount,
                iTotalRecords = model.TotalCount
            }, JsonRequestBehavior.AllowGet);
        }



        public async Task<ActionResult> AnnouncementsAddEdit(String sAnnouncementsID)
        {
            /* try
             {
                 Int32 iAnnouncementID = Convert.ToInt32(Encryption.Decrypt(sAnnouncementsID, true));

                 AdminAnnouncementsViewModel objAnnouncementViewAddEditModel = new AdminAnnouncementsViewModel();
                 objAnnouncementViewAddEditModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "EventAddEdit", "AdminEvent", "Admin");
                 if (objAnnouncementViewAddEditModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                 {
                     return RedirectToAction("HttpError403", "Error");
                 }
                 if (HasError())
                 {
                     return RedirectToAction("GeneralError", "Error");
                 }
                 else
                 {
                     if (iAnnouncementID == 0)
                     {
                         objAnnouncementViewAddEditModel.Announcements = new Announcements();
                     }
                     else
                     {
                         objAnnouncementViewAddEditModel.Announcements = await GetAnnouncementsById(iAnnouncementID);
                         // objAnnouncementViewAddEditModel.Event.listEventImage = await GetEventImageListByEventId(iEventID);
                         //return View(model);
                     }
                     return View(objAnnouncementViewAddEditModel);
                 }

             }
             catch (Exception ex)
             {
                 ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                 PopulateError(objErrorMessage);
                 return RedirectToAction("GeneralError", "Error");
             }*/
            try
            {
                Int32 iAnnouncementsID = Convert.ToInt32(Encryption.Decrypt(sAnnouncementsID, true));

                AdminAnnouncementsViewModel objAnnouncementsViewAddEditModel = new AdminAnnouncementsViewModel();
                objAnnouncementsViewAddEditModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "AnnouncementsAddEdit", "AdminAnnouncements", "Admin");
                if (objAnnouncementsViewAddEditModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (iAnnouncementsID == 0)
                    {
                        objAnnouncementsViewAddEditModel.Announcements = new Announcements();
                    }
                    else
                    {
                        objAnnouncementsViewAddEditModel.Announcements = await GetAnnouncementsById(iAnnouncementsID);
                        // objAnnouncementViewAddEditModel.Event.listEventImage = await GetEventImageListByEventId(iEventID);
                        //return View(model);
                    }
                    return View(objAnnouncementsViewAddEditModel);
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
        public async Task<ActionResult> AnnouncementsAddEdit(AnnouncementsViewAddEditModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);
                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<AnnouncementsViewAddEditModel>("api/API_Announcements/SaveAnnouncements/", model).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminAnnouncements"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("AnnouncementsAddEdit", "AdminAnnouncements"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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
            ////try
            ////{
            ////    if (ModelState.IsValid == false)
            ////    {
            ////        return View(model);
            ////    }
            ////    model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);
            ////    HttpClient httpClient = GenerateHttpClient();
            ////    HttpResponseMessage response = httpClient.PostAsJsonAsync<AnnouncementsViewAddEditModel>("api/API_Announcements/SaveAnnouncements/", model).Result;
            ////    if (response.StatusCode == HttpStatusCode.OK)
            ////    {
            ////        OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
            ////        if (objOutputMessage.MessageId > 0)
            ////        {
            ////            ToastrMessage_Success(objOutputMessage.Message);
            ////            return RedirectToAction("Index", "AdminAnnouncements"/*, new { sevent_id = model.Event.event_id }*/);
            ////        }
            ////        else
            ////        {
            ////            ToastrMessage_Error(objOutputMessage.Message);
            ////            return RedirectToAction("AnnouncementsAddEdit", "AdminAnnouncements"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
            ////        }

            ////    }
            ////    else
            ////    {
            ////        ErrorMessage _ErrorMessage = await CheckResponse(response);
            ////        throw new Exception(_ErrorMessage.ErrorMessages);
            ////    }
            ////}
            ////catch (Exception ex)
            ////{
            ////    ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
            ////    PopulateError(objErrorMessage);
            ////    return RedirectToAction("GeneralError", "Error");
            ////}
        }
        public async Task<Announcements> GetAnnouncementsById(Int32 iAnnouncements_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Announcements/GetAnnouncementsById/" + iAnnouncements_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<Announcements>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<ActionResult> DeleteAnnouncements(String sAnnouncements_id)
        {
            try
            {
                Int32 iAnnouncements_id = Convert.ToInt32(Encryption.Decrypt(sAnnouncements_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_Announcements/DeleteAnnouncements/" + iAnnouncements_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminAnnouncements");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminAnnouncements");
                    }

                    return RedirectToAction("Index", "AdminAnnouncements", new { sAnnouncements_id = sAnnouncements_id });
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
        public async Task<AdminAnnouncementsViewModel> GetAnnouncementsList(Int32 _status, Int32 page_no = 1, Int32 page_size = 10, string Search = null)

        { 
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(page_no.ToString());
            ListParameter.Add(page_size.ToString());
            ListParameter.Add(Search);
            
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Announcements/GetAnnouncementsList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<AdminAnnouncementsViewModel>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
    }
}