using OptimflexPortal.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OptimflexPortal
{
    public partial class Login : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                if (currentPage == "Verify2FA")
                {
                    if (Session["OptimflexPortalUserData"] != null)
                    {
                        CSession mySession = new CSession();
                        var varUserData = mySession.getCurrentUserData();
                        if (varUserData.USR_ISENABLED_2FA == 0) Response.Redirect("~/");
                        else
                        {
                            if (varUserData.USR_ISVERIFIED_2FA == 1) Response.Redirect("~/");
                        }
                    }
                    else Response.Redirect("~/Login");
                }
            }
            catch (Exception ex) {

            }
        }
    }
}