using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BEEKP.Areas.Admin.Controllers;
using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using BEEKP.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BEEKP.Controllers
{
    public class NewsController : BaseController
    {
        // GET: News
        public async Task<ActionResult> Index()
        {
            List<News> list = await GetNewsMedia(Constants.STATUS_ACTIVE, Constants.NEWS_PERIOD_ALL, Constants.NEWS_COUNT_ALL);

            return View(list);
        }

        public async Task<List<News>> GetNewsMedia(Int32 _status, String _news_period, Int32 _news_count)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_news_period.ToString());
            ListParameter.Add(_news_count.ToString());


            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_News/GetNewsList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<News>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
    }
}