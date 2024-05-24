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

namespace BEEKP.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        public async Task<ActionResult> Index()
        {
            List<Announcement> list = await GetUpdatesAnnouncements();
            return View(list);
        }
        public async Task<List<Announcement>> GetUpdatesAnnouncements()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Announcement/GetAnnouncementList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Announcement>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public HttpClient GenerateHttpClient()
        {
            HttpClient _HttpClient = new HttpClient();
            _HttpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ClientUrl"].ToString());
            _HttpClient.DefaultRequestHeaders.Accept.Clear();
            return _HttpClient;
        }
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
    }
}