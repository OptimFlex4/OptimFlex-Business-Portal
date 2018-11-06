using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Web;

namespace OptimflexPortal.cs
{
    public class CDevice
    {
        public string getDeviceID() {
            string strRes = string.Empty;
            try
            {
            }
            catch (Exception ex)
            {

            }
            return strRes;
        }
        public string getMachineIP() {
            return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        }
        public string getNetworkPublicIPAddress()
        {
            string strRes = string.Empty;
            try
            {
                strRes = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")).Matches((new WebClient()).DownloadString("http://checkip.dyndns.org/"))[0].ToString();
            }
            catch (Exception ex) {

            }
            return strRes;
        }
        public string getNetworkLocalIPAddress()
        {
            string strRes = string.Empty;
            try
            {
                IPHostEntry Host = default(IPHostEntry);
                string Hostname = null;
                Hostname = System.Environment.MachineName;
                Host = Dns.GetHostEntry(Hostname);
                foreach (IPAddress IP in Host.AddressList)
                {
                    if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        strRes = Convert.ToString(IP);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return strRes;
        }
        public string getMACAddress()
        {
            string strRes = string.Empty;
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                strRes = nics[0].GetPhysicalAddress().ToString();
            }
            catch (Exception ex)
            {

            }
            return strRes;
        }
        public string getOSType()
        {
            string strRes = string.Empty;
            try
            {
                strRes = HttpContext.Current.Request.Browser.Platform;
            }
            catch (Exception ex)
            {

            }
            return strRes;
        }

        public string GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
            var version = string.Empty;

            foreach (var character in temp)
            {
                var validCharacter = false;
                int test = 0;

                if (Int32.TryParse(character.ToString(), out test))
                {
                    version += character;
                    validCharacter = true;
                }

                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }

                if (validCharacter == false)
                    break;
            }

            return version;
        }
        public string getOSVersion()
        {
            string strRes = string.Empty;
            try
            {

                var ua = HttpContext.Current.Request.UserAgent;

                if (ua.Contains("Android"))
                    return string.Format("Android {0}", GetMobileVersion(ua, "Android"));

                if (ua.Contains("iPad"))
                    return string.Format("iPad OS {0}", GetMobileVersion(ua, "OS"));

                if (ua.Contains("iPhone"))
                    return string.Format("iPhone OS {0}", GetMobileVersion(ua, "OS"));

                if (ua.Contains("Linux") && ua.Contains("KFAPWI"))
                    return "Kindle Fire";

                if (ua.Contains("RIM Tablet") || (ua.Contains("BB") && ua.Contains("Mobile")))
                    return "Black Berry";

                if (ua.Contains("Windows Phone"))
                    return string.Format("Windows Phone {0}", GetMobileVersion(ua, "Windows Phone"));

                if (ua.Contains("Mac OS"))
                    return "Mac OS";

                if (ua.Contains("Windows NT 5.1") || ua.Contains("Windows NT 5.2"))
                    return "Windows XP";

                if (ua.Contains("Windows NT 6.0"))
                    return "Windows Vista";

                if (ua.Contains("Windows NT 6.1"))
                    return "Windows 7";

                if (ua.Contains("Windows NT 6.2"))
                    return "Windows 8";

                if (ua.Contains("Windows NT 6.3"))
                    return "Windows 8.1";

                if (ua.Contains("Windows NT 10"))
                    return "Windows 10";

                //fallback to basic platform:
                return HttpContext.Current.Request.Browser.Platform + (ua.Contains("Mobile") ? " Mobile " : "");
            }
            catch (Exception ex)
            {

            }
            return strRes;
        }
        
        public string getBrowserType()
        {
            string strRes = string.Empty;
            try
            {
                System.Web.HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
                strRes = browser.Type;
            }
            catch (Exception ex)
            {

            }
            return strRes;
        }
        public string getBrowserName()
        {
            string strRes = string.Empty;
            try
            {
                System.Web.HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
                strRes = browser.Browser;
            }
            catch (Exception ex)
            {

            }
            return strRes;
        }
        public string getBrowserVersion()
        {
            string strRes = string.Empty;
            try
            {
                System.Web.HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
                strRes = browser.Version;
            }
            catch (Exception ex)
            {

            }
            return strRes;
        }
        public string getNetworkType()
        {
            string strRes = string.Empty;
            try
            {
            }
            catch (Exception ex)
            {

            }
            return strRes;
        }
        public string getNetworkSpeed()
        {
            string strRes = string.Empty;
            try
            {
            }
            catch (Exception ex)
            {

            }
            return strRes;
        }
    }
}