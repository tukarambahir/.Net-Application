using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeMngWebApp.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            #region UserName Display
            //if (User.Identity.IsAuthenticated)
            //{
            //    ViewBag.UserName = User.Identity.Name;

            //}
            //else
            //{
            //    ViewBag.UserName = "";


            //}
            #endregion

            @ViewBag.UserName = User.Identity.IsAuthenticated;
            return View();
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}