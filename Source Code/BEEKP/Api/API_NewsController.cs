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
    public class API_NewsController : API_BaseController
    {
        [Route("api/API_News/GetNewsList/")]
        [HttpPost]
        public HttpResponseMessage GetNewsList(List<String> _ListParameter)
        {
            try
            {
                List<News> ListNews = new List<News>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                xml.AddElement("news_period", Convert.ToString(_ListParameter[1]));
                xml.AddElement("news_count", Convert.ToString(_ListParameter[2]));

                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetNewsList", xml.GetXML("news"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            News objNews = new News();

                            objNews.news_id = dr["news_id"] != DBNull.Value ? Convert.ToInt32(dr["news_id"]) : 0;
                            objNews.news_title = dr["news_title"] != DBNull.Value ? Convert.ToString(dr["news_title"]) : "";
                            objNews.news_date = ConvertApplicationDateTimeToDisplayDateTimeFormat(Convert.ToString(dr["news_date"]));
                            objNews.news_short_description = dr["news_short_description"] != DBNull.Value ? Convert.ToString(dr["news_short_description"]) : "";
                            objNews.news_full_description = dr["news_full_description"] != DBNull.Value ? Convert.ToString(dr["news_full_description"]) : "";
                            objNews.news_image_name = dr["news_image_name"] != DBNull.Value ? Convert.ToString(dr["news_image_name"]) : "";
                            objNews.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            ListNews.Add(objNews);
                        }
                    }
                    return Request.CreateResponse<List<News>>(HttpStatusCode.OK, ListNews);
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
        [Route("api/API_News/GetNewsById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetNewsById(Int32 id)
        {
            try
            {
                News objNews = new News();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("news_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetNewsById", xml.GetXML("news"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        //objEvent.event_id = Convert.ToInt32(dtData.Rows[0]["event_id"].ToString());
                        objNews.news_id = dtData.Rows[0]["news_id"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["news_id"].ToString()) : 0;
                        objNews.news_title = Convert.ToString(dtData.Rows[0]["news_title"]);
                        objNews.news_date = ConvertApplicationDateTimeToDisplayDateTimeFormat(Convert.ToString(dtData.Rows[0]["news_date"]));
                        objNews.news_short_description = Convert.ToString(dtData.Rows[0]["news_short_description"]);
                        objNews.news_full_description = Convert.ToString(dtData.Rows[0]["news_full_description"]);
                        objNews.news_image_name = Convert.ToString(dtData.Rows[0]["news_image_name"]);
                        objNews.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;
                    }

                    return Request.CreateResponse<News>(HttpStatusCode.OK, objNews);
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
        [Route("api/API_News/GetNewsImageById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetNewsImageById(Int32 id)
        {
            try
            {
                NewsImage objNewsImage = new NewsImage();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("news_image_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetNewsImageById", xml.GetXML("news_image"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objNewsImage.news_image_id = Convert.ToInt32(dtData.Rows[0]["news_image_id"].ToString());
                        objNewsImage.news_image_name = Convert.ToString(dtData.Rows[0]["news_image_name"]);

                    }

                    return Request.CreateResponse<NewsImage>(HttpStatusCode.OK, objNewsImage);
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

        [Route("api/API_News/SaveNews/")]
        [HttpPost]
        public HttpResponseMessage SaveNews(NewsViewAddEditModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.News.status == true ? 1 : 0;

                xml.AddElement("news_id", Convert.ToString(model.News.news_id));
                xml.AddElement("news_title", Convert.ToString(model.News.news_title));
                xml.AddElement("news_date", ConvertDisplayDateTimeToDatabaseFormat(model.News.news_date));
                xml.AddElement("news_short_description", Convert.ToString(model.News.news_short_description));
                xml.AddElement("news_full_description", Convert.ToString(model.News.news_full_description));
                xml.AddElement("news_image_name", Convert.ToString(model.News.news_image_name));
                xml.AddElement("user_id", model.user_id);
                xml.AddElement("status", Convert.ToString(status));

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveNews", xml.GetXML("news"));
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

        [Route("api/API_News/SaveNewsImage/")]
        [HttpPost]
        public HttpResponseMessage SaveNewsImage(NewsImageAddEditViewModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();

                xml.AddElement("news_id", Convert.ToString(model.news_id));
                xml.AddElement("news_image_id", Convert.ToString(model.NewsImage.news_image_id));
                xml.AddElement("news_image_name", Convert.ToString(model.NewsImage.news_image_name));
                xml.AddElement("user_id", model.user_id);


                DataTable dtData = objCDataAccess.GetDataTableSP("SaveNewsImage", xml.GetXML("news_image"));
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

        [Route("api/API_News/DeleteNews/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteNews(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("news_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteNews", xml.GetXML("news"));
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
        [Route("api/API_News/DeleteNewsImage/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteNewsImage(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("news_image_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteNewsImage", xml.GetXML("news_image"));
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

        [Route("api/API_News/GetNewsImageListByNewsId/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetNewsImageListByNewsId(Int32 id)
        {
            try
            {
                List<NewsImage> ListNewsImage = new List<NewsImage>();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("news_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetNewsImageListByNewsId", xml.GetXML("news_image"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            NewsImage objNewsImage = new NewsImage();

                            objNewsImage.news_id = Convert.ToInt32(dr["news_id"].ToString());
                            objNewsImage.news_image_id = Convert.ToInt32(dr["news_image_id"]);
                            objNewsImage.news_image_name = Convert.ToString(dr["news_image_name"]);
                            ListNewsImage.Add(objNewsImage);
                        }
                    }

                    return Request.CreateResponse<List<NewsImage>>(HttpStatusCode.OK, ListNewsImage);
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
