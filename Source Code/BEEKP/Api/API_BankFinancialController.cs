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
    public class API_BankFinancialController : API_BaseController
    {
        [Route("api/API_BankFinancial/GetBankFinancialList/")]
        [HttpPost]
        public HttpResponseMessage GetBankFinancialList(List<String> _ListParameter)
        {
            try
            {
                List<BankFinancial> ListBankFinancial = new List<BankFinancial>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                xml.AddElement("approval_status", Convert.ToString(_ListParameter[1]));

                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetBankFinancialList", xml.GetXML("bank_financial"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            BankFinancial objBankFinancial = new BankFinancial();
                            objBankFinancial.bank_financial_id = Convert.ToInt32(dr["bank_financial_id"]);
                            objBankFinancial.institution_type_id = Convert.ToInt32(dr["institution_type_id"]);
                            objBankFinancial.institution_type_name = Convert.ToString(dr["institution_type_name"]);
                            objBankFinancial.organization_name = Convert.ToString(dr["organization_name"]);
                            objBankFinancial.address = Convert.ToString(dr["address"]);
                            objBankFinancial.telephone = Convert.ToString(dr["telephone"]);
                            objBankFinancial.fax = Convert.ToString(dr["fax"]);
                            objBankFinancial.email_id = Convert.ToString(dr["email_id"]);
                            objBankFinancial.cluster_id = Convert.ToInt32(dr["cluster_id"]);
                            objBankFinancial.cluster_name = Convert.ToString(dr["cluster_name"]);
                            objBankFinancial.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            if (dr["approval_status"] != DBNull.Value)
                            {
                                if (Convert.ToInt32(dr["approval_status"]) == Constants.APPROVAL_STATUS_APPROVED)
                                {
                                    objBankFinancial.approval_status_message = Constants.APPROVAL_STATUS_APPROVED_MESSAGE;
                                }
                                else if (Convert.ToInt32(dr["approval_status"]) == Constants.APPROVAL_STATUS_REJECTED)
                                {
                                    objBankFinancial.approval_status_message = Constants.APPROVAL_STATUS_REJECTED_MESSAGE;
                                }
                                else
                                {
                                    objBankFinancial.approval_status_message = Constants.APPROVAL_STATUS_PENDING_MESSAGE;
                                }
                            }
                            else
                            {
                                objBankFinancial.approval_status_message = "";
                            }

                            ListBankFinancial.Add(objBankFinancial);
                        }
                    }
                    return Request.CreateResponse<List<BankFinancial>>(HttpStatusCode.OK, ListBankFinancial);
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

        [Route("api/API_BankFinancial/GetBankFinancialById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetBankFinancialById(Int32 id)
        {
            try

            {
                BankFinancial objBankFinancial = new BankFinancial();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("bank_financial_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("GetBankFinancialById", xml.GetXML("bank_financial"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objBankFinancial.bank_financial_id = Convert.ToInt32(dtData.Rows[0]["bank_financial_id"]);
                        objBankFinancial.institution_type_id = Convert.ToInt32(dtData.Rows[0]["institution_type_id"]);
                        objBankFinancial.institution_type_name = Convert.ToString(dtData.Rows[0]["institution_type_name"]);
                        objBankFinancial.cluster_id = Convert.ToInt32(dtData.Rows[0]["cluster_id"]);
                        objBankFinancial.cluster_name = Convert.ToString(dtData.Rows[0]["cluster_name"]);
                        objBankFinancial.organization_name = Convert.ToString(dtData.Rows[0]["organization_name"]);
                        objBankFinancial.address = Convert.ToString(dtData.Rows[0]["address"]);
                        objBankFinancial.telephone = Convert.ToString(dtData.Rows[0]["telephone"]);
                        objBankFinancial.fax = Convert.ToString(dtData.Rows[0]["fax"]);
                        objBankFinancial.email_id = Convert.ToString(dtData.Rows[0]["email_id"]);
                        objBankFinancial.approval_status = Convert.ToInt32(dtData.Rows[0]["approval_status"]);
                        objBankFinancial.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;

                    }

                    return Request.CreateResponse<BankFinancial>(HttpStatusCode.OK, objBankFinancial);
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

        [Route("api/API_BankFinancial/SaveBankFinancial/")]
        [HttpPost]
        public HttpResponseMessage SaveBankFinancial(BankFinancialManageModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.BankFinancial.status == true ? 1 : 0;
                xml.AddElement("bank_financial_id", Convert.ToString(model.BankFinancial.bank_financial_id));
                xml.AddElement("institution_type_id", Convert.ToString(model.BankFinancial.institution_type_id));
                xml.AddElement("organization_name", Convert.ToString(model.BankFinancial.organization_name));
                xml.AddElement("address", Convert.ToString(model.BankFinancial.address));
                xml.AddElement("telephone", Convert.ToString(model.BankFinancial.telephone));
                xml.AddElement("fax", Convert.ToString(model.BankFinancial.fax));
                xml.AddElement("email_id", Convert.ToString(model.BankFinancial.email_id));
                xml.AddElement("cluster_id", Convert.ToString(model.BankFinancial.cluster_id));
                xml.AddElement("status", Convert.ToString(status));
                xml.AddElement("approval_status", Convert.ToString(model.BankFinancial.approval_status));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveBankFinancial", xml.GetXML("bank_financial"));
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

        [Route("api/API_BankFinancial/DeleteBankFinancial/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteBankFinancial(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("bank_financial_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteBankFinancial", xml.GetXML("bank_financial"));
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

        [Route("api/API_BankFinancial/GetBankFinancialListByInstitutionTypeAndCluster/")]
        [HttpPost]
        public HttpResponseMessage GetBankFinancialListByInstitutionTypeAndCluster(List<String> _ListParameter)
        {
            try
            {
                List<BankFinancial> ListBankFinancial = new List<BankFinancial>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("institution_type_id", Convert.ToString(_ListParameter[0]));
                xml.AddElement("cluster_id", Convert.ToString(_ListParameter[1]));

                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetBankFinancialListByInstitutionTypeAndCluster", xml.GetXML("bank_financial"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            BankFinancial objBankFinancial = new BankFinancial();
                            objBankFinancial.bank_financial_id = Convert.ToInt32(dr["bank_financial_id"]);
                            objBankFinancial.institution_type_id = Convert.ToInt32(dr["institution_type_id"]);
                            objBankFinancial.institution_type_name = Convert.ToString(dr["institution_type_name"]);
                            objBankFinancial.organization_name = Convert.ToString(dr["organization_name"]);
                            objBankFinancial.address = Convert.ToString(dr["address"]);
                            objBankFinancial.telephone = Convert.ToString(dr["telephone"]);
                            objBankFinancial.fax = Convert.ToString(dr["fax"]);
                            objBankFinancial.email_id = Convert.ToString(dr["email_id"]);
                            objBankFinancial.cluster_id = Convert.ToInt32(dr["cluster_id"]);
                            objBankFinancial.cluster_name = Convert.ToString(dr["cluster_name"]);
                            objBankFinancial.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            if (dr["approval_status"] != DBNull.Value)
                            {
                                if (Convert.ToInt32(dr["approval_status"]) == Constants.APPROVAL_STATUS_APPROVED)
                                {
                                    objBankFinancial.approval_status_message = Constants.APPROVAL_STATUS_APPROVED_MESSAGE;
                                }
                                else if (Convert.ToInt32(dr["approval_status"]) == Constants.APPROVAL_STATUS_REJECTED)
                                {
                                    objBankFinancial.approval_status_message = Constants.APPROVAL_STATUS_REJECTED_MESSAGE;
                                }
                                else
                                {
                                    objBankFinancial.approval_status_message = Constants.APPROVAL_STATUS_PENDING_MESSAGE;
                                }
                            }
                            else
                            {
                                objBankFinancial.approval_status_message = "";
                            }

                            ListBankFinancial.Add(objBankFinancial);
                        }
                    }
                    return Request.CreateResponse<List<BankFinancial>>(HttpStatusCode.OK, ListBankFinancial);
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
