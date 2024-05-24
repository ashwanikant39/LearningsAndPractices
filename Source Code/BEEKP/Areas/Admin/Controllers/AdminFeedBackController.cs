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

namespace BEEKP.Areas.Admin.Controllers
{
    public class AdminFeedBackController : AdminBaseController
    {
        // GET: Admin/AdminFeedBack
        public async Task<ActionResult> Index()
        {
            try
            {
                AdminFeedBackViewModel objAdminFeedBackViewModel = new AdminFeedBackViewModel();
                objAdminFeedBackViewModel.ListFeedBackActive = await GetFeedBackList(Constants.STATUS_ACTIVE);
                objAdminFeedBackViewModel.ListFeedBackInactive = await GetFeedBackList(Constants.STATUS_INACTIVE);
                return View(objAdminFeedBackViewModel);
            }
            catch(Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        public async Task<List<FeedBack>> GetFeedBackList(Int32 _status)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_FeedBack/GetFeedBackList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<FeedBack>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

    }
}