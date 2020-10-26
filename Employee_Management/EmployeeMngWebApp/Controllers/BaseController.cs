using EmployeeMngWebApp.filter;
using EmployeeMngWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeMngWebApp.Controllers
{
    [Authorize]
    [CustomFilter]
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    public class BaseController : Controller
    {
        protected EmployeeEntities dbObj { get; set; }
        // GET: Base
        public BaseController()
        {
            this.dbObj = new EmployeeEntities();
        }
    }
}