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
    public class UsefulLinkController : BaseController
    {
        // GET: UsefulLink
        public ActionResult Sitemap()
        {
            return View();
        }
        public ActionResult Policy()
        {
            return View();
        }
        public ActionResult Term_Condition()
        {
            return View();
        }
      
        public async Task<ActionResult> Feedback()
        {
            FeedbackViewModel objFeedbackViewModel = new FeedbackViewModel();
            return View(objFeedbackViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Feedback(FeedbackViewModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }
                model.user_id = "1"; //for admin-user_id
                model.FeedBack.status = 0;//for status Inactive
                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<FeedbackViewModel>("api/API_FeedBack/SaveFeedBack/", model).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "Home"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Feedback", "UsefulLink"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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
    }
}