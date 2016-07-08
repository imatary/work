// cuongpv
// Cương Phạm Văn
// Lib.Web.Core
// 28/04/2016

using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Lib.Web.Core.Optimization
{
    /// <summary>
    /// Nén toàn bộ trang Html trong dự án
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class MinifyZipHtml<TModel> : WebViewPage<TModel>
    {
        static Regex REGEX_TAGS = new Regex(@">\s+<", RegexOptions.Compiled);
        static Regex REGEX_ALL = new Regex(@"\s+|\t\s+|\n\s+|\r\s+", RegexOptions.Compiled);
        public override void Write(object value)
        {
            if (value != null)
            {
                var html = value.ToString();
                html = REGEX_TAGS.Replace(html, "> <");
                html = REGEX_ALL.Replace(html, " ");
                if (value is MvcHtmlString)
                {
                    value = new MvcHtmlString(html);
                }
                else
                    value = html;
            }
            base.Write(value);
        }
        public override void WriteLiteral(object value)
        {
            if (value != null)
            {
                var html = value.ToString();
                html = REGEX_TAGS.Replace(html, "> <");
                html = REGEX_ALL.Replace(html, " ");
                if (value is MvcHtmlString)
                {
                    value = new MvcHtmlString(html);
                }
                else
                    value = html;
            }
            base.WriteLiteral(value);
        }
    }
}