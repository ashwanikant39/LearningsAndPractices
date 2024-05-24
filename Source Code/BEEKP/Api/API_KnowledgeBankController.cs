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
    public class API_KnowledgeBankController : API_BaseController
    {
        [Route("api/API_KnowledgeBank/GetKnowledgeBankList/")]
        [HttpPost]
        public HttpResponseMessage GetKnowledgeBankList(List<String> _ListParameter)
        {
            try
            {
                List<KnowledgeBank> ListKnowledgeBank = new List<KnowledgeBank>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                

                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetKnowledgeBankList", xml.GetXML("knowledge_bank"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            KnowledgeBank objKnowledgeBank = new KnowledgeBank();

                            objKnowledgeBank.knowledge_bank_id = Convert.ToInt32(dr["knowledge_bank_id"]);
                            objKnowledgeBank.knowledge_bank_name = Convert.ToString(dr["knowledge_bank_name"]);
                            objKnowledgeBank.knowledge_bank_type_id = Convert.ToInt32(dr["knowledge_bank_type_id"]);
                            objKnowledgeBank.knowledge_bank_type_name = Convert.ToString(dr["knowledge_bank_type_name"]);
                            objKnowledgeBank.file_name = Convert.ToString(dr["file_name"]);
                            objKnowledgeBank.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            ListKnowledgeBank.Add(objKnowledgeBank);
                        }
                    }
                    return Request.CreateResponse<List<KnowledgeBank>>(HttpStatusCode.OK, ListKnowledgeBank);
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

        [Route("api/API_KnowledgeBank/GetKnowledgeBankListByKnowledgeType/")]
        [HttpPost]
        public HttpResponseMessage GetKnowledgeBankListByKnowledgeType(List<String> _ListParameter)
        {
            try
            {
                List<KnowledgeBank> ListKnowledgeBank = new List<KnowledgeBank>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("knowledge_bank_type_id", Convert.ToString(_ListParameter[0]));


                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetKnowledgeBankListByknowledgeBankType", xml.GetXML("knowledge_bank"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            KnowledgeBank objKnowledgeBank = new KnowledgeBank();

                            objKnowledgeBank.knowledge_bank_id = Convert.ToInt32(dr["knowledge_bank_id"]);
                            objKnowledgeBank.knowledge_bank_name = Convert.ToString(dr["knowledge_bank_name"]);
                            objKnowledgeBank.knowledge_bank_type_id = Convert.ToInt32(dr["knowledge_bank_type_id"]);
                            objKnowledgeBank.knowledge_bank_type_name = Convert.ToString(dr["knowledge_bank_type_name"]);
                            objKnowledgeBank.file_name = Convert.ToString(dr["file_name"]);
                            objKnowledgeBank.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            ListKnowledgeBank.Add(objKnowledgeBank);
                        }
                    }
                    return Request.CreateResponse<List<KnowledgeBank>>(HttpStatusCode.OK, ListKnowledgeBank);
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


        [Route("api/API_KnowledgeBank/GetVideoLibraryListBySector/")]
        [HttpPost]
        public HttpResponseMessage GetVideoLibraryList(List<String> _ListParameter)
        {
            try
            {
                List<VideoLibrary> ListVideoLibrary = new List<VideoLibrary>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("status", Convert.ToString(_ListParameter[0]));
                xml.AddElement("sector_id", Convert.ToString(_ListParameter[1]));


                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetVideoLibraryListBySector", xml.GetXML("videolibrary"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            VideoLibrary objVideoLibrary = new VideoLibrary();

                            objVideoLibrary.video_id = Convert.ToInt32(dr["video_id"]);
                            objVideoLibrary.video_url = Convert.ToString(dr["video_url"]);
                            objVideoLibrary.sector_id = Convert.ToInt32(dr["sector_id"]);
                            objVideoLibrary.sector_name = Convert.ToString(dr["sector_name"]);
                            objVideoLibrary.technology = Convert.ToString(dr["technology"]);
                            objVideoLibrary.status = Convert.ToInt32(dr["status"]) == 1 ? true : false;
                            ListVideoLibrary.Add(objVideoLibrary);
                        }
                    }
                    return Request.CreateResponse<List<VideoLibrary>>(HttpStatusCode.OK, ListVideoLibrary);
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

        [Route("api/API_KnowledgeBank/SaveKnowledgeBank/")]
        [HttpPost]
        public HttpResponseMessage SaveKnowledgeBank(KnowledgeBankManageModel model)
        {
            try
            {

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                int status = model.KnowledgeBank.status == true ? 1 : 0;

                xml.AddElement("knowledge_bank_id", Convert.ToString(model.KnowledgeBank.knowledge_bank_id));
                xml.AddElement("knowledge_bank_name", Convert.ToString(model.KnowledgeBank.knowledge_bank_name));
                xml.AddElement("knowledge_bank_type_id", Convert.ToString(model.KnowledgeBank.knowledge_bank_type_id));
                xml.AddElement("file_name", Convert.ToString(model.KnowledgeBank.file_name));
                xml.AddElement("user_id", model.user_id);
                xml.AddElement("status", Convert.ToString(status));

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveKnowledgeBank", xml.GetXML("knowledge_bank"));
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

        [Route("api/API_KnowledgeBank/GetKnowledgeBankById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetKnowledgeBankById(Int32 id)
        {
            try
            {
                KnowledgeBank objKnowledgeBank = new KnowledgeBank();
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("knowledge_bank_id", Convert.ToString(id));
                DataTable dtData = objCDataAccess.GetDataTableSP("GetKnowledgeBankById", xml.GetXML("knowledge_bank"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        objKnowledgeBank.knowledge_bank_id = Convert.ToInt32(dtData.Rows[0]["knowledge_bank_id"]);
                        objKnowledgeBank.knowledge_bank_type_id = Convert.ToInt32(dtData.Rows[0]["knowledge_bank_type_id"]);
                        objKnowledgeBank.knowledge_bank_name = Convert.ToString(dtData.Rows[0]["knowledge_bank_name"]);
                        objKnowledgeBank.knowledge_bank_type_name = Convert.ToString(dtData.Rows[0]["knowledge_bank_type_name"]);
                        objKnowledgeBank.file_name = Convert.ToString(dtData.Rows[0]["file_name"]);
                        objKnowledgeBank.knowledge_bank_type_name = Convert.ToString(dtData.Rows[0]["knowledge_bank_type_name"]);
                        objKnowledgeBank.status = Convert.ToInt32(dtData.Rows[0]["status"]) == 1 ? true : false;
                    }

                    return Request.CreateResponse<KnowledgeBank>(HttpStatusCode.OK, objKnowledgeBank);
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

        [Route("api/API_KnowledgeBank/DeleteKnowledgeBank/{id:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteKnowledgeBank(Int32 id)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("knowledge_bank_id", Convert.ToString(id));

                DataTable dtData = objCDataAccess.GetDataTableSP("DeleteKnowledgeBank", xml.GetXML("knowledge_bank"));
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
