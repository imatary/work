﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Lib.Web.Core.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString MenuItem(this HtmlHelper htmlHelper,
                                             string text, string action,
                                             string controller,
                                             object routeValues = null,
                                             object htmlAttributes = null)
        {
            var li = new TagBuilder("li");
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentAction = routeData.GetRequiredString("action");
            var currentController = routeData.GetRequiredString("controller");
            if (string.Equals(currentAction,
                              action,
                              StringComparison.OrdinalIgnoreCase) &&
                string.Equals(currentController,
                              controller,
                              StringComparison.OrdinalIgnoreCase))
            {
                li.AddCssClass("active_nav");
            }
            if (routeValues != null)
            {
                li.InnerHtml = (htmlAttributes != null)
                    ? htmlHelper.ActionLink(text,
                                            action,
                                            controller,
                                            routeValues,
                                            htmlAttributes).ToHtmlString()
                    : htmlHelper.ActionLink(text,
                                            action,
                                            controller,
                                            routeValues).ToHtmlString();
            }
            else
            {
                li.InnerHtml = (htmlAttributes != null)
                    ? htmlHelper.ActionLink(text,
                                            action,
                                            controller,
                                            null,
                                            htmlAttributes).ToHtmlString()
                    : htmlHelper.ActionLink(text,
                                            action,
                                            controller).ToHtmlString();
            }
            return MvcHtmlString.Create(li.ToString());
        }

        public static string IsActive(this HtmlHelper html,
                                  string control,
                                  string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            // both must match
            var returnActive = control == routeControl &&
                               action == routeAction;

            return returnActive ? "active_nav" : "";
        }
        public static MvcHtmlString NavigationLink(this HtmlHelper html, string linkText, string action, string controller, object routeValues = null, object css = null)
        {
            TagBuilder aTag = new TagBuilder("a");
            TagBuilder liTag = new TagBuilder("li");
            var htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(css);
            string url = (routeValues == null) ?
                (new UrlHelper(html.ViewContext.RequestContext)).Action(action, controller)
                : (new UrlHelper(html.ViewContext.RequestContext)).Action(action, controller, routeValues);

            aTag.MergeAttribute("href", url);
            aTag.InnerHtml = linkText;
            aTag.MergeAttributes(htmlAttributes);

            if (action.ToLower() == html.ViewContext.RouteData.Values["action"].ToString().ToLower() && controller.ToLower() == html.ViewContext.RouteData.Values["controller"].ToString().ToLower())
                liTag.MergeAttribute("class", "active_nav");

            liTag.InnerHtml = aTag.ToString(TagRenderMode.Normal);
            return new MvcHtmlString(liTag.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString ActionLinkActive(this HtmlHelper html, string text, string action, string controller)
        {
            var context = html.ViewContext;
            if (context.Controller.ControllerContext.IsChildAction)
                context = html.ViewContext.ParentActionViewContext;
            var routeValues = context.RouteData.Values;
            var currentAction = routeValues["action"].ToString();
            var currentController = routeValues["controller"].ToString();

            var str = String.Format("<li role=\"presentation\"{0}>{1}</li>",
                currentAction.Equals(action, StringComparison.InvariantCulture) &&
                currentController.Equals(controller, StringComparison.InvariantCulture) ?
                " class=\"active_nav\"" :
                String.Empty, html.ActionLink(text, action, controller).ToHtmlString()
            );
            return new MvcHtmlString(str);
        }

        // As the text the: "<span class='glyphicon glyphicon-plus'></span>" can be entered
        public static MvcHtmlString NoEncodeActionLink(this HtmlHelper htmlHelper,
                                             string text, string title, string action,
                                             string controller,
                                             object routeValues = null,
                                             object htmlAttributes = null)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            var builder = new TagBuilder("a") { InnerHtml = text };
            builder.Attributes["title"] = title;
            builder.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
            builder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)));

            return MvcHtmlString.Create(builder.ToString());
        }

        public static IHtmlString Image(this HtmlHelper helper, byte[] image, string imgclass,
                                     object htmlAttributes = null)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("class", imgclass);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            var imageString = image != null ? Convert.ToBase64String(image) : "";
            var img = string.Format("data:image/jpg;base64,{0}", imageString);
            builder.MergeAttribute("src", img);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Image(this HtmlHelper html, byte[] image)
        {
            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
            return new MvcHtmlString("<img src='" + img + "' />");
        }

        public static IHtmlString MakeActiveClass(this UrlHelper urlHelper, string controller)
        {
            string result = "active_nav";

            string controllerName = urlHelper.RequestContext.RouteData.Values["controller"].ToString();

            if (!controllerName.Equals(controller, StringComparison.OrdinalIgnoreCase))
            {
                result = null;
            }

            return MvcHtmlString.Create(result);
        }

    }

}