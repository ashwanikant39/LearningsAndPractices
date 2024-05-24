using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BEEKP.Areas.Admin.Controllers;
using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using BEEKP.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BEEKP.Controllers
{
    public class AboutUsController : BaseController
    {
        // GET: AboutUs
        #region about_us
        public ActionResult AboutProject()
        {
            return View();
        }
        #endregion
        #region gef
        //public ActionResult GEF()
        public async Task<ActionResult> GEF()
        {
            GefViewModel objAboutController = new GefViewModel();

            if (Session["ShowModal"] == null)
            {
                objAboutController.show_modal = 1;
                Session["ShowModal"] = objAboutController.show_modal;
            }
            else
            {
                objAboutController.show_modal = 0;
            }


            AdminEventController objEventController = new AdminEventController();
            objAboutController.ListEventRecent =  await objEventController.GetEventList(Class.Constants.STATUS_ACTIVE, Class.Constants.EVENT_PERIOD_ALL, Class.Constants.EVENT_COUNT_DASHBOARD);
            objAboutController.ListEventUpcomming = await objEventController.GetEventList(Class.Constants.STATUS_ACTIVE, Class.Constants.EVENT_PERIOD_UPCOMMING, Class.Constants.EVENT_COUNT_DASHBOARD);

            HomeGalleryController objHomeGalleryController = new HomeGalleryController();
            objAboutController.ListPhoto = await GetPhotoGaleryDashboardList();
            objAboutController.ListVideo = await GetVideoGalleryDashboardList();

            AdminProjectComponentController objProjectComponentController = new AdminProjectComponentController();
            objAboutController.ListProjectComponent = await objProjectComponentController.GetProjectComponentList(Class.Constants.STATUS_ACTIVE);


            ClusterDetailsController objClusterDetailsController = new ClusterDetailsController();
            List<Cluster> ListClusterDetails = await GetClusterDetailsList();
            objAboutController.no_of_cluster = ListClusterDetails.Count();

            MSMEController objMSMEController = new MSMEController();
            List<MSME> ListMSME = await objMSMEController.GetMSMEList("0", "0");
            objAboutController.no_of_msmes = ListMSME.Count();


            return View(objAboutController);
            //return View();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutGef()
        {
            return View();
        }
        public ActionResult AboutBEE()
        {
            return View();
        }
        public ActionResult AboutUNIDO()
        {
            return View();
        }

        

        public ActionResult WorldBank()
        {
            return View();
        }
        #endregion

        #region Activities

        public ActionResult Activities()
        {
            return View();
        }


        public ActionResult EnergyAudits()
        {
            return View();
        }

        public ActionResult EMC()
        {
            return View();
        }

        public ActionResult CapacityBuilding()
        {
            return View();
        }

        public ActionResult CII()
        {
            return View();
        }
        public ActionResult TERI()
        {
            return View();
        }

        public ActionResult InHouse()
        {
            return View();
        }
        #region Sub InHouse
        public ActionResult inhouseBelgaum()
        {
            return View();
        }
        public ActionResult inhouseGujarat()
        {
            return View();
        }
        public ActionResult inhouseIndore()
        {
            return View();
        }
        public ActionResult inhouseJalandhar()
        {
            return View();
        }
        public ActionResult inhouseJamnagar()
        {
            return View();
        }
        public ActionResult inhouseKerala()
        {
            return View();
        }
        public ActionResult inhousekhurja()
        {
            return View();
        }
        public ActionResult inhouseMorbi()
        {
            return View();
        }
        public ActionResult inhouseNagaur()
        {
            return View();
        }
        public ActionResult inhouseThangadh()
        {
            return View();
        }
        
        #endregion
        public ActionResult InterCluster()
        {
            return View();
        }

        public ActionResult PilotProject()
        {
            return View();
        }
        public ActionResult KnowledgeMaterials()
        {
            return View();
        }
        public ActionResult Upscaling()
        {
            return View();
        }
        #endregion

        #region Knowledge Library
        public ActionResult KnowledgeLibrary()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult Videos()
        {
            return View();
        }
        public ActionResult CaseStudies()
        {
            return View();
        }

        public ActionResult TrainingManuals()
        {
            return View();
        }
        #endregion

        #region partner_agencies

        #region world_bank
        public ActionResult sector_detail()
        {
            return View();
        }

        public ActionResult ceramics()
        {
            return View();
        }

        public ActionResult dairy()
        {
            return View();
        }

        public ActionResult foundry()
        {
            return View();
        }

        public ActionResult handtools()
        {
            return View();
        }

        public ActionResult participatingmsme()
        {
            return View();
        }

        public ActionResult manufacturersandsuppliers()
        {
            return View();
        }

        public ActionResult energyexperts()
        {
            return View();

        }
        public ActionResult banksandfinancialinstitutions()
        {
            return View();
        }
        public ActionResult loanscheme()
        {
            return View();
        }
        public ActionResult subsidyscheme()
        {
            return View();
        }

        #endregion

        #region bureau_of_energy_efficiency
        public ActionResult BureauOfEnergyEfficiency()
        {
            return View();
        }
        #endregion

        #region small_industries_development_bank_of_india
        public ActionResult SmallIndustriesDevelopmentBankOfIndia()
        {
            return View();
        }
        #endregion

        #endregion
        #region knowledge_portal
        public ActionResult KnowledgePortal()
        {
            return View();
        }
        #endregion
        public ActionResult Partner_Agencies()
        {
            return View();
        }
        public ActionResult Key_People()
        {
            return View();
        }
        public ActionResult Bee()
        {
            return View();
        }
        public ActionResult Dc_msme()
        {
            return View();
        }
        public async Task<JsonResult> Subscription(String _email_val)
        {
            //List<ObligatoryEntity> lstObligatoryEntity = await GetObligatoryEntityByStateAgencyId(Convert.ToInt32(Encryption.DecryptToBase64(StateAgencyId)), Convert.ToInt32(Encryption.DecryptToBase64(UserTypeId)));
            //if (HasError())
            //{
            //    // return Json(new JsonResult { Data = Constants.AJAX_ERROR });
            //    return Json(new JsonResult { Data = Constants.AJAX_ERROR }, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json(lstObligatoryEntity, JsonRequestBehavior.AllowGet);
            //}

            String subscription_id = "0";
            List<String> ListParameter = new List<string>();
            ListParameter.Add(_email_val);
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

        public ActionResult Ministry_of_Power()
        {
            return View();
        }
    }
}