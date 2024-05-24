using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminEventViewModel
    {
        public List<Event> ListEventActive { get; set; }
        public List<Event> ListEventInactive { get; set; }
        public  Event Event { get; set; }
        public PagePermission PagePermission { get; set; }
        public int TotalCount { get; set; }

        public AdminEventViewModel()
        {
            ListEventActive = new List<Event>();
            ListEventInactive = new List<Event>();
        }
    }

    public class Event
    {
        public Int32 event_id { get; set; }

        [Required(ErrorMessage = "This Field Can't be empty")]
        public String event_title { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String event_date { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String event_location { get; set; }
        public String event_short_description { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String event_full_description { get; set; }
        public string event_image_name { get; set; }
        public Boolean status { get; set; }
        public String event_image_upload { get; set; }
        public List<EventImage> listEventImage { get; set; }
        public String event_video_url1 { get; set; }
        public String event_video_url2 { get; set; }

        public Event()
        {
            event_id = 0;
            event_title = "";
            event_date = "";
            event_title = "";
            event_location = "";
            event_short_description = "";
            event_full_description = "";
            event_image_name = "";
            listEventImage = new List<EventImage>();
        }

    }
    public class EventViewAddEditModel
    {
        public PagePermission PagePermission { get; set; }
        public Event Event { get; set; }
    
        public String user_id { get; set; }
       
        public EventViewAddEditModel()
        {
            PagePermission = new PagePermission();
            Event = new Event();
          
            user_id = "";
        }
    }
    public class EventImage
    {
        public Int32 event_image_id { get; set; }
        public Int32 event_id { get; set; }
        public String event_image_name { get; set; }


    }

    public class EventImageAddEditViewModel
    {
        public PagePermission PagePermission { get; set; }
     public Int32 event_id { get; set;}
        public EventImage EventImage { get; set; }
        public String user_id { get; set; }
        

        public EventImageAddEditViewModel()
        {
            PagePermission = new PagePermission();
            EventImage = new EventImage();
            user_id = "";
        }
    }

}