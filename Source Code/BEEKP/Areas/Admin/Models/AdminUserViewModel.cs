using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminUserViewModel
    {
        public List<AdminUserData> ListUserData { get; set; }
        public AdminUserViewModel()
        {
            ListUserData = new List<AdminUserData>();
        }
    }


    public class AdminUserData
    {
        public User User { get; set; }
        public List<UserLog> ListUserLog { get; set; }
        public AdminUserData()
        {
            ListUserLog = new List<UserLog>();
            
        }
    }
    public class User
    {
        public Int32 user_id { get; set; }
        public Int32 user_type_id { get; set; }
        public Int32 role_id { get; set; }
        public String user_type_name { get; set; }
        public String emailid { get; set; }
        public String mobile { get; set; }
        public String role_name { get; set; }
        public String password { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String address { get; set; }
        public Int32 state_id { get; set; }
        public String state_name { get; set; }
        public String city_name { get; set; }
        public Int32 pincode { get; set; }
        public User()
        {
            emailid = "";
            mobile = "";
            role_name = "";
            password = "";
            first_name = "";
            last_name = "";
            address = "";
            state_name = "";
            city_name = "";
            user_type_name = "";
        }

    }



    public class UserManageModel
    {
        public List<UserType> ListUserType { get; set; }
        public List<State> ListState { get; set; }
        public List<Role> ListRole { get; set; }
        public User User { get; set; }
        public Int32 created_by { get; set; }
        public UserManageModel()
        {
            ListUserType = new List<UserType>();
            ListState = new List<State>();
            ListRole = new List<Role>();
        }

    }
}