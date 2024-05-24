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
    public class AdminCaseStudyController : AdminBaseController
    {
        // GET: Admin/AdminCaseStudy
        public async Task<ActionResult> Index()
        {
            try
            {
                AdminCaseStudyViewModel objAdminCaseStudyViewModel = new AdminCaseStudyViewModel();
                objAdminCaseStudyViewModel.ListCaseStudy = await GetCaseStudyList(Convert.ToString(Constants.CASESTUDY_ALL));
                objAdminCaseStudyViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminCaseStudy", "Admin");
                if (objAdminCaseStudyViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminCaseStudyViewModel);
                }
            }
            catch(Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        public async Task<ActionResult> ManageCaseStudy(String scasestudy_id)
        {
            try
            {
                Int32 icasestudy_id = Convert.ToInt32(Encryption.Decrypt(scasestudy_id, true));

                CaseStudyManageModel objCaseStudyManageModel = new CaseStudyManageModel();
                AdminClusterDetailsController objClusterDetailsController = new AdminClusterDetailsController();
                objCaseStudyManageModel.ListCluster = await objClusterDetailsController.GetClusterDetailsList();
                objCaseStudyManageModel.ListCluster.Insert(0, new Cluster() { cluster_id = 0, cluster_name = "--Select--", fuel_used = "", location = "", number_of_units = 0, overall_turnover = 0, products_manufactured = "" });

                objCaseStudyManageModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageCaseStudy", "AdminCaseStudy", "Admin");
                if (objCaseStudyManageModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (icasestudy_id == 0)
                    {
                        objCaseStudyManageModel.CaseStudy = new CaseStudy();

                    }
                    else
                    {
                        objCaseStudyManageModel.CaseStudy = await GetCaseStudyById(icasestudy_id);

                    }
                    return View(objCaseStudyManageModel);
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
        public async Task<ActionResult> ManageCaseStudy(CaseStudyManageModel model, HttpPostedFileBase fileCaseStudyDoc)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }

                if (fileCaseStudyDoc != null)
                {
                    if (ValidateFile(fileCaseStudyDoc, Constants.FileSize20MB, "PDF", "Knowledge Bank Document") == false)
                    {
                        return View(model);
                    }

                    string FileName = Path.GetFileNameWithoutExtension(fileCaseStudyDoc.FileName);

                    string FileExtension = Path.GetExtension(fileCaseStudyDoc.FileName);
                    string Folder = Server.MapPath("~/documents/Case_Study/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = DateTime.Now.Ticks.ToString() + FileExtension;

                    model.CaseStudy.file_name = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/documents/Case_Study/"), fileNewName);
                    fileCaseStudyDoc.SaveAs(fileSavePath);
                }
                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<CaseStudyManageModel>("api/API_CaseStudy/SaveCaseStudy/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminCaseStudy"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageCaseStudy", "AdminCaseStudy"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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

        public async Task<List<CaseStudy>> GetCaseStudyList(String Parameter)
        {
            List<String> ListParameter = new List<string>();
            ListParameter.Add(Parameter);

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_CaseStudy/GetCaseStudyList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<CaseStudy>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<CaseStudy> GetCaseStudyById(Int32 icasestudy_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_CaseStudy/GetCaseStudyById/" + icasestudy_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<CaseStudy>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<ActionResult> DeleteCaseStudy(String scasestudy_id)
        {
            try
            {
                Int32 icasestudy_id = Convert.ToInt32(Encryption.Decrypt(scasestudy_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_CaseStudy/DeleteCaseStudy/" + icasestudy_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminCaseStudy");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminCaseStudy");
                    }

                    return RedirectToAction("Index", "AdminCaseStudy", new { scasestudy_id = scasestudy_id });
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