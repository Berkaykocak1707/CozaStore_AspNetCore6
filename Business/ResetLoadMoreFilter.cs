using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Business
{
	public class ResetLoadMoreFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var httpContext = context.HttpContext;
        var session = httpContext.Session;

        var currentUrl = httpContext.Request.Path;
        var previousUrl = session.GetString("previousUrl");

        if (!string.IsNullOrEmpty(previousUrl) && !previousUrl.Equals(currentUrl))
        {
            session.Remove("loadMore");
        }


        session.SetString("previousUrl", currentUrl);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {

    }
}
}
