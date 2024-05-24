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
    public class API_ClusterDetailsController : API_BaseController
    {
        [Route("api/API_ClusterDetails/GetClusterDetailsList/")]
        [HttpGet]
        public HttpResponseMessage GetClusterDetailsList()
        {
            try
            {
                List<Cluster> ListCluster = new List<Cluster>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetClusterDetailsList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Cluster objCluster = new Cluster();

                            objCluster.cluster_id = Convert.ToInt32(dr["cluster_id"]);
                            objCluster.cluster_name = Convert.ToString(dr["cluster_name"]);
                            objCluster.location = dr["location"] != DBNull.Value ? Convert.ToString(dr["location"]) : "";
                            objCluster.products_manufactured = dr["products_manufactured"] != DBNull.Value ? Convert.ToString(dr["products_manufactured"]) : "";
                            objCluster.fuel_used = dr["fuel_used"] != DBNull.Value ? Convert.ToString(dr["fuel_used"]) : "";
                            objCluster.number_of_units = dr["number_of_units"] != DBNull.Value ? Convert.ToInt32(dr["number_of_units"]) : 0;
                            objCluster.overall_turnover = dr["overall_turnover"] != DBNull.Value ? Convert.ToDecimal(dr["overall_turnover"]) : 0;
                            objCluster.cluster_profile = dr["cluster_profile"] != DBNull.Value ? Convert.ToString(dr["cluster_profile"]) : "";
                            objCluster.cluster_doc_hindi = dr["cluster_doc_hindi"] != DBNull.Value ? Convert.ToString(dr["cluster_doc_hindi"]) : "";
                            objCluster.cluster_doc_english = dr["cluster_doc_english"] != DBNull.Value ? Convert.ToString(dr["cluster_doc_english"]) : "";
                            objCluster.cluster_doc_marathi = dr["cluster_doc_marathi"] != DBNull.Value ? Convert.ToString(dr["cluster_doc_marathi"]) : "";
                            objCluster.phases_id = Convert.ToInt32(dr["phases_id"]);
                            objCluster.phases_title = Convert.ToString(dr["phases_title"]);

                            ListCluster.Add(objCluster);
                        }
                    }
                    return Request.CreateResponse<List<Cluster>>(HttpStatusCode.OK, ListCluster);
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

        [Route("api/API_ClusterDetails/GetClusterDetailsById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetClusterDetailsById(Int32 id)
        {
            try
            {
                Cluster objCluster = new Cluster();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("cluster_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetClusterDetailsById", xml.GetXML("cluster_details"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objCluster.cluster_id = Convert.ToInt32(dtData.Rows[0]["cluster_id"].ToString());
                        objCluster.cluster_name = Convert.ToString(dtData.Rows[0]["cluster_name"]);
                        objCluster.location = Convert.ToString(dtData.Rows[0]["location"]);
                        objCluster.products_manufactured = Convert.ToString(dtData.Rows[0]["products_manufactured"]);
                        objCluster.fuel_used = dtData.Rows[0]["fuel_used"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["fuel_used"]) : "";
                        objCluster.number_of_units = dtData.Rows[0]["number_of_units"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["number_of_units"]) : 0;
                        objCluster.overall_turnover = dtData.Rows[0]["overall_turnover"] != DBNull.Value ? Convert.ToDecimal(dtData.Rows[0]["overall_turnover"]) : 0;
                        objCluster.cluster_profile = dtData.Rows[0]["cluster_profile"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["cluster_profile"]):"";
                        objCluster.cluster_doc_hindi = dtData.Rows[0]["cluster_doc_hindi"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["cluster_doc_hindi"]) : "";
                        objCluster.cluster_doc_english = dtData.Rows[0]["cluster_doc_english"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["cluster_doc_english"]) : "";
                        objCluster.cluster_doc_marathi = dtData.Rows[0]["cluster_doc_marathi"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["cluster_doc_marathi"]) : "";
                        objCluster.phases_id = Convert.ToInt32(dtData.Rows[0]["phases_id"]);
                        objCluster.phases_title = Convert.ToString(dtData.Rows[0]["phases_title"]);
                    }

                    return Request.CreateResponse<Cluster>(HttpStatusCode.OK, objCluster);
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
        [Route("api/API_ClusterDetails/SaveClusterDetails/")]
        [HttpPost]
        public HttpResponseMessage SaveClusterDetails(ClusterDetailsAddEditModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();

                xml.AddElement("cluster_id", Convert.ToString(model.Cluster.cluster_id));
                xml.AddElement("cluster_name", Convert.ToString(model.Cluster.cluster_name));
                xml.AddElement("location", Convert.ToString(model.Cluster.location));
                xml.AddElement("products_manufactured", Convert.ToString(model.Cluster.products_manufactured));
                xml.AddElement("fuel_used", Convert.ToString(model.Cluster.fuel_used));
                xml.AddElement("number_of_units", Convert.ToString(model.Cluster.number_of_units));
                xml.AddElement("overall_turnover", Convert.ToString(model.Cluster.overall_turnover));
                xml.AddElement("cluster_profile", Convert.ToString(model.Cluster.cluster_profile));
                xml.AddElement("cluster_doc_hindi", Convert.ToString(model.Cluster.cluster_doc_hindi));
                xml.AddElement("cluster_doc_english", Convert.ToString(model.Cluster.cluster_doc_english));
                xml.AddElement("cluster_doc_marathi", Convert.ToString(model.Cluster.cluster_doc_marathi));
                xml.AddElement("phases_id", Convert.ToString(model.Cluster.phases_id));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveClusterDetails", xml.GetXML("cluster_details"));
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
        [Route("api/API_ClusterDetails/DeleteClusterDetails/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteClusterDetails(Int32 id)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("cluster_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteClusterDetails", xml.GetXML("cluster_details"));
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

        [Route("api/API_ClusterDetails/GetClusterDetailsListByPhaseId/")]
        [HttpPost]
        public HttpResponseMessage GetClusterDetailsListByPhaseId(List<String> _ListParameter)
        {
            try
            {
                List<Cluster> ListCluster = new List<Cluster>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("phases_id", Convert.ToString(_ListParameter[0]));


                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetClusterDetailsListByPhaseId", xml.GetXML("cluster_details"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Cluster objCluster = new Cluster();

                            objCluster.cluster_id = Convert.ToInt32(dr["cluster_id"]);
                            objCluster.cluster_name = Convert.ToString(dr["cluster_name"]);
                            objCluster.location = dr["location"] != DBNull.Value ? Convert.ToString(dr["location"]) : "";
                            objCluster.products_manufactured = dr["products_manufactured"] != DBNull.Value ? Convert.ToString(dr["products_manufactured"]) : "";
                            objCluster.fuel_used = dr["fuel_used"] != DBNull.Value ? Convert.ToString(dr["fuel_used"]) : "";
                            objCluster.number_of_units = dr["number_of_units"] != DBNull.Value ? Convert.ToInt32(dr["number_of_units"]) : 0;
                            objCluster.overall_turnover = dr["overall_turnover"] != DBNull.Value ? Convert.ToDecimal(dr["overall_turnover"]) : 0;
                            objCluster.cluster_profile = dr["cluster_profile"] != DBNull.Value ? Convert.ToString(dr["cluster_profile"]) : "";
                            objCluster.cluster_doc_hindi = dr["cluster_doc_hindi"] != DBNull.Value ? Convert.ToString(dr["cluster_doc_hindi"]) : "";
                            objCluster.cluster_doc_english = dr["cluster_doc_english"] != DBNull.Value ? Convert.ToString(dr["cluster_doc_english"]) : "";
                            objCluster.cluster_doc_marathi = dr["cluster_doc_marathi"] != DBNull.Value ? Convert.ToString(dr["cluster_doc_marathi"]) : "";
                            objCluster.phases_id = Convert.ToInt32(dr["phases_id"]);
                            objCluster.phases_title = Convert.ToString(dr["phases_title"]);

                            ListCluster.Add(objCluster);
                        }
                    }
                    return Request.CreateResponse<List<Cluster>>(HttpStatusCode.OK, ListCluster);
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

