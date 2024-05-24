using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator 

        public async Task<ActionResult> Index()
        {
           // List<Announcement> list = await GetUpdatesAnnouncements();
            return View();
        }

        public async Task<ActionResult> Proceed()
        {
            // List<Announcement> list = await GetUpdatesAnnouncements();
            return View();
        }
        public async Task<ActionResult> BasicFoundry()
        {
            // List<Announcement> list = await GetUpdatesAnnouncements();
            return View();
        }
        public async Task<ActionResult> AdvancedFoundry()
        {
            // List<Announcement> list = await GetUpdatesAnnouncements();
            return View();
        }

        public async Task<ActionResult> BasicForging()
        {
            // List<Announcement> list = await GetUpdatesAnnouncements();
            return View();
        }
        public async Task<ActionResult> AdvancedForging()
        {
            // List<Announcement> list = await GetUpdatesAnnouncements();
            return View();
        }

        public async Task<ActionResult> BasicRolling()
        {
            // List<Announcement> list = await GetUpdatesAnnouncements();
            return View();
        }
        public async Task<ActionResult> AdvancedRolling()
        {
            // List<Announcement> list = await GetUpdatesAnnouncements();
            return View();
        }


    }
}