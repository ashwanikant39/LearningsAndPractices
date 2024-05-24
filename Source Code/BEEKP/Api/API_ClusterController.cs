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
    public class API_ClusterController : API_BaseController
    {
        [Route("api/API_Cluster/GetClusterList/")]
        [HttpPost]
        public HttpResponseMessage GetClusterList(List<String> _ListParameter)
        {
            try
            {
                List<AdminCluster> ListCluster = new List<AdminCluster>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("SectorId", Convert.ToString(_ListParameter[0]));
                xml.AddElement("IsActive", Convert.ToString(_ListParameter[1]));
                xml.AddElement("ALL", Convert.ToString(_ListParameter[2]));

                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetClusterList", xml.GetXML("Cluster"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            AdminCluster objCluster = new AdminCluster();

                            objCluster.Id = dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0;
                            objCluster.SectorName = dr["SectorName"] != DBNull.Value ? Convert.ToString(dr["SectorName"]) : "";
                            objCluster.ClusterName = dr["ClusterName"] != DBNull.Value ? Convert.ToString(dr["ClusterName"]) : "";
                            objCluster.CreatedDate = dr["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(dr["CreatedDate"]).Date : DateTime.Now.Date;
                            objCluster.IsActive = Convert.ToInt32(dr["IsActive"]) == 1 ? true : false;
                            ListCluster.Add(objCluster);
                        }
                    }
                    return Request.CreateResponse<List<AdminCluster>>(HttpStatusCode.OK, ListCluster);
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

        [Route("api/API_Cluster/GetClusterById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetClusterById(Int32 id)
        {
            try
            {
                AdminCluster objCluster = new AdminCluster();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("Id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetClusterById", xml.GetXML("Cluster"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        //objEvent.event_id = Convert.ToInt32(dtData.Rows[0]["event_id"].ToString());

                        objCluster.Id = dtData.Rows[0]["Id"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["Id"].ToString()) : 0;
                        objCluster.SectorId = dtData.Rows[0]["SectorId"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["SectorId"].ToString()) : 0;
                        objCluster.StateId = dtData.Rows[0]["StateId"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["StateId"].ToString()) : 0;
                        objCluster.ClusterName = Convert.ToString(dtData.Rows[0]["ClusterName"]);
                        objCluster.CreatedDate = Convert.ToDateTime(dtData.Rows[0]["CreatedDate"]);
                        objCluster.IsActive = Convert.ToInt32(dtData.Rows[0]["IsActive"]) == 1 ? true : false;
                    }
                    return Request.CreateResponse<AdminCluster>(HttpStatusCode.OK, objCluster);
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

       

        [Route("api/API_Cluster/SaveCluster/")]
        [HttpPost]
        public HttpResponseMessage SaveCluster(AdminCluster model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.IsActive == true ? 1 : 0;

                xml.AddElement("Id", Convert.ToString(model.Id));
                xml.AddElement("SectorId", Convert.ToString(model.SectorId));
                xml.AddElement("StateId", Convert.ToString(model.StateId));
                xml.AddElement("ClusterName", (model.ClusterName));
                xml.AddElement("IsActive", Convert.ToString(status));
                xml.AddElement("CreatedDate", (model.CreatedDate.ToString()));
                xml.AddElement("CreatedBy", model.CreatedBy);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveCluster", xml.GetXML("Cluster"));
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

        
        [Route("api/API_Cluster/DeleteCluster/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteCluster(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("Cluster_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteCluster", xml.GetXML("Cluster"));
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
        [Route("api/API_Cluster/DeleteClusterImage/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteClusterImage(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("Cluster_image_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteClusterImage", xml.GetXML("Cluster_image"));
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
