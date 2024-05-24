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
    public class API_DiscussionForumController : API_BaseController
    {
        [Route("api/API_DiscussionForum/GetDiscussionForumList/")]
        [HttpPost]
        public HttpResponseMessage GetDiscussionForumList(List<String> _ListParameter)
        {

            try
            {
                List<DiscussionForum> lstDiscussionForum = new List<DiscussionForum>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                xml.AddElement("approval_status", Convert.ToString(_ListParameter[1]));

                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetDiscussionForumList", xml.GetXML("discussion_forum"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            DiscussionForum objDiscussionForum = new DiscussionForum();
                            objDiscussionForum.forum_id = Convert.ToInt32(dr["forum_id"]);
                            objDiscussionForum.cluster_id = Convert.ToInt32(dr["cluster_id"]);
                            objDiscussionForum.cluster_name = Convert.ToString(dr["cluster_name"]);
                            objDiscussionForum.forum_topic = Convert.ToString(dr["forum_topic"]);
                            objDiscussionForum.forum_description = Convert.ToString(dr["forum_description"]);
                            //objDiscussionForum.approved_forum_description = Convert.ToString(dr["approved_forum_description"]);
                            //objDiscussionForum.approved_forum_topic = Convert.ToString(dr["approved_forum_topic"]);
                            objDiscussionForum.remarks = Convert.ToString(dr["remarks"]);
                            objDiscussionForum.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            if (dr["approval_status"] != DBNull.Value)
                            {
                                if (Convert.ToInt32(dr["approval_status"])==Constants.APPROVAL_STATUS_APPROVED)
                                {
                                    objDiscussionForum.approval_status_message = Constants.APPROVAL_STATUS_APPROVED_MESSAGE;
                                }
                                else if (Convert.ToInt32(dr["approval_status"]) == Constants.APPROVAL_STATUS_REJECTED)
                                {
                                    objDiscussionForum.approval_status_message = Constants.APPROVAL_STATUS_REJECTED_MESSAGE;
                                }
                                else
                                {
                                    objDiscussionForum.approval_status_message = Constants.APPROVAL_STATUS_PENDING_MESSAGE;
                                }
                            }
                            else
                            {
                                objDiscussionForum.approval_status_message = "";
                            }
                           
                            lstDiscussionForum.Add(objDiscussionForum);
                        }
                    }
                    return Request.CreateResponse<List<DiscussionForum>>(HttpStatusCode.OK, lstDiscussionForum);
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

        [Route("api/API_DiscussionForum/SaveDiscussionForum/")]
        [HttpPost]
        public HttpResponseMessage SaveDiscussionForum(DiscussionForumManageModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.DiscussionForum.status == true ? 1 : 0;
                xml.AddElement("forum_id", Convert.ToString(model.DiscussionForum.forum_id));
                xml.AddElement("cluster_id", Convert.ToString(model.DiscussionForum.cluster_id));
                xml.AddElement("forum_topic", Convert.ToString(model.DiscussionForum.forum_topic));
                xml.AddElement("forum_description", Convert.ToString(model.DiscussionForum.forum_description));
                //xml.AddElement("approved_forum_topic", Convert.ToString(model.DiscussionForum.approved_forum_topic));
                //xml.AddElement("approved_forum_description", Convert.ToString(model.DiscussionForum.approved_forum_description));
                xml.AddElement("remarks", Convert.ToString(model.DiscussionForum.remarks));
                //xml.AddElement("approval_status", Convert.ToString(model.DiscussionForum.approval_status));
                xml.AddElement("status", Convert.ToString(status));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveDiscussionForum", xml.GetXML("discussion_forum"));
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

        [Route("api/API_DiscussionForum/GetDiscussionForumById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetDiscussionForumById(Int32 id)
        {
            try

            {
                DiscussionForum objDiscussionForum = new DiscussionForum();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("forum_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("GetDiscussionForumById", xml.GetXML("discussion_forum"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objDiscussionForum.forum_topic = Convert.ToString(dtData.Rows[0]["forum_topic"].ToString());
                        objDiscussionForum.forum_description = Convert.ToString(dtData.Rows[0]["forum_description"]);
                        //objDiscussionForum.approved_forum_description = Convert.ToString(dtData.Rows[0]["approved_forum_description"]);
                        //objDiscussionForum.approved_forum_topic = Convert.ToString(dtData.Rows[0]["approved_forum_topic"]);
                        objDiscussionForum.remarks = Convert.ToString(dtData.Rows[0]["remarks"]);
                        objDiscussionForum.forum_id = Convert.ToInt32(dtData.Rows[0]["forum_id"]);
                        objDiscussionForum.cluster_id = Convert.ToInt32(dtData.Rows[0]["cluster_id"]);
                        objDiscussionForum.cluster_name = Convert.ToString(dtData.Rows[0]["cluster_name"]);
                        objDiscussionForum.approval_status = Convert.ToInt32(dtData.Rows[0]["approval_status"]);
                        objDiscussionForum.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;

                    }

                    return Request.CreateResponse<DiscussionForum>(HttpStatusCode.OK, objDiscussionForum);
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

        [Route("api/API_DiscussionForum/DeleteDiscussionForum/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteDiscussionForum(Int32 id)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("forum_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteDiscussionForum", xml.GetXML("discussion_forum"));
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

        [Route("api/API_DiscussionForum/ApproveDiscussionForum/")]
        [HttpPost]
        public HttpResponseMessage ApproveDiscussionForum(DiscussionForumApproveModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.DiscussionForum.status == true ? 1 : 0;
                xml.AddElement("forum_id", Convert.ToString(model.DiscussionForum.forum_id));
                //xml.AddElement("cluster_id", Convert.ToString(model.DiscussionForum.cluster_id));
                xml.AddElement("forum_topic", Convert.ToString(model.DiscussionForum.forum_topic));
                xml.AddElement("forum_description", Convert.ToString(model.DiscussionForum.forum_description));
                //xml.AddElement("approved_forum_topic", Convert.ToString(model.DiscussionForum.approved_forum_topic));
                //xml.AddElement("approved_forum_description", Convert.ToString(model.DiscussionForum.approved_forum_description));
                xml.AddElement("remarks", Convert.ToString(model.DiscussionForum.remarks));
                xml.AddElement("approval_status", Convert.ToString(model.DiscussionForum.approval_status));
                xml.AddElement("status", Convert.ToString(status));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("ApproveDiscussionForum", xml.GetXML("discussion_forum"));
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
