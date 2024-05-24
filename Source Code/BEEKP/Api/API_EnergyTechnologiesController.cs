using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using BEEKP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BEEKP.Api
{
    public class API_EnergyTechnologiesController : API_BaseController
    {
        [Route("api/API_EnergyTechnologies/GetEnergyTechnologiesList/")]
        [HttpPost]
        public HttpResponseMessage GetEnergyTechnologiesList(List<String> _ListParameter)
        {

            try
            {
                List<EnergyTechnology> ListEnergyTechnology = new List<EnergyTechnology>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                //xml.AddElement("cluster_id",Convert.ToString(_ListParameter[1]));
                xml.AddElement("category_measure_id", Convert.ToString(_ListParameter[1]));
                xml.AddElement("page_no", Convert.ToString(_ListParameter[2]));
                xml.AddElement("page_size", Convert.ToString(_ListParameter[3]));
                xml.AddElement("Search", Convert.ToString(_ListParameter[4]));

                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = new DataTable();
                DataSet dataSet = objCDataAccess.GetDataSetTableSP("GetEnergyTechnologiesList", xml.GetXML("energy_technologies"));
                dtData = dataSet.Tables[0];

                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            EnergyTechnology objEnergyTechnology = new EnergyTechnology();
                            objEnergyTechnology.EE_technology_id = Convert.ToInt32(dr["EE_technology_id"]);
                            objEnergyTechnology.category_measure_id = Convert.ToInt32(dr["category_measure_id"]);
                            objEnergyTechnology.category_measure_name = Convert.ToString(dr["category_measure_name"]);
                            //objEnergyTechnology.cluster_id = Convert.ToInt32(dr["cluster_id"]);
                            objEnergyTechnology.clusters = Convert.ToString(dr["clusters"]);
                            objEnergyTechnology.EE_measure = Convert.ToString(dr["EE_measure"]);
                            objEnergyTechnology.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            objEnergyTechnology.sEE_technology_id= BEEKP.Class.Encryption.Encrypt(dr["EE_technology_id"].ToString(), true);
                            ListEnergyTechnology.Add(objEnergyTechnology);
                        }
                    }
                    AdminEnergyTechnologiesViewModel model = new AdminEnergyTechnologiesViewModel();
                    model.ListEnergyTechnologyActive = ListEnergyTechnology;
                    model.TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0]["Total"]);
                    return Request.CreateResponse<AdminEnergyTechnologiesViewModel>(HttpStatusCode.OK, model);
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

        [Route("api/API_EnergyTechnologies/SaveEnergyTechnologies/")]
        [HttpPost]
        public HttpResponseMessage SaveEnergyTechnologies(EnergyTechnologiesManageModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();

                int status = model.EnergyTechnology.status == true ? 1 : 0;
                xml.AddElement("EE_technology_id", Convert.ToString(model.EnergyTechnology.EE_technology_id));
                xml.AddElement("category_measure_id", Convert.ToString(model.EnergyTechnology.category_measure_id));
                xml.AddElement("category_measure_name", Convert.ToString(model.EnergyTechnology.category_measure_name));
                xml.AddElement("EE_measure", Convert.ToString(model.EnergyTechnology.EE_measure));
                //xml.AddElement("cluster_id", Convert.ToString(model.EnergyTechnology.cluster_id));
                xml.AddElement("clusters", Convert.ToString(model.EnergyTechnology.clusters));
                xml.AddElement("status", Convert.ToString(status));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveEnergyTechnologies", xml.GetXML("energy_technologies"));
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

        [Route("api/API_EnergyTechnology/GetEnergyTechnologiesById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetEnergyTechnologiesById(Int32 id)
        {
            try

            {
                EnergyTechnology objEnergyTechnology = new EnergyTechnology();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("EE_technology_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("GetEnergyTechnologiesById", xml.GetXML("energy_technologies"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objEnergyTechnology.EE_technology_id = Convert.ToInt32(dtData.Rows[0]["EE_technology_id"]);
                        objEnergyTechnology.category_measure_id = Convert.ToInt32(dtData.Rows[0]["category_measure_id"]);
                        objEnergyTechnology.category_measure_name = Convert.ToString(dtData.Rows[0]["category_measure_name"]);
                        //objEnergyTechnology.cluster_id = Convert.ToInt32(dtData.Rows[0]["cluster_id"]);
                        objEnergyTechnology.clusters = Convert.ToString(dtData.Rows[0]["clusters"]);
                        objEnergyTechnology.EE_measure = Convert.ToString(dtData.Rows[0]["EE_measure"]);
                        objEnergyTechnology.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;

                    }

                    return Request.CreateResponse<EnergyTechnology>(HttpStatusCode.OK, objEnergyTechnology);
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

        [Route("api/API_EnergyTechnologies/DeleteEnergyTechnologies/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteEnergyTechnologies(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("EE_technology_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteEnergyTechnologies", xml.GetXML("energy_technologies"));
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
