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
    public class API_ProjectComponentController : API_BaseController
    {
        [Route("api/API_ProjectComponent/GetProjectComponentList/")]
        [HttpPost]
        public HttpResponseMessage GetProjectComponentList(List<String> _ListParameter)
        {
            try
            {
                List<ProjectComponent> ListProjectComponent = new List<ProjectComponent>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetProjectComponentList", xml.GetXML("projectcomponent"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            ProjectComponent objProjectComponent = new ProjectComponent();

                            objProjectComponent.project_component_id = Convert.ToInt32(dr["project_component_id"]);
                            objProjectComponent.project_component_title = Convert.ToString(dr["project_component_title"]);
                            objProjectComponent.project_component_image_name = Convert.ToString(dr["project_component_image_name"]);
                            objProjectComponent.project_component_short_description = Convert.ToString(dr["project_component_short_description"]);
                            objProjectComponent.project_component_full_description = Convert.ToString(dr["project_component_full_description"]);
                            objProjectComponent.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            ListProjectComponent.Add(objProjectComponent);
                        }
                    }
                    return Request.CreateResponse<List<ProjectComponent>>(HttpStatusCode.OK, ListProjectComponent);
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

        [Route("api/API_ProjectComponent/SaveProjectComponent/")]
        [HttpPost]
        public HttpResponseMessage SaveProjectComponent(ProjectComponentManageModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.ProjectComponent.status == true ? 1 : 0;

                xml.AddElement("project_component_id", Convert.ToString(model.ProjectComponent.project_component_id));
                xml.AddElement("project_component_image_name", Convert.ToString(model.ProjectComponent.project_component_image_name));
                xml.AddElement("project_component_title", Convert.ToString(model.ProjectComponent.project_component_title));
                xml.AddElement("project_component_short_description", Convert.ToString(""));
                xml.AddElement("project_component_full_description", Convert.ToString(model.ProjectComponent.project_component_full_description));
                xml.AddElement("status", Convert.ToString(status));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveProjectComponent", xml.GetXML("projectcomponent"));
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

        [Route("api/API_ProjectComponent/GetProjectComponentById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetProjectComponentById(Int32 id)
        {
            try
            {
                ProjectComponent objProjectComponent = new ProjectComponent();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("project_component_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetProjectComponentById", xml.GetXML("projectcomponent"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objProjectComponent.project_component_id = Convert.ToInt32(dtData.Rows[0]["project_component_id"].ToString());
                        objProjectComponent.project_component_image_name = Convert.ToString(dtData.Rows[0]["project_component_image_name"]);
                        objProjectComponent.project_component_title = Convert.ToString(dtData.Rows[0]["project_component_title"]);
                        objProjectComponent.project_component_short_description = Convert.ToString(dtData.Rows[0]["project_component_short_description"]);
                        objProjectComponent.project_component_full_description = Convert.ToString(dtData.Rows[0]["project_component_full_description"]);
                        objProjectComponent.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;
                    }

                    return Request.CreateResponse<ProjectComponent>(HttpStatusCode.OK, objProjectComponent);
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

        [Route("api/API_ProjectComponent/DeleteProjectComponent/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteProjectComponent(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("project_component_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteProjectComponent", xml.GetXML("projectcomponent"));
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
