using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminManufacturersViewModel
    {   public List<Manufacturers> ListManufacturersApproved { get; set; }
        public List<Manufacturers> ListManufacturers { get; set; }
        public PagePermission PagePermission { get; set; }
        public int TotalCount { get; set; }
        public AdminManufacturersViewModel()
        {
            ListManufacturers = new List<Manufacturers>();
        }
    }
    public class Manufacturers
    {
        public Int32 manufacturer_id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public Int32 EE_equipment_id { get; set; }
        public String EE_equipment_name { get; set; }
        public String name_manufacturer { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public String contact_address { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public String contact_person { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public String contact_no { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public String email { get; set; }

        public String website { set; get; }

        [Required(ErrorMessage = "This Field is Required")]
        public Boolean status { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public Int32 approval_status { get; set; }
        public String approval_status_message { get; set; }
        public string smanufacturer_id { get; set; }
        public Manufacturers()
        {
            EE_equipment_name = "";
            name_manufacturer = "";
            contact_address = "";
            contact_person = "";
            contact_no = "";
            email = "";
        }
    }

    public class EE_equipment
    {
        public Int32 EE_equipment_id { get; set; }
        public String EE_equipment_name { get; set; }
    }
    public class ManufacturersManageModel
    {
        public PagePermission PagePermission { get; set; }
        public Manufacturers Manufacturers { get; set; }
        public List<EE_equipment> ListEE_equipment { get; set; }
        public List<Manufacturers> ListManufacturers { get; set; }
        public String user_id { get; set; }


    }
}