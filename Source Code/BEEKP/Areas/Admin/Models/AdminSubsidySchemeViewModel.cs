using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminSubsidySchemeViewModel
    {
        public PagePermission PagePermission { get; set; }
        public List<SubsidyScheme> ListSubsidySchemeActive { get; set; }
        public List<SubsidyScheme> ListSubsidySchemeInactive { get; set; }
        public SubsidyScheme SubsidyScheme { get; set; }
        public AdminSubsidySchemeViewModel()
        {
            ListSubsidySchemeActive = new List<SubsidyScheme>();
            ListSubsidySchemeInactive = new List<SubsidyScheme>();
        }
    }
    public class SubsidyScheme
    {
        public Int32 subsidy_scheme_id { get; set; }
        public String subsidy_scheme_name { get; set; }
        public String subsidy_scheme_short_description { get; set; }
        public String subsidy_scheme_details { get; set; }
        public Boolean status { get; set; }

        public SubsidyScheme()
        {
            subsidy_scheme_id = 0;
            subsidy_scheme_name = "";
            subsidy_scheme_short_description = "";
            subsidy_scheme_details = "";
        }

    }
    public class SubsidySchemeManageModel
    {
        public PagePermission PagePermission { get; set; }
        public SubsidyScheme SubsidyScheme { get; set; }

        public String user_id { get; set; }

        public SubsidySchemeManageModel()
        {
            PagePermission = new PagePermission();
            SubsidyScheme = new SubsidyScheme();

            user_id = "";
        }
    }
}