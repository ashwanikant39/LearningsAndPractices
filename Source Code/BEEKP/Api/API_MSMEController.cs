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
    public class API_MSMEController : API_BaseController
    {
        [Route("api/API_MSME/GetMSMEList/")]
        [HttpPost]
        public HttpResponseMessage GetMSMEList(List<String> _ListParameter)
        {
            try
            {
                List<MSME> ListMSME = new List<MSME>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                xml.AddElement("approval_status", Convert.ToString(_ListParameter[1]));
                xml.AddElement("page_no", Convert.ToString(_ListParameter[2]));
                xml.AddElement("page_size", Convert.ToString(_ListParameter[3]));
                xml.AddElement("Search", Convert.ToString(_ListParameter[4]));

                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData =new DataTable();
                DataSet dataSet= objCDataAccess.GetDataSetTableSP("GetMSMEList", xml.GetXML("msme"));
                dtData = dataSet.Tables[0];
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            MSME objMSME = new MSME();

                            objMSME.msme_id = Convert.ToInt32(dr["msme_id"]);
                            objMSME.type_unit = Convert.ToInt32(dr["type_unit"]);
                            objMSME.sector_id = Convert.ToInt32(dr["sector_id"]);
                            objMSME.sector_name = Convert.ToString(dr["sector_name"]);
                            objMSME.unit_name = Convert.ToString(dr["unit_name"]);
                            objMSME.unit_address = Convert.ToString(dr["unit_address"]);
                            objMSME.contact_name = Convert.ToString(dr["contact_name"]);
                            objMSME.email_id = Convert.ToString(dr["email_id"]);
                            objMSME.cluster_id = Convert.ToInt32(dr["cluster_id"]);
                            objMSME.cluster_name = Convert.ToString(dr["cluster_name"]);
                            objMSME.WTA_conducted = Convert.ToInt32(dr["WTA_conducted"]) == 1 ? true : false; ;
                            objMSME.DEA_conducted = Convert.ToInt32(dr["DEA_conducted"]) == 1 ? true : false; ;
                            objMSME.cluster_name = Convert.ToString(dr["cluster_name"]);
                            objMSME.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            objMSME.approval_status = Convert.ToInt32(dr["approval_status"]) == 1 ? true : false;
                            objMSME.sMSMEID = BEEKP.Class.Encryption.Encrypt(dr["msme_id"].ToString(), true);
                            ListMSME.Add(objMSME);
                        }
                    }
                    AdminMSMEViewModel adminMSMEView = new AdminMSMEViewModel();
                    adminMSMEView.ListMSMEActive=ListMSME;
                    adminMSMEView.TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0]["Total"]);
                    return Request.CreateResponse<AdminMSMEViewModel>(HttpStatusCode.OK, adminMSMEView);
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
        [Route("api/API_MSME/SaveMSME/")]
        [HttpPost]
        public HttpResponseMessage SaveMSME(AdminMSMEManageModel model)
       {
            try
            {
                
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.MSME.status == true ? 1 : 0;
                int WTA_conducted = model.MSME.WTA_conducted == true ? 1 : 0;
                int DEA_conducted = model.MSME.DEA_conducted == true ? 1 : 0;
                int approval_status = model.MSME.approval_status == true ? 1 : 0;
                xml.AddElement("msme_id", Convert.ToString(model.MSME.msme_id));
                xml.AddElement("type_unit", Convert.ToString(model.MSME.type_unit));
                xml.AddElement("sector_id", Convert.ToString(model.MSME.sector_id));
                xml.AddElement("sector_name", Convert.ToString(model.MSME.sector_name));
                xml.AddElement("unit_name", Convert.ToString(model.MSME.unit_name));
                xml.AddElement("unit_address", Convert.ToString(model.MSME.unit_address));
                xml.AddElement("contact_name", Convert.ToString(model.MSME.contact_name));
                xml.AddElement("email_id", Convert.ToString(model.MSME.email_id));
                xml.AddElement("cluster_id", Convert.ToString(model.MSME.cluster_id));
                xml.AddElement("cluster_name", Convert.ToString(model.MSME.cluster_name));
                xml.AddElement("status", Convert.ToString(status));
                xml.AddElement("WTA_conducted", Convert.ToString(WTA_conducted));
                xml.AddElement("DEA_conducted", Convert.ToString(DEA_conducted));
                xml.AddElement("approval_status", Convert.ToString(approval_status));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveMSME", xml.GetXML("msme"));
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
        [Route("api/API_MSME/GetMSMEById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetMSMEById(Int32 id)
        {
            try

            {
                MSME objMSME = new MSME();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("msme_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("GetMSMEById", xml.GetXML("msme"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objMSME.msme_id = Convert.ToInt32(dtData.Rows[0]["msme_id"]);
                        objMSME.type_unit = Convert.ToInt32(dtData.Rows[0]["type_unit"]);
                        objMSME.sector_id = Convert.ToInt32(dtData.Rows[0]["sector_id"]);
                        objMSME.sector_name = Convert.ToString(dtData.Rows[0]["sector_name"].ToString());
                        objMSME.unit_name = Convert.ToString(dtData.Rows[0]["unit_name"]);
                        objMSME.unit_address = Convert.ToString(dtData.Rows[0]["unit_address"]);
                        objMSME.contact_name = Convert.ToString(dtData.Rows[0]["contact_name"]);
                        objMSME.email_id = Convert.ToString(dtData.Rows[0]["email_id"]);
                        objMSME.cluster_id = Convert.ToInt32(dtData.Rows[0]["cluster_id"]);
                        objMSME.cluster_name = Convert.ToString(dtData.Rows[0]["cluster_name"]);
                        objMSME.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;
                        objMSME.DEA_conducted = Convert.ToInt32(dtData.Rows[0]["DEA_conducted"]) == 1 ? true : false;
                        objMSME.approval_status = Convert.ToInt32(dtData.Rows[0]["approval_status"]) == 1 ? true : false;
                        objMSME.WTA_conducted = Convert.ToInt32(dtData.Rows[0]["WTA_conducted"]) == 1 ? true : false;


                    }

                    return Request.CreateResponse<MSME>(HttpStatusCode.OK, objMSME);
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

        [Route("api/API_MSME/DeleteMSME/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteMSME(Int32 id)
        {
            try
            {
               
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("msme_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteMSME", xml.GetXML("msme"));
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

        [Route("api/API_MSME/GetMSMEListByClusterIdAndSectorId/")]
        [HttpPost]
        public HttpResponseMessage GetMSMEListByClusterIdAndSectorId(List<String> _ListParameter)
        {

            try
            {
                List<MSME> ListMSME = new List<MSME>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("cluster_id", Convert.ToString(_ListParameter[0]));
                xml.AddElement("sector_id", Convert.ToString(_ListParameter[1]));
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetMSMEListByClusterIdAndSectorId", xml.GetXML("msme"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            MSME objMSME = new MSME();
                            objMSME.msme_id = Convert.ToInt32(dr["msme_id"]);
                            objMSME.type_unit = Convert.ToInt32(dr["type_unit"]);
                            objMSME.sector_id = Convert.ToInt32(dr["sector_id"]);
                            objMSME.sector_name = Convert.ToString(dr["sector_name"]);
                            objMSME.unit_name = Convert.ToString(dr["unit_name"]);
                            objMSME.unit_address = Convert.ToString(dr["unit_address"]);
                            objMSME.contact_name = Convert.ToString(dr["contact_name"]);
                            objMSME.email_id = Convert.ToString(dr["email_id"]);
                            objMSME.cluster_id = Convert.ToInt32(dr["cluster_id"]);
                            objMSME.cluster_name = Convert.ToString(dr["cluster_name"]);
                            objMSME.WTA_conducted = Convert.ToInt32(dr["WTA_conducted"]) == 1 ? true : false; ;
                            objMSME.DEA_conducted = Convert.ToInt32(dr["DEA_conducted"]) == 1 ? true : false; ;
                            objMSME.cluster_name = Convert.ToString(dr["cluster_name"]);
                            objMSME.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            objMSME.approval_status = Convert.ToInt32(dr["approval_status"]) == 1 ? true : false;
                            ListMSME.Add(objMSME);
                        }
                    }
                    return Request.CreateResponse<List<MSME>>(HttpStatusCode.OK, ListMSME);
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
