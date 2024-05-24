using BEEKP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Models
{
    public class HomeGalleryViewModel
    {
        public List<Photo> ListPhoto { get; set; }
        public List<Video> ListVideo { get; set; }
    }
}