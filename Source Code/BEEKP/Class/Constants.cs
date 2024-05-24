using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Class
{
    public class Constants
    {
        #region error

        public const String ERROR_COLUMN_ERROR_ID = "ErrorId";
        public const String ERROR_COLUMN_ERROR_MESSAGE = "ErrorMessage";
        public const String ERROR_COLUMN_ERROR_TYPE = "ErrorType";

        public const String ERROR_ID_DEFAULT = "0";
        public const String ERROR_TYPE_GENERAL = "Application Error";
        public const String ERROR_TYPE_DATABASE = "Database Error";

        #endregion


        #region error_message

        public const String AJAX_SESSIONOUT = "sessionout";
        public const String AJAX_ERROR = "error";
        public const String ERROR_MESSAGE_MANDATORY = "Fields marked with asterisk (*) are mandatory to fill in";
        public const String ERROR_MESSAGE_CONFIGURESTATE = "Please Configure The State First";
        public const String ERROR_MESSAGE_CONFIRMPASSWORD = "Please enter the same value again";
        public const String ERROR_MESSAGE_ENDDATE = "End date must be higher than Start Date";

        public const String ERROR_MESSAGE_INVALIDFILEID = "Invalid file id";

        #endregion

        #region FAQ_approval_status

        public const Int32 FAQ_APPROVAL_STATUS_APPROVED = 1;
        public const String FAQ_APPROVAL_STATUS_APPROVED_MESSAGE = "Approved";
        public const Int32 FAQ_APPROVAL_STATUS_PENDING = 2;
        public const String FAQ_APPROVAL_STATUS_PENDING_MESSAGE = "Pending";
        public const Int32 FAQ_APPROVAL_STATUS_REJECTED = 0;
        public const String FAQ_APPROVAL_STATUS_REJECTED_MESSAGE = "Rejected";

        #endregion


        #region approval_status

        public const Int32 APPROVAL_STATUS_APPROVED = 1;
        public const String APPROVAL_STATUS_APPROVED_MESSAGE = "Approved";
        public const Int32 APPROVAL_STATUS_PENDING = 2;
        public const String APPROVAL_STATUS_PENDING_MESSAGE = "Pending";
        public const Int32 APPROVAL_STATUS_REJECTED = 0;
        public const String APPROVAL_STATUS_REJECTED_MESSAGE = "Rejected";

        public const Int32 APPROVAL_STATUS_NOT_COMPARE = -1;

        #endregion

        #region _status

        public const Int32 STATUS_ACTIVE = 1;
        public const String STATUS_APPROVED_MESSAGE = "Active";
        public const Int32 STATUS_INACTIVE = 0;

        public const Int32 STATUS_NOT_COMPARE = -1;
        #endregion


        #region image

        public const String NO_IMAGE = "~/images/NoImage.png";

        #endregion

        #region page_permission
        public const String PAGE_PERMISSION_YES = "True";
        public const String PAGE_PERMISSION_NO = "False";

        #endregion

        #region event_period
        public const String EVENT_PERIOD_ALL = "ALL";
        public const String EVENT_PERIOD_RECENT = "RECENT";
        public const String EVENT_PERIOD_UPCOMMING = "UPCOMING";

        #endregion
        #region news_period
        public const String NEWS_PERIOD_ALL = "ALL";
        public const String NEWS_PERIOD_RECENT = "RECENT";
        public const String NEWS_PERIOD_UPCOMMING = "UPCOMING";

        #endregion
        #region file_size
        public const Int32 FileSize20MB = 20971520;
        public const Int32 FileSize10MB = 10485760;
        public const Int32 FileSize5MB = 5242880;
        public const Int32 FileSize1MB = 1048576;//byte 
        public const String File1MBText = "1024 KB";

        public const Int32 FileSize100KB = 102400;
        public const String File100KBText = "100 KB";//use as File size notification bellow the file upload text box.

        public const Int32 FileSize200KB = 204800;
        public const String File200KBText = "200 KB";//use as File size notification bellow the file upload text box.

        #endregion

        #region file_type

        public const String FILE_TYPE_IMAGE = "IMAGE";
        public const String FILE_TYPE_PDF = "PDF";
        public const String FILE_TYPE_TXT = "TXT";
        public const String FILE_TYPE_DOC = "DOC";
        public const String FILE_TYPE_DOCX = "DOCX";
        public const String FILE_TYPE_VIDEO = "VIDEO";
        #endregion

        #region project_component

        //public const Int32 PROJECT_COMPONENT_IMAGE_MIN_WIDTH =370;
        //public const Int32 PROJECT_COMPONENT_IMAGE_MIN_HEIGHT =285;
        public const Int32 PROJECT_COMPONENT_IMAGE_MIN_WIDTH = 270;
        public const Int32 PROJECT_COMPONENT_IMAGE_MIN_HEIGHT = 200;
        #endregion

        #region event_image

        //public const Int32 EVENT_IMAGE_MIN_WIDTH =  370;
        //public const Int32 EVENT_IMAGE_MIN_HEIGHT = 247;
        public const Int32 EVENT_IMAGE_MIN_WIDTH = 285;
        public const Int32 EVENT_IMAGE_MIN_HEIGHT = 170;
        #endregion

        #region news_image

        //public const Int32 EVENT_IMAGE_MIN_WIDTH =  370;
        //public const Int32 EVENT_IMAGE_MIN_HEIGHT = 247;
        public const Int32 NEWS_IMAGE_MIN_WIDTH = 285;
        public const Int32 NEWS_IMAGE_MIN_HEIGHT = 170;
        #endregion

        #region sectors_image

        //public const Int32 EVENT_IMAGE_MIN_WIDTH =  370;
        //public const Int32 EVENT_IMAGE_MIN_HEIGHT = 247;
        public const Int32 SECTORS_IMAGE_MIN_WIDTH = 100;
        public const Int32 SECTORS_IMAGE_MIN_HEIGHT = 100;
        #endregion

        #region gallery_image

        public const Int32 GALLERY_IMAGE_MIN_WIDTH = 290;
        public const Int32 GALLERY_IMAGE_MIN_HEIGHT =180;
        #endregion

        #region image_ratio

        public const Double IMAGE_RATIO_MIN = 0.8;
        public const Double IMAGE_RATIO_MAX = 1.2;
        #endregion

        #region event_count

        public const Int32 EVENT_COUNT_ALL = 0;
        public const Int32 EVENT_COUNT_DASHBOARD = 4;

        #endregion
        #region news_count

        public const Int32 NEWS_COUNT_ALL = 0;
        public const Int32 NEWS_COUNT_DASHBOARD = 4;

        #endregion

        #region financing_scheme

        public const String ALL_TYPE = "all";
        public const String BANK_LOAN = "bankloan";
        public const String SUBSIDY = "subsidy";

        #endregion

        #region financing_scheme_category_id

        public const Int32 FINANCING_SCHEME_CATEGORY_ID_BANK = 1;
        public const Int32 FINANCING_SCHEME_CATEGORY_ID_SUBSIDY = 2;

        #endregion

        #region library_id

        public const Int32 NEWSLETTER_ID = 1;
        public const Int32 ENERGY_EFFICIENT_ID = 2;
        public const Int32 REPORTS_ID = 3;
        public const Int32 CREDIT_RATING_ID = 4;
        public const Int32 TRAINING_ID = 5;
        public const Int32 BEST_PRACTICE_ID = 6;
        public const Int32 NOTIFICATION_ID = 7;
        public const Int32 GALLERY_ID = 8;
        public const Int32 OTHER_ID = 9;

        #endregion
        #region casestudy
        public const Int32 CASESTUDY_ALL = 0;
        #endregion
    }

}