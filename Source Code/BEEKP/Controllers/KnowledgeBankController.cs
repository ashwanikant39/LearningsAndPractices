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
    public class KnowledgeBankController : BaseController
    {
        // GET: KnowledgeBank
        public async Task<ActionResult> Index()
        {
            KnowledgeBankViewModel objKnowledgeBankViewModel = new KnowledgeBankViewModel();
            objKnowledgeBankViewModel.ListKnowledgeBankModel = await PopulateKnowledgeBankData();

            return View(objKnowledgeBankViewModel);
        }

        public async Task<List<KnowledgeBankModel>> PopulateKnowledgeBankData()
        {
            List<KnowledgeBankModel> ListKnowledgeBankModel = new List<KnowledgeBankModel>();
            List<KnowledgeBankType> lstKnowledgeBankType = await GetKnowledgeBankTypeList();

            foreach (KnowledgeBankType objKnowledgeBankType in lstKnowledgeBankType)
            {
                KnowledgeBankModel objKnowledgeBankModel = new KnowledgeBankModel();
                objKnowledgeBankModel.KnowledgeBankType = objKnowledgeBankType;
                objKnowledgeBankModel.ListKnowledgeBank = await GetKnowledgeBankListByKnowledgeType(objKnowledgeBankType.knowledge_bank_type_id);
                ListKnowledgeBankModel.Add(objKnowledgeBankModel);
            }

            return ListKnowledgeBankModel;
        }

        public async Task<List<KnowledgeBankType>> GetKnowledgeBankTypeList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Base/GetKnowledgeBankTypeList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<KnowledgeBankType>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<List<KnowledgeBank>> GetKnowledgeBankListByKnowledgeType(Int32 _knowledge_type_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_knowledge_type_id.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_KnowledgeBank/GetKnowledgeBankListByKnowledgeType/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<KnowledgeBank>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
    }
}