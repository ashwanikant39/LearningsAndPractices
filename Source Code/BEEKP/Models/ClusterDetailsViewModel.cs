using BEEKP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Models
{
    public class ClusterDetailsViewModel
    {
        public List<ClusterDetailsModel> ListClusterDetailsModel { get; set; }
    }
    public class ClusterDetailsModel
    {
        public List<Cluster> ListCluster { get; set; }
        public Phases Phases { get; set; }
    }
}