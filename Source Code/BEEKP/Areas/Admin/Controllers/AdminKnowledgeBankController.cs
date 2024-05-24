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
    public class AdminKnowledgeBankController : AdminBaseController
    {
        // GET: Admin/AdminKnowledgeBank
        public async Task<ActionResult> Index()
        {
            try
            {
                ClearError();
                AdminKnowledgeBankViewModel objAdminKnowledgeBankViewModel = new AdminKnowledgeBankViewModel();
                objAdminKnowledgeBankViewModel.ListKnowledgeBankActive = await GetKnowledgeBankList(Constants.STATUS_ACTIVE);
                objAdminKnowledgeBankViewModel.ListKnowledgeBankInactive = await GetKnowledgeBankList(Constants.STATUS_INACTIVE);
                objAdminKnowledgeBankViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminKnowledgeBank", "Admin");
                if (objAdminKnowledgeBankViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminKnowledgeBankViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        public async Task<ActionResult> ManageKnowledgeBank(String sknowledge_bank_id)
        {
            try
            {
                Int32 iknowledge_bank_id = Convert.ToInt32(Encryption.Decrypt(sknowledge_bank_id, true));

                KnowledgeBankManageModel objKnowledgeBankManageModel = new KnowledgeBankManageModel();
                objKnowledgeBankManageModel.ListKnowledgeBankType = await GetKnowledgeBankTypeList();
                objKnowledgeBankManageModel.ListKnowledgeBankType.Insert(0, new KnowledgeBankType() { knowledge_bank_type_id = 0, knowledge_bank_type_name = "--Select--" });
                objKnowledgeBankManageModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageKnowledgeBank", "AdminKnowledgeBank", "Admin");
                if (objKnowledgeBankManageModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (iknowledge_bank_id == 0)
                    {
                        objKnowledgeBankManageModel.KnowledgeBank = new KnowledgeBank();
                    }
                    else
                    {
                        objKnowledgeBankManageModel.KnowledgeBank = await GetKnowledgeBankById(iknowledge_bank_id);
                        return View(objKnowledgeBankManageModel);
                    }
                    return View(objKnowledgeBankManageModel);
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
        public async Task<ActionResult> ManageKnowledgeBank(KnowledgeBankManageModel model, HttpPostedFileBase fileKnowledgeDoc)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }
                if (fileKnowledgeDoc != null)
                {
                    if (ValidateFile(fileKnowledgeDoc, Constants.FileSize20MB, "PDF", "Knowledge Bank Document") == false)
                    {
                        model.ListKnowledgeBankType = await GetKnowledgeBankTypeList();
                        return View(model);
                    }

                    string FileName = Path.GetFileNameWithoutExtension(fileKnowledgeDoc.FileName);

                    string FileExtension = Path.GetExtension(fileKnowledgeDoc.FileName);
                    string Folder = Server.MapPath("~/documents/Knowledge_Bank/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = FileName + "_" + DateTime.Now.Ticks.ToString() + FileExtension;

                    model.KnowledgeBank.file_name = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/documents/Knowledge_Bank/"), fileNewName);
                    fileKnowledgeDoc.SaveAs(fileSavePath);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<KnowledgeBankManageModel>("api/API_KnowledgeBank/SaveKnowledgeBank/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminKnowledgeBank"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageKnowledgeBank", "AdminKnowledgeBank"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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

        public async Task<List<KnowledgeBank>> GetKnowledgeBankList(Int32 _status)

        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());



            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_KnowledgeBank/GetKnowledgeBankList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<KnowledgeBank>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ActionResult> DeleteKnowledgeBank(String sknowledge_bank_id, String sfileKnowledgeDoc)
        {
            try
            {
                Int32 iknowledge_bank_id = Convert.ToInt32(Encryption.Decrypt(sknowledge_bank_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_KnowledgeBank/DeleteKnowledgeBank/" + iknowledge_bank_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        string fullPath;
                        fullPath = Path.Combine(Server.MapPath("~/documents/Knowledge_Bank"), sfileKnowledgeDoc);

                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminKnowledgeBank");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageKnowledgeBank", "AdminKnowledgeBank");
                    }
                    /* return RedirectToAction("Index", "Benchmark", new { sfile_id = sfile_id });*/
                    return RedirectToAction("Index", "AdminKnowledgeBank", new { iknowledge_bank_id = sknowledge_bank_id });
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

        public async Task<KnowledgeBank> GetKnowledgeBankById(Int32 iknowledge_bank_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_KnowledgeBank/GetKnowledgeBankById/" + iknowledge_bank_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<KnowledgeBank>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
    }
}