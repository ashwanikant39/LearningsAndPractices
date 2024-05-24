using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using System.Data;

namespace BEEKP.Api
{
    public class API_PhaseController : API_BaseController
    {
        [Route("api/API_Phase/GetPhasesList/")]
        [HttpPost]
        public HttpResponseMessage GetPhasesList(List<String> _ListParameter)
        {
            try
            {
                List<Phases> ListPhases = new List<Phases>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetPhasesList", xml.GetXML("phases"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Phases objPhases = new Phases();
                            objPhases.phases_id = dr["phases_id"] != DBNull.Value ? Convert.ToInt32(dr["phases_id"]) : 0;
                            objPhases.phases_title = dr["phases_title"] != DBNull.Value ? Convert.ToString(dr["phases_title"]) : "";
                            objPhases.phases_start_date = ConvertApplicationDateTimeToDisplayDateTimeFormat(Convert.ToString(dr["phases_start_date"]));
                            objPhases.phases_short_description = dr["phases_short_description"] != DBNull.Value ? Convert.ToString(dr["phases_short_description"]) : "";
                            objPhases.phases_full_description = dr["phases_full_description"] != DBNull.Value ? Convert.ToString(dr["phases_full_description"]) : "";
                            objPhases.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            ListPhases.Add(objPhases);
                        }
                    }
                    return Request.CreateResponse<List<Phases>>(HttpStatusCode.OK, ListPhases);
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
        [Route("api/API_Phase/GetPhasesById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetPhasesById(Int32 id)
        {
            try
            {
                Phases objPhases = new Phases();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("phases_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetPhasesById", xml.GetXML("phases"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        //objEvent.event_id = Convert.ToInt32(dtData.Rows[0]["event_id"].ToString());
                        objPhases.phases_id = dtData.Rows[0]["phases_id"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["phases_id"].ToString()) : 0;
                        objPhases.phases_title = Convert.ToString(dtData.Rows[0]["phases_title"]);
                        objPhases.phases_start_date = ConvertApplicationDateTimeToDisplayDateTimeFormat(Convert.ToString(dtData.Rows[0]["phases_start_date"]));
                        objPhases.phases_short_description = Convert.ToString(dtData.Rows[0]["phases_short_description"]);
                        objPhases.phases_full_description = Convert.ToString(dtData.Rows[0]["phases_full_description"]);
                        objPhases.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;
                    }

                    return Request.CreateResponse<Phases>(HttpStatusCode.OK, objPhases);
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

        [Route("api/API_Phase/SavePhases/")]
        [HttpPost]
        public HttpResponseMessage SavePhases(PhasesViewAddEditModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.Phases.status == true ? 1 : 0;

                xml.AddElement("phases_id", Convert.ToString(model.Phases.phases_id));
                xml.AddElement("phases_title", Convert.ToString(model.Phases.phases_title));
                xml.AddElement("phases_start_date", ConvertDisplayDateTimeToDatabaseFormat(model.Phases.phases_start_date));
                xml.AddElement("phases_short_description", Convert.ToString(model.Phases.phases_short_description));
                xml.AddElement("phases_full_description", Convert.ToString(model.Phases.phases_full_description));
                xml.AddElement("user_id", model.user_id);
                xml.AddElement("status", Convert.ToString(status));

                DataTable dtData = objCDataAccess.GetDataTableSP("SavePhases", xml.GetXML("phases"));
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

        [Route("api/API_Phase/DeletePhases/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeletePhases(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("phases_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeletePhases", xml.GetXML("phases"));
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
