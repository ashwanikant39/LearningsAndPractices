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
    public class GalleryController : AdminBaseController
    {
        #region photo
        public async Task<ActionResult> Photo()
        {
            try
            {
                ClearError();
                AdminPhotoGalleryViewModel objAdminPhotoGalleryViewModel = new AdminPhotoGalleryViewModel();
                objAdminPhotoGalleryViewModel.ListPhotoGalleryActive = await GetPhotoGalleryList(Constants.STATUS_ACTIVE);
                objAdminPhotoGalleryViewModel.ListPhotoGalleryInActive = await GetPhotoGalleryList(Constants.STATUS_INACTIVE);

                objAdminPhotoGalleryViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Photo", "Gallery", "Admin");
                if (objAdminPhotoGalleryViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminPhotoGalleryViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        public async Task<ActionResult> ManagePhoto(String sphoto_id)
        {
            try
            {
                Int32 iphoto_id = Convert.ToInt32(Encryption.Decrypt(sphoto_id, true));



                PhotoManageModel objPhotoManageModel = new PhotoManageModel();

                objPhotoManageModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManagePhoto", "Gallery", "Admin");
                if (objPhotoManageModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (iphoto_id == 0)
                    {
                        objPhotoManageModel.Photo = new Photo();
                    }
                    else
                    {
                        objPhotoManageModel.Photo = await GetPhotoById(iphoto_id);

                    }
                    return View(objPhotoManageModel);
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
        public async Task<ActionResult> ManagePhoto(PhotoManageModel model, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }
                if (model.Photo.photo_id == 0 && file==null)
                {
                    //ModelState.AddModelError(string.Empty, "Invalid Photo, Please Browse");
                    //return View(model);
                    ToastrMessage_Error("Invalid Photo, Please Browse");
                    return View(model);
                }

                if (file != null)
                {
                    if (ValidateFile(file, Constants.FileSize1MB, "IMAGE", "Gallery Image") == false)
                    {
                        return View(model);
                    }

                    if (!ValidateImageDimensions(file, Constants.GALLERY_IMAGE_MIN_HEIGHT, Constants.GALLERY_IMAGE_MIN_WIDTH))
                    {
                        ModelState.Clear();
                        ToastrMessage_Error("Invalid Image Dimension");
                        return View(model);
                    }
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);

                    string FileExtension = Path.GetExtension(file.FileName);
                    string Folder = Server.MapPath("~/images/Gallery/Photo/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;

                    model.Photo.photo_name = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/images/Gallery/Photo"), fileNewName);
                    file.SaveAs(fileSavePath);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<PhotoManageModel>("api/API_Gallery/SavePhotoGallery/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Photo", "Gallery");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManagePhoto", "Gallery");
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

        public async Task<List<Photo>> GetPhotoGalleryList(Int32 _status)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
           


            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Gallery/GetPhotoGalleryList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Photo>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<Photo> GetPhotoById(Int32 iphoto_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Gallery/GetPhotoById/" + iphoto_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<Photo>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ActionResult> DeletePhoto(String sphoto_id,String sphoto_name )
        {
            try
            {
                Int32 iphoto_id = Convert.ToInt32(Encryption.Decrypt(sphoto_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_Gallery/DeletePhoto/" + iphoto_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        string fullPath;
                        fullPath = Path.Combine(Server.MapPath("~/images/Gallery/Photo"), sphoto_name);

                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }

                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Photo", "Gallery");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Photo", "Gallery");
                    }
                    return RedirectToAction("Photo", "Gallery", new { sphoto_id = sphoto_id });
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

        #endregion
        //----------------------------------------------- VIDEO SECTION -------------------------------------------------------
        #region vedio
        public async Task<ActionResult> Video()
        {
            try
            {
                ClearError();
                AdminVideoGalleryViewModel objAdminVideoGalleryViewModel = new AdminVideoGalleryViewModel();
                objAdminVideoGalleryViewModel.ListVideoActive = await GetVideoGalleryList(Constants.STATUS_ACTIVE);
                objAdminVideoGalleryViewModel.ListVideoInactive = await GetVideoGalleryList(Constants.STATUS_INACTIVE);

                objAdminVideoGalleryViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Video", "Gallery", "Admin");
                if (objAdminVideoGalleryViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminVideoGalleryViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        public async Task<List<Video>> GetVideoGalleryList(Int32 _status)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());



            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Gallery/GetVideoGalleryList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Video>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ActionResult> ManageVideo(String svideo_id)
        {
            try
            {
                Int32 ivideo_id = Convert.ToInt32(Encryption.Decrypt(svideo_id, true));



                VideoManageModel objVideoManageModel = new VideoManageModel();
                objVideoManageModel.ListSectors = await GetSectorsList();
                objVideoManageModel.ListSectors.Insert(0, new Sectors() { sectors_id = 0, sectors_name = "--Select--" });
                objVideoManageModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageVideo", "Gallery", "Admin");
                if (objVideoManageModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (ivideo_id == 0)
                    {
                        objVideoManageModel.Video = new Video();
                    }
                    else
                    {
                        objVideoManageModel.Video = await GetVideoById(ivideo_id);

                    }
                    return View(objVideoManageModel);
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
        public async Task<ActionResult> ManageVideo(VideoManageModel model, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }
                if (model.Video.video_id == 0 && file == null)
                {
                    //ModelState.AddModelError(string.Empty, "Invalid Photo, Please Browse");
                    //return View(model);
                    ToastrMessage_Error("Invalid Video, Please Browse");
                    return View(model);
                }

                if (file != null)
                {
                    if (ValidateFile(file, Constants.FileSize1MB, "IMAGE", "Gallery Video Image") == false)
                    {
                        return View(model);
                    }

                    if (!ValidateImageDimensions(file, Constants.GALLERY_IMAGE_MIN_HEIGHT, Constants.GALLERY_IMAGE_MIN_WIDTH))
                    {
                        ModelState.Clear();
                        ToastrMessage_Error("Invalid Image Dimension");
                        return View(model);
                    }
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);

                    string FileExtension = Path.GetExtension(file.FileName);
                    string Folder = Server.MapPath("~/images/Gallery/Video/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;

                    model.Video.video_image_name = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/images/Gallery/Video"), fileNewName);
                    file.SaveAs(fileSavePath);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<VideoManageModel>("api/API_Gallery/SaveVideoGallery/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Video", "Gallery");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageVideo", "Gallery");
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

        public async Task<Video> GetVideoById(Int32 ivideo_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Gallery/GetVideoById/" + ivideo_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<Video>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<ActionResult> DeleteVideo(String svideo_id, String svideo_name)
        {
            try
            {
                Int32 ivideo_id = Convert.ToInt32(Encryption.Decrypt(svideo_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_Gallery/DeleteVideo/" + ivideo_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        string fullPath;
                        fullPath = Path.Combine(Server.MapPath("~/images/Gallery/Video"), svideo_name);

                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }

                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Video", "Gallery");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Video", "Gallery");
                    }
                    return RedirectToAction("Video", "Gallery", new { svideo_id = svideo_id });
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



        #endregion



    }
}