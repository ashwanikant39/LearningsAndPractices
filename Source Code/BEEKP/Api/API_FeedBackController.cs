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
    public class API_FeedBackController : API_BaseController
    {
        [Route("api/API_FeedBack/SaveFeedBack/")]
        [HttpPost]
        public HttpResponseMessage SaveFeedBack(FeedbackViewModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("feedback_id", Convert.ToString(model.FeedBack.feedback_id));
                xml.AddElement("name_user", Convert.ToString(model.FeedBack.name_user));
                xml.AddElement("email_id", Convert.ToString(model.FeedBack.email_id));
                xml.AddElement("contact_no", Convert.ToString(model.FeedBack.contact_no));
                xml.AddElement("feedback_message", Convert.ToString(model.FeedBack.feedback_message));
                xml.AddElement("status", Convert.ToString(model.FeedBack.status));
                xml.AddElement("user_id", Convert.ToString(model.user_id));

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveFeedBack", xml.GetXML("feedback"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    OutputMessage objOutputMessage = new OutputMessage();
                    objOutputMessage.MessageId = Convert.ToInt32(dtData.Rows[0]["MessageID"]);
                    objOutputMessage.Message = Convert.ToString(dtData.Rows[0]["MessageDesc"]);

                    return Request.CreateResponse<OutputMessage>(HttpStatusCode.OK, objOutputMessage);
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


        [Route("api/API_FeedBack/GetFeedBackList/")]
        [HttpPost]
        public HttpResponseMessage GetFeedBackList(List<String> _ListParameter)
        {

            try
            {
                List<FeedBack> ListFeedBack = new List<FeedBack>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));



                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetFeedBackList", xml.GetXML("feedback"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            FeedBack objFeedBack = new FeedBack();

                            objFeedBack.feedback_id = Convert.ToInt32(dr["feedback_id"]);
                            objFeedBack.name_user = Convert.ToString(dr["name_user"]);
                            objFeedBack.email_id = Convert.ToString(dr["email_id"]);
                            objFeedBack.contact_no = Convert.ToString(dr["contact_no"]);
                            objFeedBack.feedback_message = Convert.ToString(dr["feedback_message"]);
                            ListFeedBack.Add(objFeedBack);
                        }
                    }
                    return Request.CreateResponse<List<FeedBack>>(HttpStatusCode.OK, ListFeedBack);
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
