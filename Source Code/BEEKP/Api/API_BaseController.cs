using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BEEKP.Api
{
    public class API_BaseController : ApiController
    {

        [Route("api/API_Base/GetUserTypeList/")]
        [HttpGet]
        public HttpResponseMessage GetUserTypeList()
        {
            try
            {
                List<UserType> ListUserType = new List<UserType>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetUserTypeList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            UserType objUserType = new UserType();

                            objUserType.user_type_id = Convert.ToInt32(dr["user_type_id"]);
                            objUserType.user_type_name = Convert.ToString(dr["user_type_name"]);
                            ListUserType.Add(objUserType);
                        }
                    }
                    return Request.CreateResponse<List<UserType>>(HttpStatusCode.OK, ListUserType);
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

        [Route("api/API_Base/GetStateList/")]
        [HttpGet]
        public HttpResponseMessage GetStateList()
        {
            try
            {
                List<State> ListState = new List<State>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetStateList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            State objState = new State();

                            objState.state_id = Convert.ToInt32(dr["state_id"]);
                            objState.state_name = Convert.ToString(dr["state_name"]);
                            ListState.Add(objState);
                        }
                    }
                    return Request.CreateResponse<List<State>>(HttpStatusCode.OK, ListState);
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

        [Route("api/API_Base/GetFinancingSchemeCategoryList/")]
        [HttpGet]
        public HttpResponseMessage GetFinancingSchemeCategoryList()
        {
            try
            {
                List<FinancingSchemeCtaegory> ListFinancingSchemeCtaegory = new List<FinancingSchemeCtaegory>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetFinancingSchemeCategoryList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            FinancingSchemeCtaegory objFinancingSchemeCtaegory = new FinancingSchemeCtaegory();

                            objFinancingSchemeCtaegory.financing_scheme_category_id = Convert.ToInt32(dr["financing_scheme_category_id"]);
                            objFinancingSchemeCtaegory.financing_scheme_category_name = Convert.ToString(dr["financing_scheme_category_name"]);
                            ListFinancingSchemeCtaegory.Add(objFinancingSchemeCtaegory);
                        }
                    }
                    return Request.CreateResponse<List<FinancingSchemeCtaegory>>(HttpStatusCode.OK, ListFinancingSchemeCtaegory);
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

        [Route("api/API_Base/GetAreaSpecializationList/")]
        [HttpGet]
        public HttpResponseMessage GetAreaSpecializationList()
        {
            try
            {
                List<AreaSpecialization> ListAreaSpecialization = new List<AreaSpecialization>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetAreaSpecializationList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            AreaSpecialization objAreaSpecialization = new AreaSpecialization();

                            objAreaSpecialization.area_specialization_id = Convert.ToInt32(dr["area_specialization_id"]);
                            objAreaSpecialization.area_specialization_name = Convert.ToString(dr["area_specialization_name"]);
                            ListAreaSpecialization.Add(objAreaSpecialization);
                        }
                    }
                    return Request.CreateResponse<List<AreaSpecialization>>(HttpStatusCode.OK, ListAreaSpecialization);
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

        [Route("api/API_Base/GetTypeOfInstitutionList/")]
        [HttpGet]
        public HttpResponseMessage GetTypeOfInstitutionList()
        {
            try
            {
                List<TypeOfInstitution> ListTypeOfInstitutionList = new List<TypeOfInstitution>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetInstitutionTypeList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            TypeOfInstitution objTypeOfInstitution = new TypeOfInstitution();

                            objTypeOfInstitution.institution_type_id = Convert.ToInt32(dr["institution_type_id"]);
                            objTypeOfInstitution.institution_type_name = Convert.ToString(dr["institution_type_name"]);
                            ListTypeOfInstitutionList.Add(objTypeOfInstitution);
                        }
                    }
                    return Request.CreateResponse<List<TypeOfInstitution>>(HttpStatusCode.OK, ListTypeOfInstitutionList);
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
        [Route("api/API_Base/GetEE_equipmentList/")]
        [HttpGet]
        public HttpResponseMessage GetEE_equipmentList()
        {
            try
            {
                List<EE_equipment> ListEE_equipmentList = new List<EE_equipment>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetEE_EquipmentList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            EE_equipment objEE_equipment = new EE_equipment();

                            objEE_equipment.EE_equipment_id = Convert.ToInt32(dr["EE_equipment_id"]);
                            objEE_equipment.EE_equipment_name = Convert.ToString(dr["EE_equipment_name"]);
                            ListEE_equipmentList.Add(objEE_equipment);
                        }
                    }
                    return Request.CreateResponse<List<EE_equipment>>(HttpStatusCode.OK, ListEE_equipmentList);
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

        [Route("api/API_Base/GetKnowledgeBankTypeList/")]
        [HttpGet]
        public HttpResponseMessage GetKnowledgeBankTypeList()
        {
            try
            {
                List<KnowledgeBankType> ListKnowledgeBankType = new List<KnowledgeBankType>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetKnowledgeBankTypeList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            KnowledgeBankType objKnowledgeBankType = new KnowledgeBankType();

                            objKnowledgeBankType.knowledge_bank_type_id = Convert.ToInt32(dr["knowledge_bank_type_id"]);
                            objKnowledgeBankType.knowledge_bank_type_name = Convert.ToString(dr["knowledge_bank_type_name"]);
                            ListKnowledgeBankType.Add(objKnowledgeBankType);
                        }
                    }
                    return Request.CreateResponse<List<KnowledgeBankType>>(HttpStatusCode.OK, ListKnowledgeBankType);
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

        [Route("api/API_Base/GetCategoryMeasureList/")]
        [HttpGet]
        public HttpResponseMessage GetCategoryMeasureList()
        {
            try
            {
                List<CategoryMeasure> ListCategoryMeasure = new List<CategoryMeasure>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetCategoryMeasureList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            CategoryMeasure objCategoryMeasure = new CategoryMeasure();

                            objCategoryMeasure.category_measure_id = Convert.ToInt32(dr["category_measure_id"]);
                            objCategoryMeasure.category_measure_name = Convert.ToString(dr["category_measure_name"]);
                            ListCategoryMeasure.Add(objCategoryMeasure);
                        }
                    }
                    return Request.CreateResponse<List<CategoryMeasure>>(HttpStatusCode.OK, ListCategoryMeasure);
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

        [Route("api/API_Base/SaveUserLog/")]
        [HttpPost]
        public HttpResponseMessage SaveUserLog(UserLog model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();

                xml.AddElement("user_log_id", Convert.ToString(model.user_log_id));
                xml.AddElement("user_id", Convert.ToString(model.user_id));
                xml.AddElement("mac_address", Convert.ToString(model.mac_address));
                xml.AddElement("ip_address", Convert.ToString(model.ip_address));
               

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveUserLog", xml.GetXML("user_log"));
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

        [Route("api/API_Base/UpdatePassword/")]
        [HttpPost]
        public HttpResponseMessage UpdatePassword(ChangePasswordViewModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();

                xml.AddElement("new_password", Convert.ToString(model.ChangePassword.new_password));
                xml.AddElement("user_id", Convert.ToString(model.user_id));

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveChangePassword", xml.GetXML("user"));
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

        [Route("api/API_Base/GetPhaseList/")]
        [HttpGet]
        public HttpResponseMessage GetPhaseList()
        {
            try
            {
                List<Phases> ListPhase = new List<Phases>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetPhaseList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Phases objPhase = new Phases();

                            objPhase.phases_id = Convert.ToInt32(dr["phases_id"]);
                            objPhase.phases_title = Convert.ToString(dr["phases_title"]);
                            ListPhase.Add(objPhase);
                        }
                    }
                    return Request.CreateResponse<List<Phases>>(HttpStatusCode.OK, ListPhase);
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

        [Route("api/API_Base/GetSectorsList/")]
        [HttpGet]
        public HttpResponseMessage GetSectorsList()
        {
            try
            {
                List<Sectors> ListSectors = new List<Sectors>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetSectorList", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Sectors objSectors = new Sectors();

                            objSectors.sectors_id = Convert.ToInt32(dr["sectors_id"]);
                            objSectors.sectors_name = Convert.ToString(dr["sectors_name"]);
                            ListSectors.Add(objSectors);
                        }
                    }
                    return Request.CreateResponse<List<Sectors>>(HttpStatusCode.OK, ListSectors);
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
        public ErrorMessage GetError(String ErrorId, String ErrorMessages, String ErrorType)
        {
            ErrorMessage objErrorMessage = new ErrorMessage();
            objErrorMessage.ErrorId = ErrorId;
            objErrorMessage.ErrorMessages = ErrorMessages;
            objErrorMessage.ErrorType = ErrorType;
            return objErrorMessage;
        }

        ////Get DATE from database(datatable) and convert to System DATE Format - Used in GET Function
        //public static String GetSystemDateToDisplayFormat(String date)
        //{
        //    String _ShortDateTime = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
        //    String _Date = DateTime.ParseExact(date, _ShortDateTime, CultureInfo.InvariantCulture).ToString(ApplicationDateFormat(), CultureInfo.InvariantCulture);
        //    return _Date;
        //}

        //// Get DATE TIME from database(datatable) and convert to System DATE TIME  Format - Used in GET Function
        //public static String GetSystemDateTimeToDisplayFormat(String date)
        //{
        //    String _ShortDateTime = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
        //    String _Date = DateTime.ParseExact(date, _ShortDateTime, CultureInfo.InvariantCulture).ToString(ApplicationDateTimeFormat(), CultureInfo.InvariantCulture);
        //    return _Date;
        //}

        ////Convert Display DATE To Database Format - used in SAVE Function
        //public static String ConvertDisplayDateToDatabaseFormat(String date)
        //{
        //    String _Date = DateTime.ParseExact(date, ApplicationDateFormat(), CultureInfo.InvariantCulture).ToString(DatabaseDateFormat(), CultureInfo.InvariantCulture);
        //    return _Date;
        //}

        //Convert Display DATE TIME To Database Format - used in SAVE Function
        public static String ConvertApplicationDateTimeToDisplayDateTimeFormat(String ApplicationDateTime)
        {
            try
            {
                DateTime dtDateTime = DateTime.ParseExact(ApplicationDateTime, ApplicationDateTimeFormat(), CultureInfo.InvariantCulture);
                String strDateTime = dtDateTime.ToString(DisplayDateTimeFormat(), CultureInfo.InvariantCulture);  
                return strDateTime;
            }
            catch
            {
                return "";
            }

        }
        //Convert Display DATE TIME To Database Format - used in SAVE Function
        public static String ConvertDisplayDateTimeToDatabaseFormat(String DisplayDateTime)
        {
            try
            {
                DateTime dtDateTime = DateTime.ParseExact(DisplayDateTime, DisplayDateTimeFormat(), CultureInfo.InvariantCulture);
                String strDateTime = dtDateTime.ToString(DatabaseDateTimeFormat(), CultureInfo.InvariantCulture);
                return strDateTime;
            }
            catch(Exception ex)
            {
                return "";
            }
        }
        public static String ApplicationDateFormat()
        {
            String _ShortDate = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            return _ShortDate;
        }
        public static String ApplicationDateTimeFormat()
        {
            String _ShortDateTime = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
            return _ShortDateTime;
        }
        public static String DisplayDateFormat()
        {
            String _datePattern = "dd/MM/yyyy";
            return _datePattern;
        }
        public static String DisplayDateTimeFormat()
        {
            String _dateTimePattern = "dd/MM/yyyy HH:mm";
            return _dateTimePattern;
        }
        public static String DatabaseDateFormat()
        {
            String _ShortDatePattern = "yyyy-MM-dd";
            return _ShortDatePattern;
        }
        public static String DatabaseDateTimeFormat()
        {
            String _ShortDatePattern = "yyyy-MM-dd HH:mm";
            return _ShortDatePattern;
        }
        
        [Route("api/API_Base/GetPagePermission/")]
        [HttpPost]
        public HttpResponseMessage GetPagePermission(List<String> ListParameter)
        {
            try
            {
                String strRoleId = ListParameter[0];
                String strview = ListParameter[1];
                String strcontroller = ListParameter[2];
                String strarea = ListParameter[3];

                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("role_id", strRoleId);
                xml.AddElement("view", strview);
                xml.AddElement("controller", strcontroller);
                xml.AddElement("area", strarea);

                DataTable dtData = objCDataAccess.GetDataTableSP("GetPagePermission", xml.GetXML("permission"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    PagePermission objPagePermission = new PagePermission();
                    if (dtData.Rows.Count > 0)
                    {
                        objPagePermission.role_file_id = Convert.ToInt32(dtData.Rows[0]["role_file_id"]);
                        objPagePermission.file_name = Convert.ToString(dtData.Rows[0]["file_name"]);
                        objPagePermission.role_view = Convert.ToString(dtData.Rows[0]["role_view"]);
                        objPagePermission.role_add = Convert.ToString(dtData.Rows[0]["role_add"]);
                        objPagePermission.role_edit = Convert.ToString(dtData.Rows[0]["role_edit"]);
                        objPagePermission.role_delete = Convert.ToString(dtData.Rows[0]["role_delete"]);
                    }

                    return Request.CreateResponse<PagePermission>(HttpStatusCode.OK, objPagePermission);
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

        [Route("api/API_Base/GetSectorListByClusterId/")]
        [HttpPost]
        public HttpResponseMessage GetSectorListByClusterId(List<String> _ListParameter)
        {
            try
            {
                List<Sector> ListSector = new List<Sector>();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("cluster_id", Convert.ToString(_ListParameter[0]));
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetSectorListByClusterId", xml.GetXML("sector"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            Sector objSector = new Sector();
                            //objSector.cluster_id = Convert.ToInt32(dr["cluster_id"]);
                            objSector.sector_id = Convert.ToInt32(dr["sector_id"]);
                            objSector.sector_name = Convert.ToString(dr["sector_name"]);
                            //objSector.cluster_name = Convert.ToString(dr["cluster_name"]);
                            ListSector.Add(objSector);
                        }
                    }
                    return Request.CreateResponse<List<Sector>>(HttpStatusCode.OK, ListSector);
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

        [Route("api/API_Base/SaveSubscription/")]
        [HttpPost]
        public HttpResponseMessage SaveSubscription(List<String> ListParameter)
        {
            try
            {
               
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("email_id", Convert.ToString(ListParameter[0]));
                xml.AddElement("subscription_id", Convert.ToString(ListParameter[1]));

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveSubscription", xml.GetXML("subscription"));
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


        [Route("api/API_ImpactIndicators/GetImpactIndicators/")]
        [HttpGet]
        public HttpResponseMessage GetImpactIndicators()
        {
            try
            {
                List<ImpactIndicatorModel> ListImpactIndicatorModel = new List<ImpactIndicatorModel>();
                CDataAccess objCDataAccess = new CDataAccess();
                DataTable dtData = objCDataAccess.GetDataTableSP("GetImpactIndicators", "");
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtData.Rows)
                        {
                            ImpactIndicatorModel objImpactIndicatorModel = new ImpactIndicatorModel();

                            objImpactIndicatorModel.EnergyEfficciencyMeasure = Convert.ToInt32(dr["EnergyEfficciencyMeasure"]);
                            objImpactIndicatorModel.EnergySavingAchieved = Convert.ToInt32(dr["EnergySavingAchieved"]);
                            objImpactIndicatorModel.InvestorParticipatingMsmeUnits = Convert.ToInt32(dr["InvestorParticipatingMsmeUnits"]);
                            objImpactIndicatorModel.MSMEUnitsReached = Convert.ToInt32(dr["MSMEUnitsReached"]);
                            objImpactIndicatorModel.Id = Convert.ToInt32(dr["Id"]);
                            ListImpactIndicatorModel.Add(objImpactIndicatorModel);
                        }
                    }
                    return Request.CreateResponse<List<ImpactIndicatorModel>>(HttpStatusCode.OK, ListImpactIndicatorModel);
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

        [Route("api/API_ImpactIndicators/SaveImpactIndicators/")]
        [HttpPost]
        public HttpResponseMessage SaveImpactIndicators(ImpactIndicatorModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("EnergySavingAchieved", Convert.ToString(model.EnergySavingAchieved));
                xml.AddElement("MSMEUnitsReached", Convert.ToString(model.MSMEUnitsReached));
                xml.AddElement("EnergyEfficciencyMeasure", Convert.ToString(model.EnergyEfficciencyMeasure));
                xml.AddElement("InvestorParticipatingMsmeUnits", Convert.ToString(model.InvestorParticipatingMsmeUnits));
                xml.AddElement("MSMEUnitsReached", Convert.ToString(model.MSMEUnitsReached));
                xml.AddElement("user_id", model.user_id);

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveImpactIndicators", xml.GetXML("tblImpactIndicators"));
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
