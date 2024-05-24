using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminSectorViewModel
    {
        public List<Sector> ListSector { get; set; }
        public PagePermission PagePermission { get; set; }
        public AdminSectorViewModel()
        {
            ListSector = new List<Sector>();
        }
    }
    public class Sector
    {
        public Int32 sector_id { get; set; }
        public String sector_name { get; set;}
       
    }

    public class SectorManageModel
    {
        public PagePermission PagePermission { get; set; }
        public Sector Sector { get; set; }
       
        public String user_id { get; set; }

        public SectorManageModel()
        {
            Sector = new Sector();
          
        }
    }
}