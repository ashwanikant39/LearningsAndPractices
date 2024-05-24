using BEEKP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Models
{
    public class FinancingSchemeViewModel
    {
        public List<FinancialSchemeModel> ListFinancialSchemeModel { get; set; }
        public FinancingScheme FinancingScheme { get; set; }
        public String Viewtype { get; set; }

    }
    public class FinancialSchemeModel
    {
        public FinancingSchemeCtaegory FinancingSchemeCtaegory { get; set; }
        public List<FinancingScheme> ListFinancingScheme { get; set; }
    }



    public class FinancialSchemeBankLoanModel
    {
        public FinancingSchemeCtaegory FinancingSchemeCtaegory { get; set; }
        public List<FinancingScheme> ListFinancingScheme { get; set; }
    }

    public class FinancialSchemeGovernmentSubsidyModel
    {
        public FinancingSchemeCtaegory FinancingSchemeCtaegory { get; set; }
        public List<FinancingScheme> ListFinancingScheme { get; set; }
    }
}