using OptimflexPortal.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OptimflexPortal
{
    public partial class TestPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CMain myMainClass = new CMain();
            pageContent.InnerHtml = myMainClass.SimpleGrid(string.Empty);
        }
    }
}