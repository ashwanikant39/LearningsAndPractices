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
using System.Web.Routing;

namespace BEEKP.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (Session[ApplicationSession.user_id] != null)
        //    {

        //        HttpCookie cookie = filterContext.HttpContext.Request.Cookies["AntiFixationCookie"];

        //        //HttpCookie cookie_ASPNET_SessionId = filterContext.HttpContext.Request.Cookies["ASP.NET_SessionId"];


        //        //if (cookie_ASPNET_SessionId != null)
        //        //{
        //        //    filterContext.HttpContext.Request.Cookies.Remove(cookie_ASPNET_SessionId.Name);
        //        //}

        //        //cookie_ASPNET_SessionId = new HttpCookie("ASP.NET_SessionId");
        //        //cookie_ASPNET_SessionId.Value = Convert.ToString(Guid.NewGuid());
        //        //cookie_ASPNET_SessionId.Expires = DateTime.Now.AddDays(7);
        //        ////filterContext.HttpContext.Request.Cookies.Add(cookie);
        //        //Response.Cookies.Add(cookie_ASPNET_SessionId);



        //        if (cookie.Value != null && cookie.Value == Session["AntiFixationCookie"].ToString())
        //        {
        //            filterContext.HttpContext.Request.Cookies.Remove(cookie.Name);
        //            Session["AntiFixationCookie"] = Guid.NewGuid();
        //            cookie = new HttpCookie("AntiFixationCookie") { HttpOnly = true };
        //            cookie.Value = Convert.ToString(Session["AntiFixationCookie"]);
        //            cookie.Expires = DateTime.Now.AddDays(7);
        //            //filterContext.HttpContext.Request.Cookies.Add(cookie);
        //            Response.Cookies.Add(cookie);

        //            base.OnActionExecuting(filterContext);
        //        }
        //        else
        //        {

        //            if (filterContext.HttpContext.Request.IsAjaxRequest())
        //            {
        //                filterContext.Result = new JsonResult { Data = Constants.AJAX_SESSIONOUT };
        //            }
        //            else
        //            {
        //                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
        //                {
        //                    controller = "Account",
        //                    action = "Login"
        //                }));
        //            }
        //        }


        //    }
        //    else
        //    {
        //        if (filterContext.HttpContext.Request.IsAjaxRequest())
        //        {
        //            filterContext.Result = new JsonResult { Data = Constants.AJAX_SESSIONOUT };
        //        }
        //        else
        //        {
        //            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
        //            {
        //                controller = "Account",
        //                action = "Login"
        //            }));
        //        }
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

        public async Task<List<AreaSpecialization>> GetAreaSpecializationsList()
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
    }
}