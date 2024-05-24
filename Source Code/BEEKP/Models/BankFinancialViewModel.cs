using BEEKP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Models
{
    public class BankFinancialViewModel
    {
        public List<BankFinancial> ListBankFinancial { get; set; }
        public List<TypeOfInstitution> ListTypeOfInstitution { get; set; }
        public List<Cluster> ListCluster { get; set; }
        public BankFinancial BankFinancial { get; set; }
    }
}