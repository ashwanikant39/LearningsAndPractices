using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Areas.Admin.Controllers
{
    public class ChangePasswordController : AdminBaseController
    {
        public async Task<ActionResult> Index()
        {
            try
            {

                return View();
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
        public async Task<ActionResult> Index(ChangePasswordViewModel model)
        {
            model.ChangePassword.old_password = Encryption.DecryptStringAES(model.ChangePassword.old_password.Substring(0, model.ChangePassword.old_password.Length - 1));
            model.ChangePassword.new_password = Encryption.DecryptStringAES(model.ChangePassword.new_password.Substring(0, model.ChangePassword.new_password.Length - 1));
            model.ChangePassword.confirm_password = Encryption.DecryptStringAES(model.ChangePassword.confirm_password.Substring(0, model.ChangePassword.confirm_password.Length - 1));

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            String strErrorMessage = "";

            if(!ValidatePassword(model.ChangePassword.new_password, out strErrorMessage))
            {
               
                ViewBag.isError = 1;
                ModelState.Clear();
                ModelState.AddModelError("ChangePassword.new_password", strErrorMessage);
                return View(model);
            }

            if (model.ChangePassword.new_password != model.ChangePassword.confirm_password)
            {
                //ToastrMessage_Error("Password does not matches");
                ViewBag.isError = 1;
                ModelState.Clear();
                ModelState.AddModelError("", "Invalid Confirm Password");
                // ViewBag.sitekey = System.Configuration.ConfigurationManager.AppSettings["SiteKey"].ToString();

                return View(model);
            }

            if (model.ChangePassword.new_password == model.ChangePassword.old_password)
            {
                //ToastrMessage_Error("Password does not matches");
                ViewBag.isError = 1;
                ModelState.Clear();
                ModelState.AddModelError("ChangePassword.new_password", "New password has to be different from old password");
                // ViewBag.sitekey = System.Configuration.ConfigurationManager.AppSettings["SiteKey"].ToString();

                return View(model);
            }


            AdminLoginViewModel objAdminLoginViewModel = new AdminLoginViewModel();
            objAdminLoginViewModel.email_id = Convert.ToString(Session[ApplicationSession.email_id]);
            objAdminLoginViewModel.user_password = model.ChangePassword.old_password;

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ClientUrl"].ToString());
            HttpResponseMessage response = httpClient.PostAsJsonAsync<AdminLoginViewModel>("api/API_Account/GetLogin/", objAdminLoginViewModel).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                LoginDetail objLoginDetail = await response.Content.ReadAsAsync<LoginDetail>();

                if (objLoginDetail != null && objLoginDetail.password == objAdminLoginViewModel.user_password)
                {
                    model.user_id = Convert.ToInt32(Session[ApplicationSession.user_id]);

                    httpClient = GenerateHttpClient();
                    response = httpClient.PostAsJsonAsync<ChangePasswordViewModel>("api/API_Base/UpdatePassword/", model).Result;
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                        if (objOutputMessage.MessageId > 0)
                            {
                            SendAcknowledgementMail();
                            ToastrMessage_Success(objOutputMessage.Message);
                            return RedirectToAction("Index", "Home"/*, new { sevent_id = model.Event.event_id }*/);
                        }
                        else
                        {
                            ToastrMessage_Error(objOutputMessage.Message);
                            return RedirectToAction("Index", "ChangePassword"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
                        }

                    }
                    else
                    {
                        ErrorMessage _ErrorMessage = await CheckResponse(response);
                        throw new Exception(_ErrorMessage.ErrorMessages);
                    }

                }
                else
                {
                    ViewBag.isError = 1;
                    ModelState.Clear();
                    ModelState.AddModelError("", "Invalid Login Credentials");
                    // ViewBag.sitekey = System.Configuration.ConfigurationManager.AppSettings["SiteKey"].ToString();

                    return View(model);
                }

            }
            return View(model);
        }

        private bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

           

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[@#$%]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one upper case letter";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should greater than 6 characters and less then 15 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one special case characters";
                return false;
            }
            else
            {
                return true;
            }
        }
        public void SendAcknowledgementMail()
        {

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["System_Email_ID"].ToString(), "BEE Knowledge Portal"); //From Email Id  
            mailMessage.To.Add(new MailAddress(Convert.ToString(Session[ApplicationSession.email_id]))); //adding multiple TO Email Id  
            mailMessage.Subject = "Password chnaged for BEE Knowledge Portal"; //Subject of Email  

            String mailBody = "<html><body>";
            mailBody = mailBody + "Dear User," + "<br/><br/>";
            mailBody = mailBody + "Your Password has been changed successfully" + " <br/><br/>";

            mailBody = mailBody + "Regards," + "<br/><br/>";
            mailBody = mailBody + "BEE Knowledge Portal" + "<br/><br/>";
            mailBody = mailBody + "Note: This is a system generated mail.Please do not reply." + "<br/><br/>";
            mailBody = mailBody + "</html></body>";

            mailMessage.Body = WebUtility.HtmlDecode(mailBody);  //body or message of Email  
            mailMessage.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();  // creating object of smptpclient  
            smtp.Host = System.Configuration.ConfigurationManager.AppSettings["System_Email_SMTP_Server"].ToString();              //host of emailaddress for example smtp.gmail.com etc  

            //network and security related credentials  

            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = System.Configuration.ConfigurationManager.AppSettings["System_Email_ID"].ToString();
            NetworkCred.Password = System.Configuration.ConfigurationManager.AppSettings["System_Email_Password"].ToString();
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["System_Email_SMTP_Port"].ToString());
            smtp.Send(mailMessage); //sending Email  
        }
    }
}