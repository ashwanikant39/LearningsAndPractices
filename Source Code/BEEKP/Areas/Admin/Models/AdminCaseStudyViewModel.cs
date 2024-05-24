using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminCaseStudyViewModel
    {
        public PagePermission PagePermission { get; set; }
        public List<CaseStudy> ListCaseStudy { get; set; }
    }
    public class CaseStudy
    {
        public Int32 casestudy_id { get; set; }
        public Int32 cluster_id { get; set; }
        public String cluster_name { get; set; }
        public String ee_keywords { get; set; }
        public String file_name { get; set; }
    }
    public class CaseStudyManageModel
    {
        public PagePermission PagePermission { get; set; }
        public CaseStudy CaseStudy { get; set; }
        public List<Cluster> ListCluster { get; set; }
        public String user_id { get; set; }
    }
}