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
    public class API_CaseStudyController : API_BaseController
    {
        [Route("api/API_CaseStudy/GetCaseStudyList/")]
        [HttpPost]
        public HttpResponseMessage GetCaseStudyList(List<String> _ListParameter)

        {
            try
            {
                List<CaseStudy> ListCaseStudy = new List<CaseStudy>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("cluster_id", Convert.ToString(_ListParameter[0]));

                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetCaseStudyList", xml.GetXML("casestudy"));
                
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            CaseStudy objCaseStudy = new CaseStudy();

                            objCaseStudy.casestudy_id = Convert.ToInt32(dr["casestudy_id"]);
                            objCaseStudy.cluster_id = Convert.ToInt32(dr["cluster_id"]);
                            objCaseStudy.cluster_name = Convert.ToString(dr["cluster_name"]);
                            objCaseStudy.ee_keywords = Convert.ToString(dr["ee_keywords"]);
                            objCaseStudy.file_name = Convert.ToString(dr["file_name"]);
                            ListCaseStudy.Add(objCaseStudy);
                        }
                    }
                    return Request.CreateResponse<List<CaseStudy>>(HttpStatusCode.OK, ListCaseStudy);
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

        [Route("api/API_CaseStudy/SaveCaseStudy/")]
        [HttpPost]
        public HttpResponseMessage SaveCaseStudy(CaseStudyManageModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("casestudy_id", Convert.ToString(model.CaseStudy.casestudy_id));
                xml.AddElement("cluster_id", Convert.ToString(model.CaseStudy.cluster_id));
                xml.AddElement("cluster_name", Convert.ToString(model.CaseStudy.cluster_name));
                xml.AddElement("ee_keywords", Convert.ToString(model.CaseStudy.ee_keywords));
                xml.AddElement("file_name", Convert.ToString(model.CaseStudy.file_name));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveCaseStudy", xml.GetXML("casestudy"));
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

        [Route("api/API_CaseStudy/GetCaseStudyById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetCaseStudyById(Int32 id)
        {
            try
            {
                CaseStudy objCaseStudy = new CaseStudy();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("casestudy_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("GetCaseStudyById", xml.GetXML("casestudy"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objCaseStudy.casestudy_id = Convert.ToInt32(dtData.Rows[0]["casestudy_id"]);
                        objCaseStudy.cluster_id = Convert.ToInt32(dtData.Rows[0]["cluster_id"]);
                        objCaseStudy.cluster_name = Convert.ToString(dtData.Rows[0]["cluster_name"]);
                        objCaseStudy.ee_keywords = Convert.ToString(dtData.Rows[0]["ee_keywords"]);
                        objCaseStudy.file_name = Convert.ToString(dtData.Rows[0]["file_name"]);
                    }

                    return Request.CreateResponse<CaseStudy>(HttpStatusCode.OK, objCaseStudy);
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

        [Route("api/API_CaseStudy/DeleteCaseStudy/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteCaseStudy(Int32 id)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("casestudy_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteCaseStudy", xml.GetXML("casestudy"));
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
