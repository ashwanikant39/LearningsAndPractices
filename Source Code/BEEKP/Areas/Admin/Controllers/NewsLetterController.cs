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

namespace BEEKP.Areas.Admin.Controllers
{
    public class NewsLetterController : AdminBaseController
    {
        // GET: Admin/NewsLetter
        public async Task<ActionResult> Index()
        {
            NewsLetterViewModel objNewsLetterViewModel = new NewsLetterViewModel();
            objNewsLetterViewModel.ListNewsLetterMail = await GetNewsLetterMailList();
            return View(objNewsLetterViewModel);
        }
        public async Task<List<NewsLetterMail>> GetNewsLetterMailList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_NewsLetter/GetNewsLetterMailList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<NewsLetterMail>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ActionResult> ManageNewsLetter(String snews_letter_mail_id)
        {
            Int32 isector_id = Convert.ToInt32(Encryption.Decrypt(snews_letter_mail_id, true));
            NewsletterManageModel objNewsletterManageModel = new NewsletterManageModel();
            if (isector_id == 0)
            {
                objNewsletterManageModel.NewsLetterMail = new NewsLetterMail();
                List<Subscription> ListSubscription = await GetSubscriberList();
                foreach (Subscription objSubscription in ListSubscription)
                {
                    AdminSubscription objAdminSubscription = new AdminSubscription();
                    objAdminSubscription.email_id = objSubscription.email_id;
                    objAdminSubscription.is_checked =false;
                    objNewsletterManageModel.ListAdminSubscription.Add(objAdminSubscription);
                }

            }
            return View(objNewsletterManageModel);


        }
        [HttpPost]
        [ValidateInput(false)] // for ckeditor
        public async Task<ActionResult> ManageNewsLetter(NewsletterManageModel model)
        {
            //NewsletterManageModel objNewsletterManageModel = new NewsletterManageModel();
            //if (isector_id == 0)
            //{
            //    objNewsletterManageModel.NewsLetterMail = new NewsLetterMail();
            //    List<Subscription> ListSubscription = await GetSubscriberList();
            //    foreach (Subscription objSubscription in ListSubscription)
            //    {
            //        AdminSubscription objAdminSubscription = new AdminSubscription();
            //        objAdminSubscription.email_id = objSubscription.email_id;
            //        objAdminSubscription.is_checked = false;
            //        objNewsletterManageModel.ListAdminSubscription.Add(objAdminSubscription);
            //    }

            //}
            //return View(objNewsletterManageModel);
            return null;

        }

        public async Task<List<Subscription>> GetSubscriberList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_NewsLetter/GetSubscriberList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Subscription>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
    }
}