using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminAnnouncementViewModel
    {
        public List<Announcement> ListAnnouncement { get; set; }
        public PagePermission PagePermission { get; set; }
        public AdminAnnouncementViewModel()
        {
            ListAnnouncement = new List<Announcement>();
        }
    }
    public class Announcement
    {
        public Int32 announce_id { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String announce_title { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String announce_date { get; set; }
        public String announce_short_description { get; set; }
        public Boolean status { get; set; }


        public Announcement()
        {
            announce_id = 0;
            announce_title = "";
            announce_date = "";
            announce_short_description = "";
        }
    }
    public class AnnouncementViewAddEditModel
    {
        public PagePermission PagePermission { get; set; }
        public Announcement Announcement { get; set; }

        public String user_id { get; set; }

       public AnnouncementViewAddEditModel()
            
        {
            PagePermission = new PagePermission();
            Announcement = new Announcement();

            user_id = "";
        }
    }
}