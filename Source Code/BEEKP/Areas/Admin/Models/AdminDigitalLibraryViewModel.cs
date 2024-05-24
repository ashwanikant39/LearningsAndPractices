using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminDigitalLibraryViewModel
    {
        public List<DigitalLibrary> ListDigitalLibrarys { get; set; }
        public DigitalLibrary DigitalLibrary { get; set; }
        public PagePermission PagePermission { get; set; }
        public int TotalCount { get; set; }

        public AdminDigitalLibraryViewModel()
        {
            ListDigitalLibrarys = new List<DigitalLibrary>();
        }
    }

    public class DigitalLibrary
    {
        public int Id { get; set; }
        public int SectorId { get; set; }
        public string SectorName { get; set; }
        public int ClusterId { get; set; }
        public string ClusterName { get; set; }
        public string Description { get; set; }
        public string FileType { get; set; }
        public string ImageUrl { get; set; }
        public string FileUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string  CreatedBy{ get; set; }
        public bool IsActive { get; set; }
        public PagePermission PagePermission { get; set; }
        public List<SelectListItem> Clusters { get; set; }
        public List<SelectListItem> Sectors { get; set; }
        public DigitalLibrary()
        {
            PagePermission = new PagePermission();
        }

    }

    public class DigitalLibraryImage
    {
        public Int32 _image_id { get; set; }
        public Int32 news_id { get; set; }
        public String news_image_name { get; set; }


    }
}