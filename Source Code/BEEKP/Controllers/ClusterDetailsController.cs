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
    public class ClusterDetailsController : BaseController
    {
        // GET: ClusterDetails
        public async Task<ActionResult> Index()
        {
            try
            {
                ClusterDetailsViewModel objClusterDetailsViewModel = new ClusterDetailsViewModel();
                objClusterDetailsViewModel.ListClusterDetailsModel = await GetClusterDetailModelList();

                return View(objClusterDetailsViewModel);
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        public async Task<List<ClusterDetailsModel>> GetClusterDetailModelList()
        {
            
            List<ClusterDetailsModel> ListClusterDetailsModel = new List<ClusterDetailsModel>();
            List<Phases> ListPhase = await GetPhaseList();

            foreach(Phases objPhase in ListPhase)
            {
                ClusterDetailsModel objClusterDetailsModel = new ClusterDetailsModel();
                objClusterDetailsModel.Phases = objPhase;
                objClusterDetailsModel.ListCluster = await GetClusterDetailsListByPhaseId(objPhase.phases_id);

                ListClusterDetailsModel.Add(objClusterDetailsModel);

            }

            return ListClusterDetailsModel;


            //HttpClient httpClient = GenerateHttpClient();
            //HttpResponseMessage response = await httpClient.GetAsync("api/API_ClusterDetails/GetClusterDetailsList/");
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    return (await response.Content.ReadAsAsync<List<ClusterDetailsModel>>());
            //}
            //else
            //{
            //    ErrorMessage _ErrorMessage = await CheckResponse(response);
            //    throw new Exception(_ErrorMessage.ErrorMessages);
            //}
        }

        public async Task<List<Phases>> GetPhaseList()
        {
            HttpClient httpclient = GenerateHttpClient();
            HttpResponseMessage response = await httpclient.GetAsync("api/API_Base/GetPhaseList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Phases>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<List<Cluster>> GetClusterDetailsListByPhaseId(Int32 _phase_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_phase_id.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_ClusterDetails/GetClusterDetailsListByPhaseId/", ListParameter).Result;
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
    }
}