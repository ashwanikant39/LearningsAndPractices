using BEEKP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Models
{
    public class EnergyTechnologiesViewModel
    {
        public List<EnergyTechnology> ListEnergyTechnology { get; set; }
        public List<Cluster> ListCluster { get; set; }
        public List<CategoryMeasure> ListCategoryMeasure { get; set; }
        public int TotalCount { get; set; }
    }
}