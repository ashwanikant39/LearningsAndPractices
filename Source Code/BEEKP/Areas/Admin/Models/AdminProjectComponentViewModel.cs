using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEEKP.Areas.Admin.Models
{
    public class AdminProjectComponentViewModel
    {
        public List<ProjectComponent> ListProjectComponentActive { get; set; }
        public List<ProjectComponent> ListProjectComponentInactive { get; set; }
        public PagePermission PagePermission { get; set; }
    }
    public class ProjectComponent
    {
        public Int32 project_component_id { get; set; }
        public String project_component_title { get; set; }
        public String project_component_short_description { get; set; }
        public String project_component_full_description { get; set; }
        public String project_component_image_name { get; set; }
        public Boolean status { get; set; }
    }
    public class ProjectComponentManageModel
    {
        public PagePermission PagePermission { get; set; }
        public ProjectComponent ProjectComponent { get; set; }

        public String user_id { get; set; }

        public ProjectComponentManageModel()
        {
            ProjectComponent = new ProjectComponent();
            user_id = "";
        }
    }
}