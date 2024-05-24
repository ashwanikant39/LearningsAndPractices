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
    public class FinancingSchemeController : BaseController
    {
        // GET: FinancingScheme
        public async Task<ActionResult> Index()
        {
            FinancingSchemeViewModel objFinancingSchemeViewModel = new FinancingSchemeViewModel();
            objFinancingSchemeViewModel.ListFinancialSchemeModel = await PopulateFinancialSchemeData();

            return View(objFinancingSchemeViewModel);
        }


        public async Task<ActionResult> BankLoan()
        {
            List<FinancingSchemeCtaegory> lstFinancingSchemeCtaegory = await GetCategoryMeasureList();
            //var queryLondonCustomers = from _FinancingSchemeCtaegory in lstFinancingSchemeCtaegory
            //                           where _FinancingSchemeCtaegory.financing_scheme_category_id == 1
            //                           select _FinancingSchemeCtaegory;

            List<FinancingSchemeCtaegory> lstScheme = lstFinancingSchemeCtaegory.Where(n => n.financing_scheme_category_id == Constants.FINANCING_SCHEME_CATEGORY_ID_BANK).ToList();


            FinancialSchemeBankLoanModel objFinancialSchemeBankLoanModel = new FinancialSchemeBankLoanModel();
            objFinancialSchemeBankLoanModel.FinancingSchemeCtaegory = lstScheme[0];
            objFinancialSchemeBankLoanModel.ListFinancingScheme = await GetFinancingSchemeList(Constants.STATUS_ACTIVE, objFinancialSchemeBankLoanModel.FinancingSchemeCtaegory.financing_scheme_category_id);

            return View(objFinancialSchemeBankLoanModel);
        }

        public async Task<ActionResult> GovernmentSubsidy()
        {
            List<FinancingSchemeCtaegory> lstFinancingSchemeCtaegory = await GetCategoryMeasureList();
            List<FinancingSchemeCtaegory> lstScheme = lstFinancingSchemeCtaegory.Where(n => n.financing_scheme_category_id == Constants.FINANCING_SCHEME_CATEGORY_ID_SUBSIDY).ToList();


            FinancialSchemeBankLoanModel objFinancialSchemeBankLoanModel = new FinancialSchemeBankLoanModel();
            objFinancialSchemeBankLoanModel.FinancingSchemeCtaegory = lstScheme[0];
            objFinancialSchemeBankLoanModel.ListFinancingScheme = await GetFinancingSchemeList(Constants.STATUS_ACTIVE, objFinancialSchemeBankLoanModel.FinancingSchemeCtaegory.financing_scheme_category_id);

            return View(objFinancialSchemeBankLoanModel);
        }

        public async Task<List<FinancialSchemeModel>> PopulateFinancialSchemeData()
        {
            List<FinancialSchemeModel> ListFinancialSchemeModel = new List<FinancialSchemeModel>();
            List<FinancingSchemeCtaegory> lstFinancingSchemeCtaegory = await GetCategoryMeasureList();

            foreach (FinancingSchemeCtaegory objFinancingSchemeCtaegory in lstFinancingSchemeCtaegory)
            {
                FinancialSchemeModel objFinancialSchemeModel = new FinancialSchemeModel();
                objFinancialSchemeModel.FinancingSchemeCtaegory = objFinancingSchemeCtaegory;
                objFinancialSchemeModel.ListFinancingScheme = await GetFinancingSchemeList(Constants.STATUS_ACTIVE, objFinancingSchemeCtaegory.financing_scheme_category_id);
                ListFinancialSchemeModel.Add(objFinancialSchemeModel);
            }

            return ListFinancialSchemeModel;
        }

        public async Task<List<FinancingSchemeCtaegory>> GetCategoryMeasureList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetFinancingSchemeCategoryList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<FinancingSchemeCtaegory>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }


        public async Task<List<FinancingScheme>> GetFinancingSchemeList(Int32 _status, Int32 _financing_scheme_category_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_financing_scheme_category_id.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_FinancingScheme/GetFinancingSchemeList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<FinancingScheme>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ActionResult> Detail(String sfinancing_scheme_id,String viewtype)
        {
            FinancingSchemeViewModel objFinancingSchemeViewModel = new FinancingSchemeViewModel();
            Int32 ifinancing_scheme_id = Convert.ToInt32(Encryption.Decrypt(sfinancing_scheme_id, true));
            objFinancingSchemeViewModel.Viewtype = viewtype;
            AdminFinancingSchemeController objAdminFinancingSchemeController = new AdminFinancingSchemeController();
            objFinancingSchemeViewModel.FinancingScheme = await objAdminFinancingSchemeController.GetFinancingSchemeById(ifinancing_scheme_id);
            return View(objFinancingSchemeViewModel);
        }

    }
}