using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminClusterDetailsViewModel
    {
        public List<Cluster> ListCluster { get; set; }
        public Cluster Cluster { get; set; }
        public PagePermission PagePermission { get; set; }
        public AdminClusterDetailsViewModel()
        {
            ListCluster = new List<Cluster>();
        }
    }
    public class Cluster
    {
        public Int32 cluster_id { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String cluster_name { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String location { get; set; }
        
        public String products_manufactured { get; set; }
       
        public String fuel_used { get; set; }
        
        public Int32 number_of_units { get; set; }
        
        public decimal overall_turnover { get; set; }

        public String cluster_profile { get; set; }

        public String cluster_doc_hindi { get; set; }
        public String cluster_doc_english { get; set; }
        public String cluster_doc_marathi { get; set; }
         
        public Int32 phases_id { get; set; }
        public String phases_title { get; set; }

        public Cluster()
        {

            cluster_name = "";
            location = "";
            products_manufactured = "";
            fuel_used = "";
            cluster_doc_hindi = "";
            cluster_doc_english = "";
            cluster_doc_marathi = "";

        }
    }
    public class ClusterDetailsAddEditModel
    {
        public PagePermission PagePermission { get; set; }
        public Cluster Cluster { get; set; }
        public String user_id { get; set; }
        public List<Phases> ListPhase { get; set; }


    }
    /*public class Phase
    {
        public Int32 phase_id { get; set; }
        public String phase_name { get; set; }
    }*/
}