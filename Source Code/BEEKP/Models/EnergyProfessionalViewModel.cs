using BEEKP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Models
{
    public class EnergyProfessionalViewModel
    {
        public List<EnergyProfessionals> ListEnergyProfessionals { get; set; }
        
        public List<AreaSpecialization> ListAreaSpecialization { get; set; }
    }
    

}