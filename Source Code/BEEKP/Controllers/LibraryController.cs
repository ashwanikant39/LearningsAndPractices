using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using BEEKP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Controllers
{
    public class LibraryController : BaseController
    {
        // GET: Library
        //------Sub-Menu under Library Menu----
        public ActionResult Digital()
        {
            ViewBag.Clusters = new List<SelectListItem>();
            ViewBag.Sectors = PopulateSectors();
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> _DigitalSearch(int? sectorId,int? clusterId,DateTime? txtDate)
        {
            List<DigitalLibrary> listDigitalLibrarys = new List<DigitalLibrary>();
            listDigitalLibrarys = await GetDigitalLibraryList(1, sectorId, clusterId, txtDate, 20);
            return PartialView("_DigitalSearch", listDigitalLibrarys);
        }
        public async Task<List<DigitalLibrary>> GetDigitalLibraryList(Int32 IsActive, Int32? sectorId, Int32? clusterId, DateTime? createdDate, Int32 _count)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(sectorId.ToString());
            ListParameter.Add(clusterId.ToString());
            ListParameter.Add(createdDate.ToString());
            ListParameter.Add(IsActive.ToString());
            ListParameter.Add("");
            ListParameter.Add(_count.ToString());


            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_DigitalLibrary/GetDigitalLibraryList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<DigitalLibrary>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        [HttpGet]
        public ActionResult PopulateClusters(int Id)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand($"SELECT * FROM tblCluster where SectorId={Id} order by ClusterName");
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        items.Add(new SelectListItem
                        {
                            Text = sdr["ClusterName"].ToString(),
                            Value = sdr["Id"].ToString()
                        });
                    }
                }
                con.Close();
            }
            return Json(items,JsonRequestBehavior.AllowGet);
        }

        private static List<SelectListItem> PopulateSectors()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand("SELECT sector_name,sector_id FROM tblSector order by sector_name");
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        items.Add(new SelectListItem
                        {
                            Text = sdr["sector_name"].ToString(),
                            Value = sdr["sector_id"].ToString()
                        });
                    }
                }
                con.Close();
            }
            return items;
        }
        public async Task<ActionResult> NewsLetter()
        {
            List<KnowledgeBankType> lstKnowledgeBankType = await GetKnowledgeBankTypeList();

            List<KnowledgeBankType> lstbanktype = lstKnowledgeBankType.Where(n => n.knowledge_bank_type_id == Constants.NEWSLETTER_ID).ToList();

            KnowledgeBankModel objKnowledgeBankModel = new KnowledgeBankModel();
            objKnowledgeBankModel.KnowledgeBankType = lstbanktype[0];
            objKnowledgeBankModel.ListKnowledgeBank = await GetKnowledgeBankListByKnowledgeType(objKnowledgeBankModel.KnowledgeBankType.knowledge_bank_type_id);

            return View(objKnowledgeBankModel);
        }//1
        public async Task<ActionResult> ReportsAndPresentations()
        {
            List<KnowledgeBankType> lstKnowledgeBankType = await GetKnowledgeBankTypeList();

            List<KnowledgeBankType> lstbanktype = lstKnowledgeBankType.Where(n => n.knowledge_bank_type_id == Constants.REPORTS_ID).ToList();

            KnowledgeBankModel objKnowledgeBankModel = new KnowledgeBankModel();
            objKnowledgeBankModel.KnowledgeBankType = lstbanktype[0];
            objKnowledgeBankModel.ListKnowledgeBank = await GetKnowledgeBankListByKnowledgeType(objKnowledgeBankModel.KnowledgeBankType.knowledge_bank_type_id);

            return View(objKnowledgeBankModel);
        }//3
        public async Task<ActionResult> CreditRating()
        {
            List<KnowledgeBankType> lstKnowledgeBankType = await GetKnowledgeBankTypeList();

            List<KnowledgeBankType> lstbanktype = lstKnowledgeBankType.Where(n => n.knowledge_bank_type_id == Constants.CREDIT_RATING_ID).ToList();

            KnowledgeBankModel objKnowledgeBankModel = new KnowledgeBankModel();
            objKnowledgeBankModel.KnowledgeBankType = lstbanktype[0];
            objKnowledgeBankModel.ListKnowledgeBank = await GetKnowledgeBankListByKnowledgeType(objKnowledgeBankModel.KnowledgeBankType.knowledge_bank_type_id);

            return View(objKnowledgeBankModel);
        }//4
        public async Task<ActionResult> TrainingManual()
        {
            List<KnowledgeBankType> lstKnowledgeBankType = await GetKnowledgeBankTypeList();

            List<KnowledgeBankType> lstbanktype = lstKnowledgeBankType.Where(n => n.knowledge_bank_type_id == Constants.TRAINING_ID).ToList();

            KnowledgeBankModel objKnowledgeBankModel = new KnowledgeBankModel();
            objKnowledgeBankModel.KnowledgeBankType = lstbanktype[0];
            objKnowledgeBankModel.ListKnowledgeBank = await GetKnowledgeBankListByKnowledgeType(objKnowledgeBankModel.KnowledgeBankType.knowledge_bank_type_id);

            return View(objKnowledgeBankModel);
        }//5
        public async Task<ActionResult> BestPracticeGuide()
        {
            List<KnowledgeBankType> lstKnowledgeBankType = await GetKnowledgeBankTypeList();

            List<KnowledgeBankType> lstbanktype = lstKnowledgeBankType.Where(n => n.knowledge_bank_type_id == Constants.BEST_PRACTICE_ID).ToList();

            KnowledgeBankModel objKnowledgeBankModel = new KnowledgeBankModel();
            objKnowledgeBankModel.KnowledgeBankType = lstbanktype[0];
            objKnowledgeBankModel.ListKnowledgeBank = await GetKnowledgeBankListByKnowledgeType(objKnowledgeBankModel.KnowledgeBankType.knowledge_bank_type_id);

            return View(objKnowledgeBankModel);
        }//6
        public async Task<ActionResult> Notifications()
        {
            List<KnowledgeBankType> lstKnowledgeBankType = await GetKnowledgeBankTypeList();

            List<KnowledgeBankType> lstbanktype = lstKnowledgeBankType.Where(n => n.knowledge_bank_type_id == Constants.NOTIFICATION_ID).ToList();

            KnowledgeBankModel objKnowledgeBankModel = new KnowledgeBankModel();
            objKnowledgeBankModel.KnowledgeBankType = lstbanktype[0];
            objKnowledgeBankModel.ListKnowledgeBank = await GetKnowledgeBankListByKnowledgeType(objKnowledgeBankModel.KnowledgeBankType.knowledge_bank_type_id);

            return View(objKnowledgeBankModel);
        }//7
        public async Task<ActionResult> Gallery()
        {
            List<KnowledgeBankType> lstKnowledgeBankType = await GetKnowledgeBankTypeList();

            List<KnowledgeBankType> lstbanktype = lstKnowledgeBankType.Where(n => n.knowledge_bank_type_id == Constants.GALLERY_ID).ToList();

            KnowledgeBankModel objKnowledgeBankModel = new KnowledgeBankModel();
            objKnowledgeBankModel.KnowledgeBankType = lstbanktype[0];
            objKnowledgeBankModel.ListKnowledgeBank = await GetKnowledgeBankListByKnowledgeType(objKnowledgeBankModel.KnowledgeBankType.knowledge_bank_type_id);

            return View(objKnowledgeBankModel);
        }//8
        public async Task<ActionResult> Other()
        {
            List<KnowledgeBankType> lstKnowledgeBankType = await GetKnowledgeBankTypeList();

            List<KnowledgeBankType> lstbanktype = lstKnowledgeBankType.Where(n => n.knowledge_bank_type_id == Constants.OTHER_ID).ToList();

            KnowledgeBankModel objKnowledgeBankModel = new KnowledgeBankModel();
            objKnowledgeBankModel.KnowledgeBankType = lstbanktype[0];
            objKnowledgeBankModel.ListKnowledgeBank = await GetKnowledgeBankListByKnowledgeType(objKnowledgeBankModel.KnowledgeBankType.knowledge_bank_type_id);

            return View(objKnowledgeBankModel);
        }//9


        public async Task<ActionResult> Video()
        {
            VideoLibraryViewModel objVideoLibraryViewModel = new VideoLibraryViewModel();
            objVideoLibraryViewModel.ListSector = await GetVideoSectorList();
            objVideoLibraryViewModel.ListSector.Insert(0, new Sector() { sector_id = 0, sector_name = "--Select--" });

            objVideoLibraryViewModel.ListVideoLibrary = await GetVideoLibraryList(1, 0);

            return View(objVideoLibraryViewModel);

        }
        //----End Library Menu------

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

        public async Task<List<Sector>> GetVideoSectorList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Sector/GetVideoSectorList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<Sector>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }


        public async Task<List<VideoLibrary>> GetVideoLibraryList(Int32 _status, Int32 _sector_id)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_sector_id.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_KnowledgeBank/GetVideoLibraryListBySector/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<VideoLibrary>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GetVideosBySector(Int32 _sector_id)
        {
            VideoLibraryViewModel objVideoLibraryViewModel = new VideoLibraryViewModel();
            objVideoLibraryViewModel.ListVideoLibrary = await GetVideoLibraryList(1, _sector_id);

            return PartialView("_VideoPartial", objVideoLibraryViewModel);


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
        public ActionResult Tools()
        {
            return View();
        }
        public ActionResult SAMEEEKSHA()
        {
            return View();
        }
    }


}



