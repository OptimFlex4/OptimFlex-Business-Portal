using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using DevExpress.Web.Demos;

namespace OptimflexPortal
{
    public partial class Search : UserControl
    {
        public bool FocusOnLoad { get; set; }

        public string LinkFormatString
        {
            get
            {
                if (DemoUtils.CurrentResolution != Resolution.FullScreen)
                    return "{0}?resolution=" + DemoUtils.CurrentResolution.ToString();
                return "{0}";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (FocusOnLoad)
                searchEditor.Focus();
        }
        public string GetSearchItemTitle(object dataItem)
        {
            BootstrapSearchResult sr = (BootstrapSearchResult)dataItem;
            return sr.Text;
        }
        public string GetSearchItemUrl(object dataItem)
        {
            BootstrapSearchResult sr = (BootstrapSearchResult)dataItem;
            string url = sr.Section != null ? BootstrapUtils.GenerateDemoSectionUrl(sr.Section) : BootstrapUtils.GenerateDemoPageUrl(sr.Demo);
            return string.Format(LinkFormatString, ResolveClientUrl(url));
        }
        public string GetSearchItemDemoTitle(object dataItem)
        {
            BootstrapSearchResult sr = (BootstrapSearchResult)dataItem;
            return sr.Demo.Title;
        }
        public string GetSearchItemDemoUrl(object dataItem)
        {
            BootstrapSearchResult sr = (BootstrapSearchResult)dataItem;
            string url = BootstrapUtils.GenerateDemoPageUrl(sr.Demo);
            return string.Format(LinkFormatString, ResolveClientUrl(url));
        }
        public string GetSearchItemDemoGroupTitle(object dataItem)
        {
            BootstrapSearchResult sr = (BootstrapSearchResult)dataItem;
            return sr.Group.Title;
        }
        public string GetSearchItemDemoGroupUrl(object dataItem)
        {
            BootstrapSearchResult sr = (BootstrapSearchResult)dataItem;
            string url = BootstrapUtils.GenerateDemoPageUrl(sr.Group);
            return string.Format(LinkFormatString, ResolveClientUrl(url));
        }
        public bool GetSearchItemAdditionalInfoVisible(object dataItem)
        {
            BootstrapSearchResult sr = (BootstrapSearchResult)dataItem;
            return sr.Section != null;
        }

        protected void searchResults_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var text = e.Parameter;
            var results = BootstrapSearchUtils.DoSearch(text);
            if (results.Count > 0)
            {
                resultsContainer.Visible = true;
                noResultsContainer.Visible = false;
                resultsRepeater.DataSource = results;
                resultsRepeater.DataBind();
            }
            else
            {
                resultsContainer.Visible = false;
                noResultsContainer.Visible = true;
                requestText.InnerHtml = text;
            }
        }
    }
}
