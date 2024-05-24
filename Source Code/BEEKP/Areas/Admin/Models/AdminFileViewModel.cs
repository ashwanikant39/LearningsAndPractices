using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminFileViewModel
    {
        public List<File> ListFile { get; set; }
        public File File { get; set; }
        public AdminFileViewModel()
        {
            ListFile = new List<File>();
        }
    }

    public class AdminFileManageViewModel
    {
        public File File { get; set; }
        public String user_id { get; set; }


    }

    public class File
    {
        public Int32 file_id { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String file_name { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String view { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String controller { get; set; }
        [Required(ErrorMessage = "This Field Can't be empty")]
        public String area { get; set; }

        public File()
        {
            view = "";
            controller = "";
            area = "";
        }

    }
}