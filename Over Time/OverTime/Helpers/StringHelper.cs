using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace OverTime.Helpers
{
    public static class StringHelper
    {
        public static string GetInfo(string username)
        {
            //System.Environment.MachineName
            //HttpContext.Current.Server.MachineName
            //System.Net.Dns.GetHostName()
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            String pcName = Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["remote_addr"]).HostName;
            string info = $"{username} - {pcName} - {GetComputerLanIp()} - {DateTime.Now}";
            return info;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private static string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        private static string GetUserIp()
        {
            string ip = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else if (!string.IsNullOrEmpty(HttpContext.Current.Request.UserHostAddress))
            {
                ip = HttpContext.Current.Request.UserHostAddress;
            }
            return ip;
        }


        /// <summary>
        /// Get computer LAN address like 192.168.1.3
        /// </summary>
        /// <returns></returns>
        private static string GetComputerLanIp()
        {
            string strHostName = Dns.GetHostName();

            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);

            foreach (IPAddress ipAddress in ipEntry.AddressList)
            {
                if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    return ipAddress.ToString();
                }
            }
            return "-";
        }


        /// <summary>
        /// Get computer INTERNET address like 93.136.91.7
        /// </summary>
        /// <returns></returns>
        private static string GetComputerInternetIP()
        {
            // check IP using DynDNS's service
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org");
            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());

            // IMPORTANT: set Proxy to null, to drastically INCREASE the speed of request
            request.Proxy = null;

            // read complete response
            string ipAddress = stream.ReadToEnd();

            // replace everything and keep only IP
            return ipAddress.
        Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", string.Empty).
        Replace("</body></html>", string.Empty);
        }


        public static string LengthStaffCode(string staffCode)
        {
            string prefix = null;
            if (staffCode.Length == 1)
            {
                prefix = "0000" + staffCode;
            }
            else if (staffCode.Length == 2)
            {
                prefix = "000" + staffCode;
            }
            else if (staffCode.Length == 3)
            {
                prefix = "00" + staffCode;
            }
            else if (staffCode.Length == 4)
            {
                prefix = "0" + staffCode;
            }
            else if (staffCode.Length == 5)
            {
                prefix = staffCode;
            }
            if (prefix != null)
                return prefix;

            return staffCode;
        }
    }
}