using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminClusterViewModel
    {
        public List<AdminCluster> ListClusters { get; set; }
        public AdminCluster Cluster { get; set; }
        public PagePermission PagePermission { get; set; }
        public int TotalCount { get; set; }

        public AdminClusterViewModel()
        {
            ListClusters = new List<AdminCluster>();
        }


    }
    public class AdminCluster
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public int SectorId { get; set; }
        public string ClusterName { get; set; }
        public string SectorName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public PagePermission PagePermission { get; set; }
        public List<SelectListItem> States { get; set; }
        public List<SelectListItem> Sectors { get; set; }
        public AdminCluster()
        {
            PagePermission = new PagePermission();
        }
    }
}