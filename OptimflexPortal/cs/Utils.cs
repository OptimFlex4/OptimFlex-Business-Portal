using System;
using System.ComponentModel;
using System.Reflection;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using DevExpress.Web.Bootstrap;

public enum Resolution
{
    [Description("Full Screen")]
    FullScreen,
    [Description("Large")]
    Large,
    [Description("Medium")]
    Medium,
    [Description("Small")]
    Small,
    [Description("Xtra Small")]
    XtraSmall
}

public static class DemoUtils
{
    public const string DefaultTheme = "default";
    public const string CurrentThemeCookieKey = "DXBS4CurrentTheme";

    public static string CurrentTheme
    {
        get
        {
            if (HttpContext.Current.Request.Cookies[CurrentThemeCookieKey] != null)
                return HttpContext.Current.Request.Cookies[CurrentThemeCookieKey].Value;
            return DefaultTheme;
        }
    }

    public static bool NeedCollapseNav
    {
        get
        {
            return HttpContext.Current.Request.Cookies["collapse-nav"] != null;
        }
    }

    public static Resolution CurrentResolution
    {
        get
        {
            var res = HttpContext.Current.Request.QueryString["resolution"];
            if (string.IsNullOrEmpty(res))
                return Resolution.FullScreen;
            return (Resolution)Enum.Parse(typeof(Resolution), res);
        }
    }

    public static string BuyUrl
    {
        get { return "https://www.devexpress.com/Subscriptions/"; }
    }

    public static string TryUrl
    {
        get { return "https://go.devexpress.com/DevExpressDownload_UniversalTrial.aspx"; }
    }

    public static string GetResolutionDescription(Resolution res)
    {
        FieldInfo fi = typeof(Resolution).GetField(res.ToString());
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes != null && attributes.Length > 0)
            return attributes[0].Description;
        return res.ToString();
    }

    public static bool IsMobileDevice
    {
        get
        {
            return HttpContext.Current.Request.Browser["IsMobileDevice"] == "true";
        }
    }

    public static bool IsFrame
    {
        get
        {
            return !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["frame"]);
        }
    }
    public static bool IsFrameContainer
    {
        get
        {
            return !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["url"]);
        }
    }

    public static string StartDemoUrl
    {
        get { return "GridView"; }
    }

    public static string FrameUrl
    {
        get
        {
            var url = AddQuery(HttpContext.Current.Request.QueryString["url"], "frame=true&resolution=" + CurrentResolution.ToString());
            if (HttpContext.Current.Request.QueryString["hash"] != null)
                url += "#" + HttpContext.Current.Request.QueryString["hash"];
            return url;
        }
    }

    public static void ShowToast(Page page, string message)
    {
        var jsLink = new HtmlGenericControl()
        {
            TagName = "script",
            InnerHtml = string.Format("dxbsDemo.showToast(\"{0}\")", message.Replace("\"", "\\\""))
        };
        jsLink.Attributes.Add("type", "text/javascript");
        page.Controls.Add(jsLink);
    }

    static string AddQuery(string url, string query)
    {
        return url + (url.Contains("?") ? "&" : "?") + query;
    }
}