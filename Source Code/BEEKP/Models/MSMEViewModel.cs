using BEEKP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Models
{
    public class MSMEViewModel
    {
        public List<MSME> ListMSME { get; set; }
        public List<Cluster> ListCluster { get; set; }
        public List<Sector> ListSector { get; set; }
        public MSME MSME { get; set; }
    }
}