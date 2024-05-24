using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BEEKP.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            AdminLoginViewModel objLoginModel = new AdminLoginViewModel();
            String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
            ViewBag.sitekey = SiteKey;

            return View(objLoginModel);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(AdminLoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    // ViewBag.isError = 1;
                    String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
                    ViewBag.sitekey = SiteKey;
                    model.user_password = String.Empty;
                    ClearSession();
                    return View(model);
                }

                //Session[RPOCS.Class.ApplicationSession.ThemeColour] = "default";

                ViewBag.isError = 0;
                // model.user_password = Convert.ToString(Encryption.DecryptToBase64(model.user_password));

                if (ValidateCaptcha() == false) // validate captcha
                {
                    ModelState.AddModelError("", "reCaptcha validation failed");
                    String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
                    ViewBag.sitekey = SiteKey;
                    //ResetModel(model);
                    return View(model);
                }


                String strUserHostAddress = Request.UserHostAddress;
                String strUserHostName = Request.UserHostName;
             

                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ClientUrl"].ToString());
                HttpResponseMessage response = httpClient.PostAsJsonAsync<AdminLoginViewModel>("api/API_Account/GetLogin/", model).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    LoginDetail objLoginDetail = await response.Content.ReadAsAsync<LoginDetail>();

                    if (objLoginDetail != null)
                    {
                        String _strPassword = Encryption.ComputeSha256Hash(objLoginDetail.password + Session["LoginSaltKey"].ToString());
                        if(_strPassword == model.user_password)
                        {
                            OutputMessage objOutputMessage = new OutputMessage();
                            objOutputMessage = await ManageUserLog(objLoginDetail.user_id, 0, strUserHostName, strUserHostAddress);
                            Session[ApplicationSession.user_log_id] = Convert.ToString(objOutputMessage.MessageId);

                            PopulateSession(objLoginDetail);
                            return RedirectToAction("Index", "Home", new { Area = "Admin" });
                        }
                        else
                        {
                            ViewBag.isError = 1;
                            ModelState.Clear();
                            ModelState.AddModelError("", "Invalid Login Credentials");
                            String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
                            ViewBag.sitekey = SiteKey;
                            model.user_password = String.Empty;
                            return View(model);
                        }

                       
                    }
                    else
                    {
                        ViewBag.isError = 1;
                        ModelState.Clear();
                        String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
                        ViewBag.sitekey = SiteKey;
                        ModelState.AddModelError("", "Invalid Login Credentials");
                        // ViewBag.sitekey = System.Configuration.ConfigurationManager.AppSettings["SiteKey"].ToString();
                        model.user_password = String.Empty;
                        return View(model);
                    }

                }
                else
                {
                    ErrorMessage objErrorMessage = await response.Content.ReadAsAsync<ErrorMessage>();
                    ViewBag.isError = 1;
                    ModelState.Clear();
                    ModelState.AddModelError("", objErrorMessage.ErrorMessages);
                    String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
                    ViewBag.sitekey = SiteKey;
                    //ViewBag.sitekey = System.Configuration.ConfigurationManager.AppSettings["SiteKey"].ToString();
                    model.user_password = String.Empty;
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                ViewBag.isError = 1;
                String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
                ViewBag.sitekey = SiteKey;
                ModelState.Clear();
                ModelState.AddModelError("",Convert.ToString(ex.Message));
                // ViewBag.sitekey = System.Configuration.ConfigurationManager.AppSettings["SiteKey"].ToString();
                model.user_password = String.Empty;
                return View(model);
            }
        }

        [OutputCache(NoStore = true, Duration = 0)]
        [AllowAnonymous]
        public async Task<ActionResult> Logout()
        {
            OutputMessage objOutputMessage = await ManageUserLog(Convert.ToInt32(Session[ApplicationSession.user_id]), Convert.ToInt32(Session[ApplicationSession.user_log_id]),"","");
            RemoveAllCookie();
            ClearSession();
            String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
            ViewBag.sitekey = SiteKey;
            return RedirectToAction("Login", "Account");
        }


        [AllowAnonymous]
        public async Task<ActionResult> Registration()
        {
            RegistrationViewModel objRegistrationViewModel = new RegistrationViewModel();
            objRegistrationViewModel.ListState = await GetStateList();
            objRegistrationViewModel.ListState.Insert(0, new State() { state_id = 0, state_name = "--Select--" });
            return View(objRegistrationViewModel);
        }

        [AllowAnonymous]
        public async Task<ActionResult> ForgotPassword()
        {
            //AdminLoginViewModel objLoginModel = new AdminLoginViewModel();
            ForgetPasswordViewModel objForgetPasswordViewModel = new ForgetPasswordViewModel();
            String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
            ViewBag.sitekey = SiteKey;

            return View(objForgetPasswordViewModel);
        }

        [AllowAnonymous]
        public async Task<ActionResult> ResetPassword()
        {
            //AdminLoginViewModel objLoginModel = new AdminLoginViewModel();
            ResetPasswordViewModel objResetPasswordViewModel = new ResetPasswordViewModel();
            String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
            ViewBag.sitekey = SiteKey;

            return View(objResetPasswordViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
           try
            {
                if(ModelState.IsValid == false)
                {
                    return View(model);
                }
                if (ValidateCaptcha() == false) // validate captcha
                {
                    ModelState.AddModelError("", "reCaptcha validation failed");
                    String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
                    ViewBag.sitekey = SiteKey;
                    //ResetModel(model);
                    return View(model);
                }
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ClientUrl"].ToString());
                HttpResponseMessage response = httpClient.PostAsJsonAsync<ResetPasswordViewModel>("api/API_Account/SaveUserResetPassword/", model).Result;
                
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    ViewBag.MessageId = objOutputMessage.MessageId;
                    ViewBag.Message = objOutputMessage.Message;
                    if (objOutputMessage.MessageId > 0)
                    {
                        SendAcknowledgementMail(model);
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("", "Invalid Login Credentials");
                        String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
                        ViewBag.sitekey = SiteKey;
                        return View(model);
                    }
                   
                }

                return View(model);

            }
            catch(Exception ex)
            {
                String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
                ViewBag.sitekey = SiteKey;
                ModelState.Clear();
                ModelState.AddModelError("", Convert.ToString(ex.Message));
                return View(model);
            }

            
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgetPasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }
                if (ValidateCaptcha() == false) // validate captcha
                {
                    ModelState.AddModelError("", "reCaptcha validation failed");
                    String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
                    ViewBag.sitekey = SiteKey;
                    //ResetModel(model);
                    return View(model);
                }
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ClientUrl"].ToString());
                HttpResponseMessage response = httpClient.PostAsJsonAsync<ForgetPasswordViewModel>("api/API_Account/GetForgotPasswordOTP/", model).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    ForgetPasswordOTP objForgetPasswordOTP = await response.Content.ReadAsAsync<ForgetPasswordOTP>();

                    if (objForgetPasswordOTP != null && objForgetPasswordOTP.MessageID != 0)
                    {

                        SendMail(objForgetPasswordOTP);

                    }

                }
                return RedirectToAction("ResetPassword", "Account", new { });

            }
            catch (Exception ex)
            {
                String SiteKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-sitekey"].ToString();
                ViewBag.sitekey = SiteKey;
                ModelState.Clear();
                ModelState.AddModelError("", Convert.ToString(ex.Message));
                return View(model);
            }
        }

        public void ResetModel(AdminLoginViewModel model)
        {
            //ModelState.Clear();
            ViewBag.isError = 1;
            ViewBag.sitekey = System.Configuration.ConfigurationManager.AppSettings["SiteKey"].ToString();//for Captcha
            //model.Key = GetKey();//generate unique key
            Session["LoginSaltKey"] = "";
            model.user_password = String.Empty;
            ClearSession();
        }


        public void SendMail(ForgetPasswordOTP objForgetPasswordOTP)
        {
            try {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["System_Email_ID"].ToString(), "BEE Knowledge Portal"); //From Email Id  
                mailMessage.To.Add(new MailAddress(objForgetPasswordOTP.email_id)); //adding multiple TO Email Id  
                mailMessage.Subject = "OTP form BEE Knowledge Portal"; //Subject of Email  

                String mailBody = "<html><body>";
                mailBody = mailBody + "Dear User," + "<br/><br/>";
                mailBody = mailBody + "Your OTP is: " + "<b>" + objForgetPasswordOTP.OTP + "</b>" + "<br/><br/>";
                mailBody = mailBody + "The provided OTP is valid for 15 minutes to reset your password for BEE Knowledge Portal." + " <br/><br/>";

                mailBody = mailBody + "Regards," + "<br/><br/>";
                mailBody = mailBody + "BEE Knowledge Portal" + "<br/><br/>";
                mailBody = mailBody + "Note: This is a system generated mail.Please do not reply." + "<br/><br/>";
                mailBody = mailBody + "</html></body>";


                mailMessage.Body = WebUtility.HtmlDecode(mailBody);  //body or message of Email  
                mailMessage.IsBodyHtml = true;




                SmtpClient smtp = new SmtpClient();  // creating object of smptpclient  
                smtp.Host = System.Configuration.ConfigurationManager.AppSettings["System_Email_SMTP_Server"].ToString();   //host of emailaddress for example smtp.gmail.com etc  

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
            catch(Exception ex)
            {
                ModelState.Clear();
                ModelState.AddModelError("", Convert.ToString(ex.Message));
            }
            
        }

        public void SendAcknowledgementMail(ResetPasswordViewModel objResetPasswordViewModel)
        {

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["System_Email_ID"].ToString(), "BEE Knowledge Portal"); //From Email Id  
            mailMessage.To.Add(new MailAddress(objResetPasswordViewModel.email_id)); //adding multiple TO Email Id  
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

        public void ClearSession()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            HttpCookie cookie_ASPNET_SessionId = Request.Cookies["ASP.NET_SessionId"];

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Request.Cookies.Remove(cookie_ASPNET_SessionId.Name);
                Response.Cookies.Remove(cookie_ASPNET_SessionId.Name);

            }
            cookie_ASPNET_SessionId = new HttpCookie("ASP.NET_SessionId") { HttpOnly = true };
            cookie_ASPNET_SessionId.Value = Convert.ToString(Guid.NewGuid());
            cookie_ASPNET_SessionId.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(cookie_ASPNET_SessionId);

        }

        public bool ValidateCaptcha()
        {
                return true;
            var response_capcha = Request["g-recaptcha-response"];
            String SecretKey = System.Configuration.ConfigurationManager.AppSettings["GoogleReCapcha-BEEKP-SecretKey"].ToString();
            var clientCapcha = new WebClient();
            var resultCapcha = clientCapcha.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", SecretKey, response_capcha));


            if (resultCapcha.ToLower().Contains("false"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void PopulateSession(LoginDetail objLoginDetail)
        {
            Session["AntiFixationCookie"] = Guid.NewGuid();
            HttpCookie cookie = new HttpCookie("AntiFixationCookie") { HttpOnly = true };
            cookie.Value = Convert.ToString(Session["AntiFixationCookie"]);
            cookie.Expires = DateTime.Now.AddDays(7);
            // cookie.Secure = true;
            Response.Cookies.Add(cookie);
            Session[ApplicationSession.user_id] = Convert.ToString(objLoginDetail.user_id);
            Session[ApplicationSession.user_type_id] = objLoginDetail.user_type_id;
            Session[ApplicationSession.role_id] = objLoginDetail.role_id;
            Session[ApplicationSession.email_id] = Convert.ToString(objLoginDetail.email_id);
            Session[ApplicationSession.first_name] = Convert.ToString(objLoginDetail.first_name);

        }

        public void RemoveAllCookie()
        {
            string[] allCookies = Request.Cookies.AllKeys;
            foreach (string cookie in allCookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
        }


        public async Task<OutputMessage> ManageUserLog(Int32 user_id, Int32 user_log_id, String mac_address, String ip_address)
        {

            string ip = HttpContext.Request.UserHostAddress;
            UserLog objUserLog = new UserLog();
            objUserLog.user_log_id = user_log_id;
            objUserLog.user_id = user_id;
            objUserLog.mac_address = mac_address;
            objUserLog.ip_address = ip_address;


            OutputMessage objOutputMessage = new OutputMessage();
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ClientUrl"].ToString());

            HttpResponseMessage response = httpClient.PostAsJsonAsync<UserLog>("api/API_Base/SaveUserLog/", objUserLog).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
            }
            return objOutputMessage;
        }

        public async Task<List<State>> GetStateList()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ClientUrl"].ToString());
            HttpResponseMessage response = httpClient.GetAsync("api/API_Base/GetStateList/").Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<State>>());
            }
            else
            {
                return new List<State>();
            }
        }

        [HttpGet]
        public String GetKey()
        {
            String strKey = Encryption.ConvertStringtoMD5(Encryption.RandomString());
           // String strKey = Encryption.RandomString();
            Session["LoginSaltKey"] = strKey;
            return strKey;
        }
    }

}