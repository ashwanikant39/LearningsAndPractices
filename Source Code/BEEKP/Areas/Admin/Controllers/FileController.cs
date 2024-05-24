using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
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
    public class FileController : AdminBaseController
    {
        // GET: Admin/File
        public async Task<ActionResult> Index()
        {
            AdminFileViewModel objAdminFileViewModel = new AdminFileViewModel();
            objAdminFileViewModel.ListFile = await GetFileList();
            return View(objAdminFileViewModel);
        }

        public async Task<ActionResult> Manage(String sFileID)
        {
            try
            {
                Int32 iFileID = Convert.ToInt32(Encryption.Decrypt(sFileID, true));
                AdminFileManageViewModel model = new AdminFileManageViewModel();
                if (iFileID == 0)
                {
                    model.File = new File();
                }
                else
                {
                    model.File = await GetFileById(iFileID);
                    //return View(model);
                }
                return View(model);

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
        public async Task<ActionResult> Manage(AdminFileManageViewModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }
                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<AdminFileManageViewModel>("api/API_File/SaveFile/", model).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "File"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Manage", "File"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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

        public async Task<ActionResult> DeleteFile(String sFileID)
        {
            try
            {
                Int32 iFileID = Convert.ToInt32(Encryption.Decrypt(sFileID, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_File/DeleteFile/" + iFileID.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "File");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "File");
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

        public async Task<List<File>> GetFileList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_File/GetFileList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<File>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<File> GetFileById(Int32 iFileID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_File/GetFileById/" + iFileID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<File>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

    }
}