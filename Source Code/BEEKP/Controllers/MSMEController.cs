using BEEKP.Areas.Admin.Controllers;
using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using BEEKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Controllers
{
    public class MSMEController : BaseController
    {
        // GET: MSME
        public async Task<ActionResult> Index()

        {
            try
            {
                MSMEViewModel objMSMEViewModel = new MSMEViewModel();
                objMSMEViewModel.ListMSME = await GetMSMEList("0", "0");

                AdminClusterDetailsController objAdminClusterDetailsController = new AdminClusterDetailsController();
                objMSMEViewModel.ListCluster = await objAdminClusterDetailsController.GetClusterDetailsList();
                objMSMEViewModel.ListCluster.Insert(0, new Cluster() { cluster_id = 0, cluster_name = "--Select--" });


                AdminSectorController objAdminSectorController = new AdminSectorController();
                objMSMEViewModel.ListSector = await objAdminSectorController.GetSectorList();
                objMSMEViewModel.ListSector.Insert(0, new Sector() { sector_id = 0, sector_name = "--Select--" });


                return View(objMSMEViewModel);
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                return RedirectToAction("GeneralError", "Error");
            }
        }


        public async Task<ActionResult> Detail(String smsme_id)
        {
            MSMEViewModel objMSMEViewModel = new MSMEViewModel();
            Int32 imsme = Convert.ToInt32(Encryption.Decrypt(smsme_id, true));

            AdminMSMEController objAdminMSMEController = new AdminMSMEController();
            objMSMEViewModel.MSME = await objAdminMSMEController.GetMSMEById(imsme);
            return View(objMSMEViewModel);
        }



        public async Task<List<MSME>> GetMSMEList(String _cluster_id, String _sector_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_cluster_id.ToString());
            ListParameter.Add(_sector_id.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_MSME/GetMSMEListByClusterIdAndSectorId/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<MSME>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> GetSectorList(String _cluster_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_cluster_id.ToString());

            List<Sector> lstSector = new List<Sector>();

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Base/GetSectorListByClusterId/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                lstSector = await response.Content.ReadAsAsync<List<Sector>>();
                lstSector.Insert(0, new Sector() { sector_id = 0, sector_name = "--Select--" });
                return Json(lstSector, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GetMSMEListByClusterIdAndSectorId(String _cluster_id, String _sector_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_cluster_id);
            ListParameter.Add(_sector_id);

            MSMEViewModel objMSMEViewModel = new MSMEViewModel();
            objMSMEViewModel.ListMSME = await GetMSMEList(_cluster_id, _sector_id);
            return PartialView("_MSMEPartial", objMSMEViewModel);

            //HttpClient httpClient = GenerateHttpClient();
            //HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_MSME/GetMSMEListByClusterIdAndSectorId/", ListParameter).Result;
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    objMSMEViewModel.ListMSME = await response.Content.ReadAsAsync<List<MSME>>();



            //}
            //else
            //{
            //    ErrorMessage _ErrorMessage = await CheckResponse(response);
            //    throw new Exception(_ErrorMessage.ErrorMessages);
            //}
        }
    }
}