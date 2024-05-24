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
    public class API_ManufacturersController : API_BaseController
    {
        [Route("api/API_Manufacturers/GetManufacturersList/")]
        [HttpPost]
        public HttpResponseMessage GetManufacturersList(List<String> _ListParameter)
        {
            try
            {
                List<Manufacturers> ListManufacturers = new List<Manufacturers>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                xml.AddElement("approval_status", Convert.ToString(_ListParameter[1]));
                xml.AddElement("page_no", Convert.ToString(_ListParameter[2]));
                xml.AddElement("page_size", Convert.ToString(_ListParameter[3]));
                xml.AddElement("Search", Convert.ToString(_ListParameter[4]));

                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = new DataTable();
                DataSet dataSet = objCDataAccess.GetDataSetTableSP("GetManufacturerList", xml.GetXML("manufacturer"));
                dtData = dataSet.Tables[0];

                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Manufacturers objManufacturers = new Manufacturers();
                            objManufacturers.manufacturer_id = Convert.ToInt32(dr["manufacturer_id"]);
                            objManufacturers.EE_equipment_id = Convert.ToInt32(dr["EE_equipment_id"]);
                            objManufacturers.EE_equipment_name = Convert.ToString(dr["EE_equipment_name"]);
                            objManufacturers.name_manufacturer = Convert.ToString(dr["name_manufacturer"]);
                            objManufacturers.contact_address = Convert.ToString(dr["contact_address"]);
                            objManufacturers.contact_person = Convert.ToString(dr["contact_person"]);
                            objManufacturers.contact_no = Convert.ToString(dr["contact_no"]);
                            objManufacturers.email = Convert.ToString(dr["email"]);
                            objManufacturers.website = Convert.ToString(dr["website"]);
                            objManufacturers.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            objManufacturers.smanufacturer_id= BEEKP.Class.Encryption.Encrypt(dr["manufacturer_id"].ToString(), true);
                            if (dr["approval_status"] != DBNull.Value)
                            {
                                if (Convert.ToInt32(dr["approval_status"]) == Constants.APPROVAL_STATUS_APPROVED)
                                {
                                    objManufacturers.approval_status_message = Constants.APPROVAL_STATUS_APPROVED_MESSAGE;
                                }
                                else if (Convert.ToInt32(dr["approval_status"]) == Constants.APPROVAL_STATUS_REJECTED)
                                {
                                    objManufacturers.approval_status_message = Constants.APPROVAL_STATUS_REJECTED_MESSAGE;
                                }
                                else
                                {
                                    objManufacturers.approval_status_message = Constants.APPROVAL_STATUS_PENDING_MESSAGE;
                                }
                            }
                            else
                            {
                                objManufacturers.approval_status_message = "";
                            }

                            ListManufacturers.Add(objManufacturers);
                        }
                    }
                    AdminManufacturersViewModel adminManufacturers = new AdminManufacturersViewModel();
                    adminManufacturers.ListManufacturers = ListManufacturers;
                    adminManufacturers.TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0]["Total"]);
                    return Request.CreateResponse<AdminManufacturersViewModel>(HttpStatusCode.OK, adminManufacturers);
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

        [Route("api/API_Manufacturers/SaveManufacturers/")]
        [HttpPost]
        public HttpResponseMessage SaveManufacturers(ManufacturersManageModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.Manufacturers.status == true ? 1 : 0;
                
                xml.AddElement("manufacturer_id", Convert.ToString(model.Manufacturers.manufacturer_id));
                xml.AddElement("EE_equipment_id", Convert.ToString(model.Manufacturers.EE_equipment_id));
                xml.AddElement("name_manufacturer", Convert.ToString(model.Manufacturers.name_manufacturer));
                xml.AddElement("contact_address", Convert.ToString(model.Manufacturers.contact_address));
                xml.AddElement("contact_person", Convert.ToString(model.Manufacturers.contact_person));
                xml.AddElement("contact_no", Convert.ToString(model.Manufacturers.contact_no));
                xml.AddElement("email", Convert.ToString(model.Manufacturers.email));
                xml.AddElement("website", Convert.ToString(model.Manufacturers.website));
                xml.AddElement("approval_status", Convert.ToString(model.Manufacturers.approval_status));
                xml.AddElement("status", Convert.ToString(status));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveManufacturer", xml.GetXML("manufacturer"));
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
        [Route("api/API_Manufacturers/GetManufacturersById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetManufacturersById(Int32 id)
        {
            try

            {
                Manufacturers objManufacturers = new Manufacturers();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("manufacturer_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("GetManufacturerById", xml.GetXML("manufacturer"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objManufacturers.manufacturer_id = Convert.ToInt32(dtData.Rows[0]["manufacturer_id"]);
                        objManufacturers.EE_equipment_id = Convert.ToInt32(dtData.Rows[0]["EE_equipment_id"]);
                        objManufacturers.EE_equipment_name = Convert.ToString(dtData.Rows[0]["EE_equipment_name"]);
                        objManufacturers.name_manufacturer = Convert.ToString(dtData.Rows[0]["name_manufacturer"]);
                        objManufacturers.contact_address = Convert.ToString(dtData.Rows[0]["contact_address"]);
                        objManufacturers.contact_person = Convert.ToString(dtData.Rows[0]["contact_person"]);
                        objManufacturers.contact_no = Convert.ToString(dtData.Rows[0]["contact_no"]);
                        objManufacturers.email = Convert.ToString(dtData.Rows[0]["email"]);
                        objManufacturers.website = Convert.ToString(dtData.Rows[0]["website"]);
                        objManufacturers.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;
                        objManufacturers.approval_status = Convert.ToInt32(dtData.Rows[0]["approval_status"]);

                    }

                    return Request.CreateResponse<Manufacturers>(HttpStatusCode.OK, objManufacturers);
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

        [Route("api/API_Manufacturers/DeleteManufacturers/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteManufacturers(Int32 id)
        {
            try
            {
                Manufacturers objManufacturers = new Manufacturers();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("manufacturer_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteManufacturer", xml.GetXML("manufacturer"));
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

        [Route("api/API_Manufacturers/GetManufacturerListByEEEquipmentId/")]
        [HttpPost]
        public HttpResponseMessage GetManufacturerListByEEEquipmentId(List<String> _ListParameter)
        {

            try
            {
                List<Manufacturers> ListManufacturers = new List<Manufacturers>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("EE_equipment_id", Convert.ToString(_ListParameter[0]));
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetManufacturerListByEEEquipmentId", xml.GetXML("manufacturer"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Manufacturers objManufacturers = new Manufacturers();
                            objManufacturers.manufacturer_id = Convert.ToInt32(dr["manufacturer_id"]);
                            objManufacturers.EE_equipment_id = Convert.ToInt32(dr["EE_equipment_id"]);
                            objManufacturers.EE_equipment_name = Convert.ToString(dr["EE_equipment_name"]);
                            objManufacturers.name_manufacturer = Convert.ToString(dr["name_manufacturer"]);
                            objManufacturers.contact_address = Convert.ToString(dr["contact_address"]);
                            objManufacturers.contact_person = Convert.ToString(dr["contact_person"]);
                            objManufacturers.contact_no = Convert.ToString(dr["contact_no"]);
                            objManufacturers.email = Convert.ToString(dr["email"]);
                            objManufacturers.website = Convert.ToString(dr["website"]);
                            objManufacturers.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            if (dr["approval_status"] != DBNull.Value)
                            {
                                if (Convert.ToInt32(dr["approval_status"]) == Constants.APPROVAL_STATUS_APPROVED)
                                {
                                    objManufacturers.approval_status_message = Constants.APPROVAL_STATUS_APPROVED_MESSAGE;
                                }
                                else if (Convert.ToInt32(dr["approval_status"]) == Constants.APPROVAL_STATUS_REJECTED)
                                {
                                    objManufacturers.approval_status_message = Constants.APPROVAL_STATUS_REJECTED_MESSAGE;
                                }
                                else
                                {
                                    objManufacturers.approval_status_message = Constants.APPROVAL_STATUS_PENDING_MESSAGE;
                                }
                            }
                            else
                            {
                                objManufacturers.approval_status_message = "";
                            }
                            ListManufacturers.Add(objManufacturers);
                        }
                    }
                    return Request.CreateResponse<List<Manufacturers>>(HttpStatusCode.OK, ListManufacturers);
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
