using BEEKP.Areas.Admin.Controllers;
using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using BEEKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace BEEKP.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                HomeViewModel objHomeController = new HomeViewModel();

                if (Session["ShowModal"] == null)
                {
                    objHomeController.show_modal = 1;
                    Session["ShowModal"] = objHomeController.show_modal;
                }
                else
                {
                    objHomeController.show_modal = 0;
                }


                AdminEventController objEventController = new AdminEventController();
                objHomeController.ListEventRecent = await objEventController.GetEventList(Class.Constants.STATUS_ACTIVE, Class.Constants.EVENT_PERIOD_ALL, Class.Constants.EVENT_COUNT_DASHBOARD);
                objHomeController.ListEventUpcomming = await objEventController.GetEventList(Class.Constants.STATUS_ACTIVE, Class.Constants.EVENT_PERIOD_UPCOMMING, Class.Constants.EVENT_COUNT_DASHBOARD);

                HomeGalleryController objHomeGalleryController = new HomeGalleryController();
                objHomeController.ListPhoto = await GetPhotoGaleryDashboardList();
                objHomeController.ListVideo = await GetVideoGalleryDashboardList();

                AdminProjectComponentController objProjectComponentController = new AdminProjectComponentController();
                objHomeController.ListProjectComponent = await objProjectComponentController.GetProjectComponentList(Class.Constants.STATUS_ACTIVE);


                ClusterDetailsController objClusterDetailsController = new ClusterDetailsController();
                List<Cluster> ListClusterDetails = await GetClusterDetailsList();
                objHomeController.no_of_cluster = ListClusterDetails.Count();

                MSMEController objMSMEController = new MSMEController();
                List<MSME> ListMSME = await objMSMEController.GetMSMEList("0", "0");
                objHomeController.no_of_msmes = ListMSME.Count();



                return View(objHomeController);
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        #region GetUpdatesAnnouncements and GetNewsMedia

        public async Task<ActionResult> _updatesAnnouncements()
        {
            List<Announcement> list = await GetUpdatesAnnouncements();
            return PartialView("_updatesAnnouncements", list);
        }
        public async Task<List<Announcement>> GetUpdatesAnnouncements()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Announcement/GetAnnouncementList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Announcement>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ActionResult> _newsMedia()
        {
            List<News> list = await GetNewsMedia(Constants.STATUS_ACTIVE, Constants.NEWS_PERIOD_ALL, Constants.NEWS_COUNT_ALL);
            return PartialView(list);
        }
        public async Task<List<News>> GetNewsMedia(Int32 _status, String _news_period, Int32 _news_count)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_news_period.ToString());
            ListParameter.Add(_news_count.ToString());


            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_News/GetNewsList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<News>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        #endregion
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Brass()
        {
            ViewBag.Message = "Brass sector page.";

            return View();
        }
        public ActionResult Ceramic()
        {
            ViewBag.Message = "Ceramic sector page.";

            return View();
        }
        public ActionResult Dairy()
        {
            ViewBag.Message = "Dairy sector page.";

            return View();
        }
        public ActionResult Foundry()
        {
            ViewBag.Message = "Foundry sector page.";

            return View();
        }
        public ActionResult Hand_tool()
        {
            ViewBag.Message = "Hand_tool sector page.";

            return View();
        }

        public ActionResult Textiles()
        {
            ViewBag.Message = "Textiles sector page.";

            return View();
        }

        public ActionResult Foods()
        {
            ViewBag.Message = "Foods sector page.";

            return View();
        }

        public ActionResult SeaFood()
        {
            ViewBag.Message = "Sea Food sector page.";

            return View();
        }

        public ActionResult Bricks()
        {
            ViewBag.Message = "Hand_tool sector page.";

            return View();
        }

        public ActionResult Forging()
        {
            ViewBag.Message = "Forging sector page.";

            return View();
        }

        public ActionResult Chemicals()
        {
            ViewBag.Message = "Hand_tool sector page.";

            return View();
        }

        public ActionResult Limekilns()
        {
            ViewBag.Message = "Limekiln sector page.";

            return View();
        }


        public ActionResult Automobile()
        {
            ViewBag.Message = "Automobile sector page.";

            return View();
        }
        public ActionResult Carpet()
        {
            ViewBag.Message = "Carpet sector page.";

            return View();
        }
        public ActionResult Coir()
        {
            ViewBag.Message = "Coir sector page.";

            return View();
        }
        public ActionResult Engg()
        {
            ViewBag.Message = "Engg sector page.";

            return View();
        }
        public ActionResult Footware()
        {
            ViewBag.Message = "Footware sector page.";

            return View();
        }
        public ActionResult Oilmill()
        {
            ViewBag.Message = "Oilmill sector page.";

            return View();
        }
        public ActionResult Ornaments()
        {
            ViewBag.Message = "Ornaments sector page.";

            return View();
        }
        public ActionResult Pharma()
        {
            ViewBag.Message = "Pharma sector page.";

            return View();
        }
        public ActionResult Refractory()
        {
            ViewBag.Message = "Refractory sector page.";

            return View();
        }
        public ActionResult Rubber()
        {
            ViewBag.Message = "Rubber sector page.";

            return View();
        }
        public ActionResult SteelRolling()
        {
            ViewBag.Message = "Steel Rolling sector page.";

            return View();
        }
        public ActionResult Tea()
        {
            ViewBag.Message = "Tea sector page.";

            return View();
        }

        public ActionResult Glass()
        {
            ViewBag.Message = "Glass sector page.";

            return View();
        }

        public ActionResult Leather()
        {
            ViewBag.Message = "Leather sector page.";

            return View();
        }

        public ActionResult Paper()
        {
            ViewBag.Message = "Paper sector page.";

            return View();
        }

        public ActionResult RiceMills()
        {
            ViewBag.Message = "Rice Mills sector page.";

            return View();
        }









        public ActionResult News()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Partner_agencies()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task<List<Cluster>> GetClusterDetailsList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_ClusterDetails/GetClusterDetailsList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Cluster>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        //public async Task<ActionResult> Subscription(String _email_val)
        //{
        //    String subscription_id = "0";
        //    List<String> ListParameter = new List<string>();
        //    ListParameter.Add(_email_val);
        //    ListParameter.Add(subscription_id);

        //    HttpClient httpClient = GenerateHttpClient();
        //    HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Base/SaveSubscription/", ListParameter).Result;
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
        //        if (objOutputMessage.MessageId > 0)
        //        {

        //            return RedirectToAction("Index", "Home"/*, new { sevent_id = model.Event.event_id }*/);
        //        }
        //        else
        //        {

        //            return RedirectToAction("Index", "Home"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
        //        }

        //    }
        //    else
        //    {
        //        ErrorMessage _ErrorMessage = await CheckResponse(response);
        //        throw new Exception(_ErrorMessage.ErrorMessages);
        //    }
        //}

        [HttpGet]
        [Route("Home/Subscription/")]
        public async Task<JsonResult> Subscription(String email_val)
        {
            String subscription_id = "0";
            List<String> ListParameter = new List<string>();
            ListParameter.Add(email_val);
            ListParameter.Add(subscription_id);

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Base/SaveSubscription/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                return Json(objOutputMessage, JsonRequestBehavior.AllowGet);

            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }

        }


        [HttpGet]
        [Route("Home/ImpactIndicators/")]
        public async Task<JsonResult> ImpactIndicators()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_ImpactIndicators/GetImpactIndicators/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsAsync<List<ImpactIndicatorModel>>();
                return Json(result[0], JsonRequestBehavior.AllowGet);
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }

        }

        public async Task<List<Photo>> GetPhotoGaleryDashboardList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Gallery/GetPhotoGalleryDashboardList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Photo>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<List<Video>> GetVideoGalleryDashboardList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Gallery/GetVideoGalleryDashboardList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Video>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<ActionResult> ResourceEfficiencyAssessment()
        {
            return View();
        }
        public async Task<ActionResult> EnergySavingsAssessment()
        {
            return View();
        }

        public async Task<ActionResult> Inauguration()
        {
            return View();
        }

        /**********************************************************************************/
        public ActionResult Indexs()
        {
            return View();
            /* string markers = "[";
             string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
             SqlCommand cmd = new SqlCommand("SELECT * FROM tblClusterDetails");
             using (SqlConnection con = new SqlConnection(conString))
             {
                 cmd.Connection = con;
                 con.Open();
                 using (SqlDataReader sdr = cmd.ExecuteReader())
                 {
                     while (sdr.Read())
                     {
                         markers += "{";
                         markers += string.Format("'title': '{0}',", sdr["cluster_name"]);
                         markers += string.Format("'lat': '{0}',", sdr["Latitude"]);
                         markers += string.Format("'lng': '{0}',", sdr["Longitude"]);
                         markers += string.Format("'description': '{0}'", sdr["Description"]);
                         markers += "},";
                     }
                 }
                 con.Close();
             }

             markers += "];";
             ViewBag.Markers = markers;
             return View();*/
        }
        public JsonResult GetPlaceNames(string stateName)
        {
            List<SelectListItem> names = PopulateLocations().Where(x => x.state == stateName)
                                        .Select(x => new SelectListItem { Text = x.name, Value = x.name })
                                        .Distinct().ToList();
            return Json(names, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetLocations(string location)
        {
            List<Location> locations;
            // List<Locations> locati;
            if (!string.IsNullOrEmpty(location))
            {
                locations = PopulateLocations().Where(x => x.name == location).ToList();
                //locations = PopulateStates().Where(x => x.state == location).ToList();
            }
            else
            {
                locations = PopulateLocations();
            }
            return Json(locations, JsonRequestBehavior.AllowGet);
        }
        /**************************************************************************************/
        public JsonResult GetStateNames()
        {
            List<SelectListItem> stat = PopulateStates()
                                        .Select(x => new SelectListItem { Text = x.state, Value = x.state })
                                        .Distinct().ToList();
            return Json(stat, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetMapLatLng(string state, string cluster, string sector)
        {
            List<Location> states;
            if (!string.IsNullOrEmpty(state) || !string.IsNullOrEmpty(cluster) || !string.IsNullOrEmpty(sector))
            {
                states = PopulateStates()
                    .Where(x => x.state == (state != null ? state : x.state) &&
                                x.name == (cluster != null ? cluster : x.name) &&
                                x.sector == (sector != null ? sector : x.sector)
                    ).ToList();
            }
            else
            {
                states = PopulateStates();
            }
            return Json(states, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSectorNames()
        {
            List<SelectListItem> sect = PopulateLocations()
                                        .Select(x => new SelectListItem { Text = x.sector, Value = x.sector })
                                        .Distinct().ToList();
            return Json(sect, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetSector(string sectors)
        {
            List<Location> sector;
            if (!string.IsNullOrEmpty(sectors))
            {
                sector = PopulateLocations().Where(x => x.name == sectors).ToList();
            }
            else
            {
                sector = PopulateLocations();
            }
            return Json(sector, JsonRequestBehavior.AllowGet);
        }




        /********************************************************************************************/
        private static List<Location> PopulateLocations()
        {
            List<Location> locations = new List<Location>();
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblClusterDetails");
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        locations.Add(new Location
                        {
                            name = sdr["location"].ToString(),
                            icn = sdr["icon"].ToString(),
                            sector = sdr["sector"].ToString(),
                            state = sdr["state"].ToString(),
                            stlat = Convert.ToDecimal(sdr["stLatitude"]),
                            stlng = Convert.ToDecimal(sdr["stLongitude"]),
                            lat = Convert.ToDecimal(sdr["Latitude"]),
                            lng = Convert.ToDecimal(sdr["Longitude"]),
                            description = sdr["Description"].ToString()
                        });
                    }
                }
                con.Close();
            }
            return locations;
        }
        private static List<Location> PopulateStates()
        {
            List<Location> states = new List<Location>();
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblClusterDetails");
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        states.Add(new Location
                        {
                            name = sdr["location"].ToString(),
                            icn = sdr["icon"].ToString(),
                            sector = sdr["sector"].ToString(),
                            state = sdr["state"].ToString(),
                            stlat = Convert.ToDecimal(sdr["stLatitude"]),
                            stlng = Convert.ToDecimal(sdr["stLongitude"]),
                            lat = Convert.ToDecimal(sdr["Latitude"]),
                            lng = Convert.ToDecimal(sdr["Longitude"]),
                            description = sdr["Description"].ToString()
                        });
                    }
                }
                con.Close();
            }
            return states;
        }
        public class Location
        {

            public string name { get; set; }
            public string sector { get; set; }
            public string state { get; set; }
            public decimal lat { get; set; }
            public decimal lng { get; set; }
            public decimal stlat { get; set; }
            public decimal stlng { get; set; }
            public string description { get; set; }
            public string icn { get; set; }
        }
        public class Locations
        {

            //public string name { get; set; }
            //public string sector { get; set; }
            public string state { get; set; }
            //public decimal lat { get; set; }
            //public decimal lng { get; set; }
            public decimal stlat { get; set; }
            public decimal stlng { get; set; }
            //public string description { get; set; }
        }
    }
}