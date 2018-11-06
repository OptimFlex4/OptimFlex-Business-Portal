using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.Bootstrap;
using DevExpress.Web;
using DevExpress.Web.Demos;
using OptimflexPortal.cs;

namespace OptimflexPortal
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CMain mainClass = new CMain();
                mainClass.PageInit();

                Page.Header.DataBind();

                FillSectionsMenu();

                themeLink.Attributes["href"] = string.Format("../css/devexpress/{0}bootstrap.min.css", DemoUtils.CurrentTheme.Equals(DemoUtils.DefaultTheme, StringComparison.InvariantCultureIgnoreCase) ? "" : ("bootswatch/" + DemoUtils.CurrentTheme + "/"));
                body.Attributes["class"] = string.Format("theme-{0}{1}", DemoUtils.CurrentTheme.ToLower(), DemoUtils.NeedCollapseNav ? " collapse-nav" : "");
            }
            catch (Exception ex) {

            }
        }
        protected void FillSectionsMenu()
        {
            if (BootstrapUtils.CurrentDemoSections == null || BootstrapUtils.CurrentDemoSections.Count() < 2)
                submenubar.Visible = false;
            else
            {
                foreach (var section in BootstrapUtils.CurrentDemoSections)
                {
                    var item = subMenu.Items.Add(section.Title, section.Key);
                    if (section.IsNew)
                        item.Badge.Text = "New";
                    if (section.IsUpdated)
                        item.Badge.Text = "Upd";
                }
            }
        }
        public string GetBadgeMarkup(BootstrapMenuItem item)
        {
            if (!string.IsNullOrEmpty(item.Badge.Text))
                return string.Format("<span class=\"badge-secondary badge\"><span>{0}</span></span>", item.Badge.Text);
            return string.Empty;
        }
    }
}