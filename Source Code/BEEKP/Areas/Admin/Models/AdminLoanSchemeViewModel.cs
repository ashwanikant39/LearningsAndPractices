using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminLoanSchemeViewModel
    {
        public PagePermission PagePermission { get; set; }
        public List<LoanScheme> ListLoanSchemeActive { get; set; }
        public List<LoanScheme> ListLoanSchemeInactive { get; set; }
        public LoanScheme LoanScheme { get; set; }
        public AdminLoanSchemeViewModel()
        {
            ListLoanSchemeActive = new List<LoanScheme>();
            ListLoanSchemeInactive = new List<LoanScheme>();
        }
    }
    public class LoanScheme
    {
        public Int32 loan_scheme_id { get; set; }
        public String loan_scheme_name { get; set; }
        public String loan_scheme_short_description { get; set; }
        public String loan_scheme_details { get; set; }
        public Boolean status { get; set; }

        public LoanScheme()
        {
            loan_scheme_id = 0;
            loan_scheme_name = "";
            loan_scheme_short_description = "";
            loan_scheme_details = "";
        }

    }
    public class LoanSchemeManageModel
    {
        public PagePermission PagePermission { get; set; }
        public LoanScheme LoanScheme { get; set; }

        public String user_id { get; set; }

        public LoanSchemeManageModel()
        {
            PagePermission = new PagePermission();
            LoanScheme = new LoanScheme();

            user_id = "";
        }
    }
}