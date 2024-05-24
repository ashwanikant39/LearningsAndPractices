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
    public class EnergyTechnologiesController : BaseController
    {
        // GET: EnergyTechnologies
        public async Task<ActionResult> Index()
        {
            try
            {
                EnergyTechnologiesViewModel objEnergyTechnologiesViewModel = new EnergyTechnologiesViewModel();
                objEnergyTechnologiesViewModel.ListEnergyTechnology = await GetEnergyTechnologiesList(Constants.STATUS_ACTIVE,0);

                objEnergyTechnologiesViewModel.ListCluster = await GetClusterDetailsList();
                objEnergyTechnologiesViewModel.ListCluster.Insert(0, new Cluster() { cluster_id = 0, cluster_name = "---ALL---" });

                objEnergyTechnologiesViewModel.ListCategoryMeasure = await GetCategoryMeasureList();
                objEnergyTechnologiesViewModel.ListCategoryMeasure.Insert(0, new CategoryMeasure() { category_measure_id = 0, category_measure_name = "---ALL---" });
                return View(objEnergyTechnologiesViewModel);
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public async Task<List<EnergyTechnology>> GetFAQList(Int32 _status)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_EnergyTechnologies/GetEnergyTechnologiesList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<EnergyTechnology>>());
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

        public async Task<List<CategoryMeasure>> GetCategoryMeasureList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetCategoryMeasureList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<CategoryMeasure>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }


        public async Task<List<EnergyTechnology>> GetEnergyTechnologiesList(Int32 _status, Int32 _category_measure_id)

        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_category_measure_id.ToString());



            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_EnergyTechnologies/GetEnergyTechnologiesList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<EnergyTechnology>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PopulateEnergyTechnologies(Int32 _category_measure_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_category_measure_id.ToString());

            EnergyTechnologiesViewModel objEnergyTechnologiesViewModel = new EnergyTechnologiesViewModel();
            objEnergyTechnologiesViewModel.ListEnergyTechnology = await GetEnergyTechnologiesList(1, _category_measure_id);
            return PartialView("_EnergyTechnologiesPartial", objEnergyTechnologiesViewModel);
        
        }
    }
}