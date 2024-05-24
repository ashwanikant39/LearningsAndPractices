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
    public class AdminNewsController : AdminBaseController
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                ClearError();
                AdminNewsViewModel objAdminNewsViewModel = new AdminNewsViewModel();
                objAdminNewsViewModel.ListNewsActive = await GetNewsList(Constants.STATUS_ACTIVE, Constants.NEWS_PERIOD_ALL, Constants.NEWS_COUNT_ALL);
                objAdminNewsViewModel.ListNewsInactive = await GetNewsList(Constants.STATUS_INACTIVE, Constants.NEWS_PERIOD_ALL, Constants.NEWS_COUNT_ALL);
                objAdminNewsViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminNews", "Admin");
                if (objAdminNewsViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminNewsViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        public async Task<ActionResult> NewsAddEdit(String sNewsID)
        {
            try
            {
                Int32 iNewsID = Convert.ToInt32(Encryption.Decrypt(sNewsID, true));

                NewsViewAddEditModel objNewsViewAddEditModel = new NewsViewAddEditModel();
                objNewsViewAddEditModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "NewsAddEdit", "AdminNews", "Admin");
                if (objNewsViewAddEditModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (iNewsID == 0)
                    {
                        objNewsViewAddEditModel.News = new News();
                    }
                    else
                    {
                        objNewsViewAddEditModel.News = await GetNewsById(iNewsID);
                        objNewsViewAddEditModel.News.listNewsImage = await GetNewsImageListByNewsId(iNewsID);
                        //return View(model);
                    }
                    return View(objNewsViewAddEditModel);
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
        public async Task<ActionResult> NewsAddEdit(NewsViewAddEditModel model, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                if (file != null)
                {
                    if (ValidateFile(file, Constants.FileSize1MB, "IMAGE", "News Image") == false)
                    {
                        return View(model);
                    }
                    if (!ValidateImageDimensions(file, Constants.NEWS_IMAGE_MIN_HEIGHT, Constants.NEWS_IMAGE_MIN_WIDTH))
                    {
                        ModelState.Clear();
                        ToastrMessage_Error("Invalid Image Dimension");
                        return View(model);
                    }
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);

                    string FileExtension = Path.GetExtension(file.FileName);
                    string Folder = Server.MapPath("~/images/News/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = DateTime.Now.Ticks.ToString() + FileExtension;

                    model.News.news_image_name = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/images/News/"), fileNewName);
                    file.SaveAs(fileSavePath);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<NewsViewAddEditModel>("api/API_News/SaveNews/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminNews"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("NewsAddEdit", "AdminNews"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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
        public async Task<ActionResult> NewsImageAddEdit(String sNewsID, String sNewsImageID)
        {
            try
            {
                Int32 iNewsID = Convert.ToInt32(Encryption.Decrypt(sNewsID, true));
                Int32 iNewsImageID = Convert.ToInt32(Encryption.Decrypt(sNewsImageID, true));
                NewsImageAddEditViewModel objNewsImageAddEditViewModel = new NewsImageAddEditViewModel();
                objNewsImageAddEditViewModel.news_id = iNewsID;
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
                if (iNewsID == 0)
                {
                    ToastrMessage_Error("Invalid News");
                    return View();
                }
                else
                {
                    if (iNewsImageID == 0)
                    {
                        objNewsImageAddEditViewModel.NewsImage = new NewsImage();
                    }
                    else
                    {
                        objNewsImageAddEditViewModel.NewsImage = await GetNewsImageById(iNewsImageID);
                    }

                    //return View(model);
                }
                return View(objNewsImageAddEditViewModel);
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
        public async Task<ActionResult> NewsImageAddEdit(NewsImageAddEditViewModel model, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                if (file != null)
                {
                    if (ValidateFile(file, Constants.FileSize10MB, "IMAGE", "News Image") == false)
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
                    string Folder = Server.MapPath("~/images/News/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = DateTime.Now.Ticks.ToString() + FileExtension;

                    model.NewsImage.news_image_name = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/images/News/"), fileNewName);
                    file.SaveAs(fileSavePath);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<NewsImageAddEditViewModel>("api/API_News/SaveNewsImage/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("NewsAddEdit", "AdminNews", new { sNewsID = BEEKP.Class.Encryption.Encrypt(Convert.ToString(model.news_id), true) });
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("NewsAddEdit", "AdminNews", new { sNewsID = BEEKP.Class.Encryption.Encrypt(Convert.ToString(model.news_id), true) });
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

        public async Task<ActionResult> DeleteNews(String sNewsID, String sNews_image_name)
        {
            try
            {
                Int32 iNewsID = Convert.ToInt32(Encryption.Decrypt(sNewsID, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_News/DeleteNews/" + iNewsID.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        string fullPath;
                        fullPath = Path.Combine(Server.MapPath("~/images/News"), sNews_image_name);

                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminNews");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("NewsAddEdit", "AdminNews");
                    }
                    /* return RedirectToAction("Index", "Benchmark", new { sfile_id = sfile_id });*/
                    return RedirectToAction("Index", "AdminNews", new { sNewsID = sNewsID });
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

        public async Task<ActionResult> DeleteNewsImage(String sNewsID, String sNewsImageID, String sNews_image_name)
        {
            try
            {
                Int32 iNewsImageID = Convert.ToInt32(Encryption.Decrypt(sNewsImageID, true));
                Int32 iNewsID = Convert.ToInt32(Encryption.Decrypt(sNewsID, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_News/DeleteNewsImage/" + iNewsImageID.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        string fullPath;
                        fullPath = Path.Combine(Server.MapPath("~/images/News"), sNews_image_name);

                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("NewsAddEdit", "AdminNews", new { sNewsID = sNewsID });
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("NewsAddEdit", "AdminNews", new { sNewsID = sNewsID });
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

        public async Task<List<News>> GetNewsList(Int32 _status, String _news_period, Int32 _news_count)

        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_news_period.ToString());
            ListParameter.Add(_news_count.ToString());


            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_News/GetNewsList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<News>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<News> GetNewsById(Int32 iNewsID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_News/GetNewsById/" + iNewsID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<News>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<NewsImage> GetNewsImageById(Int32 iNewsImageID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_News/GetNewsImageById/" + iNewsImageID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<NewsImage>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<List<NewsImage>> GetNewsImageListByNewsId(Int32 iNewsID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_News/GetNewsImageListByNewsId/" + iNewsID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<NewsImage>>());
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
                    if (ValidateFile(file, Constants.FileSize1MB, "IMAGE", "News Image") == false)
                    {
                        ModelState.Clear();
                        ToastrMessage_Error("Invalid Image Extension");

                    }
                    if (!ValidateImageDimensions(file, Constants.NEWS_IMAGE_MIN_HEIGHT, Constants.NEWS_IMAGE_MIN_WIDTH))
                    {
                        ModelState.Clear();
                        ToastrMessage_Error("Invalid Image Dimension");

                    }
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);

                    string FileExtension = Path.GetExtension(file.FileName);
                    string Folder = Server.MapPath("~/images/News/");
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
                    file.SaveAs(Server.MapPath("~/images/News") + fileName);//File will be saved in application desired path
                    HttpClient httpClient = GenerateHttpClient();
                    HttpResponseMessage response = httpClient.PostAsJsonAsync<String>("api/API_News/SaveNews/", fileName).Result;
                }

            }

            return Json("Uploaded " + Request.Files.Count + " files");
        }


    }
}