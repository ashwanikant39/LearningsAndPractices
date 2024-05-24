using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using BEEKP.Models;
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
    public class FAQController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                FAQViewModel ObjFAQViewModel = new FAQViewModel();
                ObjFAQViewModel.ListFAQ = await GetFAQList(Constants.STATUS_ACTIVE);
                return View(ObjFAQViewModel);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<FAQ>> GetFAQList(Int32 _status)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_FAQ/GetFAQList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<FAQ>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
    }
}