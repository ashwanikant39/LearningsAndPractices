using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminFinancingSchemeViewModel
    {

        public PagePermission PagePermission { get; set; }
        public List<FinancingScheme> ListFinancingSchemeActive { get; set; }
        public List<FinancingScheme> ListFinancingSchemeInactive { get; set; }

        public AdminFinancingSchemeViewModel()
        {
            ListFinancingSchemeActive = new List<FinancingScheme>();
            ListFinancingSchemeInactive = new List<FinancingScheme>();
        }
    }
    public class FinancingScheme
    {
        public Int32 financing_scheme_id { get; set; }
        public Int32 financing_scheme_category_id { get; set; }
        public String financing_scheme_category_name { get; set; }
        public String financing_scheme_name { get; set; }
        public String financing_scheme_details { get; set; }

        public Boolean status { get; set; }
        public FinancingScheme()
        {
            financing_scheme_category_name = "";
            financing_scheme_name = "";
            financing_scheme_details = "";

        }
    }
    public class FinancingSchemeCtaegory
    {
        public Int32 financing_scheme_category_id { get; set; }
        public String financing_scheme_category_name { get; set; }
        public FinancingSchemeCtaegory()
        {
            financing_scheme_category_name = "";
        }
    }
    public class FinancingSchemeManageModel
    {
        public FinancingScheme FinancingScheme { get; set; }
        public PagePermission PagePermission { get; set; }
        public List<FinancingSchemeCtaegory> ListFinancingSchemeCtaegory { get; set; }
        public String user_id { get; set; }


    }


}