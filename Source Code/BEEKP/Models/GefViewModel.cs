using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BEEKP.Areas.Admin.Models;

namespace BEEKP.Models
{
    public class GefViewModel
    {
        public List<Event> ListEventRecent { get; set; }
        public List<Event> ListEventUpcomming { get; set; }
        public List<Photo> ListPhoto { get; set; }
        public List<Video> ListVideo { get; set; }
        public List<ProjectComponent> ListProjectComponent { get; set; }

        public Int32 no_of_capacity_building { get; set; }
        public Int32 no_of_ee_financing_project { get; set; }
        public Int32 no_of_msmes { get; set; }
        public Int32 no_of_cluster { get; set; }
        public Int32 show_modal { get; set; }

        public GefViewModel()
        {
            ListEventRecent = new List<Event>();
            ListEventUpcomming = new List<Event>();
            ListPhoto = new List<Photo>();
            ListVideo = new List<Video>();
            ListProjectComponent = new List<ProjectComponent>();
            show_modal = 0;
        }

    }
}