using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using System.Data;
using System.Xml;
using System.IO;
using System.Text;

namespace BEEKP.Api
{
    public class API_RoleController : API_BaseController
    {
        [Route("api/API_Role/GetRoleList/")]
        [HttpGet]
        public HttpResponseMessage GetRoleList()
        {
            try
            {
                List<Role> ListRole = new List<Role>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetRoleList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Role objRole = new Role();
                            objRole.role_id = Convert.ToInt32(dr["role_id"]);
                            objRole.role_name = Convert.ToString(dr["role_name"]);
                            objRole.role_description = Convert.ToString(dr["role_description"]);
                            objRole.user_type_id = Convert.ToInt32(dr["user_type_id"]);
                            objRole.user_type_name = Convert.ToString(dr["user_type_name"]);
                            objRole.file_id = Convert.ToInt32(dr["file_id"]);
                            objRole.file_name = Convert.ToString(dr["file_name"]);
                            ListRole.Add(objRole);
                        }
                    }
                    return Request.CreateResponse<List<Role>>(HttpStatusCode.OK, ListRole);
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

        [Route("api/API_Role/GetRoleById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetRoleById(Int32 id)
        {
            try
            {
                Role objRole = new Role();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("role_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetRoleById", xml.GetXML("role"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objRole.role_id = Convert.ToInt32(dtData.Rows[0]["role_id"]);
                        objRole.role_name = Convert.ToString(dtData.Rows[0]["role_name"]);
                        objRole.role_description = Convert.ToString(dtData.Rows[0]["role_description"]);
                        objRole.user_type_id = Convert.ToInt32(dtData.Rows[0]["user_type_id"]);
                        objRole.user_type_name = Convert.ToString(dtData.Rows[0]["user_type_name"]);
                        objRole.file_id = Convert.ToInt32(dtData.Rows[0]["file_id"]);
                        objRole.file_name = Convert.ToString(dtData.Rows[0]["file_name"]);
                    }

                    return Request.CreateResponse<Role>(HttpStatusCode.OK, objRole);
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

        [Route("api/API_Role/SaveRole/")]
        [HttpPost]
        public HttpResponseMessage SaveRole(AdminRoleManageViewModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();

                StringBuilder _stringBuilder = new StringBuilder();
                using (StringWriter _stringWriter = new StringWriter(_stringBuilder))
                {
                    using (XmlTextWriter writer = new XmlTextWriter(_stringWriter))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("documentelement");

                        writer.WriteStartElement("role");
                        writer.WriteElementString("role_id", Convert.ToString(model.Role.role_id));
                        writer.WriteElementString("user_type_id", Convert.ToString(model.Role.user_type_id));
                        writer.WriteElementString("file_id", Convert.ToString(model.Role.file_id));
                        writer.WriteElementString("role_name", Convert.ToString(model.Role.role_name));
                        writer.WriteElementString("role_description", Convert.ToString(model.Role.role_description));
                        writer.WriteElementString("user_id", model.user_id);
                        writer.WriteEndElement(); // role

                        if (model.ListRoleFilePermission != null && model.ListRoleFilePermission.Count > 0)
                        {
                            foreach (RoleFilePermission objRoleFilePermission in model.ListRoleFilePermission)
                            {
                                writer.WriteStartElement("rolepermission");
                                writer.WriteElementString("role_file_id", Convert.ToString(objRoleFilePermission.role_file_id));
                                writer.WriteElementString("role_id", Convert.ToString(model.Role.role_id));
                                writer.WriteElementString("file_id", Convert.ToString(objRoleFilePermission.file_id));
                                writer.WriteElementString("role_add", Convert.ToString(Convert.ToBoolean(objRoleFilePermission.role_add) == true ? 1 : 0));
                                writer.WriteElementString("role_edit", Convert.ToString(Convert.ToBoolean(objRoleFilePermission.role_edit) == true ? 1 : 0));
                                writer.WriteElementString("role_delete", Convert.ToString(Convert.ToBoolean(objRoleFilePermission.role_delete) == true ? 1 : 0));
                                writer.WriteElementString("role_view", Convert.ToString(Convert.ToBoolean(objRoleFilePermission.role_view) == true ? 1 : 0));
                                writer.WriteElementString("user_id", model.user_id);

                                writer.WriteEndElement(); // rolepermission
                            }
                        }
                        writer.WriteEndElement(); //documentelement
                        writer.WriteEndDocument();
                    }
                }
                
                _stringBuilder = _stringBuilder.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveRole", _stringBuilder.ToString());
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

        [Route("api/API_Role/GetRoleFilePermissionList/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetRoleFilePermissionList(Int32 id)
        {
            try
            {
                List<RoleFilePermission> ListRoleFilePermission = new List<RoleFilePermission>();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("role_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetRolePermissionList", xml.GetXML("rolefilepermission"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            RoleFilePermission objRoleFilePermission = new RoleFilePermission();

                            objRoleFilePermission.role_file_id = Convert.ToInt32(dr["role_file_id"]);
                            objRoleFilePermission.file_id = Convert.ToInt32(dr["file_id"]);
                            objRoleFilePermission.file_name = Convert.ToString(dr["file_name"]);
                            objRoleFilePermission.role_view = Convert.ToBoolean(dr["role_view"]);
                            objRoleFilePermission.role_add = Convert.ToBoolean(dr["role_add"]);
                            objRoleFilePermission.role_edit = Convert.ToBoolean(dr["role_edit"]);
                            objRoleFilePermission.role_delete = Convert.ToBoolean(dr["role_delete"]);
                            ListRoleFilePermission.Add(objRoleFilePermission);
                        }
                    }
                    return Request.CreateResponse<List<RoleFilePermission>>(HttpStatusCode.OK, ListRoleFilePermission);
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
        [Route("api/API_Role/DeleteRole/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteRole(Int32 id)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("role_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteRole", xml.GetXML("role"));
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
