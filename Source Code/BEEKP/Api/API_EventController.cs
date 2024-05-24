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
    public class API_EventController : API_BaseController
    {
        [Route("api/API_Event/GetEventList/")]
        [HttpPost]
        public HttpResponseMessage GetEventList(List<String> _ListParameter)
        {
            try
            {
                List<Event> ListEvent = new List<Event>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                xml.AddElement("event_period", Convert.ToString(_ListParameter[1]));
                xml.AddElement("event_count", Convert.ToString(_ListParameter[2]));

                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetEventList", xml.GetXML("event"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Event objEvent = new Event();

                            objEvent.event_id = dr["event_id"] != DBNull.Value ? Convert.ToInt32(dr["event_id"]) : 0;
                            objEvent.event_title = dr["event_title"] != DBNull.Value ? Convert.ToString(dr["event_title"]) : "";
                            objEvent.event_date = ConvertApplicationDateTimeToDisplayDateTimeFormat(Convert.ToString(dr["event_date"]));
                            objEvent.event_location = dr["event_location"] != DBNull.Value ? Convert.ToString(dr["event_location"]) : "";
                            objEvent.event_short_description = dr["event_short_description"] != DBNull.Value ? Convert.ToString(dr["event_short_description"]) : "";
                            objEvent.event_full_description = dr["event_full_description"] != DBNull.Value ? Convert.ToString(dr["event_full_description"]) : ""; 
                            objEvent.event_image_name = dr["event_image_name"] != DBNull.Value ? Convert.ToString(dr["event_image_name"]) : ""; 
                            objEvent.event_video_url1 = dr["event_video_url1"] != DBNull.Value ? Convert.ToString(dr["event_video_url1"]) : "";
                            objEvent.event_video_url2 = dr["event_video_url1"] != DBNull.Value ? Convert.ToString(dr["event_video_url2"]) : "";
                            objEvent.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            ListEvent.Add(objEvent);
                        }
                    }
                    return Request.CreateResponse<List<Event>>(HttpStatusCode.OK, ListEvent);
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
        [Route("api/API_Event/GetEventById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetEventById(Int32 id)
        {
            try
            {
                Event objEvent = new Event();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("event_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetEventById", xml.GetXML("event"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        //objEvent.event_id = Convert.ToInt32(dtData.Rows[0]["event_id"].ToString());
                        objEvent.event_id = dtData.Rows[0]["event_id"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["event_id"].ToString()):0;
                        objEvent.event_title = Convert.ToString(dtData.Rows[0]["event_title"]);
                        objEvent.event_date = ConvertApplicationDateTimeToDisplayDateTimeFormat(Convert.ToString(dtData.Rows[0]["event_date"]));
                        objEvent.event_location = Convert.ToString(dtData.Rows[0]["event_location"]);
                        objEvent.event_short_description = Convert.ToString(dtData.Rows[0]["event_short_description"]);
                        objEvent.event_full_description = Convert.ToString(dtData.Rows[0]["event_full_description"]);
                        objEvent.event_image_name = Convert.ToString(dtData.Rows[0]["event_image_name"]);
                        objEvent.event_video_url1 = Convert.ToString(dtData.Rows[0]["event_video_url1"]);
                        objEvent.event_video_url2 = Convert.ToString(dtData.Rows[0]["event_video_url2"]);
                        objEvent.event_image_name = Convert.ToString(dtData.Rows[0]["event_image_name"]);
                        objEvent.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;
                    }

                    return Request.CreateResponse<Event>(HttpStatusCode.OK, objEvent);
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
        [Route("api/API_Event/GetEventImageById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetEventImageById(Int32 id)
        {
            try
            {
                EventImage objEventImage = new EventImage();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("event_image_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetEventImageById", xml.GetXML("event_image"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objEventImage.event_image_id = Convert.ToInt32(dtData.Rows[0]["event_image_id"].ToString());
                        objEventImage.event_image_name = Convert.ToString(dtData.Rows[0]["event_image_name"]);
                        
                    }

                    return Request.CreateResponse<EventImage>(HttpStatusCode.OK, objEventImage);
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

        [Route("api/API_Event/SaveEvent/")]
        [HttpPost]
        public HttpResponseMessage SaveEvent(EventViewAddEditModel model)
        {
            try
            {
               
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.Event.status == true ? 1 : 0;

                xml.AddElement("event_id", Convert.ToString(model.Event.event_id));
                xml.AddElement("event_title", Convert.ToString(model.Event.event_title));
                xml.AddElement("event_date", ConvertDisplayDateTimeToDatabaseFormat(model.Event.event_date));
                xml.AddElement("event_location", Convert.ToString(model.Event.event_location));
                xml.AddElement("event_short_description", Convert.ToString(model.Event.event_short_description));
                xml.AddElement("event_full_description", Convert.ToString(model.Event.event_full_description));
                xml.AddElement("event_image_name", Convert.ToString(model.Event.event_image_name));
                xml.AddElement("event_video_url1", Convert.ToString(model.Event.event_video_url1));
                xml.AddElement("event_video_url2", Convert.ToString(model.Event.event_video_url2));
                xml.AddElement("user_id", model.user_id);
                xml.AddElement("status", Convert.ToString(status));

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveEvent", xml.GetXML("event"));
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

        [Route("api/API_Event/SaveEventImage/")]
        [HttpPost]
        public HttpResponseMessage SaveEventImage(EventImageAddEditViewModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();

                xml.AddElement("event_id", Convert.ToString(model.event_id));
                xml.AddElement("event_image_id", Convert.ToString(model.EventImage.event_image_id));
                xml.AddElement("event_image_name", Convert.ToString(model.EventImage.event_image_name));
                xml.AddElement("user_id", model.user_id);
               

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveEventImage", xml.GetXML("event_image"));
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

        [Route("api/API_Event/DeleteEvent/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteEvent(Int32 id)
        {
            try
            {
                
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("event_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteEvent", xml.GetXML("event"));
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
        [Route("api/API_Event/DeleteEventImage/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteEventImage(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("event_image_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteEventImage", xml.GetXML("event_image"));
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

        [Route("api/API_Event/GetEventImageListByEventId/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetEventImageListByEventId(Int32 id)
        {
            try
            {
                List<EventImage> ListEventImage = new List<EventImage>();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("event_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetEventImageListByEventId", xml.GetXML("event_image"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            EventImage objEventImage = new EventImage();

                            objEventImage.event_id = Convert.ToInt32(dr["event_id"].ToString());
                            objEventImage.event_image_id = Convert.ToInt32(dr["event_image_id"]);
                            objEventImage.event_image_name = Convert.ToString(dr["event_image_name"]);
                            ListEventImage.Add(objEventImage);
                        }
                    }

                    return Request.CreateResponse<List<EventImage>>(HttpStatusCode.OK, ListEventImage);
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
