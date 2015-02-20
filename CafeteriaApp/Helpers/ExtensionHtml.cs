using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeteriaApp.Helpers
{
    public static class ExtentionHtml
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            string cssClass = "active";
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static MvcHtmlString Box(this HtmlHelper html, string header, string content, string id)
        {
            var div = new TagBuilder("div");
                div.MergeAttribute("id", id);

            string template = "<header><h1>"+header+"</h1></header>"+
                              "<section>"+
                              content+
                              "</section>";

            div.InnerHtml = template;
            return new MvcHtmlString(div.ToString());
        }

        public static string ContentBox(this HtmlHelper html, int row, String [] head, String []definition)
        {
            var div = new TagBuilder("div");
                div.AddCssClass("container");

            string template = "";
            for(int i = 0; i < row; ++i)
                template += "<div class='container row'><strong>" + head[i] + ": </strong><span class='pull-right'>" + definition[i] + "</span></div>";
                
            div.InnerHtml = template;
            return div.ToString();
        }
    }
}