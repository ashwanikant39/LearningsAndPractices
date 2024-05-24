using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminFeedBackViewModel
    {
       public List<FeedBack> ListFeedBackActive { get; set; }
        public List<FeedBack> ListFeedBackInactive { get; set; }
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