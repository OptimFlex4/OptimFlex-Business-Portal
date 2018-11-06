using OptimflexPortal.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OptimflexPortal
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                CMain mainClass = new CMain();
                mainClass.PageInit();
                CSession mySession = new CSession();
                var myUserData = mySession.getCurrentUserData();
                spanUserLastname.InnerHtml = myUserData.USR_LASTNAME;
                spanUserFirstname.InnerHtml = myUserData.USR_FIRSTNAME;
                inputProfileData.Value = "{\"profile_selectUserType\": \"" + myUserData.USR_TYPE + "\", \"profile_inputUserMiddleName\": \"" + myUserData.USR_FAMILYNAME + "\", \"profile_inputUserLastName\": \"" + myUserData.USR_LASTNAME + "\", \"profile_inputUserFirstName\": \"" + myUserData.USR_FIRSTNAME + "\", \"profile_selectUserGender\": \"" + myUserData.USR_GENDER + "\", \"profile_inputUserEmail\": \"" + myUserData.USR_USERNAME + "\", \"profile_inputUserTel1\": \"" + myUserData.USR_TEL1 + "\", \"profile_inputUserTel2\": \"" + myUserData.USR_TEL2 + "\", \"profile_inputUserBirthday\": \"" + myUserData.USR_BIRTHDATE + "\", \"profile_check2FAuth\":\"" + myUserData.USR_ISENABLED_2FA + "\"}";
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}