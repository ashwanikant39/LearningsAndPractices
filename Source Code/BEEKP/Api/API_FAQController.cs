using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BEEKP.Api
{
    public class API_FAQController : API_BaseController
    {
        [Route("api/API_FAQ/GetFAQList/")]
        [HttpPost]
        public HttpResponseMessage GetFAQList(List<String> _ListParameter)
        {

            try
            {
                List<FAQ> ListFAQ = new List<FAQ>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetFAQList", xml.GetXML("faq"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            FAQ objFAQ = new FAQ();
                            objFAQ.FAQ_id = Convert.ToInt32(dr["FAQ_id"]);
                            objFAQ.category_id = Convert.ToInt32(dr["category_id"]);
                            objFAQ.cluster_id = Convert.ToInt32(dr["cluster_id"]);
                            objFAQ.cluster_name = Convert.ToString(dr["cluster_name"]);
                            objFAQ.category_name = Convert.ToString(dr["category_name"]);
                            objFAQ.FAQ_question = Convert.ToString(dr["FAQ_question"]);
                            objFAQ.FAQ_answer = Convert.ToString(dr["FAQ_answer"]);
                            objFAQ.remarks = dr["remarks"] != DBNull.Value ? Convert.ToString(dr["remarks"].ToString()) : "";
                            objFAQ.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;

                            ListFAQ.Add(objFAQ);
                        }
                    }
                    return Request.CreateResponse<List<FAQ>>(HttpStatusCode.OK, ListFAQ);
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

        [Route("api/API_FAQ/SaveFAQ/")]
        [HttpPost]
        public HttpResponseMessage SaveFAQ(FAQManageModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.FAQ.status == true ? 1 : 0;
                xml.AddElement("FAQ_id", Convert.ToString(model.FAQ.FAQ_id));
                xml.AddElement("category_id", Convert.ToString(model.FAQ.category_id));
                xml.AddElement("cluster_id", Convert.ToString(model.FAQ.cluster_id));
                xml.AddElement("category_name", Convert.ToString(model.FAQ.category_name));
                xml.AddElement("FAQ_question", Convert.ToString(model.FAQ.FAQ_question));
                xml.AddElement("FAQ_answer", Convert.ToString(model.FAQ.FAQ_answer));
                xml.AddElement("remarks", Convert.ToString(model.FAQ.remarks));
                xml.AddElement("status", Convert.ToString(status));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveFAQ", xml.GetXML("faq"));
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

        [Route("api/API_FAQ/GetFAQById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetFAQById(Int32 id)
        {
            try
            {
                FAQ objFAQ = new FAQ();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("FAQ_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("GetFAQById", xml.GetXML("faq"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objFAQ.FAQ_id = Convert.ToInt32(dtData.Rows[0]["FAQ_id"]);
                        objFAQ.category_name = Convert.ToString(dtData.Rows[0]["category_name"].ToString());
                        objFAQ.category_id = Convert.ToInt32(dtData.Rows[0]["category_id"]);
                        objFAQ.cluster_id = Convert.ToInt32(dtData.Rows[0]["cluster_id"]);
                        objFAQ.cluster_name = Convert.ToString(dtData.Rows[0]["cluster_name"]);
                        objFAQ.FAQ_question = Convert.ToString(dtData.Rows[0]["FAQ_question"]);
                        objFAQ.FAQ_answer = Convert.ToString(dtData.Rows[0]["FAQ_answer"]);
                        objFAQ.remarks = Convert.ToString(dtData.Rows[0]["remarks"]);
                        objFAQ.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;

                    }

                    return Request.CreateResponse<FAQ>(HttpStatusCode.OK, objFAQ);
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

        [Route("api/API_FAQ/DeleteFAQ/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteFAQ(Int32 id)
        {
            try
            {
                FAQ objFAQ = new FAQ();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("FAQ_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteFAQ", xml.GetXML("faq"));
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

     


    }
}
