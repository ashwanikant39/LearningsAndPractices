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
    public class AdminSectorsController : AdminBaseController
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                ClearError();
                AdminSectorsViewModel objAdminSectorsViewModel = new AdminSectorsViewModel();
                objAdminSectorsViewModel.ListSectorsActive = await GetSectorsList(Constants.STATUS_ACTIVE );
                objAdminSectorsViewModel.ListSectorsInactive = await GetSectorsList(Constants.STATUS_INACTIVE );
                objAdminSectorsViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminSectors", "Admin");
                if (objAdminSectorsViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminSectorsViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        public async Task<ActionResult> SectorsAddEdit(String sSectorsID)
        {
            try
            {
                Int32 iSectorsID = Convert.ToInt32(Encryption.Decrypt(sSectorsID, true));

                SectorsViewAddEditModel objSectorsViewAddEditModel = new SectorsViewAddEditModel();
                objSectorsViewAddEditModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "SectorsAddEdit", "AdminSectors", "Admin");
                if (objSectorsViewAddEditModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (iSectorsID == 0)
                    {
                        objSectorsViewAddEditModel.Sectors = new Sectors();
                    }
                    else
                    {
                        objSectorsViewAddEditModel.Sectors = await GetSectorsById(iSectorsID);
                        //objSectorsViewAddEditModel.Sectors.listSectorsImage = await GetSectorsImageListBySectorsId(iSectorsID);
                        objSectorsViewAddEditModel.Sectors.listSectorsImage = await GetSectorsImageListBySectorsId(iSectorsID);
                        //return View(model);
                    }
                    return View(objSectorsViewAddEditModel);
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
        public async Task<ActionResult> SectorsAddEdit(SectorsViewAddEditModel model, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                if (file != null)
                {
                    if (ValidateFile(file, Constants.FileSize1MB, "IMAGE", "Sectors Image") == false)
                    {
                        return View(model);
                    }

                    if (!ValidateImageDimensions(file, Constants.SECTORS_IMAGE_MIN_HEIGHT, Constants.SECTORS_IMAGE_MIN_WIDTH))
                    {
                        ModelState.Clear();
                        ToastrMessage_Error("Invalid Image Dimension");
                        return View(model);
                    }
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);

                    string FileExtension = Path.GetExtension(file.FileName);
                    string Folder = Server.MapPath("~/images/Sectors/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = DateTime.Now.Ticks.ToString() + FileExtension;

                    model.Sectors.sectors_image_name = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/images/Sectors/"), fileNewName);
                    file.SaveAs(fileSavePath);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<SectorsViewAddEditModel>("api/API_Sectors/SaveSectors/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminSectors"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("SectorsAddEdit", "AdminSectors"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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
        public async Task<ActionResult> SectorsImageAddEdit(String sSectorsID, String sSectorsImageID)
        {
            try
            {
                Int32 iSectorsID = Convert.ToInt32(Encryption.Decrypt(sSectorsID, true));
                Int32 iSectorsImageID = Convert.ToInt32(Encryption.Decrypt(sSectorsImageID, true));
                SectorsImageAddEditViewModel objSectorsImageAddEditViewModel = new SectorsImageAddEditViewModel();
                objSectorsImageAddEditViewModel.sectors_id = iSectorsID;
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
                if (iSectorsID == 0)
                {
                    ToastrMessage_Error("Invalid Event");
                    return View();
                }
                else
                {
                    if (iSectorsImageID == 0)
                    {
                        objSectorsImageAddEditViewModel.SectorsImage = new SectorsImage();
                    }
                    else
                    {
                        objSectorsImageAddEditViewModel.SectorsImage = await GetSectorsImageById(iSectorsImageID);
                    }

                    //return View(model);
                }
                return View(objSectorsImageAddEditViewModel);
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
        public async Task<ActionResult> SectorsImageAddEdit(SectorsImageAddEditViewModel model, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                if (file != null)
                {
                    if (ValidateFile(file, Constants.FileSize10MB, "IMAGE", "Sectors Image") == false)
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
                    string Folder = Server.MapPath("~/images/Sectors/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = DateTime.Now.Ticks.ToString() + FileExtension;

                    model.SectorsImage.sectors_image_name = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/images/Sectors/"), fileNewName);
                    file.SaveAs(fileSavePath);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<SectorsImageAddEditViewModel>("api/API_Sectors/SaveSectorsImage/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("SectorsAddEdit", "AdminSectors", new { sSectorsID = BEEKP.Class.Encryption.Encrypt(Convert.ToString(model.sectors_id), true) });
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("SectorsAddEdit", "AdminSectors", new { sSectorsID = BEEKP.Class.Encryption.Encrypt(Convert.ToString(model.sectors_id), true) });
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

        public async Task<ActionResult> DeleteSectors(String sSectorsID, String sSectors_image_name)
        {
            try
            {
                Int32 iSectorsID = Convert.ToInt32(Encryption.Decrypt(sSectorsID, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_Sectors/DeleteSectors/" + iSectorsID.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        string fullPath;
                        fullPath = Path.Combine(Server.MapPath("~/images/Sectors"), sSectors_image_name);

                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminSectors");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("SectorsAddEdit", "AdminSectors");
                    }
                    /* return RedirectToAction("Index", "Benchmark", new { sfile_id = sfile_id });*/
                    return RedirectToAction("Index", "AdminSectors", new { sSectorsID = sSectorsID });
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

        public async Task<ActionResult> DeleteSectorsImage(String sSectorsID, String sSectorsImageID, String sSectors_image_name)
        {
            try
            {
                Int32 iSectorsImageID = Convert.ToInt32(Encryption.Decrypt(sSectorsImageID, true));
                Int32 iSectorsID = Convert.ToInt32(Encryption.Decrypt(sSectorsID, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_Sectors/DeleteSectorsImage/" + iSectorsImageID.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        string fullPath;
                        fullPath = Path.Combine(Server.MapPath("~/images/Sectors"), sSectors_image_name);

                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("SectorsAddEdit", "AdminSectors", new { sSectorsID = sSectorsID });
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("SectorsAddEdit", "AdminSectors", new { sSectorsID = sSectorsID });
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

        public async Task<List<Sectors>> GetSectorsList(Int32 _status)

        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Sectors/GetSectorsList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Sectors>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<Sectors> GetSectorsById(Int32 iSectorsID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Sectors/GetSectorsById/" + iSectorsID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<Sectors>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<SectorsImage> GetSectorsImageById(Int32 iSectorsImageID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Sectors/GetSectorsImageById/" + iSectorsImageID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<SectorsImage>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<List<SectorsImage>> GetSectorsImageListBySectorsId(Int32 iSectorsID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Sectors/GetSectorsImageListBySectorsId/" + iSectorsID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<SectorsImage>>());
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
                    if (ValidateFile(file, Constants.FileSize1MB, "IMAGE", "Sectors Image") == false)
                    {
                        ModelState.Clear();
                        ToastrMessage_Error("Invalid Image Extension");

                    }
                    if (!ValidateImageDimensions(file, Constants.SECTORS_IMAGE_MIN_HEIGHT, Constants.SECTORS_IMAGE_MIN_WIDTH))
                    {
                        ModelState.Clear();
                        ToastrMessage_Error("Invalid Image Dimension");

                    }
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);

                    string FileExtension = Path.GetExtension(file.FileName);
                    string Folder = Server.MapPath("~/images/Sectors/");
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
                    file.SaveAs(Server.MapPath("~/images/Sectors") + fileName);//File will be saved in application desired path
                    HttpClient httpClient = GenerateHttpClient();
                    HttpResponseMessage response = httpClient.PostAsJsonAsync<String>("api/API_Sectors/SaveSectors/", fileName).Result;
                }

            }

            return Json("Uploaded " + Request.Files.Count + " files");
        }

    }
}