using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminPhasesViewModel
    {
        public List<Phases> ListPhasesActive { get; set; }
        public List<Phases> ListPhasesInactive { get; set; }
        public Phases Phases { get; set; }
        public PagePermission PagePermission { get; set; }
        public AdminPhasesViewModel()
        {
            ListPhasesActive = new List<Phases>();
            ListPhasesInactive = new List<Phases>();
        }
    }

    public class Phases
    {
        public Int32 phases_id { get; set; }

        [Required(ErrorMessage = "This Field Can't be empty")]
        public String phases_title { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String phases_start_date { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String phases_short_description { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String phases_full_description { get; set; }
        public Boolean status { get; set; }

        public Phases()
        {
            phases_id = 0;
            phases_title = "";
            phases_start_date = "";
            phases_short_description = "";
            phases_full_description = "";
        }

    }
    public class PhasesViewAddEditModel
    {
        public PagePermission PagePermission { get; set; }
        public Phases Phases { get; set; }

        public String user_id { get; set; }

        public PhasesViewAddEditModel()
        {
            PagePermission = new PagePermission();
            Phases = new Phases();
            user_id = "";
        }
    }
}