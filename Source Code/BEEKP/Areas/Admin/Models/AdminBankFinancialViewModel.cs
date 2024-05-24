using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminBankFinancialViewModel
    {
        public List<BankFinancial> ListBankFinancialActive { get; set; }
        public List<BankFinancial> ListBankFinancialInactive { get; set; }
        public PagePermission PagePermission { get; set; }
        public AdminBankFinancialViewModel()
        {
            ListBankFinancialActive = new List<BankFinancial>();
            ListBankFinancialInactive = new List<BankFinancial>();
        }
    }
   
    public class BankFinancial
    {

        public Int32 bank_financial_id { get; set; }
        public Int32 institution_type_id { get; set; }
        public String institution_type_name { get; set; }
        public String organization_name { get; set; }
        public String address { get; set; }
        public String telephone { get; set; }
        public String fax { get; set; }
        public String email_id { get; set; }
        public Int32 cluster_id { get; set; }
        public String cluster_name { get; set; }
        public Boolean status { get; set; }
        public Int32 approval_status { get; set; }
        public String approval_status_message { get; set; }
        public BankFinancial()
        {
            institution_type_name = "";
            organization_name = "";
            address = "";
            telephone = "";
            fax = "";
            email_id = "";
            cluster_name = "";
            approval_status_message = "";
        }
    }
    public class TypeOfInstitution
    {
        public Int32 institution_type_id { get; set; }
        public String institution_type_name { get; set; }
    }
    public class BankFinancialManageModel
    {
        public PagePermission PagePermission { get; set; }
        public List<Cluster> ListCluster { get; set; }
        public List<TypeOfInstitution> ListTypeOfInstitution { get; set; }
        public BankFinancial BankFinancial { get; set; }
        public String user_id { get; set; }


    }
}