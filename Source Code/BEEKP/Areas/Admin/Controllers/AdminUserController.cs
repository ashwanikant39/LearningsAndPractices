using BEEKP.Areas.Admin.Models;
using BEEKP.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Areas.Admin.Controllers
{
    public class AdminUserController : AdminBaseController
    {
        // GET: Admin/AdminUserControlle
        public async Task<ActionResult> Index()
        {
            AdminUserViewModel objAdminUserViewModel = new AdminUserViewModel();
          
            List<User> lstUser = await GetUserList();
            foreach(User objUser in lstUser)
            {
                AdminUserData objAdminUserData = new AdminUserData();
                objAdminUserData.User = objUser;
                objAdminUserData.ListUserLog = await GetUserLogList(objUser.user_id);
                objAdminUserViewModel.ListUserData.Add(objAdminUserData);
            }


            return View(objAdminUserViewModel);

        }
        public async Task<List<User>> GetUserList()
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_User/GetUserList/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<User>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        [HttpPost]
        public async Task<List<UserLog>> GetUserLogList(Int32 _user_id) //post
        {
            List<String> ListParameter = new List<string>();
            ListParameter.Add(Convert.ToString(_user_id));


            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = httpClient.PostAsJsonAsync<List<String>>("api/API_User/GetUserLogList/",ListParameter).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<List<UserLog>>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

        public async Task<ActionResult> ManageUser(String suser_id)
        {
            Int32 iuser_id = Convert.ToInt32(Encryption.Decrypt(suser_id, true));

            UserManageModel objUserManageModel = new UserManageModel();
            objUserManageModel.ListUserType = await GetUserTypeList();
            objUserManageModel.ListUserType.Insert(0, new UserType() { user_type_id = 0, user_type_name = "--Select--" });
            objUserManageModel.ListState = await GetStateList();
            objUserManageModel.ListState.Insert(0, new State() { state_id = 0, state_name = "--Select--" });

            //RoleController objRoleController = new RoleController();
            //objUserManageModel.ListRole = await objRoleController.GetRoleList();
            //objUserManageModel.ListRole.Insert(0, new Role() { role_id = 0, role_name = "--Select--" });

            if (iuser_id == 0)
            {
                objUserManageModel.User = new User();

            }
            else
            {
                //objUserManageModel.User = await GetUserById(iuser_id);
                //return RedirectToAction("Modal", "AdminUser");
                objUserManageModel.User = await GetUserById(iuser_id);
                Session["TempUserPassword"] = objUserManageModel.User.password;
                objUserManageModel.User.password = Encryption.Encrypt(objUserManageModel.User.password, true);

            }
            return View(objUserManageModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ManageUser(UserManageModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(model);
                }


                model.created_by = Convert.ToInt32(Session[ApplicationSession.user_id]);

                HttpClient httpClient = GenerateHttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<UserManageModel>("api/API_User/SaveUser/", model).Result;

                if(model.User.user_id!=0 && Session["TempUserPassword"]!= null )
                {

                    String _prePassword = Encryption.Decrypt(Convert.ToString(Session["TempUserPassword"]), true);
                 
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OutputMessage objOutputMessage = await response.Content.ReadAsAsync<OutputMessage>();
                    if (objOutputMessage.MessageId > 0)
                    {
                        ToastrMessage_Success(objOutputMessage.Message);
                        return RedirectToAction("Index", "AdminUser"/*, new { sevent_id = model.Event.event_id }*/);
                    }
                    else
                    {
                        model.ListUserType = await GetUserTypeList();
                        model.ListUserType.Insert(0, new UserType() { user_type_id = 0, user_type_name = "--Select--" });
                        model.ListState = await GetStateList();
                        model.ListState.Insert(0, new State() { state_id = 0, state_name = "--Select--" });

                        ToastrMessage_Error(objOutputMessage.Message);
                        return RedirectToAction("ManageUser", "AdminUser"/*, new { sBenchmarkID = Encryption.Encrypt(objOutputMessage.MessageId.ToString(), true), sfile_id = model.file_id }*/);
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

        public async Task<User> GetUserById(Int32 iuser_id)
        {
            HttpClient httpClient = GenerateHttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("api/API_User/GetUserById/" + iuser_id.ToString() + "/");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return (await response.Content.ReadAsAsync<User>());
            }
            else
            {
                ErrorMessage _ErrorMessage = await CheckResponse(response);
                throw new Exception(_ErrorMessage.ErrorMessages);
            }
        }

    }
}