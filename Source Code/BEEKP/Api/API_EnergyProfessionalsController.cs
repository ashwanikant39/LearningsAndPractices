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
    public class API_EnergyProfessionalsController : API_BaseController
    {
        [Route("api/API_EnergyProfessionals/GetEnergyProfessionalList/")]
        [HttpPost]
        public HttpResponseMessage GetEnergyProfessionalList(List<String> _ListParameter)
        {

            try
            {
                List<EnergyProfessionals> ListEnergyProfessionals = new List<EnergyProfessionals>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                xml.AddElement("approval_status", Convert.ToString(_ListParameter[1]));
                xml.AddElement("page_no", Convert.ToString(_ListParameter[2]));
                xml.AddElement("page_size", Convert.ToString(_ListParameter[3]));
                xml.AddElement("Search", Convert.ToString(_ListParameter[4]));

                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = new DataTable();
                DataSet dataSet = objCDataAccess.GetDataSetTableSP("GetEnergyProfessionalList", xml.GetXML("energy_professional"));
                dtData = dataSet.Tables[0];
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            EnergyProfessionals objEnergyProfessionals = new EnergyProfessionals();
                            objEnergyProfessionals.energy_professional_id = Convert.ToInt32(dr["energy_professional_id"]);
                            objEnergyProfessionals.name = Convert.ToString(dr["name"]);
                            objEnergyProfessionals.organization_address = Convert.ToString(dr["organization_address"]);
                            objEnergyProfessionals.email_id = Convert.ToString(dr["email_id"]);
                            objEnergyProfessionals.area_specialization_id = Convert.ToInt32(dr["area_specialization_id"]);
                            objEnergyProfessionals.area_specialization_name = Convert.ToString(dr["area_specialization_name"]);
                            objEnergyProfessionals.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            objEnergyProfessionals.senergy_professional_id= BEEKP.Class.Encryption.Encrypt(dr["energy_professional_id"].ToString(), true);
                            if (dr["approval_status"] != DBNull.Value)
                            {
                                if (Convert.ToInt32(dr["approval_status"]) == Constants.APPROVAL_STATUS_APPROVED)
                                {
                                    objEnergyProfessionals.approval_status_message = Constants.APPROVAL_STATUS_APPROVED_MESSAGE;
                                }
                                else if (Convert.ToInt32(dr["approval_status"]) == Constants.APPROVAL_STATUS_REJECTED)
                                {
                                    objEnergyProfessionals.approval_status_message = Constants.APPROVAL_STATUS_REJECTED_MESSAGE;
                                }
                                else
                                {
                                    objEnergyProfessionals.approval_status_message = Constants.APPROVAL_STATUS_PENDING_MESSAGE;
                                }
                            }
                            else
                            {
                                objEnergyProfessionals.approval_status_message = "";
                            }
                            ListEnergyProfessionals.Add(objEnergyProfessionals);
                        }
                    }
                    AdminEnergyProfessionalsViewModel model = new AdminEnergyProfessionalsViewModel();
                    model.ListEnergyProfessionalsActive = ListEnergyProfessionals;
                    model.TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0]["Total"]);
                    return Request.CreateResponse<AdminEnergyProfessionalsViewModel>(HttpStatusCode.OK, model);
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

        [Route("api/API_EnergyProfessionals/SaveEnergyProfessional/")]
        [HttpPost]
        public HttpResponseMessage SaveEnergyProfessional(EnergyProfessionalsManageModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.EnergyProfessionals.status == true ? 1 : 0;
                xml.AddElement("energy_professional_id", Convert.ToString(model.EnergyProfessionals.energy_professional_id));
                xml.AddElement("name", Convert.ToString(model.EnergyProfessionals.name));
                xml.AddElement("organization_address", Convert.ToString(model.EnergyProfessionals.organization_address));
                xml.AddElement("email_id", Convert.ToString(model.EnergyProfessionals.email_id));
                xml.AddElement("area_specialization_id", Convert.ToString(model.EnergyProfessionals.area_specialization_id));
                xml.AddElement("area_specialization_name", Convert.ToString(model.EnergyProfessionals.area_specialization_name));
                xml.AddElement("approval_status", Convert.ToString(model.EnergyProfessionals.approval_status));
                xml.AddElement("status", Convert.ToString(status));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveEnergyProfessional", xml.GetXML("energy_professional"));
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

        [Route("api/API_EnergyProfessionals/GetEnergyProfessionalById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetEnergyProfessionalById(Int32 id)
        {
            try

            {
                EnergyProfessionals objEnergyProfessionals = new EnergyProfessionals();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("energy_professional_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("GetEnergyProfessionalById", xml.GetXML("energy_professional"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objEnergyProfessionals.energy_professional_id = Convert.ToInt32(dtData.Rows[0]["energy_professional_id"]);
                        objEnergyProfessionals.name = Convert.ToString(dtData.Rows[0]["name"]);
                        objEnergyProfessionals.organization_address = Convert.ToString(dtData.Rows[0]["organization_address"]);
                        objEnergyProfessionals.email_id = Convert.ToString(dtData.Rows[0]["email_id"]);
                        objEnergyProfessionals.area_specialization_id = Convert.ToInt32(dtData.Rows[0]["area_specialization_id"]);
                        objEnergyProfessionals.area_specialization_name = Convert.ToString(dtData.Rows[0]["area_specialization_name"]);
                        objEnergyProfessionals.approval_status = Convert.ToInt32(dtData.Rows[0]["approval_status"]);
                        objEnergyProfessionals.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;

                    }

                    return Request.CreateResponse<EnergyProfessionals>(HttpStatusCode.OK, objEnergyProfessionals);
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

        [Route("api/API_EnergyProfessionals/DeleteEnergyProfessional/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteEnergyProfessional(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("energy_professional_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteEnergyProfessional", xml.GetXML("energy_professional"));
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

        [Route("api/API_EnergyProfessionals/EnergyProfessionalListByAreaSpecialization/")]
        [HttpPost]
        public HttpResponseMessage EnergyProfessionalListByAreaSpecialization(List<String> _ListParameter)
        {

            try
            {
                List<EnergyProfessionals> ListEnergyProfessionals = new List<EnergyProfessionals>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("area_specialization_id", Convert.ToString(_ListParameter[0]));
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetEnergyProfessionalListByAreaSpecializationId", xml.GetXML("energy_professional"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            EnergyProfessionals objEnergyProfessionals = new EnergyProfessionals();
                            objEnergyProfessionals.energy_professional_id = Convert.ToInt32(dr["energy_professional_id"]);
                            objEnergyProfessionals.name = Convert.ToString(dr["name"]);
                            objEnergyProfessionals.organization_address = Convert.ToString(dr["organization_address"]);
                            objEnergyProfessionals.email_id = Convert.ToString(dr["email_id"]);
                            objEnergyProfessionals.area_specialization_id = Convert.ToInt32(dr["area_specialization_id"]);
                            objEnergyProfessionals.area_specialization_name = Convert.ToString(dr["area_specialization_name"]);
                            objEnergyProfessionals.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            if (dr["approval_status"] != DBNull.Value)
                            {
                                if (Convert.ToInt32(dr["approval_status"]) == Constants.APPROVAL_STATUS_APPROVED)
                                {
                                    objEnergyProfessionals.approval_status_message = Constants.APPROVAL_STATUS_APPROVED_MESSAGE;
                                }
                                else if (Convert.ToInt32(dr["approval_status"]) == Constants.APPROVAL_STATUS_REJECTED)
                                {
                                    objEnergyProfessionals.approval_status_message = Constants.APPROVAL_STATUS_REJECTED_MESSAGE;
                                }
                                else
                                {
                                    objEnergyProfessionals.approval_status_message = Constants.APPROVAL_STATUS_PENDING_MESSAGE;
                                }
                            }
                            else
                            {
                                objEnergyProfessionals.approval_status_message = "";
                            }
                            ListEnergyProfessionals.Add(objEnergyProfessionals);
                        }
                    }
                    return Request.CreateResponse<List<EnergyProfessionals>>(HttpStatusCode.OK, ListEnergyProfessionals);
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
