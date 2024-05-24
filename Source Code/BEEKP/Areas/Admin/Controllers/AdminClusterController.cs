using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
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

namespace BEEKP.Areas.Admin.Controllers
{
    public class AdminClusterController : AdminBaseController
    {
        // GET: Admin/AdminCluster
        public async Task<ActionResult> Index()
        {
            try
            {
                ClearError();
                AdminClusterViewModel objAdminClusterViewModel = new AdminClusterViewModel();
                objAdminClusterViewModel.ListClusters = await GetClusterList(1, null, 20);
                //objAdminClusterViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminCluster", "Admin");
                //if (objAdminClusterViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                //{
                //    return RedirectToAction("HttpError403", "Error");
                //}
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminClusterViewModel);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        [HttpGet]
        public async Task<ActionResult> ClusterAddEdit(string _id)
        {
            try
            {
                Int32 id = Convert.ToInt32(Encryption.Decrypt(_id, true));

                AdminCluster objCluster = new AdminCluster();

                //objCluster.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ClusterAddEdit", "AdminCluster", "Admin");
                //if (objCluster.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                //{
                //    return RedirectToAction("HttpError403", "Error");
                //}
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    if (id == 0)
                    {
                        objCluster = new AdminCluster();
                        objCluster.CreatedDate = DateTime.Now;
                        objCluster.IsActive = true;
                    }
                    else
                    {
                        objCluster = await GetClusterById(id);
                        objCluster.CreatedDate = DateTime.Now;

                        //return View(model);
                    }
                    objCluster.States = PopulateState();
                    objCluster.Sectors = PopulateSectors();
                    return View(objCluster);
                }

            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }
        public async Task<AdminCluster> GetClusterById(Int32 Id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_Cluster/GetClusterById/" + Id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<AdminCluster>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ClusterAddEdit(AdminCluster model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    model.States = PopulateState();
                    model.Sectors = PopulateSectors();
                    return View(model);
                }

                model.CreatedBy = Convert.ToString(Session[ApplicationSession.user_id]);
                model.CreatedDate = DateTime.Now;
                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<AdminCluster>("api/API_Cluster/SaveCluster/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminCluster"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ClusterAddEdit", "AdminCluster"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
                    }

                }
                else
                {
                    ErrorMessage _ErrorMessage = await CheckResponse(response);
                    throw new Exception(_ErrorMessage.ErrorMessages);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        public async Task<List<AdminCluster>> GetClusterList(Int32 IsActive, Int32? sectorId,Int32 _count)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(sectorId.ToString());
            ListParameter.Add(IsActive.ToString());
            ListParameter.Add("All");
            ListParameter.Add(_count.ToString());


            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_Cluster/GetClusterList/", ListParameter).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<AdminCluster>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        private static List<SelectListItem> PopulateState()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand("SELECT state,state_id FROM tblStates order by state");
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
                            Text = sdr["state"].ToString(),
                            Value = sdr["state_id"].ToString()
                        });
                    }
                }
                con.Close();
            }
            return items;
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
    }
}