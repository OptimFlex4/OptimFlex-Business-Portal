using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.DynamicData;

namespace OptimflexPortal
{
    public partial class Sidebar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillNavigationTreeView();
            if (DemoUtils.CurrentResolution != Resolution.FullScreen)
                navTreeView.NavigateUrlFormatString = "{0}?resolution=" + DemoUtils.CurrentResolution.ToString();
        }

        protected void FillNavigationTreeView()
        {
            //navTreeView.Nodes.Add("Getting Started", "GettingStarted", "icon icon-gettingstarted", "~/GettingStarted.aspx");
            navTreeView.Nodes.Add("Menu 01", "Menu01", "icon icon-card", "~/TestPage1.aspx");
            //foreach (var demoGroup in BootstrapDemosModel.Instance.DemoGroups)
            //{
            //    var demoGroupNode = navTreeView.Nodes.Add(demoGroup.Title, "", demoGroup.IconCssClass, "");

            //    demoGroupNode.Nodes.Add("Overview", demoGroup.Key, "", ResolveUrl(BootstrapUtils.GenerateDemoPageUrl(demoGroup)));

            //    foreach (var demo in demoGroup.Demos)
            //    {
            //        var demoNode = demoGroupNode.Nodes.Add(demo.Title, demo.Key, "",
            //            ResolveUrl(BootstrapUtils.GenerateDemoPageUrl(demo)));
            //    }

            //}
            navTreeView.CollapseAll();
            navTreeView.SelectedNode = navTreeView.Nodes.FindAllRecursive(n => ResolveUrl(n.NavigateUrl).Equals(Request.Url.LocalPath, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            if (navTreeView.SelectedNode != null && navTreeView.SelectedNode.Parent != null)
            {
                navTreeView.SelectedNode.Parent.CssClass = "active-parent";
                navTreeView.SelectedNode.Parent.Expanded = true;
            }
        }
    }
}
