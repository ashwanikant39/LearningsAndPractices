using BEEKP.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BEEKP.Areas.Admin.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Admin/Error
        public ActionResult HttpError403()
        {
            return View();
        }

        public ActionResult HttpError404()
        {
            return View();
        }

        public ActionResult HttpError500()
        {
            return View();
        }

        public ActionResult GeneralError()
        {
            ErrorMessage objErrorMessage = new ErrorMessage();
            if (Session[ApplicationSession.ErrorMessages] != null)
            {
                objErrorMessage.ErrorId = Convert.ToString(Session[ApplicationSession.ErrorId]);
                objErrorMessage.ErrorMessages = Convert.ToString(Session[ApplicationSession.ErrorMessages]);
                objErrorMessage.ErrorType = Convert.ToString(Session[ApplicationSession.ErrorType]);
            }

            return View(objErrorMessage);
        }

    }
}