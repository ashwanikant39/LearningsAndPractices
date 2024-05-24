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
    public class API_FinancingSchemeController : API_BaseController
    {
        [Route("api/API_FinancingScheme/GetFinancingSchemeList/")]
        [HttpPost]
        public HttpResponseMessage GetFinancingSchemeList(List<String> _ListParameter)
        {

            try
            {
                List<FinancingScheme> ListFinancingScheme = new List<FinancingScheme>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                xml.AddElement("financing_scheme_category_id", Convert.ToString(_ListParameter[1]));



                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetFinancingSchemeList", xml.GetXML("financing_scheme"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            FinancingScheme objFinancingScheme = new FinancingScheme();
                            objFinancingScheme.financing_scheme_id = Convert.ToInt32(dr["financing_scheme_id"]);
                            objFinancingScheme.financing_scheme_name = Convert.ToString(dr["financing_scheme_name"]);
                            objFinancingScheme.financing_scheme_category_id = Convert.ToInt32(dr["financing_scheme_category_id"]);
                            objFinancingScheme.financing_scheme_category_name = Convert.ToString(dr["financing_scheme_category_name"]);
                            objFinancingScheme.financing_scheme_details = Convert.ToString(dr["financing_scheme_details"]);
                            objFinancingScheme.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;

                            ListFinancingScheme.Add(objFinancingScheme);
                        }
                    }
                    return Request.CreateResponse<List<FinancingScheme>>(HttpStatusCode.OK, ListFinancingScheme);
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

        [Route("api/API_FinancingScheme/SaveFinancingScheme")]
        [HttpPost]
        public HttpResponseMessage SaveFinancingScheme(FinancingSchemeManageModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.FinancingScheme.status == true ? 1 : 0;
                xml.AddElement("financing_scheme_id", Convert.ToString(model.FinancingScheme.financing_scheme_id));
                xml.AddElement("financing_scheme_category_id", Convert.ToString(model.FinancingScheme.financing_scheme_category_id));
                xml.AddElement("financing_scheme_name", Convert.ToString(model.FinancingScheme.financing_scheme_name));
                xml.AddElement("financing_scheme_category_name", Convert.ToString(model.FinancingScheme.financing_scheme_category_name));
                xml.AddElement("financing_scheme_details", Convert.ToString(model.FinancingScheme.financing_scheme_details));
                xml.AddElement("status", Convert.ToString(status));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveFinancingScheme", xml.GetXML("financing_scheme"));
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

        [Route("api/API_FinancingScheme/GetFinancingSchemeById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetFinancingSchemeById(Int32 id)
        {
            try
            {
                FinancingScheme objFinancingScheme = new FinancingScheme();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("financing_scheme_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("GetFinancingSchemeById", xml.GetXML("financing_scheme"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objFinancingScheme.financing_scheme_id = Convert.ToInt32(dtData.Rows[0]["financing_scheme_id"]);
                        objFinancingScheme.financing_scheme_name = Convert.ToString(dtData.Rows[0]["financing_scheme_name"].ToString());
                        objFinancingScheme.financing_scheme_category_id = Convert.ToInt32(dtData.Rows[0]["financing_scheme_category_id"]);
                        objFinancingScheme.financing_scheme_category_name = Convert.ToString(dtData.Rows[0]["financing_scheme_category_name"]);
                        objFinancingScheme.financing_scheme_details = Convert.ToString(dtData.Rows[0]["financing_scheme_details"]);
                        objFinancingScheme.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;

                    }

                    return Request.CreateResponse<FinancingScheme>(HttpStatusCode.OK, objFinancingScheme);
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

        [Route("api/API_FinancingScheme/DeleteFinancingScheme/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteFinancingScheme(Int32 id)
        {
            try
            {
                FinancingScheme objFinancingScheme = new FinancingScheme();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("financing_scheme_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteFinancingScheme", xml.GetXML("financing_scheme"));
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
