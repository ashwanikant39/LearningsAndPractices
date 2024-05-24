using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Models
{
    public class SubscriptionViewModel
    {
        public Subscription Subscription { get; set; }
    }
    public class Subscription
    {
        public Int32 subscription_id { get; set; }
        public String email_id { get; set; }
    }
}