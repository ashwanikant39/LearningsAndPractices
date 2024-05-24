using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Areas.Admin.Controllers
{
    public class AdminEventController : AdminBaseController
    {
        // GET: Admin/Events
        public async Task<ActionResult> Index()
        {
            try
            {
                ClearError();
                AdminEventViewModel objAdminEventViewModel = new AdminEventViewModel();
                objAdminEventViewModel.ListEventActive = await GetEventList(Constants.STATUS_ACTIVE, Constants.EVENT_PERIOD_ALL, Constants.EVENT_COUNT_ALL);
                objAdminEventViewModel.ListEventInactive = await GetEventList(Constants.STATUS_INACTIVE, Constants.EVENT_PERIOD_ALL, Constants.EVENT_COUNT_ALL);
                objAdminEventViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminEvent", "Admin");
                if (objAdminEventViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminEventViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        public async Task<ActionResult> EventAddEdit(String sEventID)
        {
            try
            {
                Int32 iEventID = Convert.ToInt32(Encryption.Decrypt(sEventID, true));

                EventViewAddEditModel objEventViewAddEditModel = new EventViewAddEditModel();
                objEventViewAddEditModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "EventAddEdit", "AdminEvent", "Admin");
                if (objEventViewAddEditModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (iEventID == 0)
                    {
                        objEventViewAddEditModel.Event = new Event();
                    }
                    else
                    {
                        objEventViewAddEditModel.Event = await GetEventById(iEventID);
                        objEventViewAddEditModel.Event.listEventImage = await GetEventImageListByEventId(iEventID);
                        //return View(model);
                    }
                    return View(objEventViewAddEditModel);
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
        public async Task<ActionResult> EventAddEdit(EventViewAddEditModel model, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                if (file != null)
                {
                    if (ValidateFile(file, Constants.FileSize1MB, "IMAGE", "Event Image") == false)
                    {
                        return View(model);
                    }

                    if (!ValidateImageDimensions(file, Constants.EVENT_IMAGE_MIN_HEIGHT, Constants.EVENT_IMAGE_MIN_WIDTH))
                    {
                        ModelState.Clear();
                        ToastrMessage_Error("Invalid Image Dimension");
                        return View(model);
                    }
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);

                    string FileExtension = Path.GetExtension(file.FileName);
                    string Folder = Server.MapPath("~/images/Event/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = DateTime.Now.Ticks.ToString() + FileExtension;

                    model.Event.event_image_name = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/images/Event/"), fileNewName);
                    file.SaveAs(fileSavePath);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<EventViewAddEditModel>("api/API_Event/SaveEvent/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminEvent"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("EventAddEdit", "AdminEvent"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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
        public async Task<ActionResult> EventImageAddEdit(String sEventID, String sEventImageID)
        {
            try
            {
                Int32 iEventID = Convert.ToInt32(Encryption.Decrypt(sEventID, true));
                Int32 iEventImageID = Convert.ToInt32(Encryption.Decrypt(sEventImageID, true));
                EventImageAddEditViewModel objEventImageAddEditViewModel = new EventImageAddEditViewModel();
                objEventImageAddEditViewModel.event_id = iEventID;
                //objEventImageAddEditViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "EventImageAddEdit", "AdminEvent", "Admin");
                //if (objEventImageAddEditViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                //{
                //    return RedirectToAction("HttpError403", "Error");
                //}
                //if (HasError())
                //{
                //    return RedirectToAction("GeneralError", "Error");
                //}
                //else
                //{
                if (iEventID == 0)
                {
                    ToastrMessage_Error("Invalid Event");
                    return View();
                }
                else
                {
                    if (iEventImageID == 0)
                    {
                        objEventImageAddEditViewModel.EventImage = new EventImage();
                    }
                    else
                    {
                        objEventImageAddEditViewModel.EventImage = await GetEventImageById(iEventImageID);
                    }

                    //return View(model);
                }
                return View(objEventImageAddEditViewModel);
                //}

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
        public async Task<ActionResult> EventImageAddEdit(EventImageAddEditViewModel model, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                if (file != null)
                {
                    if (ValidateFile(file, Constants.FileSize10MB, "IMAGE", "Event Image") == false)
                    {
                        return View(model);
                    }

                    //if (!ValidateImageDimensions(file, Constants.EVENT_IMAGE_MIN_HEIGHT, Constants.EVENT_IMAGE_MIN_WIDTH))
                    //{
                    //    ModelState.Clear();
                    //    ToastrMessage_Error("Invalid Image Dimension");
                    //    return View(model);
                    //}
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);

                    string FileExtension = Path.GetExtension(file.FileName);
                    string Folder = Server.MapPath("~/images/Event/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = DateTime.Now.Ticks.ToString() + FileExtension;

                    model.EventImage.event_image_name = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/images/Event/"), fileNewName);
                    file.SaveAs(fileSavePath);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<EventImageAddEditViewModel>("api/API_Event/SaveEventImage/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("EventAddEdit", "AdminEvent", new { sEventID = BEEKP.Class.Encryption.Encrypt(Convert.ToString(model.event_id), true) });
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("EventAddEdit", "AdminEvent", new { sEventID = BEEKP.Class.Encryption.Encrypt(Convert.ToString(model.event_id), true) });
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

        public async Task<ActionResult> DeleteEvent(String sEventID, String sevent_image_name)
        {
            try
            {
                Int32 iEventID = Convert.ToInt32(Encryption.Decrypt(sEventID, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_Event/DeleteEvent/" + iEventID.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        string fullPath;
                        fullPath = Path.Combine(Server.MapPath("~/images/Event"), sevent_image_name);

                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminEvent");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("EventAddEdit", "AdminEvent");
                    }
                    /* return RedirectToAction("Index", "Benchmark", new { sfile_id = sfile_id });*/
                    return RedirectToAction("Index", "AdminEvent", new { sEventID = sEventID });
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

        public async Task<ActionResult> DeleteEventImage(String sEventID, String sEventImageID, String sevent_image_name)
        {
            try
            {
                Int32 iEventImageID = Convert.ToInt32(Encryption.Decrypt(sEventImageID, true));
                Int32 iEventID = Convert.ToInt32(Encryption.Decrypt(sEventID, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_Event/DeleteEventImage/" + iEventImageID.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        string fullPath;
                        fullPath = Path.Combine(Server.MapPath("~/images/Event"), sevent_image_name);

                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("EventAddEdit", "AdminEvent",new { sEventID = sEventID });
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("EventAddEdit", "AdminEvent", new { sEventID = sEventID });
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

        public async Task<List<Event>> GetEventList(Int32 _status, String _event_period, Int32 _event_count)

        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_event_period.ToString());
            ListParameter.Add(_event_count.ToString());


            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Event/GetEventList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Event>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<Event> GetEventById(Int32 iEventID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Event/GetEventById/" + iEventID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<Event>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<EventImage> GetEventImageById(Int32 iEventImageID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Event/GetEventImageById/" + iEventImageID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<EventImage>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<List<EventImage>> GetEventImageListByEventId(Int32 iEventID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Event/GetEventImageListByEventId/" + iEventID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<EventImage>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public JsonResult Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                if (file != null)
                {
                    if (ValidateFile(file, Constants.FileSize1MB, "IMAGE", "Event Image") == false)
                    {
                        ModelState.Clear();
                        ToastrMessage_Error("Invalid Image Extension");

                    }
                    if (!ValidateImageDimensions(file, Constants.EVENT_IMAGE_MIN_HEIGHT, Constants.EVENT_IMAGE_MIN_WIDTH))
                    {
                        ModelState.Clear();
                        ToastrMessage_Error("Invalid Image Dimension");

                    }
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);

                    string FileExtension = Path.GetExtension(file.FileName);
                    string Folder = Server.MapPath("~/images/Event/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = DateTime.Now.Ticks.ToString() + FileExtension;

                    int fileSize = file.ContentLength;
                    string fileName = file.FileName;
                    string mimeType = file.ContentType;
                    System.IO.Stream fileContent = file.InputStream;
                    //To save file, use SaveAs method
                    file.SaveAs(Server.MapPath("~/images/Event") + fileName);//File will be saved in application desired path
                    HttpClient httpClient = GenerateHttpClient();
                    HttpResponseMessage response = httpClient.PostAsJsonAsync<String>("api/API_Event/SaveEvent/", fileName).Result;
                }

            }

            return Json("Uploaded " + Request.Files.Count + " files");
        }

    }
}