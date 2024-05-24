using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminEnergyTechnologiesViewModel
    {
        public List<EnergyTechnology> ListEnergyTechnologyActive { get; set; }
        public List<EnergyTechnology> ListEnergyTechnologyInactive { get; set; }
        public PagePermission PagePermission { get; set; }
        public int TotalCount { get; set; }

        public AdminEnergyTechnologiesViewModel()
        {
            ListEnergyTechnologyActive = new List<EnergyTechnology>();
            ListEnergyTechnologyInactive = new List<EnergyTechnology>();
        }
       

    }

    public class EnergyTechnology
    {
        public Int32 EE_technology_id { get; set; }
        public string sEE_technology_id { get; set; }
        public Int32 category_measure_id { get; set; }
        public String category_measure_name { get; set; }
        //public Int32 cluster_id { get; set; }
        public String clusters { get; set; }
        public String EE_measure { get; set; }
        public Boolean status { get; set; }

        public EnergyTechnology()
        {
            EE_measure = "";
        }
    }
    public class CategoryMeasure
    {
        public Int32 category_measure_id { get; set; }
        public String category_measure_name { get; set; }
    }
    public class EnergyTechnologiesManageModel
    {
        public PagePermission PagePermission { get; set; }
        public EnergyTechnology EnergyTechnology { get; set; }
        public List<CategoryMeasure> ListCategoryMeasure { get; set; }
        //public List<Cluster> ListCluster { get; set; }
        public String user_id { get; set; }
    }
}