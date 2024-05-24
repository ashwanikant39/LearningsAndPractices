using BEEKP.Areas.Admin.Controllers;
using BEEKP.Class;
using BEEKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Controllers
{
    public class ProjectComponentController : BaseController
    {
        // GET: ProjectComponent
        public async Task<ActionResult> Detail(String id)
        {
            ProjectComponentViewModel objProjectComponentViewModel = new ProjectComponentViewModel();
            Int32 iproject_component_id = Convert.ToInt32(Encryption.Decrypt(id, true));
            AdminProjectComponentController objAdminProjectComponentController = new AdminProjectComponentController();
            objProjectComponentViewModel.ProjectComponent = await objAdminProjectComponentController.GetProjectComponentById(iproject_component_id);
            return View(objProjectComponentViewModel);
        }
        public ActionResult BEE_SME_Programme()
        {
            return View();
        }
        public ActionResult Brick_Mission()
        {
            return View();
        }
        public ActionResult GEF_WorldBank()
        {
            return View();
        }
        public ActionResult GEF_UNIDO()
        {
            return View();
        }
        public ActionResult Japan_India_Energy_Dialogue()
        {
            return View();
        }
        public ActionResult Indo_German_Energy_Programme()
        {
            return View();
        }
        public ActionResult BEE_2021()
        {
            return View();
        }
















































    }
}