using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    /*public class AdminAnnouncementsViewModel
    {
        public List<Announcements> ListAnnouncementsActive { get; set; }
        public List<Announcements> ListAnnouncementsInactive { get; set; }
        public Announcements Announcements { get; set; }
        public PagePermission PagePermission { get; set; }
        public AdminAnnouncementsViewModel()
        {
            ListAnnouncementsActive = new List<Announcements>();
            ListAnnouncementsInactive = new List<Announcements>();
        }
    }
    public class Announcements
    {
        public Int32 announcements_id { get; set; }

        [Required(ErrorMessage = "This Field Can't be empty")]
        public String announcements_title { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String announcements_date { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String announcements_short_description { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String announcements_full_description { get; set; }
        public Boolean status { get; set; }

        public Announcements()
        {
            announcements_id = 0;
            announcements_title = "";
            announcements_date = "";
            announcements_short_description = "";
            announcements_full_description = "";
        }

    }
    public class AnnouncementsViewAddEditModel
    {
        public PagePermission PagePermission { get; set; }
        public Announcements Announcements { get; set; }

        public String user_id { get; set; }

        public AnnouncementsViewAddEditModel()
        {
            PagePermission = new PagePermission();
            Announcements = new Announcements();
            user_id = "";
        }
    }*/
    public class AdminAnnouncementsViewModel
    {
        public List<Announcements> ListAnnouncementsActive { get; set; }
        public List<Announcements> ListAnnouncementsInactive { get; set; }
        public Announcements Announcements { get; set; }
        public PagePermission PagePermission { get; set; }
        public int TotalCount { get;  set; }

        public AdminAnnouncementsViewModel()
        {
            ListAnnouncementsActive = new List<Announcements>();
            ListAnnouncementsInactive = new List<Announcements>();
        }
    }

    public class Announcements
    {
        public Int32 announcements_id { get; set; }

        [Required(ErrorMessage = "This Field Can't be empty")]
        public String announcements_title { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String announcements_date { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String announcements_short_description { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String announcements_full_description { get; set; }
        public Boolean status { get; set; }

        public Announcements()
        {
            announcements_id = 0;
            announcements_title = "";
            announcements_date = "";
            announcements_short_description = "";
            announcements_full_description = "";
        }

    }
    public class AnnouncementsViewAddEditModel
    {
        public PagePermission PagePermission { get; set; }
        public Announcements Announcements { get; set; }

        public String user_id { get; set; }

        public AnnouncementsViewAddEditModel()
        {
            PagePermission = new PagePermission();
            Announcements = new Announcements();

            user_id = "";
        }
    }
}