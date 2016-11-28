using System;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Routing;
using TryCatch.Common;

namespace TryCatch
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            var exception = Server.GetLastError();
            if (exception == null)
                return;

            var mail = new MailMessage { From = new MailAddress("your-address") };
            mail.To.Add(new MailAddress("recipient-address"));
            mail.Subject = "Site Error at " + DateTime.Now;
            mail.Body = "Error Description: " + exception.Message;
            var server = new SmtpClient { Host = "mail.someserver.com" };
            server.Send(mail);

            // Clear the error
            Server.ClearError();

            // Redirect (home)
            Response.Redirect("/home/error");
        }
    }
}