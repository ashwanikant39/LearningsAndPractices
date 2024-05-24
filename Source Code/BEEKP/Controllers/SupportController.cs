using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Controllers
{
    public class SupportController : Controller
    {
        // GET: ContanctUs
        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult HelpDesk()
        {
            return View();
        }
    }
}