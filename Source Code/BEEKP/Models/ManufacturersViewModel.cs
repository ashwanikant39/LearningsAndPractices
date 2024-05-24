using BEEKP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Models
{
    public class ManufacturersViewModel
    {
        public List<Manufacturers> ListManufacturers { get; set; }
        public List<EE_equipment> ListEE_equipment { get; set; }
        public Manufacturers Manufacturers { get; set; }
    }
}