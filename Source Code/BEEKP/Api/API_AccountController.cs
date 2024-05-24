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
    public class API_AccountController : API_BaseController
    {

        [AllowAnonymous]
        [Route("api/API_Account/GetLogin/")]
        [HttpPost]
        public HttpResponseMessage GetLogin(AdminLoginViewModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("email_id", Convert.ToString(model.email_id));


                DataTable dtData = objCDataAccess.GetDataTableSP("GetLogin", xml.GetXML("login"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    LoginDetail objLoginDetail = new LoginDetail();
                    if (dtData.Rows.Count > 0)
                    {
                        objLoginDetail.user_id = Convert.ToInt32(dtData.Rows[0]["user_id"]);
                        objLoginDetail.user_type_id = Convert.ToInt32(dtData.Rows[0]["user_type_id"]);
                        objLoginDetail.first_name = Convert.ToString(dtData.Rows[0]["first_name"]);
                        objLoginDetail.password = Convert.ToString(dtData.Rows[0]["password"]);
                        objLoginDetail.email_id = Convert.ToString(dtData.Rows[0]["emailid"]);
                        objLoginDetail.mobile = Convert.ToString(dtData.Rows[0]["mobile"]);
                        objLoginDetail.role_id = Convert.ToInt32(dtData.Rows[0]["role_id"]);

                    }

                    return Request.CreateResponse<LoginDetail>(HttpStatusCode.OK, objLoginDetail);
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

        [AllowAnonymous]
        [Route("api/API_Account/GetForgotPasswordOTP/")]
        [HttpPost]
        public HttpResponseMessage GetForgotPasswordOTP(ForgetPasswordViewModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                xml.AddElement("email_id", Convert.ToString(model.email_id));


                DataTable dtData = objCDataAccess.GetDataTableSP("GetForgotPasswordOTP", xml.GetXML("forgotpassword"));
                if (!dtData.Columns.Contains(Constants.ERROR_COLUMN_ERROR_ID))
                {
                    ForgetPasswordOTP objForgetPasswordOTP = new ForgetPasswordOTP();
                    if (dtData.Rows.Count > 0)
                    {
                        objForgetPasswordOTP.email_id = dtData.Rows[0]["email_id"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["email_id"]) : "";
                        objForgetPasswordOTP.OTP = dtData.Rows[0]["OTP"] != DBNull.Value ? Convert.ToString(dtData.Rows[0]["OTP"]) : "";
                        objForgetPasswordOTP.MessageID = dtData.Rows[0]["MessageID"] != DBNull.Value ? Convert.ToInt32(dtData.Rows[0]["MessageID"]) : 0;

                    }

                    return Request.CreateResponse<ForgetPasswordOTP>(HttpStatusCode.OK, objForgetPasswordOTP);
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

        [Route("api/API_Account/SaveUserResetPassword/")]
        [HttpPost]
        public HttpResponseMessage SaveUserResetPassword(ResetPasswordViewModel model)
        {
            try
            {
                CDataAccess objCDataAccess = new CDataAccess();
                XmlProcessor xml = new XmlProcessor();
                
                xml.AddElement("email_id", Convert.ToString(model.email_id));
                xml.AddElement("OTP", Convert.ToString(model.OTP));
                xml.AddElement("password", Convert.ToString(model.password));
                xml.AddElement("confirm_password", Convert.ToString(model.confirm_password));

                DataTable dtData = objCDataAccess.GetDataTableSP("SaveUserResetPassword", xml.GetXML("resetpassword"));
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
