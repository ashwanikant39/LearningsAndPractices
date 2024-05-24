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
    public class API_GalleryController : API_BaseController
    {
        [Route("api/API_Gallery/GetPhotoGalleryList/")]
        [HttpPost]
        public HttpResponseMessage GetPhotoGalleryList(List<String> _ListParameter)
        {

            try
            {
                List<Photo> ListPhoto = new List<Photo>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetPhotoGalleryList", xml.GetXML("photogallery"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Photo objPhoto = new Photo();
                            objPhoto.photo_id = Convert.ToInt32(dr["photo_id"]);
                            objPhoto.photo_name = Convert.ToString(dr["photo_name"]);
                            objPhoto.photo_title = Convert.ToString(dr["photo_title"]);
                            objPhoto.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            objPhoto.display_dashboard = Convert.ToInt32(dr["display_dashboard"]) == 1 ? true : false;
                            ListPhoto.Add(objPhoto);
                        }
                    }
                    return Request.CreateResponse<List<Photo>>(HttpStatusCode.OK, ListPhoto);
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

        [Route("api/API_Gallery/SavePhotoGallery/")]
        [HttpPost]
        public HttpResponseMessage SavePhotoGallery(PhotoManageModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.Photo.status == true ? 1 : 0;
                int display_dashboard = model.Photo.display_dashboard == true ? 1 : 0;

                xml.AddElement("photo_id", Convert.ToString(model.Photo.photo_id));
                xml.AddElement("photo_name", Convert.ToString(model.Photo.photo_name));
                xml.AddElement("photo_title", Convert.ToString(model.Photo.photo_title));
                xml.AddElement("status", Convert.ToString(status));
                xml.AddElement("display_dashboard", Convert.ToString(display_dashboard));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SavePhotoGallery", xml.GetXML("photogallery"));
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

        [Route("api/API_Gallery/GetPhotoById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetPhotoById(Int32 id)
        {
            try
            {
                Photo objPhoto = new Photo();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("photo_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetPhotoGalleryById", xml.GetXML("photogallery"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objPhoto.photo_id = Convert.ToInt32(dtData.Rows[0]["photo_id"].ToString());
                        objPhoto.photo_title = Convert.ToString(dtData.Rows[0]["photo_title"]);
                        objPhoto.photo_name = Convert.ToString(dtData.Rows[0]["photo_name"]);
                        objPhoto.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;
                        objPhoto.display_dashboard = Convert.ToInt32(dtData.Rows[0]["display_dashboard"]) == 1 ? true : false;
                    }

                    return Request.CreateResponse<Photo>(HttpStatusCode.OK, objPhoto);
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
        [Route("api/API_Gallery/DeletePhoto/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeletePhoto(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("photo_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeletePhotoGallery", xml.GetXML("photogallery"));
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

        [Route("api/API_Gallery/GetPhotoGalleryDashboardList/")]
        [HttpGet]
        public HttpResponseMessage GetPhotoGalleryDashboardList()
        {
            try
            {
                List<Photo> ListPhoto = new List<Photo>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetPhotoGalleryDashboardList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Photo objPhoto = new Photo();
                            objPhoto.photo_id = Convert.ToInt32(dr["photo_id"]);
                            objPhoto.photo_name = Convert.ToString(dr["photo_name"]);
                            objPhoto.photo_title = Convert.ToString(dr["photo_title"]);
                            objPhoto.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            objPhoto.display_dashboard = Convert.ToInt32(dr["display_dashboard"]) == 1 ? true : false;
                            ListPhoto.Add(objPhoto);
                        }
                    }
                    return Request.CreateResponse<List<Photo>>(HttpStatusCode.OK, ListPhoto);
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


        //------------------------------------------------------------------ Video Section---------------------------------------------------------
        [Route("api/API_Gallery/GetVideoGalleryList/")]
        [HttpPost]
        public HttpResponseMessage GetVideoGalleryList(List<String> _ListParameter)
        {

            try
            {
                List<Video> ListVideo = new List<Video>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetVideoGalleryList", xml.GetXML("videogallery"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Video objVideo = new Video();
                            objVideo.video_id = Convert.ToInt32(dr["video_id"]);
                            objVideo.video_title = Convert.ToString(dr["video_title"]);
                            objVideo.video_image_name = Convert.ToString(dr["video_image_name"]);
                            objVideo.video_url = Convert.ToString(dr["video_url"]);
                            objVideo.sectors_id = Convert.ToInt32(dr["sectors_id"]);
                            objVideo.sectors_name = Convert.ToString(dr["sectors_name"]);
                            objVideo.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            objVideo.display_dashboard = Convert.ToInt32(dr["display_dashboard"]) == 1 ? true : false;
                            ListVideo.Add(objVideo);
                        }
                    }
                    return Request.CreateResponse<List<Video>>(HttpStatusCode.OK, ListVideo);
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

        [Route("api/API_Gallery/SaveVideoGallery/")]
        [HttpPost]
        public HttpResponseMessage SaveVideoGallery(VideoManageModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.Video.status == true ? 1 : 0;
                int display_dashboard = model.Video.display_dashboard == true ? 1 : 0;

                xml.AddElement("video_id", Convert.ToString(model.Video.video_id));
                xml.AddElement("video_title", Convert.ToString(model.Video.video_title));
                xml.AddElement("video_image_name", Convert.ToString(model.Video.video_image_name));
                xml.AddElement("video_url", Convert.ToString(model.Video.video_url));
                xml.AddElement("sectors_id", Convert.ToString(model.Video.sectors_id));
                xml.AddElement("status", Convert.ToString(status));
                xml.AddElement("display_dashboard", Convert.ToString(display_dashboard));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveVideoGallery", xml.GetXML("videogallery"));
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

        [Route("api/API_Gallery/GetVideoById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetVideoById(Int32 id)
        {
            try
            {
                Video objVideo = new Video();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("video_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetVideoGalleryById", xml.GetXML("videogallery"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objVideo.video_id = Convert.ToInt32(dtData.Rows[0]["video_id"].ToString());
                        objVideo.video_title = Convert.ToString(dtData.Rows[0]["video_title"]);
                        objVideo.video_image_name = Convert.ToString(dtData.Rows[0]["video_image_name"]);
                        objVideo.video_url = Convert.ToString(dtData.Rows[0]["video_url"]);
                        objVideo.sectors_id = Convert.ToInt32(dtData.Rows[0]["sectors_id"]);
                        objVideo.sectors_name = Convert.ToString(dtData.Rows[0]["sectors_name"]);
                        objVideo.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;
                        objVideo.display_dashboard = Convert.ToInt32(dtData.Rows[0]["display_dashboard"]) == 1 ? true : false;
                    }

                    return Request.CreateResponse<Video>(HttpStatusCode.OK, objVideo);
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

        [Route("api/API_Gallery/DeleteVideo/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteVideo(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("video_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteVideoGallery", xml.GetXML("videogallery"));
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
        [Route("api/API_Gallery/GetVideoGalleryDashboardList/")]
        [HttpGet]
        public HttpResponseMessage GetVideoGalleryDashboardList()
        {
            try
            {
                List<Video> ListVideo = new List<Video>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetVideoGalleryDashboardList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {

                            Video objVideo = new Video();
                            objVideo.video_id = Convert.ToInt32(dr["video_id"]);
                            objVideo.video_title = Convert.ToString(dr["video_title"]);
                            objVideo.video_image_name = Convert.ToString(dr["video_image_name"]);
                            objVideo.video_url = Convert.ToString(dr["video_url"]);
                            objVideo.sectors_id = Convert.ToInt32(dtData.Rows[0]["sectors_id"]);
                            objVideo.sectors_name = Convert.ToString(dtData.Rows[0]["sectors_name"]);
                            objVideo.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            objVideo.display_dashboard = Convert.ToInt32(dr["display_dashboard"]) == 1 ? true : false;
                            ListVideo.Add(objVideo);
                        }
                    }
                    return Request.CreateResponse<List<Video>>(HttpStatusCode.OK, ListVideo);
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