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
    public class ManufacturersController : BaseController
    {
        // GET: Manufacturers
        public async Task<ActionResult> Index()
        {
            try
            {
                ManufacturersViewModel objManufacturersViewModel = new ManufacturersViewModel();
                objManufacturersViewModel.ListManufacturers = await GetManufacturersList(Constants.STATUS_ACTIVE, Constants.APPROVAL_STATUS_APPROVED);
                objManufacturersViewModel.ListEE_equipment = await GetEE_equipmentList();
                objManufacturersViewModel.ListEE_equipment.Insert(0, new EE_equipment() { EE_equipment_id = 0, EE_equipment_name = "--ALL--" });
                return View(objManufacturersViewModel);
            }

            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        public async Task<List<Manufacturers>> GetManufacturersList(Int32 _status, Int32 _approvedStatus, Int32 page_no = 1, Int32 page_size = 10, string Search = null)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_approvedStatus.ToString());
            ListParameter.Add(page_no.ToString());
            ListParameter.Add(page_size.ToString());
            ListParameter.Add(Search);

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Manufacturers/GetManufacturersList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ManufacturersViewModel model = await response.Content.ReadAsAsync<ManufacturersViewModel>();
                return (model.ListManufacturers);
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GetManufacturerListByEEEquipmentId(String sEE_EquipmentID)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(sEE_EquipmentID);

            ManufacturersViewModel objManufacturersViewModel = new ManufacturersViewModel();

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Manufacturers/GetManufacturerListByEEEquipmentId/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                objManufacturersViewModel.ListManufacturers = await response.Content.ReadAsAsync<List<Manufacturers>>();

                return PartialView("_ManufacturersPartial", objManufacturersViewModel);

            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<ActionResult> Detail(String smanufacturer_id)
        {
            ManufacturersViewModel objManufacturersViewModel = new ManufacturersViewModel();
            Int32 imanufacturer_id = Convert.ToInt32(Encryption.Decrypt(smanufacturer_id, true));

            objManufacturersViewModel.Manufacturers = await GetManufacturersById(imanufacturer_id);
            return View(objManufacturersViewModel);
        }

        public async Task<Manufacturers> GetManufacturersById(Int32 imanufacturer_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Manufacturers/GetManufacturersById/" + imanufacturer_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<Manufacturers>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

    }
}