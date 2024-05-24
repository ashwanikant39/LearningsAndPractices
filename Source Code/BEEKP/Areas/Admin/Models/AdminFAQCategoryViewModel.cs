using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminFAQCategoryViewModel
    {
        public List<FAQCategory> ListFAQCategory { get; set; }
        public PagePermission PagePermission { get; set; }
        public AdminFAQCategoryViewModel()
        {
            ListFAQCategory = new List<FAQCategory>();
        }
    }
    public class FAQCategory
    {
        public Int32 category_id { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String category_name { get; set; }

        public Int32 cluster_id { get; set; }
        /*Required(ErrorMessage = "This Field Can't be empty")]*/
        public String cluster_name { get; set;
        }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public Boolean status { get; set; }

        public FAQCategory()
        {
            category_name = "";
            cluster_name = "";
        }
    }
    public class FAQCategoryManageModel
    {
        public PagePermission PagePermission { get; set; }
        public FAQCategory FAQCategory { get; set; }

        public List<Cluster> ListCluster { get; set; }
        public String user_id { get; set; }


    }
}