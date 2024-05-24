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
    public class Api_FAQCategoryController : API_BaseController
    {
        [Route("api/API_FAQCategory/GetFAQCategoryList/")]
        [HttpGet]
        public HttpResponseMessage GetFAQCategoryList()
        {

            try
            {
                List<FAQCategory> ListFAQCategory = new List<FAQCategory>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetFAQCategoryList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            FAQCategory objFAQCategory = new FAQCategory();
                            objFAQCategory.category_name = Convert.ToString(dr["category_name"]);
                            objFAQCategory.category_id = Convert.ToInt32(dr["category_id"]);
                            objFAQCategory.cluster_id = Convert.ToInt32(dr["cluster_id"]);
                            objFAQCategory.cluster_name = Convert.ToString(dr["cluster_name"]);
                            objFAQCategory.status = Convert.ToInt32(dr["status"]) == 1 ? true : false; 

                            ListFAQCategory.Add(objFAQCategory);
                        }
                    }
                    return Request.CreateResponse<List<FAQCategory>>(HttpStatusCode.OK, ListFAQCategory);
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
        [Route("api/API_FAQCategory/SaveFAQCategory/")]
        [HttpPost]
        public HttpResponseMessage SaveFAQCategory(FAQCategoryManageModel model)
        {
            try
            {
                FAQCategoryManageModel objFAQCategoryManageModel = new FAQCategoryManageModel();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.FAQCategory.status == true ? 1 : 0;
                xml.AddElement("category_id", Convert.ToString(model.FAQCategory.category_id));
                xml.AddElement("category_name", Convert.ToString(model.FAQCategory.category_name));
                xml.AddElement("cluster_id", Convert.ToString(model.FAQCategory.cluster_id));
               
                xml.AddElement("status",Convert.ToString(status));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveFAQCategory", xml.GetXML("faq_category"));
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

        [Route("api/API_FAQCategory/GetFAQCategoryById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetFAQCategoryById(Int32 id)
        {
            try
               
            {
                FAQCategory objFAQCategory = new FAQCategory();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("category_id", Convert.ToString(id));                
                DataTable dtData = objCDataAccess.GetDataTableSP("GetFAQCategoryById", xml.GetXML("faq_category"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objFAQCategory.category_name = Convert.ToString(dtData.Rows[0]["category_name"].ToString());
                        objFAQCategory.category_id = Convert.ToInt32(dtData.Rows[0]["category_id"]);
                        objFAQCategory.cluster_id = Convert.ToInt32(dtData.Rows[0]["cluster_id"]);
                        objFAQCategory.cluster_name = Convert.ToString(dtData.Rows[0]["cluster_name"]);
                        objFAQCategory.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;

                    }

                    return Request.CreateResponse<FAQCategory>(HttpStatusCode.OK, objFAQCategory);
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
        [Route("api/API_FAQCategory/DeleteFAQCategory/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteFAQCategory(Int32 id)
        {
            try
            {
                FAQCategory objFAQCategory = new FAQCategory();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("category_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteFAQCategory", xml.GetXML("faq_category"));
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

        [Route("api/API_FAQCategory/GetFAQCategoryListByClusterId/")]
        [HttpPost]
        public HttpResponseMessage GetFAQCategoryListByClusterId(List<String> _ListParameter)
        {

            try
            {
                List<FAQCategory> ListFAQCategory = new List<FAQCategory>();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("cluster_id", Convert.ToString(_ListParameter[0]));

                DataTable dtData = objCDataAccess.GetDataTableSP("GetFAQCategoryListByClusterId", xml.GetXML("faq_category"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            FAQCategory objFAQCategory = new FAQCategory();
                            objFAQCategory.category_name = Convert.ToString(dr["category_name"]);
                            objFAQCategory.category_id = Convert.ToInt32(dr["category_id"]);
                            objFAQCategory.cluster_id = Convert.ToInt32(dr["cluster_id"]);
                            objFAQCategory.cluster_name = Convert.ToString(dr["cluster_name"]);
                            objFAQCategory.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;

                            ListFAQCategory.Add(objFAQCategory);
                        }
                    }
                    return Request.CreateResponse<List<FAQCategory>>(HttpStatusCode.OK, ListFAQCategory);
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
