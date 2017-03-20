﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;
using System.Xml;

namespace Umc.Web {

    public static class DemoHtmlHelper {
        // HtmlHelper
        public static MvcHtmlString DropDownList(this HtmlHelper helper, string name, Type type, object selectedValue) {
            return DropDownList(helper, name, type, selectedValue, null);
        }
        public static MvcHtmlString DropDownList(this HtmlHelper helper, string name, Type type, object selectedValue, object htmlAttributes) {
            if(!type.IsEnum)
                throw new ArgumentException("Invalid type. It should be an enum.");
            if(selectedValue == null || selectedValue.GetType() != type)
                throw new ArgumentException("Invalid selected value type. It should be '" + type.ToString() + "'");

            var items = new List<SelectListItem>();
            foreach(int value in Enum.GetValues(type)) {
                string valueText = Enum.GetName(type, value);
                if(!IsObsoleteValue(value, valueText, type)) {
                    var item = new SelectListItem();
                    item.Value = value.ToString();
                    item.Text = valueText;
                    item.Selected = object.Equals(value, (int)selectedValue);
                    items.Add(item);
                }
            }
            return SelectExtensions.DropDownList(helper, name, items, htmlAttributes);
        }
        static bool IsObsoleteValue(int value, string valueText, Type enumType) {
            foreach(object attribute in enumType.GetField(valueText).GetCustomAttributes(true))
                if(attribute is ObsoleteAttribute)
                    return true;
            return false;
        }
        public static MvcHtmlString ComponentList(this HtmlHelper helper, string componentGroupName, int columnSize) {
            StringBuilder stb = new StringBuilder();
            stb.Append("<div>");
            string xmlFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Components.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            XmlNode node = xmlDoc.DocumentElement.SelectSingleNode("/Groups/Group[@Text='" + componentGroupName + "']");
            stb.Append("<ul class=\"component_list\">");
            for(int i = 0; i < node.ChildNodes.Count; i++) {
                XmlNode product = node.ChildNodes[i];
                if((i % columnSize) == 0 && i > 0) {
                    stb.Append("</ul>");
                    stb.Append("<ul class=\"component_list\">");
                }
                CreateComponentListItem(helper, stb, product.Attributes["Text"].Value, product.Attributes["Index"].Value);
            }
            stb.Append("</ul>");
            stb.Append("</div>");
            return MvcHtmlString.Create(stb.ToString());
        }
        static void CreateComponentListItem(this HtmlHelper helper, StringBuilder stb, string productName, string index) {
            stb.Append("<li class=\"component_list_item\">");
            stb.Append("<a href=\"javascript:void(0);\">");
            Controller controller = helper.ViewContext.Controller as Controller;
            string url = (controller != null) ? controller.Url.Content("~/Content/1x1.gif") : string.Empty;
            stb.Append("<img alt=\"\" src=\"" + url + "\" class=\"" + string.Format("component_image_{0}", index) + "\" />");
            stb.Append(productName);
            stb.Append("</a>");
            stb.Append("</li>");
        }
    }

}
