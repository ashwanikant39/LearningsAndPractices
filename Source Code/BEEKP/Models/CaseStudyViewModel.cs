using BEEKP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Models
{
    public class CaseStudyViewModel
    {
        public List<CaseStudy> ListCaseStudy { get; set; }
        public List<Cluster> ListCluster { get; set; }
    }
}