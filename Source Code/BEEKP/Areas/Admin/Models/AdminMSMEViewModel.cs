using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminMSMEViewModel
    {
        public List<MSME> ListMSMEActive { get; set; }
        public List<MSME> ListMSMEInactive { get; set; }
        public PagePermission PagePermission { get; set; }
        public int TotalCount { get; set; }
        public AdminMSMEViewModel()
        {
            ListMSMEActive = new List<MSME>();
            ListMSMEInactive = new List<MSME>();
        }
    }

    

    public class MSME
    {
        public Int32 msme_id { get; set; }
        public string sMSMEID { get; set; }
        public Int32 sector_id { get; set; }
        public String sector_name { get; set; }

        public Int32 cluster_id { get; set; }

        public String cluster_name { get; set; }
        public Int32 type_unit { get; set; }
        
        public String unit_name { get; set; }
        public String unit_address { get; set; }
        public String contact_name { get; set; }
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Invalid Email")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]

        public String email_id { get; set; }
        
      
        public Boolean WTA_conducted { get; set; }
        public Boolean DEA_conducted { get; set; }
        public Boolean status { get; set; }
        public Boolean approval_status { get; set; }




        public MSME()
        {
            sector_name = "";
            unit_name = "";
            unit_address = "";
            contact_name = "";
            email_id = "";
            cluster_name = "";
        }


    }
    public class AdminMSMEManageModel
    {
        public PagePermission PagePermission { get; set; }
        public MSME MSME { get; set; }
        public List<Sector> ListSector { get; set; }
        public List<Cluster> ListCluster { get; set; }
        public String user_id { get; set; }


    }
}