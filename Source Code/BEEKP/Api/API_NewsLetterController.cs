using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using BEEKP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BEEKP.Api
{
    public class API_NewsLetterController : API_BaseController
    {

        [Route("api/API_NewsLetter/GetNewsLetterMailList/")]
        [HttpGet]
        public HttpResponseMessage GetNewsLetterMailList()
        {
            try
            {
                List<NewsLetterMail> ListNewsLetterMail = new List<NewsLetterMail>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetNewsLetterMailList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            NewsLetterMail objNewsLetterMail = new NewsLetterMail();

                            objNewsLetterMail.news_letter_mail_id = Convert.ToInt32(dr["news_letter_mail_id"]);
                            objNewsLetterMail.mail_to = Convert.ToString(dr["mail_to"]);
                            objNewsLetterMail.mail_cc = Convert.ToString(dr["mail_cc"]);
                            objNewsLetterMail.mail_vcc = Convert.ToString(dr["mail_vcc"]);
                            objNewsLetterMail.subject = Convert.ToString(dr["subject"]);
                            objNewsLetterMail.body = Convert.ToString(dr["body"]);
                            objNewsLetterMail.sent_on = Convert.ToString(dr["sent_on"]);
                            ListNewsLetterMail.Add(objNewsLetterMail);
                        }
                    }
                    return Request.CreateResponse<List<NewsLetterMail>>(HttpStatusCode.OK, ListNewsLetterMail);
                }
                else
                {
                    ErrorMessage objErrorMessage = GetError(Convert.ToString(dtData.Rows[0][Constants.ERROR_COLUMN_ERROR_ID]), Convert.ToString(dtData.Rows[0][Constants.ERROR_COLUMN_ERROR_MESSAGE]), Convert.ToString(dtData.Rows[0][Constants.ERROR_COLUMN_ERROR_TYPE]));
                    return Request.CreateResponse<ErrorMessage>(HttpStatusCode.NotFound, objErrorMessage);
                }

            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = GetError("", Convert.ToString(ex.Message), Constants.ERROR_TYPE_GENERAL);
                return Request.CreateResponse<ErrorMessage>(HttpStatusCode.NotFound, objErrorMessage);
            }
        }

        [Route("api/API_NewsLetter/GetSubscriberList/")]
        [HttpGet]
        public HttpResponseMessage GetSubscriberList()
        {
            try
            {
                List<Subscription> ListSubscription = new List<Subscription>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetSubscriberList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Subscription objSubscription = new Subscription();

                            objSubscription.subscription_id = Convert.ToInt32(dr["subscription_id"]);
                            objSubscription.email_id = Convert.ToString(dr["email_id"]);

                            ListSubscription.Add(objSubscription);
                        }
                    }
                    return Request.CreateResponse<List<Subscription>>(HttpStatusCode.OK, ListSubscription);
                }
                else
                {
                    ErrorMessage objErrorMessage = GetError(Convert.ToString(dtData.Rows[0][Constants.ERROR_COLUMN_ERROR_ID]), Convert.ToString(dtData.Rows[0][Constants.ERROR_COLUMN_ERROR_MESSAGE]), Convert.ToString(dtData.Rows[0][Constants.ERROR_COLUMN_ERROR_TYPE]));
                    return Request.CreateResponse<ErrorMessage>(HttpStatusCode.NotFound, objErrorMessage);
                }

            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = GetError("", Convert.ToString(ex.Message), Constants.ERROR_TYPE_GENERAL);
                return Request.CreateResponse<ErrorMessage>(HttpStatusCode.NotFound, objErrorMessage);
            }
        }
    }
}
