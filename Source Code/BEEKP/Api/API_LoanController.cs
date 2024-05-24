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
    public class API_LoanController : API_BaseController
    {
        [Route("api/API_Loan/GetLoanSchemeList/")]
        [HttpPost]
        public HttpResponseMessage GetLoanSchemeList(List<String> _ListParameter)
        {
            try
            {
                List<LoanScheme> ListLoanScheme = new List<LoanScheme>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetLoanSchemeList", xml.GetXML("loan_scheme"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            LoanScheme objloanscheme = new LoanScheme();
                            objloanscheme.loan_scheme_id = dr["loan_scheme_id"] != DBNull.Value ? Convert.ToInt32(dr["loan_scheme_id"]) : 0;
                            objloanscheme.loan_scheme_name = dr["loan_scheme_name"] != DBNull.Value ? Convert.ToString(dr["loan_scheme_name"]) : "";
                            objloanscheme.loan_scheme_short_description = dr["loan_scheme_short_description"] != DBNull.Value ? Convert.ToString(dr["loan_scheme_short_description"]) : "";
                            // objannouncements.announcements_date = ConvertApplicationDateTimeToDisplayDateTimeFormat(Convert.ToString(dr["announcements_date"]));
                            objloanscheme.loan_scheme_details = dr["loan_scheme_details"] != DBNull.Value ? Convert.ToString(dr["loan_scheme_details"]) : "";
                            objloanscheme.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            ListLoanScheme.Add(objloanscheme);
                        }
                    }
                    return Request.CreateResponse<List<LoanScheme>>(HttpStatusCode.OK, ListLoanScheme);
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
        [Route("api/API_Loan/GetLoanSchemeById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetLoanSchemeById(Int32 id)
        {
            try
            {
                LoanScheme objLoanScheme = new LoanScheme();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("loan_scheme_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetLoanSchemeById", xml.GetXML("loan_scheme"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        //objEvent.event_id = Convert.ToInt32(dtData.Rows[0]["event_id"].ToString());
                        objLoanScheme.loan_scheme_id = dtData.Rows[0]["loan_scheme_id"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["loan_scheme_id"].ToString()) : 0;
                        objLoanScheme.loan_scheme_name = Convert.ToString(dtData.Rows[0]["loan_scheme_name"]);
                        objLoanScheme.loan_scheme_short_description = Convert.ToString(dtData.Rows[0]["loan_scheme_short_description"]);
                        objLoanScheme.loan_scheme_details = Convert.ToString(dtData.Rows[0]["loan_scheme_details"]);
                        objLoanScheme.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;
                    }

                    return Request.CreateResponse<LoanScheme>(HttpStatusCode.OK, objLoanScheme);
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

        [Route("api/API_Loan/SaveLoanScheme/")]
        [HttpPost]
        public HttpResponseMessage SaveLoanScheme(LoanSchemeManageModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.LoanScheme.status == true ? 1 : 0;

                xml.AddElement("loan_scheme_id", Convert.ToString(model.LoanScheme.loan_scheme_id));
                xml.AddElement("loan_scheme_name", Convert.ToString(model.LoanScheme.loan_scheme_name));
                xml.AddElement("loan_scheme_short_description", Convert.ToString(model.LoanScheme.loan_scheme_short_description));
                xml.AddElement("loan_scheme_details", Convert.ToString(model.LoanScheme.loan_scheme_details));
                xml.AddElement("user_id", model.user_id);
                xml.AddElement("status", Convert.ToString(status));

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveLoanScheme", xml.GetXML("loan_scheme"));
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
                Console.WriteLine(ex);
                ErrorMessage objErrorMessage = GetError("", Convert.ToString(ex.Message), Constants.ERROR_TYPE_GENERAL);
                return Request.CreateResponse<ErrorMessage>(HttpStatusCode.NotFound, objErrorMessage);
            }
        }

        [Route("api/API_Loan/DeleteLoanScheme/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteLoanScheme(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("loan_scheme_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteLoanScheme", xml.GetXML("loan_scheme"));
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
