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
    public class API_UserController : API_BaseController
    {
        [Route("api/API_User/GetUserList/")]
        [HttpGet]
        public HttpResponseMessage GetUserList()
        {
            try
            {
                List<User> ListUser = new List<User>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetUserList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            User objUser = new User();

                            objUser.user_id = dr["user_id"] != DBNull.Value ? Convert.ToInt32(dr["user_id"]):0;
                            objUser.user_type_id = dr["user_type_id"] != DBNull.Value ? Convert.ToInt32(dr["user_type_id"]) : 0;
                            objUser.role_id = dr["role_id"] != DBNull.Value ? Convert.ToInt32(dr["role_id"]) : 0;
                            objUser.pincode = dr["pincode"] != DBNull.Value ? Convert.ToInt32(dr["pincode"]) : 0;
                            objUser.user_type_name = dr["user_type_name"] != DBNull.Value ? Convert.ToString(dr["user_type_name"]) :"";
                            objUser.first_name = dr["first_name"] != DBNull.Value ? Convert.ToString(dr["first_name"]) : "";
                            objUser.last_name = dr["last_name"] != DBNull.Value ? Convert.ToString(dr["last_name"]) : "";
                            objUser.role_name = dr["role_name"] != DBNull.Value ? Convert.ToString(dr["role_name"]) : "";
                            objUser.address = dr["address"] != DBNull.Value ? Convert.ToString(dr["address"]) : "";
                            objUser.mobile = dr["mobile"] != DBNull.Value ? Convert.ToString(dr["mobile"]) : "";
                            objUser.emailid = dr["emailid"] != DBNull.Value ? Convert.ToString(dr["emailid"]) : "";
                            ListUser.Add(objUser);
                        }
                    }
                    return Request.CreateResponse<List<User>>(HttpStatusCode.OK, ListUser);
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

        [Route("api/API_User/GetUserById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetUserById(Int32 id)
        {
            try
            {
                User objUser = new User();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("user_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("GetUserById", xml.GetXML("user"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objUser.user_id = dtData.Rows[0]["user_id"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["user_id"]) : 0; ;
                        objUser.user_type_id = dtData.Rows[0]["user_type_id"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["user_type_id"]) : 0;
                        objUser.role_id = dtData.Rows[0]["role_id"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["role_id"]) : 0; ;
                        objUser.state_id = dtData.Rows[0]["state_id"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["state_id"]) : 0; 
                        objUser.first_name = dtData.Rows[0]["first_name"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["first_name"]) : "";
                        objUser.last_name = dtData.Rows[0]["last_name"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["last_name"]) : "";
                        objUser.emailid = dtData.Rows[0]["emailid"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["emailid"]) : "";
                        objUser.password = dtData.Rows[0]["password"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["password"]) : "";
                        objUser.address= dtData.Rows[0]["address"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["address"]) : "";
                        objUser.pincode = dtData.Rows[0]["pincode"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["pincode"]) : 0;
                        objUser.city_name = dtData.Rows[0]["city_name"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["city_name"]) : "";
                        objUser.state_name = dtData.Rows[0]["state_name"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["state_name"]) : "";
                        objUser.user_type_name = dtData.Rows[0]["user_type_name"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["user_type_name"]) : "";
                        objUser.role_name = dtData.Rows[0]["role_name"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["role_name"]) : "";
                    }

                    return Request.CreateResponse<User>(HttpStatusCode.OK, objUser);
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

        [Route("api/API_User/SaveUser/")]
        [HttpPost]
        public HttpResponseMessage SaveUser(UserManageModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("user_id", Convert.ToString(model.User.user_id));
                xml.AddElement("user_type_id", Convert.ToString(model.User.user_type_id));
                xml.AddElement("emailid", Convert.ToString(model.User.emailid));
                xml.AddElement("password", Convert.ToString(model.User.password));
                xml.AddElement("first_name", Convert.ToString(model.User.first_name));
                xml.AddElement("last_name", Convert.ToString(model.User.last_name));
                xml.AddElement("address", Convert.ToString(model.User.address));
                xml.AddElement("state_id", Convert.ToString(model.User.state_id));
                xml.AddElement("city_name", Convert.ToString(model.User.city_name));
                xml.AddElement("pincode", Convert.ToString(model.User.pincode));
                xml.AddElement("mobile", Convert.ToString(model.User.mobile));
                xml.AddElement("created_by", Convert.ToString(model.created_by));

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveUser", xml.GetXML("user"));
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

        [Route("api/API_User/GetUserLogList/")]
        [HttpPost]
        public HttpResponseMessage GetUserLogList(List<String> ListParameter)
        {
            try
            {
                List<UserLog> ListUser = new List<UserLog>();
                XmlProcessor xml= new XmlProcessor();
                xml.AddElement("user_id", Convert.ToString(ListParameter[0]));



                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetUserLogList", xml.GetXML("user"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            UserLog objUserLog = new UserLog();

                            objUserLog.user_id = dr["user_id"] != DBNull.Value ? Convert.ToInt32(dr["user_id"]) : 0;
                            objUserLog.ip_address = dr["ip_address"] != DBNull.Value ? Convert.ToString(dr["ip_address"]) : "";
                            objUserLog.mac_address = dr["mac_address"] != DBNull.Value ? Convert.ToString(dr["mac_address"]) : "";
                            objUserLog.user_log_id = dr["user_log_id"] != DBNull.Value ? Convert.ToInt32(dr["user_log_id"]) : 0;
                           
                            ListUser.Add(objUserLog);
                        }
                    }
                    return Request.CreateResponse<List<UserLog>>(HttpStatusCode.OK, ListUser);
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
