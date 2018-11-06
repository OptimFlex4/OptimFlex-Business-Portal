using Google.Authenticator;
using OptimflexPortal.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OptimflexPortal
{
    public partial class Verify2FA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OptimflexPortalUserData"] != null)
            {
                CSession mySession = new CSession();
                var varUserData = mySession.getCurrentUserData();
                if (varUserData.USR_ISENABLED_2FA == 0) Response.Redirect("~/");
                else
                {
                    if (varUserData.USR_ISVERIFIED_2FA == 1) Response.Redirect("~/");
                    else
                    {
                        try
                        {
                            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                            var setupInfo = tfa.GenerateSetupCode(varUserData.AUTH_2FA_ISSUER_NAME, varUserData.AUTH_2FA_ISSUER_NOTE, varUserData.AUTH_2FA_SECRET_KEY, varUserData.AUTH_2FA_QRCODE_WIDTH, varUserData.AUTH_2FA_QRCODE_HEIGHT); //the width and height of the Qr Code in pixels
                            verify2fa_imgQRCode.Src = setupInfo.QrCodeSetupImageUrl;
                            verify2fa_spanEntryCode.InnerHtml = setupInfo.ManualEntryKey;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            else Response.Redirect("~/Login");
        }
    }
}