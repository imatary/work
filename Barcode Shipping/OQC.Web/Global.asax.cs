using OQC.Web.Models;
using System;
using System.Data.Entity;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OQC.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //You don't want to redirect on posts, or images/css/js
            bool isGet = HttpContext.Current.Request.RequestType.ToLowerInvariant().Contains("get");
            if (isGet && HttpContext.Current.Request.Url.AbsolutePath.Contains(".") == false)
            {
                string lowercaseUrl = (Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.Url.AbsolutePath);
                if (Regex.IsMatch(lowercaseUrl, @"[A-Z]"))
                {
                    //You don't want to change casing on query strings
                    lowercaseUrl = lowercaseUrl.ToLower() + HttpContext.Current.Request.Url.Query;

                    Response.Clear();
                    Response.Status = "301 Moved Permanently";
                    Response.AddHeader("Location", lowercaseUrl);
                    Response.End();
                }
            }
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    if (exception == null)
        //        return;
        //    //var mail = new MailMessage { From = new MailAddress("automated@contoso.com") };
        //    //mail.To.Add(new MailAddress("administrator@contoso.com"));
        //    //mail.Subject = "Site Error at " + DateTime.Now;
        //    //mail.Body = "Error Description: " + exception.Message;
        //    //var server = new SmtpClient { Host = "your.smtp.server"};
        //    //server.Send(mail);

        //    // Clear the error
        //    Server.ClearError();

        //    // Redirect to
        //    Response.Redirect("~/Error/Index");

        //}
    }
}
