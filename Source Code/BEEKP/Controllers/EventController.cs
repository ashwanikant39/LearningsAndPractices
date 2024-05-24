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
using System.Data;

namespace BEEKP.Controllers
{
    public class EventController : BaseController
    {
        // GET: Event
        public async Task<ActionResult> Detail(String sid, String period)
        {
            EventViewModel objEventViewModel = new EventViewModel();
            Int32 iEventID = Convert.ToInt32(Encryption.Decrypt(sid, true));
            String speriod = Convert.ToString(Encryption.Decrypt(period, true));

            AdminEventController objAdminEventController = new AdminEventController();
            objEventViewModel.Event = await GetEventById(iEventID);
            objEventViewModel.Event.listEventImage = await GetEventImageListByEventId(iEventID);
            objEventViewModel.Event_Period = speriod;
            if (objEventViewModel.Event_Period == Constants.EVENT_PERIOD_ALL)
                objEventViewModel.ListEventRecent = await objAdminEventController.GetEventList(Constants.STATUS_ACTIVE, Constants.EVENT_PERIOD_ALL, Constants.EVENT_COUNT_ALL);
            if (objEventViewModel.Event_Period == Constants.EVENT_PERIOD_UPCOMMING)
                objEventViewModel.ListEventUpcomming = await objAdminEventController.GetEventList(Constants.STATUS_ACTIVE, Constants.EVENT_PERIOD_UPCOMMING, Constants.EVENT_COUNT_ALL);

            return View(objEventViewModel);
        }

        public async Task<List<EventImage>> GetEventImageListByEventId(Int32 iEventID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Event/GetEventImageListByEventId/" + iEventID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<EventImage>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<List<EventImage>> GetEventList(String speriod)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Event/GetEventList/" +speriod + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<EventImage>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<Event> GetEventById(Int32 iEventID)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Event/GetEventById/" + iEventID.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<Event>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        //     public ActionResult List()
        //     {
        //         List<EventViewModel> objList = Event.();  // this method should returns list of  Users
        //         return View("users", objList)
        //}
        public ActionResult List()
          {
            List<EventViewModel> list = new List<EventViewModel>();
            return View(list);
            //return View();
        }
        //public async Task<List<EventViewModel>> GetEventList()
        //{
        //    HttpClient httpClient = GenerateHttpClient();
        //    HttpResponseMessage response = await httpClient.GetAsync("api/API_Event/GetEventList/");
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        return (await response.Content.ReadAsAsync<List<EventViewModel>>());
        //    }
        //    else
        //    {
        //        ErrorMessage _ErrorMessage = await CheckResponse(response);
        //        throw new Exception(_ErrorMessage.ErrorMessages);
        //    }
        //}
       /* public ActionResult Lists()
        {
            HomeViewModel em = new HomeViewModel();
            // Assign ALL already created dishes to the list that the user can choose.
            // AddedDishes is wrong? ViewBag preferred?
            CDataAccess objCDataAccess = new CDataAccess();
            DataTable dtData = objCDataAccess.GetDataTableSP("GetAreaSpecializationList", "");
            return View(em);
        }*/
        public ActionResult Lists(AdminEventViewModel avv, List<Event> evt)
        {
            avv.ListEventActive = evt;
            return View(avv);
        }
    }
}