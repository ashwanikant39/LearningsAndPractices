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
    public class API_AnnouncementsController : API_BaseController
    {
        [Route("api/API_Announcements/GetAnnouncementsList/")]
        [HttpPost]
        public HttpResponseMessage GetAnnouncementsList(List<String> _ListParameter)
        {
            try
            {
                List<Announcements> ListAnnouncements = new List<Announcements>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                xml.AddElement("page_no", Convert.ToString(_ListParameter[1]));
                xml.AddElement("page_size", Convert.ToString(_ListParameter[2]));
                xml.AddElement("Search", Convert.ToString(_ListParameter[3]));
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = new DataTable();
                DataSet dataSet = objCDataAccess.GetDataSetTableSP("GetAnnouncementsList", xml.GetXML("announcements"));
                dtData = dataSet.Tables[0];
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Announcements objannouncements = new Announcements();
                            objannouncements.announcements_id = dr["announcements_id"] != DBNull.Value ? Convert.ToInt32(dr["announcements_id"]) : 0;
                            objannouncements.announcements_title = dr["announcements_title"] != DBNull.Value ? Convert.ToString(dr["announcements_title"]) : "";
                            objannouncements.announcements_date = ConvertApplicationDateTimeToDisplayDateTimeFormat(Convert.ToString(dr["announcements_date"]));
                            objannouncements.announcements_short_description = dr["announcements_short_description"] != DBNull.Value ? Convert.ToString(dr["announcements_short_description"]) : "";
                            objannouncements.announcements_full_description = dr["announcements_full_description"] != DBNull.Value ? Convert.ToString(dr["announcements_full_description"]) : "";
                            objannouncements.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            ListAnnouncements.Add(objannouncements);
                        }
                    }
                    AdminAnnouncementsViewModel model = new AdminAnnouncementsViewModel();
                    model.ListAnnouncementsActive = ListAnnouncements;
                    model.TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0]["Total"]);
                    return Request.CreateResponse<AdminAnnouncementsViewModel>(HttpStatusCode.OK,model);
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
        [Route("api/API_Announcements/GetAnnouncementsById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetAnnouncementsById(Int32 id)
        {
            try
            {
                Announcements objAnnouncements = new Announcements();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("announcements_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetAnnouncementsById", xml.GetXML("announcements"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        //objEvent.event_id = Convert.ToInt32(dtData.Rows[0]["event_id"].ToString());
                        objAnnouncements.announcements_id = dtData.Rows[0]["announcements_id"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["announcements_id"].ToString()) : 0;
                        objAnnouncements.announcements_title = Convert.ToString(dtData.Rows[0]["announcements_title"]);
                        objAnnouncements.announcements_date = ConvertApplicationDateTimeToDisplayDateTimeFormat(Convert.ToString(dtData.Rows[0]["announcements_date"]));
                        objAnnouncements.announcements_short_description = Convert.ToString(dtData.Rows[0]["announcements_short_description"]);
                        objAnnouncements.announcements_full_description = Convert.ToString(dtData.Rows[0]["announcements_full_description"]);
                        objAnnouncements.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;
                    }

                    return Request.CreateResponse<Announcements>(HttpStatusCode.OK, objAnnouncements);
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

        [Route("api/API_Announcements/SaveAnnouncements/")]
        [HttpPost]
        public HttpResponseMessage SaveAnnouncements(AnnouncementsViewAddEditModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.Announcements.status == true ? 1 : 0;

                xml.AddElement("announcements_id", Convert.ToString(model.Announcements.announcements_id));
                xml.AddElement("announcements_title", Convert.ToString(model.Announcements.announcements_title));
                xml.AddElement("announcements_date", ConvertDisplayDateTimeToDatabaseFormat(model.Announcements.announcements_date));
                xml.AddElement("announcements_short_description", Convert.ToString(model.Announcements.announcements_short_description));
                xml.AddElement("announcements_full_description", Convert.ToString(model.Announcements.announcements_full_description));
                xml.AddElement("user_id", model.user_id);
                xml.AddElement("status", Convert.ToString(status));

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveAnnouncements", xml.GetXML("announcements"));
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

        [Route("api/API_Announcements/DeleteAnnouncements/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteAnnouncements(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("announcements_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteAnnouncements", xml.GetXML("announcements"));
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