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
    public class API_SubsidySchemeController : API_BaseController
    {
        [Route("api/API_SubsidyScheme/GetSubsidySchemeList/")]
        [HttpPost]
        public HttpResponseMessage GetSubsidySchemeList(List<String> _ListParameter)
        {
            try
            {
                List<SubsidyScheme> ListSubsidyScheme = new List<SubsidyScheme>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetSubsidySchemeList", xml.GetXML("subsidy_scheme"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            SubsidyScheme objloanscheme = new SubsidyScheme();
                            objloanscheme.subsidy_scheme_id = dr["subsidy_scheme_id"] != DBNull.Value ? Convert.ToInt32(dr["subsidy_scheme_id"]) : 0;
                            objloanscheme.subsidy_scheme_name = dr["subsidy_scheme_name"] != DBNull.Value ? Convert.ToString(dr["subsidy_scheme_name"]) : "";
                            objloanscheme.subsidy_scheme_short_description = dr["subsidy_scheme_short_description"] != DBNull.Value ? Convert.ToString(dr["subsidy_scheme_short_description"]) : "";
                            // objannouncements.announcements_date = ConvertApplicationDateTimeToDisplayDateTimeFormat(Convert.ToString(dr["announcements_date"]));
                            objloanscheme.subsidy_scheme_details = dr["subsidy_scheme_details"] != DBNull.Value ? Convert.ToString(dr["subsidy_scheme_details"]) : "";
                            objloanscheme.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            ListSubsidyScheme.Add(objloanscheme);
                        }
                    }
                    return Request.CreateResponse<List<SubsidyScheme>>(HttpStatusCode.OK, ListSubsidyScheme);
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
        [Route("api/API_SubsidyScheme/GetSubsidySchemeById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetSubsidySchemeById(Int32 id)
        {
            try
            {
                SubsidyScheme objsubsidy_scheme = new SubsidyScheme();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("subsidy_scheme_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetSubsidySchemeById", xml.GetXML("subsidy_scheme"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        //objEvent.event_id = Convert.ToInt32(dtData.Rows[0]["event_id"].ToString());
                        objsubsidy_scheme.subsidy_scheme_id = dtData.Rows[0]["subsidy_scheme_id"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["subsidy_scheme_id"].ToString()) : 0;
                        objsubsidy_scheme.subsidy_scheme_name = Convert.ToString(dtData.Rows[0]["subsidy_scheme_name"]);
                        objsubsidy_scheme.subsidy_scheme_short_description = Convert.ToString(dtData.Rows[0]["subsidy_scheme_short_description"]);
                        objsubsidy_scheme.subsidy_scheme_details = Convert.ToString(dtData.Rows[0]["subsidy_scheme_details"]);
                        objsubsidy_scheme.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;
                    }

                    return Request.CreateResponse<SubsidyScheme>(HttpStatusCode.OK, objsubsidy_scheme);
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

        [Route("api/API_SubsidyScheme/SaveSubsidyScheme/")]
        [HttpPost]
        public HttpResponseMessage SaveSubsidyScheme(SubsidySchemeManageModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.SubsidyScheme.status == true ? 1 : 0;

                xml.AddElement("subsidy_scheme_id", Convert.ToString(model.SubsidyScheme.subsidy_scheme_id));
                xml.AddElement("subsidy_scheme_name", Convert.ToString(model.SubsidyScheme.subsidy_scheme_name));
                xml.AddElement("subsidy_scheme_short_description", Convert.ToString(model.SubsidyScheme.subsidy_scheme_short_description));
                xml.AddElement("subsidy_scheme_details", Convert.ToString(model.SubsidyScheme.subsidy_scheme_details));
                xml.AddElement("user_id", model.user_id);
                xml.AddElement("status", Convert.ToString(status));

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveSubsidyScheme", xml.GetXML("subsidy_scheme"));
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

        [Route("api/API_SubsidyScheme/DeleteSubsidyScheme/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteSubsidyScheme(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("subsidy_scheme_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteSubsidyScheme", xml.GetXML("subsidy_scheme"));
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
