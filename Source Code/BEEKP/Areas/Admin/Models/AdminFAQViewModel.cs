using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminFAQViewModel
    {
        public List<FAQ> ListFAQActive { get; set; }
        public List<FAQ> ListFAQInactive { get; set; }
        public PagePermission PagePermission { get; set; }
        public AdminFAQViewModel()
        {
            ListFAQActive = new List<FAQ>();
            ListFAQInactive = new List<FAQ>();
        }
    }
    public class FAQ
    {
        public Int32 FAQ_id { get; set; }
        public Int32 category_id { get; set; }
        public Int32 cluster_id { get; set; }
        public String cluster_name { get; set; }

        public String category_name { get; set; }
        public String FAQ_question { get; set; }
        public String FAQ_answer { get; set; }
        public Boolean status { get; set; }
      
        public String remarks { get; set; }

        public FAQ()
        {
            FAQ_question = "";
            FAQ_answer = "";
         
            remarks = "";
            
        }
    }

    public class FAQManageModel
    {
        public FAQ FAQ { get; set; }

        public PagePermission PagePermission { get; set; }
        public List<Cluster> ListCluster { get; set; }
        public List<FAQCategory> ListFAQCategory { get; set; }
        public String user_id { get; set; }


    }
}