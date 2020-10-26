using EmployeeMngWebApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeMngWebApp.filter
{
    public class CustomFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Logger.CurrentLogger.Log(string.Format("/{0}/{1} is about to execute",
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                filterContext.ActionDescriptor.ActionName));
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Logger.CurrentLogger.Log(string.Format("/{0}/{1} executed!!",
               filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
               filterContext.ActionDescriptor.ActionName));
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Logger.CurrentLogger.Log("UI Processing is about to begin");
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Logger.CurrentLogger.Log("UI Processing is Done");
        }
    }
}