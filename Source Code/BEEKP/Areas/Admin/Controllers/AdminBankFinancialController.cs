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
    public class AdminBankFinancialController : AdminBaseController
    {
        // GET: Admin/AdminBankFinancial
        public async Task<ActionResult> Index()
        {
            try
            {
                AdminBankFinancialViewModel objAdminBankFinancialViewModel = new AdminBankFinancialViewModel();
                objAdminBankFinancialViewModel.ListBankFinancialInactive = await GetBankFinancialList(Constants.STATUS_NOT_COMPARE, Constants.APPROVAL_STATUS_NOT_COMPARE);
                objAdminBankFinancialViewModel.ListBankFinancialActive = await GetBankFinancialList(Constants.STATUS_ACTIVE, Constants.APPROVAL_STATUS_APPROVED);
                objAdminBankFinancialViewModel.PagePermission = await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "Index", "AdminBankFinancial", "Admin");
                if (objAdminBankFinancialViewModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                { 
                    return View(objAdminBankFinancialViewModel);
                }
            }

            catch (Exception ex)
            {
                ErrorMessage objErrorMessage = new ErrorMessage() { ErrorId = "", ErrorMessages = ex.Message, ErrorType = Constants.ERROR_TYPE_GENERAL };
                PopulateError(objErrorMessage);
                return RedirectToAction("GeneralError", "Error");
            }
        }

        public async Task<ActionResult> ManageBankFinancial(String sbank_financial_id)
        {
            try
            {
                Int32 ibank_financial_id = Convert.ToInt32(Encryption.Decrypt(sbank_financial_id, true));
                //Int32 ibank_financial_id = Convert.ToInt32(sbank_financial_id);


                AdminClusterDetailsController objClusterDetailsController = new AdminClusterDetailsController();
                BankFinancialManageModel objBankFinancialManageModel = new BankFinancialManageModel();
                objBankFinancialManageModel.ListCluster = await objClusterDetailsController.GetClusterDetailsList();
                objBankFinancialManageModel.ListCluster.Insert(0, new Cluster() { cluster_id = 0, cluster_name = "--Select--", fuel_used = "", location = "", number_of_units = 0, overall_turnover = 0, products_manufactured = "" });
                objBankFinancialManageModel.ListTypeOfInstitution = await GetTypeOfInstitutionList();
                objBankFinancialManageModel.ListTypeOfInstitution.Insert(0, new TypeOfInstitution() { institution_type_id = 0, institution_type_name = "--Select--" });
                objBankFinancialManageModel.PagePermission=await GetPagePermission(Convert.ToInt32(Session[ApplicationSession.role_id]), "ManageBankFinancial", "AdminBankFinancial", "Admin");
                if (objBankFinancialManageModel.PagePermission.role_view != Constants.PAGE_PERMISSION_YES)
                {
                    return RedirectToAction("HttpError403", "Error");
                }
                if (HasError())
                {
                    return RedirectToAction("GeneralError", "Error");
                }
                else
                {

                    if (ibank_financial_id == 0)
                    {
                        objBankFinancialManageModel.BankFinancial = new BankFinancial();
                        
                    }
                    else
                    {
                        objBankFinancialManageModel.BankFinancial = await GetBankFinancialById(ibank_financial_id);

                    }
                }
                return View(objBankFinancialManageModel);
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
        public async Task<ActionResult> ManageBankFinancial(BankFinancialManageModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }


                model.user_id = Convert.ToString(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<BankFinancialManageModel>("api/API_BankFinancial/SaveBankFinancial/", model).Result;



                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminBankFinancial"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageBankFinancial", "AdminBankFinancial"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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

        public async Task<List<BankFinancial>> GetBankFinancialList(Int32 _status, Int32 _approvedStatus)
        {
            List<String> ListParameter = new List<String>();
            ListParameter.Add(_status.ToString());
            ListParameter.Add(_approvedStatus.ToString());



            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_BankFinancial/GetBankFinancialList/", ListParameter).Result;
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

        public async Task<ActionResult> DeleteBankFinancial(String sbank_financial_id)
        {
            try
            {
                Int32 ibank_financial_id = Convert.ToInt32(Encryption.Decrypt(sbank_financial_id, true));

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("api/API_BankFinancial/DeleteBankFinancial/" + ibank_financial_id.ToString() + "/");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();

                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminBankFinancial");
                    }
                    else
                    {
                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminBankFinancial");
                    }

                    return RedirectToAction("Index", "AdminBankFinancial", new { sbank_financial_id = sbank_financial_id });
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