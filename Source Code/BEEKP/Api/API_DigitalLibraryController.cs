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
    public class API_DigitalLibraryController : API_BaseController
    {
        [Route("api/API_DigitalLibrary/GetDigitalLibraryList/")]
        [HttpPost]
        public HttpResponseMessage GetDigitalLibraryList(List<String> _ListParameter)
        {
            try
            {
                List<DigitalLibrary> ListDigitalLibrary = new List<DigitalLibrary>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("SectorId", Convert.ToString(_ListParameter[0]));
                xml.AddElement("ClusterId", Convert.ToString(_ListParameter[1]));
                xml.AddElement("CreatedDate", Convert.ToString(_ListParameter[2]));
                xml.AddElement("IsActive", Convert.ToString(_ListParameter[3]));
                xml.AddElement("ALL", Convert.ToString(_ListParameter[4]));

                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetDigitalLibraryList", xml.GetXML("DigitalLibrary"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            DigitalLibrary objDigitalLibrary = new DigitalLibrary();

                            objDigitalLibrary.Id = dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0;
                            objDigitalLibrary.SectorName = dr["SectorName"] != DBNull.Value ? Convert.ToString(dr["SectorName"]) : "";
                            objDigitalLibrary.ClusterName = dr["ClusterName"] != DBNull.Value ? Convert.ToString(dr["ClusterName"]) : "";
                            objDigitalLibrary.Description = dr["Description"] != DBNull.Value ? Convert.ToString(dr["Description"]) : "";
                            objDigitalLibrary.FileType = dr["FileType"] != DBNull.Value ? Convert.ToString(dr["FileType"]) : "";
                            objDigitalLibrary.FileUrl = dr["FileUrl"] != DBNull.Value ? Convert.ToString(dr["FileUrl"]) : "";
                            objDigitalLibrary.ImageUrl = dr["ImageUrl"] != DBNull.Value ? Convert.ToString(dr["ImageUrl"]) : "";
                            objDigitalLibrary.CreatedDate = dr["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(dr["CreatedDate"]).Date : DateTime.Now.Date;
                            objDigitalLibrary.IsActive = Convert.ToInt32(dr["IsActive"]) == 1 ? true : false;
                            ListDigitalLibrary.Add(objDigitalLibrary);
                        }
                    }
                    return Request.CreateResponse<List<DigitalLibrary>>(HttpStatusCode.OK, ListDigitalLibrary);
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

        [Route("api/API_DigitalLibrary/GetDigitalLibraryById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetDigitalLibraryById(Int32 id)
        {
            try
            {
                DigitalLibrary objDigitalLibrary = new DigitalLibrary();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("Id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetDigitalLibraryById", xml.GetXML("DigitalLibrary"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        //objEvent.event_id = Convert.ToInt32(dtData.Rows[0]["event_id"].ToString());

                        objDigitalLibrary.Id = dtData.Rows[0]["Id"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["Id"].ToString()) : 0;
                        objDigitalLibrary.SectorId = dtData.Rows[0]["SectorId"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["SectorId"].ToString()) : 0;
                        objDigitalLibrary.ClusterId = dtData.Rows[0]["ClusterId"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["ClusterId"].ToString()) : 0;
                        objDigitalLibrary.Description = Convert.ToString(dtData.Rows[0]["Description"]);
                        objDigitalLibrary.FileType = Convert.ToString(dtData.Rows[0]["FileType"]);
                        objDigitalLibrary.FileUrl = Convert.ToString(dtData.Rows[0]["FileUrl"]);
                        objDigitalLibrary.ImageUrl = Convert.ToString(dtData.Rows[0]["ImageUrl"]);
                        objDigitalLibrary.CreatedDate = Convert.ToDateTime(dtData.Rows[0]["CreatedDate"]);

                        objDigitalLibrary.IsActive = Convert.ToInt32(dtData.Rows[0]["IsActive"]) == 1 ? true : false;
                    }
                    return Request.CreateResponse<DigitalLibrary>(HttpStatusCode.OK, objDigitalLibrary);
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

       

        [Route("api/API_DigitalLibrary/SaveDigitalLibrary/")]
        [HttpPost]
        public HttpResponseMessage SaveDigitalLibrary(DigitalLibrary model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.IsActive == true ? 1 : 0;

                xml.AddElement("Id", Convert.ToString(model.Id));
                xml.AddElement("SectorId", Convert.ToString(model.SectorId));
                xml.AddElement("ClusterId", Convert.ToString(model.ClusterId));
                xml.AddElement("Description", (model.Description));
                xml.AddElement("FileType", (model.FileType));
                xml.AddElement("FileUrl", (model.FileUrl));
                xml.AddElement("ImageUrl", (model.ImageUrl));
                xml.AddElement("IsActive", Convert.ToString(status));
                xml.AddElement("CreatedDate", (model.CreatedDate.ToString()));
                xml.AddElement("CreatedBy", model.CreatedBy);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveDigitalLibrary", xml.GetXML("DigitalLibrary"));
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

        
        [Route("api/API_DigitalLibrary/DeleteDigitalLibrary/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteDigitalLibrary(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("DigitalLibrary_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteDigitalLibrary", xml.GetXML("DigitalLibrary"));
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
        [Route("api/API_DigitalLibrary/DeleteDigitalLibraryImage/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteDigitalLibraryImage(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("DigitalLibrary_image_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteDigitalLibraryImage", xml.GetXML("DigitalLibrary_image"));
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
