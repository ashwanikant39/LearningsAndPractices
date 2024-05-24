using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BEEKP.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session[ApplicationSession.user_id] != null)
            {

                HttpCookie cookie = filterContext.HttpContext.Request.Cookies["AntiFixationCookie"];

                //HttpCookie cookie_ASPNET_SessionId = filterContext.HttpContext.Request.Cookies["ASP.NET_SessionId"];


                //if (cookie_ASPNET_SessionId != null)
                //{
                //    filterContext.HttpContext.Request.Cookies.Remove(cookie_ASPNET_SessionId.Name);
                //}

                //cookie_ASPNET_SessionId = new HttpCookie("ASP.NET_SessionId");
                //cookie_ASPNET_SessionId.Value = Convert.ToString(Guid.NewGuid());
                //cookie_ASPNET_SessionId.Expires = DateTime.Now.AddDays(7);
                ////filterContext.HttpContext.Request.Cookies.Add(cookie);
                //Response.Cookies.Add(cookie_ASPNET_SessionId);



                if (cookie.Value != null && cookie.Value == Session["AntiFixationCookie"].ToString())
                {
                    filterContext.HttpContext.Request.Cookies.Remove(cookie.Name);
                    Session["AntiFixationCookie"] = Guid.NewGuid();
                    cookie = new HttpCookie("AntiFixationCookie") { HttpOnly = true };
                    cookie.Value = Convert.ToString(Session["AntiFixationCookie"]);
                    cookie.Expires = DateTime.Now.AddDays(7);
                    //filterContext.HttpContext.Request.Cookies.Add(cookie);
                    Response.Cookies.Add(cookie);

                    base.OnActionExecuting(filterContext);
                }
                else
                {

                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.Result = new JsonResult { Data = Constants.AJAX_SESSIONOUT };
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Account",
                            action = "Login"
                        }));
                    }
                }


            }
            else
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult { Data = Constants.AJAX_SESSIONOUT };
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Account",
                        action = "Login"
                    }));
                }
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
            PopulateError(objErrorMessage);
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "Error",
                action = "GeneralError",
                area = "Admin"
            }));


        }

        public async Task<List<State>> GetStateList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetStateList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<State>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<List<UserType>> GetUserTypeList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetUserTypeList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<UserType>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<List<EE_equipment>> GetEE_equipmentList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetEE_equipmentList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<EE_equipment>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<List<AreaSpecialization>> GetAreaSpecializationList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetAreaSpecializationList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<AreaSpecialization>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<List<TypeOfInstitution>> GetTypeOfInstitutionList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetTypeOfInstitutionList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<TypeOfInstitution>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<List<KnowledgeBankType>> GetKnowledgeBankTypeList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetKnowledgeBankTypeList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<KnowledgeBankType>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<List<CategoryMeasure>> GetCategoryMeasureList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetCategoryMeasureList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<CategoryMeasure>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<List<Sector>> GetSectorListByClusterId(String _cluster_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_cluster_id.ToString());


            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Base/GetSectorListByClusterId/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Sector>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> GetSectorDropDownList(String _cluster_id)
        {
            List<Sector> lstSector = await GetSectorListByClusterId(_cluster_id);
            //lstDistrict.Insert(0, new ApproverType() {  approver_type_id = 0, approver_type_name = "-- Select --" });
            return new JsonResult { Data = lstSector, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public async Task<List<FinancingSchemeCtaegory>> GetFinancingSchemeCategoryList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetFinancingSchemeCategoryList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<FinancingSchemeCtaegory>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        /*public async Task<List<LoanSchemeCtaegory>> GetLoanSchemeCategoryList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetLoanSchemeCategoryList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<LoanSchemeCtaegory>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<List<SubsidySchemeCtaegory>> GetSubsidySchemeCategoryList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetSubsidySchemeCategoryList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<SubsidySchemeCtaegory>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }*/
        public async Task<List<Phases>> GetPhaseList()
        {
            HttpClient httpclient = GenerateHttpClient();
            HttpResponseMessage response = await httpclient.GetAsync("api/API_Base/GetPhaseList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Phases>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<List<Sectors>> GetSectorsList()
        {
            HttpClient httpclient = GenerateHttpClient();
            HttpResponseMessage response = await httpclient.GetAsync("api/API_Base/GetSectorsList/");
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<OutputMessage> ManageUserLog(UserLog model)
        //{

        //    HttpClient httpClient = GenerateHttpClient();
        //    HttpResponseMessage response = httpClient.PostAsJsonAsync<UserLog>("api/API_Base/SaveUserLog/", model).Result;
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        return (await response.Content.ReadAsAsync<OutputMessage>());
        //    }
        //    else
        //    {
        //        ErrorMessage _ErrorMessage = await CheckResponse(response);
        //        throw new Exception(_ErrorMessage.ErrorMessages);
        //    }
        //}


        // GET: Admin/Base
        //public HttpClient GenerateHttpClient_WithToken()
        //{
        //    HttpClient _HttpClient = new HttpClient();
        //    _HttpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ClientUrl"].ToString());
        //    _HttpClient.DefaultRequestHeaders.Accept.Clear();
        //    var EncryptToken = (string)Session[ApplicationSession.AccessToken];
        //    var DecryptToken = Convert.ToString(Encryption.Decrypt(EncryptToken, true));
        //    _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", DecryptToken);

        //    return _HttpClient;

        //    //HttpClient _HttpClient = new HttpClient();
        //    //_HttpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ClientUrl"].ToString());
        //    //_HttpClient.DefaultRequestHeaders.Accept.Clear();
        //    //return _HttpClient;
        //}

        public async Task<ErrorMessage> CheckResponse(HttpResponseMessage response)
        {
            ErrorMessage objErrorMessage = new ErrorMessage();
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                objErrorMessage.ErrorMessages = "Unauthorized access";
            }
            else
            {
                objErrorMessage = await response.Content.ReadAsAsync<ErrorMessage>();
            }

            return objErrorMessage;
        }
        public HttpClient GenerateHttpClient()
        {
            HttpClient _HttpClient = new HttpClient();
            _HttpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ClientUrl"].ToString());
            _HttpClient.DefaultRequestHeaders.Accept.Clear();
            return _HttpClient;
        }
        public void ToastrMessage_Success(String _message)
        {
            TempData["ShowMessage"] = "true";
            TempData["MessageType"] = "success";
            TempData["MessageTitle"] = "Success";
            TempData["Message"] = _message;
        }
        public void ToastrMessage_Error(String _message)
        {
            TempData["ShowMessage"] = "true";
            TempData["MessageType"] = "error";
            TempData["MessageTitle"] = "Error";
            TempData["Message"] = _message;
        }
        public void PopulateError(ErrorMessage objErrorMessage)
        {
            Session[ApplicationSession.ErrorId] = objErrorMessage.ErrorId;
            Session[ApplicationSession.ErrorMessages] = objErrorMessage.ErrorMessages;
            Session[ApplicationSession.ErrorType] = objErrorMessage.ErrorType;
        }

        public async Task<PagePermission> GetPagePermission(Int32 iRoleId, String View, String Controller, String Area)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(iRoleId.ToString());
            ListParameter.Add(View);
            ListParameter.Add(Controller);
            ListParameter.Add(Area);


            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Base/GetPagePermission/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                PagePermission objPagePermission = await response.Content.ReadAsAsync<PagePermission>();
                return (objPagePermission);
            }
            else
            {
                ErrorMessage objErrorMessage = await response.Content.ReadAsAsync<ErrorMessage>();
                PopulateError(objErrorMessage);
                return new PagePermission();
            }
        }

        public void ClearError()
        {
            ErrorMessage objErrorMessage = new ErrorMessage();
            Session[ApplicationSession.ErrorId] = objErrorMessage.ErrorId;
            Session[ApplicationSession.ErrorMessages] = objErrorMessage.ErrorMessages;
            Session[ApplicationSession.ErrorType] = objErrorMessage.ErrorType;
        }

        public Boolean HasError()
        {
            if (Convert.ToString(Session[ApplicationSession.ErrorMessages]).Trim() != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateFile(HttpPostedFileBase file, Int32 MaxFileSizeInKB, String FileType, String FileName)
        {
            if (file == null || file.ContentLength == 0)
            {
                ToastrMessage_Error(FileName + " - File not found");
                return false;
            }
            else if (file.ContentLength > 0)
            {
                string fileName = file.FileName; // getting File Name
                string fileContentType = file.ContentType; // getting ContentType
                byte[] tempFileBytes = new byte[file.ContentLength]; // getting filebytes
                var data = file.InputStream.Read(tempFileBytes, 0, Convert.ToInt32(file.ContentLength));

                //string _fileExtension = Path.GetExtension(file.FileName);

                String[] _fileExtension = file.FileName.Split('.');

                if (ExtesionCheck(FileType, _fileExtension[_fileExtension.Length - 1]) == false)
                {
                    ToastrMessage_Error(FileName + " - Invalid file type");
                    return false;
                }

                FileUploadCheck.FileType types = new FileUploadCheck.FileType();
                bool result = false;

                if (FileType == Constants.FILE_TYPE_PDF)
                {
                    types = FileUploadCheck.FileType.PDF;  // Setting Image type
                    result = FileUploadCheck.isValidFile(tempFileBytes, types, fileContentType); // Validate Header
                }
                if (FileType == Constants.FILE_TYPE_VIDEO)
                {
                    types = FileUploadCheck.FileType.Video;  // Setting Image type
                    result = FileUploadCheck.isValidFile(tempFileBytes, types, fileContentType); // Validate Header
                }

                if (FileType == Constants.FILE_TYPE_IMAGE)
                {

                    types = FileUploadCheck.FileType.Image;  // Setting Image type
                    if (IsImage(file))
                    {
                        result = FileUploadCheck.isValidFile(tempFileBytes, types, fileContentType); // Validate Header
                    }
                    else
                    {
                        result = false;
                    }
                }

                if (FileType == Constants.FILE_TYPE_TXT)
                {
                    types = FileUploadCheck.FileType.Text;  // Setting Image type
                    result = FileUploadCheck.isValidFile(tempFileBytes, types, fileContentType); // Validate Header
                }

                if (FileType == Constants.FILE_TYPE_DOC)
                {
                    types = FileUploadCheck.FileType.DOC;  // Setting Image type
                    result = FileUploadCheck.isValidFile(tempFileBytes, types, fileContentType); // Validate Header
                }

                if (FileType == Constants.FILE_TYPE_DOCX)
                {
                    types = FileUploadCheck.FileType.DOCX;  // Setting Image type
                    result = FileUploadCheck.isValidFile(tempFileBytes, types, fileContentType); // Validate Header
                }

                if (result == true)
                {
                    String[] ext = file.FileName.Split('.');
                    if (ext.Length > 2) //filename[1].ext[2]
                    {
                        ModelState.Clear();
                        ToastrMessage_Error(FileName + " - Multiple file extention not allowed");
                        return false;
                    }

                    if (file.ContentLength > MaxFileSizeInKB)//File size in byte
                    {
                        int FileKB = MaxFileSizeInKB / 1024; //Convert to KB
                        ModelState.Clear();
                        ToastrMessage_Error(FileName + " - Maximum File size is:" + FileKB + "KB");
                        return false;
                    }
                }
                else
                {
                    ModelState.Clear();
                    ToastrMessage_Error(FileName + " - Invalid File Type");
                    return false;
                }
            }

            return true;
        }

        public bool ValidateVideoFile(HttpPostedFileBase file, Int32 MaxFileSizeInKB, String FileType, String FileName)
        {
            if (file == null || file.ContentLength == 0)
            {
                ToastrMessage_Error(FileName + " - File not found");
                return false;
            }
            else if (file.ContentLength > 0)
            {
                string fileName = file.FileName; // getting File Name
                string fileContentType = file.ContentType; // getting ContentType
                byte[] tempFileBytes = new byte[file.ContentLength]; // getting filebytes
                var data = file.InputStream.Read(tempFileBytes, 0, Convert.ToInt32(file.ContentLength));

                //string _fileExtension = Path.GetExtension(file.FileName);

                String[] _fileExtension = file.FileName.Split('.');

                if (ExtesionCheck(FileType, _fileExtension[_fileExtension.Length - 1]) == false)
                {
                    ToastrMessage_Error(FileName + " - Invalid file type");
                    return false;
                }

                FileUploadCheck.FileType types = new FileUploadCheck.FileType();
                bool result = false;

                if (FileType == Constants.FILE_TYPE_VIDEO)
                {
                    types = FileUploadCheck.FileType.Video;  // Setting Image type
                    result = FileUploadCheck.isValidFile(tempFileBytes, types, fileContentType); // Validate Header
                }

                if (FileType == Constants.FILE_TYPE_IMAGE)
                {

                    types = FileUploadCheck.FileType.Image;  // Setting Image type
                    if (IsImage(file))
                    {
                        result = FileUploadCheck.isValidFile(tempFileBytes, types, fileContentType); // Validate Header
                    }
                    else
                    {
                        result = false;
                    }
                }

                if (FileType == Constants.FILE_TYPE_TXT)
                {
                    types = FileUploadCheck.FileType.Text;  // Setting Image type
                    result = FileUploadCheck.isValidFile(tempFileBytes, types, fileContentType); // Validate Header
                }

                if (FileType == Constants.FILE_TYPE_DOC)
                {
                    types = FileUploadCheck.FileType.DOC;  // Setting Image type
                    result = FileUploadCheck.isValidFile(tempFileBytes, types, fileContentType); // Validate Header
                }

                if (FileType == Constants.FILE_TYPE_DOCX)
                {
                    types = FileUploadCheck.FileType.DOCX;  // Setting Image type
                    result = FileUploadCheck.isValidFile(tempFileBytes, types, fileContentType); // Validate Header
                }

                if (result == true)
                {
                    String[] ext = file.FileName.Split('.');
                    if (ext.Length > 2) //filename[1].ext[2]
                    {
                        ModelState.Clear();
                        ToastrMessage_Error(FileName + " - Multiple file extention not allowed");
                        return false;
                    }

                    if (file.ContentLength > MaxFileSizeInKB)//File size in byte
                    {
                        int FileKB = MaxFileSizeInKB / 1024; //Convert to KB
                        ModelState.Clear();
                        ToastrMessage_Error(FileName + " - Maximum File size is:" + FileKB + "KB");
                        return false;
                    }
                }
                else
                {
                    ModelState.Clear();
                    ToastrMessage_Error(FileName + " - Invalid File Type");
                    return false;
                }
            }

            return true;
        }

        public Boolean ExtesionCheck(String FileType, String Extension)
        {
            Boolean FileExtensionCheck = true;

            if (FileType == "PDF")
            {
                if (Extension.ToUpper() != FileType)
                {
                    FileExtensionCheck = false;
                }
            }
            if (FileType == "IMAGE")
            {
                if (Extension.ToUpper() != "JPG" && Extension.ToUpper() != "JPEG" && Extension.ToUpper() != "PNG")
                {
                    FileExtensionCheck = false;
                }
            }
            if (FileType == "TXT")
            {
                if (Extension.ToUpper() != FileType)
                {
                    FileExtensionCheck = false;
                }
            }
            if (FileType == "DOC")
            {
                if (Extension.ToUpper() != FileType)
                {
                    FileExtensionCheck = false;
                }
            }
            if (FileType == "DOCX")
            {
                if (Extension.ToUpper() != FileType)
                {
                    FileExtensionCheck = false;
                }
            }

            return FileExtensionCheck;
        }

        public bool IsImage(HttpPostedFileBase postedFile)
        {
            try
            {
                using (var bitmap = new System.Drawing.Bitmap(postedFile.InputStream))
                {
                    return !bitmap.Size.IsEmpty;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ValidateImageDimensions(HttpPostedFileBase file, Int32 minImageHeight, Int32 minImageWidth)
        {
            using (System.Drawing.Image myImage = System.Drawing.Image.FromStream(file.InputStream))
            {

                Decimal _height = myImage.Height, _width = myImage.Width;
                Decimal _ratioOriginal = Convert.ToDecimal(minImageHeight) / Convert.ToDecimal(minImageWidth);
                Decimal _ratioUploaded = _height / _width;

                //Decimal _ratio = _height / _width;
                //Decimal _ratioHeight = minImageHeight / _height;
                //Decimal _ratioWidth = minImageWidth / _width;


                if (_height < minImageHeight || _width < minImageWidth)
                {
                    return false;
                }
                //else if ((_ratioHeight > Convert.ToDecimal(Constants.IMAGE_RATIO_MAX) || _ratioHeight < Convert.ToDecimal(Constants.IMAGE_RATIO_MIN))|| (_ratioWidth > Convert.ToDecimal(Constants.IMAGE_RATIO_MAX) || _ratioWidth < Convert.ToDecimal(Constants.IMAGE_RATIO_MIN))) // Image _maxRatio = 1.2, _minRatio = 0.8
                else if ((_ratioUploaded / _ratioOriginal) > Convert.ToDecimal(Constants.IMAGE_RATIO_MAX)|| (_ratioUploaded / _ratioOriginal) < Convert.ToDecimal(Constants.IMAGE_RATIO_MIN)) // Image _maxRatio = 1.2, _minRatio = 0.8
                {
                    return false;
                }
                else
                {
                    return true;
                }
                //return (myImage.Height == 140 && myImage.Width == 140);
            }
        }


    }
}