namespace BEEKP.Api
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using BEEKP.Areas.Admin.Models;
    using BEEKP.Class;

    /// <summary>
    /// Defines the <see cref="API_AnnouncementController" />.
    /// </summary>
    public class API_AnnouncementController : API_BaseController
    {
        /// <summary>
        /// The GetAnnouncementList.
        /// </summary>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        [Route("api/API_Announcement/GetAnnouncementList/")]
        [HttpGet]
        public HttpResponseMessage GetAnnouncementList()
        {
            try
            {
                List<Announcement> ListAnnouncement = new List<Announcement>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetAnnouncementList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Announcement objAnnouncement = new Announcement();

                            objAnnouncement.announce_id = Convert.ToInt32(dr["announce_id"]);
                            objAnnouncement.announce_title = Convert.ToString(dr["announce_title"]);
                            objAnnouncement.announce_date = Convert.ToString(dr["announce_date"]);
                            objAnnouncement.announce_short_description = Convert.ToString(dr["announce_short_description"]);
                            ListAnnouncement.Add(objAnnouncement);
                        }
                    }
                    return Request.CreateResponse<List<Announcement>>(HttpStatusCode.OK, ListAnnouncement);
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

        /// <summary>
        /// The SaveAnnouncement.
        /// </summary>
        /// <param name="model">The model<see cref="AnnouncementViewAddEditModel"/>.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        [Route("api/API_Announcement/SaveAnnouncement/")]
        [HttpPost]
        public HttpResponseMessage SaveAnnouncement(AnnouncementViewAddEditModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.Announcement.status == true ? 1 : 0;

                xml.AddElement("announce_id", Convert.ToString(model.Announcement.announce_id));
                xml.AddElement("announce_title", Convert.ToString(model.Announcement.announce_title));
                xml.AddElement("announce_date", ConvertDisplayDateTimeToDatabaseFormat(model.Announcement.announce_date));
                xml.AddElement("announce_short_description", Convert.ToString(model.Announcement.announce_short_description));
                xml.AddElement("user_id", model.user_id);
                xml.AddElement("status", Convert.ToString(status));

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveAnnouncement", xml.GetXML("announce"));
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

        /// <summary>
        /// The GetAnnouncementById.
        /// </summary>
        /// <param name="id">The id<see cref="Int32"/>.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        [Route("api/API_Announcement/GetAnnouncementById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetAnnouncementById(Int32 id)
        {
            try
            {
                Announcement objAnnouncement = new Announcement();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("announce_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("GetAnnouncementById", xml.GetXML("announce"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objAnnouncement.announce_id = Convert.ToInt32(dtData.Rows[0]["announce_id"]);
                        objAnnouncement.announce_title = Convert.ToString(dtData.Rows[0]["announce_title"]);
                        objAnnouncement.announce_date = Convert.ToString(dtData.Rows[0]["announce_date"]);
                        objAnnouncement.announce_short_description = Convert.ToString(dtData.Rows[0]["announce_short_description"]);
                        //objAnnouncement.announce_image_name = Convert.ToString(dtData.Rows[0]["announce_image_name"]);

                    }

                    return Request.CreateResponse<Announcement>(HttpStatusCode.OK, objAnnouncement);
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

        /// <summary>
        /// The DeleteAnnouncement.
        /// </summary>
        /// <param name="id">The id<see cref="Int32"/>.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        [Route("api/API_Announcement/DeleteAnnouncement/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteAnnouncement(Int32 id)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("announce_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteAnnouncement", xml.GetXML("announcement"));
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
