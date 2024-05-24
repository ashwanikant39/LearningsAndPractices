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
    public class HomeGalleryController : BaseController
    {
        // GET: HomeGallery
        public async Task<ActionResult> Index()
        {
            HomeGalleryViewModel objHomeGalleryViewModel = new HomeGalleryViewModel();
            objHomeGalleryViewModel.ListPhoto = await GetPhotoGalleryList(Class.Constants.STATUS_ACTIVE);
            objHomeGalleryViewModel.ListVideo = await GetVideoGalleryList(Class.Constants.STATUS_ACTIVE);
            return View(objHomeGalleryViewModel);
        }

        public async Task<List<Photo>> GetPhotoGalleryList(Int32 _status)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());



            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Gallery/GetPhotoGalleryList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Photo>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<List<Video>> GetVideoGalleryList(Int32 _status)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());



            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Gallery/GetVideoGalleryList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Video>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

      
    }
}