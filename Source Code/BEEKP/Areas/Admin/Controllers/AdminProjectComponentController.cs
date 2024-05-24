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
    public class AdminProjectComponentController : AdminBaseController
    {
        // GET: Admin/ProjectComponent
        public async Task<ActionResult> Index()
        {
            try
            {
                ClearError();
                AdminProjectComponentViewModel objAdminProjectComponentViewModel = new AdminProjectComponentViewModel();
                objAdminProjectComponentViewModel.ListProjectComponentActive = await GetProjectComponentList(Constants.STATUS_ACTIVE);
                objAdminProjectComponentViewModel.ListProjectComponentInactive = await GetProjectComponentList(Constants.STATUS_INACTIVE);
                objAdminProjectComponentViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminProjectComponent", "Admin");
                if (objAdminProjectComponentViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminProjectComponentViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        public async Task<ActionResult> ManageProjectComponent(String sproject_component_id)
        {
            try
            {
                Int32 iproject_component_id = Convert.ToInt32(Encryption.Decrypt(sproject_component_id, true));



                ProjectComponentManageModel objProjectComponentManageModel = new ProjectComponentManageModel();

                objProjectComponentManageModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageProjectComponent", "AdminProjectComponent", "Admin");
                if (objProjectComponentManageModel.PagePermission.role_view != BEEKP.Class.Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (iproject_component_id == 0)
                    {
                        objProjectComponentManageModel.ProjectComponent = new ProjectComponent();
                    }
                    else
                    {
                        objProjectComponentManageModel.ProjectComponent = await GetProjectComponentById(iproject_component_id);

                    }
                    return View(objProjectComponentManageModel);
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
        public async Task<ActionResult> ManageProjectComponent(ProjectComponentManageModel model, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }
                if (model.ProjectComponent.project_component_id == 0 && file == null)
                {
                    //ModelState.AddModelError(string.Empty, "Invalid Photo, Please Browse");
                    //return View(model);
                    ToastrMessage_Error("Invalid Photo, Please Browse");
                    return View(model);
                }

                if (file != null)
                {
                    if (ValidateFile(file, Constants.FileSize1MB, "IMAGE", "Project Component Image") == false)
                    {
                        return View(model);
                    }

                    if (!ValidateImageDimensions(file, Constants.PROJECT_COMPONENT_IMAGE_MIN_HEIGHT, Constants.PROJECT_COMPONENT_IMAGE_MIN_WIDTH))
                    {
                        ModelState.Clear();
                        ToastrMessage_Error("Invalid Image Dimension");
                        return View(model);
                    }
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);

                    string FileExtension = Path.GetExtension(file.FileName);
                    string Folder = Server.MapPath("~/images/ProjectComponent/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    String fileNewName = DateTime.Now.Ticks.ToString() + FileExtension;

                    model.ProjectComponent.project_component_image_name = fileNewName;
                    var fileSavePath = Path.Combine(Server.MapPath("~/images/ProjectComponent"), fileNewName);
                    file.SaveAs(fileSavePath);
                }

                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<ProjectComponentManageModel>("api/API_ProjectComponent/SaveProjectComponent/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminProjectComponent");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageProjectComponent", "AdminProjectComponent");
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

        public async Task<List<ProjectComponent>> GetProjectComponentList(Int32 _status)

        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
           


            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_ProjectComponent/GetProjectComponentList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<ProjectComponent>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ProjectComponent> GetProjectComponentById(Int32 iproject_component_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_ProjectComponent/GetProjectComponentById/" + iproject_component_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<ProjectComponent>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ActionResult> DeleteProjectComponent(String sproject_component_id, String sproject_component_name)
        {
            try
            {
                Int32 iphoto_id = Convert.ToInt32(Encryption.Decrypt(sproject_component_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_ProjectComponent/DeleteProjectComponent/" + iphoto_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        string fullPath;
                        fullPath = Path.Combine(Server.MapPath("~/images/ProjectComponent"), sproject_component_name);

                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }

                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminProjectComponent");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminProjectComponent");
                    }
                    return RedirectToAction("Index", "AdminProjectComponent", new { sproject_component_id = sproject_component_id });
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