using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Umc.Web
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString IsMenuActive(this HtmlHelper htmlHelper,
                                        string linkText,
                                        string actionName,
                                        string controllerName
                                        )
        {

            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            if (actionName == currentAction && controllerName == currentController)
            {
                return htmlHelper.ActionLink(actionName, controllerName, null, new { @class = "active" });
            }

            return htmlHelper.Action(actionName, controllerName);
        }
    }
}