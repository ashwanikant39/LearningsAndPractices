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
    public class EnergyProfessionalController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                EnergyProfessionalViewModel objEnergyProfessionalsViewModel = new EnergyProfessionalViewModel();
                objEnergyProfessionalsViewModel.ListEnergyProfessionals = await EnergyProfessionalList("0");
                objEnergyProfessionalsViewModel.ListAreaSpecialization = await GetAreaSpecializationsList();
                objEnergyProfessionalsViewModel.ListAreaSpecialization.Insert(0, new AreaSpecialization() { area_specialization_id = 0, area_specialization_name = "--ALL--" });
                return View(objEnergyProfessionalsViewModel);
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                return RedirectToAction("GeneralError", "Error");
            }
        }


        public async Task<List<EnergyProfessionals>> EnergyProfessionalList(String sAreaSpecializationID)
        {
            //List<String> ListParameter = new List<String>();
            //ListParameter.Add(_status.ToString());
            //ListParameter.Add(_approvedStatus.ToString());

            //HttpClient httpClient = GenerateHttpClient();
            //HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_EnergyProfessionals/GetEnergyProfessionalList/", ListParameter).Result;
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    return (await response.Content.ReadAsAsync<List<EnergyProfessionals>>());
            //}
            //else
            //{
            //    ErrorMessage _ErrorMessage = await CheckResponse(response);
            //    throw new Exception(_ErrorMessage.ErrorMessages);
            //}


            List<EnergyProfessionals> ListEnergyProfessionals = new List<EnergyProfessionals>();

            List <String> ListParameter = new List<String>();
            ListParameter.Add(sAreaSpecializationID);

            EnergyProfessionalViewModel objEnergyProfessionalsViewModel = new EnergyProfessionalViewModel();

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_EnergyProfessionals/EnergyProfessionalListByAreaSpecialization/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ListEnergyProfessionals = await response.Content.ReadAsAsync<List<EnergyProfessionals>>();

                return ListEnergyProfessionals;

            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnergyProfessionalListByAreaSpecialization(String sAreaSpecializationID)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(sAreaSpecializationID);

            EnergyProfessionalViewModel objEnergyProfessionalsViewModel = new EnergyProfessionalViewModel();
            objEnergyProfessionalsViewModel.ListEnergyProfessionals = await EnergyProfessionalList(sAreaSpecializationID);
            return PartialView("_EnergyProfessionalPartial", objEnergyProfessionalsViewModel);

            //HttpClient httpClient = GenerateHttpClient();
            //HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_EnergyProfessionals/EnergyProfessionalListByAreaSpecialization/", ListParameter).Result;
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    objEnergyProfessionalsViewModel.ListEnergyProfessionals = await response.Content.ReadAsAsync<List<EnergyProfessionals>>();

                
             
            //}
            //else
            //{
            //    ErrorMessage _ErrorMessage = await CheckResponse(response);
            //    throw new Exception(_ErrorMessage.ErrorMessages);
            //}
        }
        public ActionResult Energy_Management_Centres()
        {
            return View();
        }
        public ActionResult State_Designatted_Agencies()
        {
            return View();
        }
        public ActionResult Industrial_Associations()
        {
            return View();
        }
    }
}