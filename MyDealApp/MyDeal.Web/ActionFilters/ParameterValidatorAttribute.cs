using System;
using System.Web.Mvc;

namespace MyDeal.Web.ActionFilters
{
    public class ParameterValidatorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            foreach(var kvp in filterContext.ActionParameters)
            {
                if (string.IsNullOrEmpty(kvp.Value.ToString()))
                    throw new Exception("Url is empty");
            }
        }
    }
}