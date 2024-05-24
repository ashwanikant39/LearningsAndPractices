namespace BEEKP.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using BEEKP.Areas.Admin.Models;
    using BEEKP.Class;

    /// <summary>
    /// Defines the <see cref="AdminAnnouncementController" />.
    /// </summary>
    public class AdminAnnouncementController : AdminBaseController
    {
        // GET: Admin/AdminAnnouncement
        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="Task{ActionResult}"/>.</returns>
        public async Task<ActionResult> Index()
        {
            try
            {
                ClearError();
                AdminAnnouncementViewModel objAdminAnnouncementViewModel = new AdminAnnouncementViewModel();
                objAdminAnnouncementViewModel.ListAnnouncement = await GetAnnouncementList();
                objAdminAnnouncementViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminEvent", "Admin");
                if (objAdminAnnouncementViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminAnnouncementViewModel);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        /// <summary>
        /// The GetAnnouncementList.
        /// </summary>
        /// <returns>The <see cref="Task{List{Announcement}}"/>.</returns>
        public async Task<List<Announcement>> GetAnnouncementList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Announcement/GetAnnouncementList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Announcement>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        /// <summary>
        /// The AnnouncementAddEdit.
        /// </summary>
        /// <param name="sAnnouncementID">The sAnnouncementID<see cref="String"/>.</param>
        /// <returns>The <see cref="Task{ActionResult}"/>.</returns>
        public async Task<ActionResult> AnnouncementAddEdit(String sAnnouncementID)
        {
            try
            {
                Int32 iAnnouncementID = Convert.ToInt32(Encryption.Decrypt(sAnnouncementID, true));

                AnnouncementViewAddEditModel objAnnouncementViewAddEditModel = new AnnouncementViewAddEditModel();
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
                        objAnnouncementViewAddEditModel.Announcement = new Announcement();
                    }
                    else
                    {
                        objAnnouncementViewAddEditModel.Announcement = await GetAnnouncemenetById(iAnnouncementID);
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
            }
        }

        /// <summary>
        /// The AnnouncementAddEdit.
        /// </summary>
        /// <param name="model">The model<see cref="AnnouncementViewAddEditModel"/>.</param>
        /// <returns>The <see cref="Task{ActionResult}"/>.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] // for ckeditor
        public async Task<ActionResult> AnnouncementAddEdit(AnnouncementViewAddEditModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);
                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<AnnouncementViewAddEditModel>("api/API_Announcement/SaveAnnouncement/", model).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminAnnouncement"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("AnnouncementAddEdit", "AdminAnnouncement"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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

        /// <summary>
        /// The GetAnnouncemenetById.
        /// </summary>
        /// <param name="iAnnouncementID">The iAnnouncementID<see cref="Int32"/>.</param>
        /// <returns>The <see cref="Task{Announcement}"/>.</returns>
        public async Task<Announcement> GetAnnouncemenetById(Int32 iAnnouncementID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Announcement/GetAnnouncementById/" + iAnnouncementID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<Announcement>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        /*public async Task<ActionResult> DeleteAnnouncement(String sAnnouncement_id)
        {
            try
            {
                Int32 iAnnouncement_id = Convert.ToInt32(Encryption.Decrypt(sAnnouncement_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_Announcement/DeleteAnnouncement/" + iAnnouncement_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminAnnouncement");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminAnnouncement");
                    }

                    return RedirectToAction("Index", "AdminAnnouncement", new { sAnnouncement_id = sAnnouncement_id });
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
        /// <summary>
        /// The DeleteAnnouncement.
        /// </summary>
        /// <param name="sannouncement_id">The sannouncement_id<see cref="String"/>.</param>
        /// <returns>The <see cref="Task{ActionResult}"/>.</returns>
        public async Task<ActionResult> DeleteAnnouncement(String sannouncement_id)
        {
            try
            {
                Int32 iannouncement_id = Convert.ToInt32(Encryption.Decrypt(sannouncement_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_Announcement/DeleteAnnouncement/" + iannouncement_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminAnnouncement");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminAnnouncement");
                    }

                    return RedirectToAction("Index", "AdminAnnouncement", new { sannouncement_id = sannouncement_id });
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
