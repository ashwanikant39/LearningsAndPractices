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
    public class CaseStudyController : BaseController
    {
        // GET: CaseStudy
        public async Task<ActionResult> Index()
        {
            try
            {
                CaseStudyViewModel objCaseStudyViewModel = new CaseStudyViewModel();
                objCaseStudyViewModel.ListCaseStudy = await GetCaseStudyList(Convert.ToString(Constants.CASESTUDY_ALL));
                objCaseStudyViewModel.ListCluster = await GetClusterDetailsList();
                objCaseStudyViewModel.ListCluster.Insert(0, new Cluster() { cluster_id = 0, cluster_name = "--ALL--" });
                return View(objCaseStudyViewModel);
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        public async Task<List<CaseStudy>> GetCaseStudyList(String Parameter)
        {
            List<String> ListParameter = new List<string>();
            ListParameter.Add(Parameter);
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_CaseStudy/GetCaseStudyList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<CaseStudy>>());
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CaseStudyListByCluster(String sClusterID)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(sClusterID);

            CaseStudyViewModel objCaseStudyViewModel = new CaseStudyViewModel();
            objCaseStudyViewModel.ListCaseStudy = await GetCaseStudyList(sClusterID);
            return PartialView("_CaseStudyPartial", objCaseStudyViewModel);
        }
    }
}