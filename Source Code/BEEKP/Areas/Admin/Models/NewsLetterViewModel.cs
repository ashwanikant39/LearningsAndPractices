using BEEKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class NewsLetterViewModel
    {
        public List<NewsLetterMail> ListNewsLetterMail { get; set; }

        public Int32 user_id { get; set; }
    }


    public class NewsLetterMail
    {
        public Int32 news_letter_mail_id { get; set; }
        public String mail_to { get; set; }
        public String mail_cc { get; set; }
        public String mail_vcc { get; set; }
        public String subject { get; set; }
        public String body { get; set; }
        public List<NewsLetterMailAttachment> ListNewsLetterMailAttachment { get; set; }
        public String sent_on { get; set; }

        public NewsLetterMail()
        {
            mail_to = "";
            mail_cc = "";
            mail_vcc = "";
            subject = "";
            body = "";
            ListNewsLetterMailAttachment = new List<NewsLetterMailAttachment>();
            sent_on = "";
        }

    }
    public class NewsLetterMailAttachment
    {
        public Int32 news_letter_mail_attachment_id { get; set; }
        public Int32 news_letter_mail_id { get; set; }
        public String attachment_name { get; set; }

    }

    public class NewsletterManageModel
    {
        public List<AdminSubscription> ListAdminSubscription { get; set; }
        public NewsLetterMail NewsLetterMail { get; set; }
        public String user_id { get; set; }
        public NewsletterManageModel()
        {
            user_id = "";
            NewsLetterMail = new NewsLetterMail();
            ListAdminSubscription = new List<AdminSubscription>();
        }

    }

    public class AdminSubscription
    {
        public String email_id { get; set; }
        public Boolean is_checked { get; set; }
        public AdminSubscription()
        {
            email_id = "";
            is_checked = false;

        }
    }
}