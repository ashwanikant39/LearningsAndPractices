using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminEnergyProfessionalsViewModel
    {
        public List<EnergyProfessionals> ListEnergyProfessionalsActive { get; set; }
        public List<EnergyProfessionals> ListEnergyProfessionalsInactive { get; set; }
        public PagePermission PagePermission { get; set; }
        public int TotalCount { get; set; }
        public AdminEnergyProfessionalsViewModel()
        {
            ListEnergyProfessionalsActive = new List<EnergyProfessionals>();
            ListEnergyProfessionalsInactive = new List<EnergyProfessionals>();
        }
    }
    public class AdminEnergyProfessionalsApprovedViewModel
    {
        public List<EnergyProfessionals> ListEnergyProfessionalsApproval_Pending { get; set; }
        public List<EnergyProfessionals> ListEnergyProfessionalsApproval_Approved { get; set; }
        public List<EnergyProfessionals> ListEnergyProfessionalsApproval_Rejected { get; set; }
        public AdminEnergyProfessionalsApprovedViewModel()
        {
            ListEnergyProfessionalsApproval_Pending = new List<EnergyProfessionals>();
            ListEnergyProfessionalsApproval_Approved = new List<EnergyProfessionals>();
            ListEnergyProfessionalsApproval_Rejected = new List<EnergyProfessionals>();
        }
    }
    public class EnergyProfessionals
    {
        public Int32 energy_professional_id { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public String name { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public String organization_address { get; set; }
        public String email_id { get; set; }
        public Int32 area_specialization_id { get; set; }
        public String area_specialization_name { get; set; }
        public Boolean status { get; set; }
        public Int32 approval_status { get; set; }
        public String approval_status_message { get; set; }
        public string senergy_professional_id { get; set; }
        public EnergyProfessionals()
        {
            name = "";
            organization_address = "";
            email_id = "";
            area_specialization_name = "";

            approval_status_message = "";
        }

    }
    public class AreaSpecialization
    {
        public Int32 area_specialization_id { get; set; }
        public String area_specialization_name { get; set; }
    }
    public class EnergyProfessionalsManageModel
    {
        public PagePermission PagePermission { get; set; }
        public List<AreaSpecialization> ListAreaSpecialization { get; set; }
        public EnergyProfessionals EnergyProfessionals { get; set; }
        public String user_id { get; set; }


    }
}