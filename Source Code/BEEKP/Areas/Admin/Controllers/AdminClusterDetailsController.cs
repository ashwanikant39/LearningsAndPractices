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
    public class AdminClusterDetailsController : AdminBaseController
    {
        // GET: Admin/ClusterDetails
        public async Task<ActionResult> Index()
        {
            try
            {
                ClearError();
                AdminClusterDetailsViewModel objClusterDetailsModel = new AdminClusterDetailsViewModel();
                objClusterDetailsModel.ListCluster = await GetClusterDetailsList();
                objClusterDetailsModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminClusterDetails", "Admin");
                if (objClusterDetailsModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objClusterDetailsModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        public async Task<ActionResult> ClusterDetailsAddEdit(String scluster_id)
        {
            try
            {
                Int32 icluster_id = Convert.ToInt32(Encryption.Decrypt(scluster_id, true));


                ClusterDetailsAddEditModel objClusterDetailsAddEditModel = new ClusterDetailsAddEditModel();
                objClusterDetailsAddEditModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ClusterDetailsAddEdit", "AdminClusterDetails", "Admin");
                objClusterDetailsAddEditModel.ListPhase = await GetPhaseList();
                objClusterDetailsAddEditModel.ListPhase.Insert(0, new Phases() { phases_id = 0, phases_title = "--Select--" });
                if (objClusterDetailsAddEditModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (icluster_id == 0)
                    {
                        objClusterDetailsAddEditModel.Cluster = new Cluster();
                        //model.Event.event_id = iEventID;
                    }
                    else
                    {
                        objClusterDetailsAddEditModel.Cluster = await GetClusterDetailsById(icluster_id);
                        //return View(model);
                    }

                    return View(objClusterDetailsAddEditModel);
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
        public async Task<ActionResult> ClusterDetailsAddEdit(ClusterDetailsAddEditModel model, HttpPostedFileBase file_hindi, HttpPostedFileBase file_english, HttpPostedFileBase file_marathi)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }
                if (file_hindi != null)
                {
                    if (ValidateFile(file_hindi, Constants.FileSize5MB, "PDF", "Cluster Document") == false)
                    {
                        return View(model);
                    }
                    string strHindi = "Hindi_";

                    string FileName = Path.GetFileNameWithoutExtension(file_hindi.FileName);

                    string FileExtension = Path.GetExtension(file_hindi.FileName);
                    string Folder = Server.MapPath("~/documents/Cluster/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = strHindi + DateTime.Now.Ticks.ToString() + FileExtension;

                    model.Cluster.cluster_doc_hindi = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/documents/Cluster/"), fileNewName);
                    file_hindi.SaveAs(fileSavePath);
                }


                if (file_english != null)
                {
                    if (ValidateFile(file_english, Constants.FileSize5MB, "PDF", "Cluster Document") == false)
                    {
                        return View(model);
                    }
                    string strEnglish = "English_";

                    string FileName = Path.GetFileNameWithoutExtension(file_english.FileName);

                    string FileExtension = Path.GetExtension(file_english.FileName);
                    string Folder = Server.MapPath("~/documents/Cluster/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = strEnglish + DateTime.Now.Ticks.ToString() + FileExtension;

                    model.Cluster.cluster_doc_english = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/documents/Cluster/"), fileNewName);
                    file_english.SaveAs(fileSavePath);
                }
                if (file_marathi != null)
                {
                    if (ValidateFile(file_marathi, Constants.FileSize5MB, "PDF", "Cluster Document") == false)
                    {
                        return View(model);
                    }
                    string strMarathi = "Marathi_";

                    string FileName = Path.GetFileNameWithoutExtension(file_marathi.FileName);

                    string FileExtension = Path.GetExtension(file_marathi.FileName);
                    string Folder = Server.MapPath("~/documents/Cluster/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = strMarathi + DateTime.Now.Ticks.ToString() + FileExtension;

                    model.Cluster.cluster_doc_marathi = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/documents/Cluster/"), fileNewName);
                    file_marathi.SaveAs(fileSavePath);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<ClusterDetailsAddEditModel>("api/API_ClusterDetails/SaveClusterDetails/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminClusterDetails"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ClusterDetailsAddEdit", "AdminClusterDetails"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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
        public async Task<ActionResult> DeleteClusterDetails(String scluster_id, String sdocument_hindi, String sdocument_english, String sdocument_marathi)
        {
            try
            {
                Int32 icluster_id = Convert.ToInt32(Encryption.Decrypt(scluster_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_ClusterDetails/DeleteClusterDetails/" + icluster_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        string fullPath_hindi, fullPath_english, fullPath_marathi;
                        if(sdocument_hindi != null && sdocument_hindi != "")
                        {
                            fullPath_hindi = Path.Combine(Server.MapPath("~/documents/Cluster"), sdocument_hindi);
                            if (System.IO.File.Exists(fullPath_hindi))
                            {
                                System.IO.File.Delete(fullPath_hindi);
                            }
                        }
                        if (sdocument_english != null && sdocument_english != "")
                        {
                            fullPath_english = Path.Combine(Server.MapPath("~/documents/Cluster"), sdocument_english);
                            if (System.IO.File.Exists(fullPath_english))
                            {
                                System.IO.File.Delete(fullPath_english);
                            }
                        }
                        if (sdocument_marathi != null && sdocument_marathi != "")
                        {
                            fullPath_marathi = Path.Combine(Server.MapPath("~/documents/Cluster"), sdocument_marathi);
                            if (System.IO.File.Exists(fullPath_marathi))
                            {
                                System.IO.File.Delete(fullPath_marathi);
                            }
                        }
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminClusterDetails");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminClusterDetails");
                    }

                    return RedirectToAction("Index", "AdminClusterDetails", new { scluster_id = scluster_id });
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

        public async Task<List<Cluster>> GetClusterDetailsList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_ClusterDetails/GetClusterDetailsList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Cluster>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<Cluster> GetClusterDetailsById(Int32 icluster_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_ClusterDetails/GetClusterDetailsById/" + icluster_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<Cluster>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ActionResult> DeleteFile(String scluster_id,String sdocument_hindi, String sdocument_english, String sdocument_marathi)
        {
            try
            {
                Int32 icluster_id = Convert.ToInt32(Encryption.Decrypt(scluster_id, true));

                ClusterDetailsAddEditModel objClusterDetailsAddEditModel = new ClusterDetailsAddEditModel();
                objClusterDetailsAddEditModel.Cluster = await GetClusterDetailsById(icluster_id);

                if (sdocument_hindi != null && sdocument_hindi != "")
                {
                    objClusterDetailsAddEditModel.Cluster.cluster_doc_hindi = String.Empty;

                    HttpClient httpClient = GenerateHttpClient();
                    HttpResponseMessage response = httpClient.PostAsJsonAsync<ClusterDetailsAddEditModel>("api/API_ClusterDetails/SaveClusterDetails/", objClusterDetailsAddEditModel).Result;


                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                        if (objOutputMessage.MessageId > 0)
                        {
                            string fullPath_hindi;
                            fullPath_hindi = Path.Combine(Server.MapPath("~/documents/Cluster"), sdocument_hindi);
                            if (System.IO.File.Exists(fullPath_hindi))
                            {
                                System.IO.File.Delete(fullPath_hindi);
                            }

                            //ToastrMessage_Success(objOutputMessage.Message);
                            return RedirectToAction("ClusterDetailsAddEdit", "AdminClusterDetails", new { scluster_id = scluster_id });
                        }
                        else
                        {
                            ToastrMessage_Error(objOutputMessage.Message);
                            return RedirectToAction("ClusterDetailsAddEdit", "AdminClusterDetails", new { scluster_id = scluster_id });
                        }

                    }
                    else
                    {
                        ErrorMessage _ErrorMessage = await CheckResponse(response);
                        throw new Exception(_ErrorMessage.ErrorMessages);
                    }
                  
                }
                if (sdocument_english != null && sdocument_english != "")
                {


                    objClusterDetailsAddEditModel.Cluster.cluster_doc_english = String.Empty;

                    HttpClient httpClient = GenerateHttpClient();
                    HttpResponseMessage response = httpClient.PostAsJsonAsync<ClusterDetailsAddEditModel>("api/API_ClusterDetails/SaveClusterDetails/", objClusterDetailsAddEditModel).Result;


                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                        if (objOutputMessage.MessageId > 0)
                        {
                            string fullPath_english;
                            fullPath_english = Path.Combine(Server.MapPath("~/documents/Cluster"), sdocument_english);
                            if (System.IO.File.Exists(fullPath_english))
                            {
                                System.IO.File.Delete(fullPath_english);
                            }

                            //ToastrMessage_Success(objOutputMessage.Message);
                            return RedirectToAction("ClusterDetailsAddEdit", "AdminClusterDetails", new { scluster_id = scluster_id });
                        }
                        else
                        {
                            ToastrMessage_Error(objOutputMessage.Message);
                            return RedirectToAction("ClusterDetailsAddEdit", "AdminClusterDetails", new { scluster_id = scluster_id });
                        }

                    }
                    else
                    {
                        ErrorMessage _ErrorMessage = await CheckResponse(response);
                        throw new Exception(_ErrorMessage.ErrorMessages);
                    }


                  
                }
                if (sdocument_marathi != null && sdocument_marathi != "")
                {

                    objClusterDetailsAddEditModel.Cluster.cluster_doc_marathi = String.Empty;

                    HttpClient httpClient = GenerateHttpClient();
                    HttpResponseMessage response = httpClient.PostAsJsonAsync<ClusterDetailsAddEditModel>("api/API_ClusterDetails/SaveClusterDetails/", objClusterDetailsAddEditModel).Result;


                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                        if (objOutputMessage.MessageId > 0)
                        {
                            string fullPath_marathi;
                            fullPath_marathi = Path.Combine(Server.MapPath("~/documents/Cluster"), sdocument_marathi);
                            if (System.IO.File.Exists(fullPath_marathi))
                            {
                                System.IO.File.Delete(fullPath_marathi);
                            }

                            //ToastrMessage_Success(objOutputMessage.Message);
                            return RedirectToAction("ClusterDetailsAddEdit", "AdminClusterDetails", new { scluster_id = scluster_id });
                        }
                        else
                        {
                            ToastrMessage_Error(objOutputMessage.Message);
                            return RedirectToAction("ClusterDetailsAddEdit", "AdminClusterDetails", new { scluster_id = scluster_id });
                        }

                    }
                    else
                    {
                        ErrorMessage _ErrorMessage = await CheckResponse(response);
                        throw new Exception(_ErrorMessage.ErrorMessages);
                    }

                  
                }

                return RedirectToAction("ClusterDetailsAddEdit", "AdminClusterDetails", new { scluster_id = scluster_id });
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