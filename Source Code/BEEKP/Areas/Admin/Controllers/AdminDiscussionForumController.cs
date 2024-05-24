using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Areas.Admin.Controllers
{
    public class AdminDiscussionForumController : AdminBaseController
    {
        // GET: Admin/DiscussionForum
        public async Task<ActionResult> Index()
        {
            try
            {
                AdminDiscussionForumViewModel objAdminDiscussionForumViewModel = new AdminDiscussionForumViewModel();
                objAdminDiscussionForumViewModel.ListDiscussionForumActive = await GetDiscussionForumList(Constants.STATUS_ACTIVE, Constants.APPROVAL_STATUS_NOT_COMPARE);
                objAdminDiscussionForumViewModel.ListDiscussionForumInactive = await GetDiscussionForumList(Constants.STATUS_INACTIVE, Constants.APPROVAL_STATUS_NOT_COMPARE);
                objAdminDiscussionForumViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminDiscussionForum", "Admin");
                if (objAdminDiscussionForumViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminDiscussionForumViewModel);
                }
            }

            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        public async Task<ActionResult> Approve()
        {
            try
            {
                AdminDiscussionForumApprovedViewModel objAdminDiscussionForumApprovedViewModel = new AdminDiscussionForumApprovedViewModel();
                objAdminDiscussionForumApprovedViewModel.ListDiscussionForumApproval_Pending = await GetDiscussionForumList(Constants.STATUS_NOT_COMPARE, Constants.APPROVAL_STATUS_PENDING);
                objAdminDiscussionForumApprovedViewModel.ListDiscussionForumApproval_Approved = await GetDiscussionForumList(Constants.STATUS_NOT_COMPARE, Constants.APPROVAL_STATUS_APPROVED);
                objAdminDiscussionForumApprovedViewModel.ListDiscussionForumApproval_Rejected = await GetDiscussionForumList(Constants.STATUS_NOT_COMPARE, Constants.APPROVAL_STATUS_REJECTED);
                objAdminDiscussionForumApprovedViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Approve", "AdminDiscussionForum", "Admin");
                if (objAdminDiscussionForumApprovedViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {
                    return View(objAdminDiscussionForumApprovedViewModel);
                }
                
            }

            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        public async Task<ActionResult> ManageDiscussionForum(String sforum_id)
        {
            try
            {
                Int32 iforum_id = Convert.ToInt32(Encryption.Decrypt(sforum_id, true));
                


                AdminClusterDetailsController objClusterDetailsController = new AdminClusterDetailsController();
                DiscussionForumManageModel objDiscussionForumManageModel = new DiscussionForumManageModel();
                objDiscussionForumManageModel.ListCluster = await objClusterDetailsController.GetClusterDetailsList();
                objDiscussionForumManageModel.ListCluster.Insert(0, new Cluster() { cluster_id = 0, cluster_name = "--Select--", fuel_used = "", location = "", number_of_units = 0, overall_turnover = 0, products_manufactured = "" });
                objDiscussionForumManageModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageDiscussionForum", "AdminDiscussionForum", "Admin");
                if (objDiscussionForumManageModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {

                    if (iforum_id == 0)
                    {
                        objDiscussionForumManageModel.DiscussionForum = new DiscussionForum();

                    }
                    else
                    {
                        objDiscussionForumManageModel.DiscussionForum = await GetDiscussionForumById(iforum_id);

                    }

                    return View(objDiscussionForumManageModel);
                }
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
        public async Task<ActionResult> ManageDiscussionForum(DiscussionForumManageModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }


                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<DiscussionForumManageModel>("api/API_DiscussionForum/SaveDiscussionForum/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminDiscussionForum"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageDiscussionForum", "AdminDiscussionForum"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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

        public async Task<ActionResult> ApproveDiscussionForum(String sforum_id)
        {
            try
            {
                Int32 iforum_id = Convert.ToInt32(Encryption.Decrypt(sforum_id, true));
                

                DiscussionForumApproveModel objDiscussionForumApproveModel = new DiscussionForumApproveModel();
                if (iforum_id == 0)
                {
                    ToastrMessage_Error("Invalid Discussion Forum");
                    return RedirectToAction("Approve", "AdminDiscussionForum");
                }
                else
                {
                    objDiscussionForumApproveModel.DiscussionForum = await GetDiscussionForumById(iforum_id);
                    return View(objDiscussionForumApproveModel);
                }

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
        public async Task<ActionResult> ApproveDiscussionForum(DiscussionForumApproveModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }


                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<DiscussionForumApproveModel>("api/API_DiscussionForum/ApproveDiscussionForum/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Approve", "AdminDiscussionForum"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ApproveDiscussionForum", "AdminDiscussionForum"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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

        public async Task<List<DiscussionForum>> GetDiscussionForumList(Int32 _status, Int32 _approvedStatus)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_approvedStatus.ToString());

            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_DiscussionForum/GetDiscussionForumList/", ListParameter).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<DiscussionForum>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<DiscussionForum> GetDiscussionForumById(Int32 iforum_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_DiscussionForum/GetDiscussionForumById/" + iforum_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<DiscussionForum>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }
        public async Task<ActionResult> DeleteDiscussionForum(String sforum_id)
        {
            try
            {
                Int32 iforum_id = Convert.ToInt32(Encryption.Decrypt(sforum_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_DiscussionForum/DeleteDiscussionForum/" + iforum_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminDiscussionForum");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminDiscussionForum");
                    }

                    return RedirectToAction("Index", "AdminDiscussionForum", new { sforum_id = sforum_id });
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
    }
}