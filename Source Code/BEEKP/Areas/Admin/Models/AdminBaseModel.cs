using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminBaseModel
    {
    }

    public class UserType
    {
        public Int32 user_type_id { get; set; }
        public String user_type_name { get; set; }

    }

    public class UserLog
    {
        public Int32 user_log_id { get; set; }
        public Int32 user_id { get; set; }
        public String mac_address { get; set; }
        public String ip_address { get; set; }
    }

    public class PagePermission
    {
        public Int32 role_file_id { get; set; }
        public String file_name { get; set; }
        public String role_view { get; set; }
        public String role_add { get; set; }
        public String role_edit { get; set; }
        public String role_delete { get; set; }
    }


    public class MenuViewModel
    {
        public Menu Menu { get; set; }
        public Int32 ParentMenuID { get; set; }
        public List<MenuFile> ListMenufile { get; set; }
        public List<MenuFile> ListParentMenu { get; set; }
        public String file_id { get; set; }
        public PagePermission PagePermission { get; set; }
    }

    public class Menu
    {
        public Int32 menu_id { get; set; }
        public String menu_name { get; set; }
        public Int32 role_id { get; set; }
        public Int32 is_active { get; set; }
    }

    public class MenuFile
    {
        public Int32 menu_file_id { get; set; }
        public Int32 menu_id { get; set; }
        public Int32? file_id { get; set; }
        public String view { get; set; }
        public String controller { get; set; }
        public String area { get; set; }
        public String menu_caption { get; set; }
        public Int32? parent_menu_id { get; set; }
        public Boolean is_parent { get; set; }
        public Int32 display_order { get; set; }
        public Boolean is_active { get; set; }
        public String menu_icon { get; set; }
        public Boolean role_view { get; set; }

        List<MenuFile> ListMenfile = new List<MenuFile>();

    }

    public class ManageMenuFile
    {
        public Int32 MenuFileID { get; set; }
        public Int32 MenuID { get; set; }
        public Int32? FileID { get; set; }
        public String MenuCaption { get; set; }
        public Int32? ParentMenuID { get; set; }
        public Boolean IsParent { get; set; }
        public Int32 DisplayOrder { get; set; }
        public Boolean IsActive { get; set; }
        public String MenuIcon { get; set; }
    }

    public class ManageMenuViewModel
    {
        public ManageMenuFile ManageMenuFile { get; set; }
        public List<File> ListFile { get; set; }
        public List<MenuFile> ListPayrentMenu { get; set; }
        public List<MenuFile> ListChildMenu { get; set; }
        public Int32 user_id { get; set; }

        public PagePermission PagePermission { get; set; }
        public String file_id { get; set; }
    }
}