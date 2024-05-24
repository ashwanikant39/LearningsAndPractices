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
    public class API_SectorsController : API_BaseController
    {
        [Route("api/API_Sectors/GetSectorsList/")]
        [HttpPost]
        public HttpResponseMessage GetSectorsList(List<String> _ListParameter)
        {
            try
            {
                List<Sectors> ListSectors = new List<Sectors>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetSectorsList", xml.GetXML("sectors"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Sectors objSectors = new Sectors();

                            objSectors.sectors_id = dr["sectors_id"] != DBNull.Value ? Convert.ToInt32(dr["sectors_id"]) : 0;
                            objSectors.sectors_name = dr["sectors_name"] != DBNull.Value ? Convert.ToString(dr["sectors_name"]) : "";
                            objSectors.sectors_location = dr["sectors_location"] != DBNull.Value ? Convert.ToString(dr["sectors_location"]) : "";
                            objSectors.sectors_short_description = dr["sectors_short_description"] != DBNull.Value ? Convert.ToString(dr["sectors_short_description"]) : "";
                            objSectors.sectors_full_description = dr["sectors_full_description"] != DBNull.Value ? Convert.ToString(dr["sectors_full_description"]) : "";
                            objSectors.sectors_image_name = dr["sectors_image_name"] != DBNull.Value ? Convert.ToString(dr["sectors_image_name"]) : "";
                            objSectors.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            ListSectors.Add(objSectors);
                        }
                    }
                    return Request.CreateResponse<List<Sectors>>(HttpStatusCode.OK, ListSectors);
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
        [Route("api/API_Sectors/GetSectorsById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetSectorsById(Int32 id)
        {
            try
            {
                Sectors objSectors = new Sectors();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("sectors_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetSectorsById", xml.GetXML("sectors"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objSectors.sectors_id = dtData.Rows[0]["sectors_id"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["sectors_id"].ToString()) : 0;
                        objSectors.sectors_name = Convert.ToString(dtData.Rows[0]["sectors_name"]);
                        objSectors.sectors_location = Convert.ToString(dtData.Rows[0]["sectors_location"]);
                        objSectors.sectors_short_description = Convert.ToString(dtData.Rows[0]["sectors_short_description"]);
                        objSectors.sectors_full_description = Convert.ToString(dtData.Rows[0]["sectors_full_description"]);
                        objSectors.sectors_image_name = Convert.ToString(dtData.Rows[0]["sectors_image_name"]);
                        objSectors.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;
                    }

                    return Request.CreateResponse<Sectors>(HttpStatusCode.OK, objSectors);
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
        [Route("api/API_Sectors/GetSectorsImageById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetSectorsImageById(Int32 id)
        {
            try
            {
                SectorsImage objSectorsImage = new SectorsImage();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("sectors_image_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetSectorsImageById", xml.GetXML("sectors_image"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objSectorsImage.sectors_image_id = Convert.ToInt32(dtData.Rows[0]["sectors_image_id"].ToString());
                        objSectorsImage.sectors_image_name = Convert.ToString(dtData.Rows[0]["sectors_image_name"]);

                    }

                    return Request.CreateResponse<SectorsImage>(HttpStatusCode.OK, objSectorsImage);
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
        [Route("api/API_Sectors/SaveSectors/")]
        [HttpPost]
        public HttpResponseMessage SaveSectors(SectorsViewAddEditModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.Sectors.status == true ? 1 : 0;

                xml.AddElement("sectors_id", Convert.ToString(model.Sectors.sectors_id));
                xml.AddElement("sectors_name", Convert.ToString(model.Sectors.sectors_name));
                xml.AddElement("sectors_location", Convert.ToString(model.Sectors.sectors_location));
                xml.AddElement("sectors_short_description", Convert.ToString(model.Sectors.sectors_short_description));
                xml.AddElement("sectors_full_description", Convert.ToString(model.Sectors.sectors_full_description));
                xml.AddElement("sectors_image_name", Convert.ToString(model.Sectors.sectors_image_name));
                xml.AddElement("user_id", model.user_id);
                xml.AddElement("status", Convert.ToString(status));

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveSectors", xml.GetXML("sectors"));
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
        [Route("api/API_Sectors/SaveSectorsImage/")]
        [HttpPost]
        public HttpResponseMessage SaveSectorsImage(SectorsImageAddEditViewModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();

                xml.AddElement("sectors_id", Convert.ToString(model.sectors_id));
                xml.AddElement("sectors_image_id", Convert.ToString(model.SectorsImage.sectors_image_id));
                xml.AddElement("sectors_image_name", Convert.ToString(model.SectorsImage.sectors_image_name));
                xml.AddElement("user_id", model.user_id);


                DataTable dtData = objCDataAccess.GetDataTableSP("SaveSectorsImage", xml.GetXML("sectors_image"));
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
        [Route("api/API_Sectors/DeleteSectors/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteSectors(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("sectors_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteSectors", xml.GetXML("sectors"));
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
        [Route("api/API_Sectors/DeleteSectorsImage/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteSectorsImage(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("sectors_image_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteSectorsImage", xml.GetXML("sectors_image"));
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
        [Route("api/API_Sectors/GetSectorsImageListBySectorsId/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetSectorsImageListBySectorsId(Int32 id)
        {
            try
            {
                List<SectorsImage> ListSectorsImage = new List<SectorsImage>();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("sectors_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetSectorsImageListBySectorsId", xml.GetXML("sectors_image"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            SectorsImage objSectorsImage = new SectorsImage();

                            objSectorsImage.sectors_id = Convert.ToInt32(dr["sectors_id"].ToString());
                            objSectorsImage.sectors_image_id = Convert.ToInt32(dr["sectors_image_id"]);
                            objSectorsImage.sectors_image_name = Convert.ToString(dr["sectors_image_name"]);
                            ListSectorsImage.Add(objSectorsImage);
                        }
                    }

                    return Request.CreateResponse<List<SectorsImage>>(HttpStatusCode.OK, ListSectorsImage);
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
