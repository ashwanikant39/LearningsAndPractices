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
    public class BankFinancialController : BaseController
    {
        // GET: BankFinancial
        public async Task<ActionResult> Index()
        {
            try
            {
                BankFinancialViewModel objBankFinancialViewModel = new BankFinancialViewModel();
                objBankFinancialViewModel.ListBankFinancial = await GetBankFinancialListByInstitutionTypeAndCluster(Convert.ToInt32("0"), Convert.ToInt32("0"));

                objBankFinancialViewModel.ListTypeOfInstitution=await GetTypeOfInstitutionList();
                objBankFinancialViewModel.ListTypeOfInstitution.Insert(0, new TypeOfInstitution() { institution_type_id = 0, institution_type_name = "--ALL--" });
                AdminClusterDetailsController objAdminClusterDetailsController = new AdminClusterDetailsController();
                objBankFinancialViewModel.ListCluster = await objAdminClusterDetailsController.GetClusterDetailsList();
                objBankFinancialViewModel.ListCluster.Insert(0, new Cluster() { cluster_id = 0, cluster_name = "--ALL--" });

                return View(objBankFinancialViewModel);
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<List<BankFinancial>> GetBankFinancialListByInstitutionTypeAndCluster(Int32 sinstitution_type_id, Int32 scluster_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(sinstitution_type_id.ToString());
            ListParameter.Add(scluster_id.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_BankFinancial/GetBankFinancialListByInstitutionTypeAndCluster/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<BankFinancial>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<List<TypeOfInstitution>> GetTypeOfInstitutionList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetTypeOfInstitutionList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<TypeOfInstitution>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PopulateBankFinancialList(String sinstitution_type_id, String scluster_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(sinstitution_type_id);
            ListParameter.Add(scluster_id);

            BankFinancialViewModel objBankFinancialViewModel = new BankFinancialViewModel();
            objBankFinancialViewModel.ListBankFinancial = await GetBankFinancialListByInstitutionTypeAndCluster(Convert.ToInt32(sinstitution_type_id), Convert.ToInt32(scluster_id));

            return PartialView("_BankFinancialPartial", objBankFinancialViewModel);

            //HttpClient httpClient = GenerateHttpClient();
            //HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_EnergyProfessionals/EnergyProfessionalListByAreaSpecialization/", ListParameter).Result;
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
                

            //}
            //else
            //{
            //    ErrorMessage _ErrorMessage = await CheckResponse(response);
            //    throw new Exception(_ErrorMessage.ErrorMessages);
            //}
        }

        public async Task<ActionResult> Detail(String sbank_financial_id)
        {
            BankFinancialViewModel objBankFinancialViewModel = new BankFinancialViewModel();
            Int32 ibank_financial_id = Convert.ToInt32(Encryption.Decrypt(sbank_financial_id, true));

            objBankFinancialViewModel.BankFinancial = await GetBankFinancialById(ibank_financial_id);
            return View(objBankFinancialViewModel);
        }
        public async Task<BankFinancial> GetBankFinancialById(Int32 ibank_financial_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_BankFinancial/GetBankFinancialById/" + ibank_financial_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<BankFinancial>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

    }
}
