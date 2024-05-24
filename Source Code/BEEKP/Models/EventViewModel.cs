using BEEKP.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Models
{
    public class EventViewModel
    {
        public List<Event> ListEventRecent { get; set; }
        public List<Event> ListEventUpcomming { get; set; }
        public Event Event { get; set; }
        public String Event_Period { get; set; }
    }
}