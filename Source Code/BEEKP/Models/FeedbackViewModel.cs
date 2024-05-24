using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Models
{
    public class FeedbackViewModel
    {
        public FeedBack FeedBack { get; set; }
        public String user_id { get; set; }
    }
    public class FeedBack
    {
        public Int32 feedback_id { get; set; }
        public String name_user { get; set; }
        public String email_id { get; set; }
        public String contact_no { get; set; }
        public String feedback_message { get; set; }
        public Int32 status { get; set; }


    }
}