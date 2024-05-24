using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Areas.Admin.Controllers
{
    public class AdminDigitalLibraryController : AdminBaseController
    {
        // GET: Admin/AdminDigitalLibrary
        public async Task<ActionResult> Index()
        {
            try
            {
                ClearError();
                AdminDigitalLibraryViewModel objAdminDigitalLibraryViewModel = new AdminDigitalLibraryViewModel();
                objAdminDigitalLibraryViewModel.ListDigitalLibrarys = await GetDigitalLibraryList(1,null,null,null,20);
                //objAdminDigitalLibraryViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminDigitalLibrary", "Admin");
                //if (objAdminDigitalLibraryViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                //{
                //    return RedirectToAction("HttpError403", "Error");
                //}
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminDigitalLibraryViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        public async Task<ActionResult> DigitalLibraryAddEdit(string _id)
        {
            try
            {
                Int32 id = Convert.ToInt32(Encryption.Decrypt(_id, true));

                DigitalLibrary objDigitalLibraryViewAddEditModel = new DigitalLibrary();
               
                //objDigitalLibraryViewAddEditModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "DigitalLibraryAddEdit", "AdminDigitalLibrary", "Admin");
                //if (objDigitalLibraryViewAddEditModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                //{
                //    return RedirectToAction("HttpError403", "Error");
                //}
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (id == 0)
                    {
                        objDigitalLibraryViewAddEditModel = new DigitalLibrary();
                        objDigitalLibraryViewAddEditModel.CreatedDate = DateTime.Now;
                        objDigitalLibraryViewAddEditModel.IsActive = true;
                        objDigitalLibraryViewAddEditModel.Clusters = new List<SelectListItem>();

                    }
                    else
                    {
                        objDigitalLibraryViewAddEditModel = await GetDigitalLibraryById(id);
                        objDigitalLibraryViewAddEditModel.CreatedDate = DateTime.Now;
                        objDigitalLibraryViewAddEditModel.Clusters = PopulateClusters1(objDigitalLibraryViewAddEditModel.SectorId);

                        //return View(model);
                    }
                    objDigitalLibraryViewAddEditModel.Sectors = PopulateSectors();
                    return View(objDigitalLibraryViewAddEditModel);
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
        public async Task<ActionResult> DigitalLibraryAddEdit(DigitalLibrary model, HttpPostedFileBase FileUrl,HttpPostedFileBase ImageUrl)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    model.Clusters = PopulateClusters1(model.SectorId);
                    model.Sectors = PopulateSectors();
                    return View(model);
                }
                

                if (FileUrl != null&& model.FileType != "Video")
                {
                    if (FileUrl.ContentType!= "application/pdf" && ValidateFile(FileUrl, Constants.FileSize1MB, "IMAGE", "DigitalLibrary Image") == false)
                    {
                        return View(model);
                    }

                    //if (!ValidateImageDimensions(file, Constants.DigitalLibrary_IMAGE_MIN_HEIGHT, Constants.DigitalLibrary_IMAGE_MIN_WIDTH))
                    //{
                    //    ModelState.Clear();
                    //    ToastrMessage_Error("Invalid Image Dimension");
                    //    return View(model);
                    //}
                    string FileName = Path.GetFileNameWithoutExtension(FileUrl.FileName);

                    string FileExtension = Path.GetExtension(FileUrl.FileName);
                    string Folder = Server.MapPath("~/images/DigitalLibrary/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = DateTime.Now.Ticks.ToString() + FileExtension;
                    if (model.Id > 0&&model.FileUrl!=null)
                    {
                        fileNewName = model.FileUrl;
                    }
                    else
                    {
                        model.FileUrl = fileNewName;
                    }
                    
                    var fileSavePath = Path.Combine(Server.MapPath("~/images/DigitalLibrary/"), fileNewName);
                    FileUrl.SaveAs(fileSavePath);
                }
                if (FileUrl != null && model.FileType=="Video")
                {
                    if (ValidateFile(FileUrl, Constants.FileSize20MB, "VIDEO", "DigitalLibrary Video") == false)
                    {
                        model.Clusters = PopulateClusters1(model.SectorId);
                        model.Sectors = PopulateSectors(); 
                        return View(model);
                    }

                    //if (!ValidateImageDimensions(file, Constants.DigitalLibrary_IMAGE_MIN_HEIGHT, Constants.DigitalLibrary_IMAGE_MIN_WIDTH))
                    //{
                    //    ModelState.Clear();
                    //    ToastrMessage_Error("Invalid Image Dimension");
                    //    return View(model);
                    //}
                    string FileName = Path.GetFileNameWithoutExtension(FileUrl.FileName);

                    string FileExtension = Path.GetExtension(FileUrl.FileName);
                    string Folder = Server.MapPath("~/videos/DigitalLibrary/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    //String fileNewName = FileName + DateTime.Now.Ticks.ToString() + FileExtension;
                    String fileNewName = DateTime.Now.Ticks.ToString() + FileExtension;
                    if (model.Id > 0 && model.FileUrl != null)
                    {
                        fileNewName = model.FileUrl;
                    }
                    else
                    {
                        model.FileUrl = fileNewName;
                    }
                    var fileSavePath = Path.Combine(Server.MapPath("~/videos/DigitalLibrary/"), fileNewName);
                    FileUrl.SaveAs(fileSavePath);
                }
                if (ImageUrl != null)
                {
                    string imageFileName = Path.GetFileNameWithoutExtension(model.FileUrl);
                    string imageExtension = Path.GetExtension(ImageUrl.FileName);
                    string imageNewName = $"{imageFileName}_1{imageExtension}";
                    var imagefileSavePath = Path.Combine(Server.MapPath("~/images/DigitalLibrary/"), imageNewName);
                    ImageUrl.SaveAs(imagefileSavePath);
                    model.ImageUrl = imageNewName;

                }
                model.CreatedBy = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<DigitalLibrary>("api/API_DigitalLibrary/SaveDigitalLibrary/", model).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminDigitalLibrary"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("DigitalLibraryAddEdit", "AdminDigitalLibrary"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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
       
        public async Task<List<DigitalLibrary>> GetDigitalLibraryList(Int32 IsActive, Int32? sectorId, Int32? clusterId,DateTime? createdDate , Int32 _count)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(sectorId.ToString());
            ListParameter.Add(clusterId.ToString());
            ListParameter.Add(createdDate.ToString());
            ListParameter.Add(IsActive.ToString());
            ListParameter.Add("All");
            ListParameter.Add(_count.ToString());


            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_DigitalLibrary/GetDigitalLibraryList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<DigitalLibrary>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<DigitalLibrary> GetDigitalLibraryById(Int32 iDigitalLibraryID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_DigitalLibrary/GetDigitalLibraryById/" + iDigitalLibraryID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<DigitalLibrary>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<DigitalLibraryImage> GetDigitalLibraryImageById(Int32 iDigitalLibraryImageID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_DigitalLibrary/GetDigitalLibraryImageById/" + iDigitalLibraryImageID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<DigitalLibraryImage>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<List<DigitalLibraryImage>> GetDigitalLibraryImageListByDigitalLibraryId(Int32 iDigitalLibraryID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_DigitalLibrary/GetDigitalLibraryImageListByDigitalLibraryId/" + iDigitalLibraryID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<DigitalLibraryImage>>());
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
                    if (ValidateFile(file, Constants.FileSize1MB, "IMAGE", "DigitalLibrary Image") == false)
                    {
                        ModelState.Clear();
                        ToastrMessage_Error("Invalid Image Extension");

                    }
                    
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);

                    string FileExtension = Path.GetExtension(file.FileName);
                    string Folder = Server.MapPath("~/images/DigitalLibrary/");
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
                    file.SaveAs(Server.MapPath("~/images/DigitalLibrary") + fileName);//File will be saved in application desired path
                    HttpClient httpClient = GenerateHttpClient();
                    HttpResponseMessage response = httpClient.PostAsJsonAsync<String>("api/API_DigitalLibrary/SaveDigitalLibrary/", fileName).Result;
                }

            }

            return Json("Uploaded " + Request.Files.Count + " files");
        }


        private static List<SelectListItem> PopulateClusters1(int Id)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand($"SELECT Id,ClusterName FROM tblCluster where Id={Id} order by ClusterName");
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        items.Add(new SelectListItem
                        {
                            Text = sdr["ClusterName"].ToString(),
                            Value = sdr["Id"].ToString()
                        });
                    }
                }
                con.Close();
            }
            return items;
        }

        [HttpGet]
        public ActionResult PopulateClusters(int Id)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand($"SELECT * FROM tblCluster where SectorId={Id} order by ClusterName");
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        items.Add(new SelectListItem
                        {
                            Text = sdr["ClusterName"].ToString(),
                            Value = sdr["Id"].ToString()
                        });
                    }
                }
                con.Close();
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        private static List<SelectListItem> PopulateSectors()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand("SELECT sector_name,sector_id FROM tblSector order by sector_name");
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        items.Add(new SelectListItem
                        {
                            Text = sdr["sector_name"].ToString(),
                            Value = sdr["sector_id"].ToString()
                        });
                    }
                }
                con.Close();
            }
            return items;
        }
    }
}