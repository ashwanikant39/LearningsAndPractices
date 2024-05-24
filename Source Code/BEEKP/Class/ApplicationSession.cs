using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Class
{
    public class ApplicationSession
    {

        #region Login Session Variable

        public const String user_id = "user_id";
        public const String user_type_id = "user_type_id";
        public const String user_log_id = "user_log_id";
        public const String role_id = "role_id";
        public const String email_id = "email_id";
        public const String first_name = "first_name";
       

        #endregion
        #region Error Message Variable

        public const String ErrorId = "ErrorId";
        public const String ErrorMessages = "ErrorMessages";
        public const String ErrorType = "ErrorType";

        #endregion

        #region For Token Session variable

        public const String AccessToken = "AccessToken";  //// Sam 22-08-2017 because token authentication.

        #endregion


    }
}