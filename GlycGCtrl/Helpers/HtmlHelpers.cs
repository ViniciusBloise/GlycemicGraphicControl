using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace GlycGCtrl.Helpers
{
    public static class HtmlHelpersExtension
    {
        public static MvcHtmlString MenuLink(this HtmlHelper<dynamic> htmlHelper,
                                            string linkText,
                                            string actionName,
                                            string controllerName
                                            )
        {

            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            if (actionName == currentAction && controllerName == currentController)
            {
                return htmlHelper.ActionLink(linkText, actionName, controllerName, null, new { @class = "active" });
            }

            return htmlHelper.ActionLink(linkText, actionName, controllerName);


        }

        public static MvcHtmlString LiLink(this HtmlHelper<dynamic> htmlHelper,
                                            string linkText,
                                            string actionName,
                                            string controllerName
                                            )
        {

            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            var li = new TagBuilder("li");
            if (actionName == currentAction && controllerName == currentController)
            {
                li.AddCssClass("active");
            }
            li.InnerHtml = htmlHelper.ActionLink(linkText, actionName, controllerName).ToHtmlString();
            return MvcHtmlString.Create(li.ToString(TagRenderMode.Normal));
        }
    }

}
