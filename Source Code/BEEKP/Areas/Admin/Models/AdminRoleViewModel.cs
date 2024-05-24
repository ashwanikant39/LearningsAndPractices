using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminRoleViewModel
    {
        public List<Role> ListRole { get; set; }
        public PagePermission PagePermission { get; set; }
    }

    public class AdminRoleManageViewModel
    {
        public Role Role { get; set; }
        public List<UserType> ListUserType { get; set; }
        public List<File> ListFile { get; set; }
        public List<RoleFilePermission> ListRoleFilePermission { get; set; }
        public String user_id { get; set; }
    }
    public class Role
    {
        public Int32 role_id { get; set; }
        public Int32 user_type_id { get; set; }
        public String user_type_name { get; set; }
        public String role_name { get; set; }
        public String role_description { get; set; }
        public Int32 file_id { get; set; }
        public String file_name { get; set; }
    }

    public class RoleFilePermission
    {
        public Int32 role_file_id { get; set; }
        public Int32 file_id { get; set; }
        public String file_name { get; set; }
        public Boolean role_view { get; set; }
        public Boolean role_add { get; set; }
        public Boolean role_edit { get; set; }
        public Boolean role_delete { get; set; }

    }
}