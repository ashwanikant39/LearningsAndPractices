using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminSectorsViewModel
    {
            public List<Sectors> ListSectorsActive { get; set; }
            public List<Sectors> ListSectorsInactive { get; set; }
            public Sectors Sectors { get; set; }
            public PagePermission PagePermission { get; set; }
            public AdminSectorsViewModel()
            {
            ListSectorsActive = new List<Sectors>();
            ListSectorsInactive = new List<Sectors>();
            }
        }

        public class Sectors
    {
            public Int32 sectors_id { get; set; }

            [Required(ErrorMessage = "This Field Can't be empty")]
            public String sectors_name { get; set; }
            [Required(ErrorMessage = "This Field Can't be empty")]
            public String sectors_location { get; set; }
            public String sectors_short_description { get; set; }
            [Required(ErrorMessage = "This Field Can't be empty")]
            public String sectors_full_description { get; set; }
            public string sectors_image_name { get; set; }
            public Boolean status { get; set; }
            public String sectors_image_upload { get; set; }
            public List<SectorsImage> listSectorsImage { get; set; }

            public Sectors()
            {
            sectors_id = 0;
            sectors_name = "";
            sectors_location = "";
            sectors_short_description = "";
            sectors_full_description = "";
            sectors_image_name = "";
            listSectorsImage = new List<SectorsImage>();
            }

        }
        public class SectorsViewAddEditModel
    {
            public PagePermission PagePermission { get; set; }
            public Sectors Sectors { get; set; }

            public String user_id { get; set; }

            public SectorsViewAddEditModel()
            {
                PagePermission = new PagePermission();
            Sectors = new Sectors();

                user_id = "";
            }
        }
        public class SectorsImage
    {
            public Int32 sectors_image_id { get; set; }
            public Int32 sectors_id { get; set; }
            public String sectors_image_name { get; set; }


        }

        public class SectorsImageAddEditViewModel
    {
            public PagePermission PagePermission { get; set; }
            public Int32 sectors_id { get; set; }
            public SectorsImage SectorsImage { get; set; }
            public String user_id { get; set; }


            public SectorsImageAddEditViewModel()
            {
                PagePermission = new PagePermission();
                SectorsImage = new SectorsImage();
                user_id = "";
            }
        }
    }
