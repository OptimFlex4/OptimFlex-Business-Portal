using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using OptimflexPortal.cs;
using static OptimflexPortal.cs.CJsonRequest;

namespace OptimflexPortal
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CMain myMainClass = new CMain();
            //pageContent.InnerHtml = myMainClass.SimpleGrid(string.Empty);

            var aa = JsonConvert.DeserializeObject<JsonRequestData>("{\"d\":{\"__type\":\"Diverse.OptimFlex.Service.Android.CResultJ\",\"RetType\":0,\"RetDesc\":\"\",\"RetData\":[[{\"Name\":\"hrEmployee_EmployeeID\",\"Value\":\"1\"},{\"Name\":\"hrEmployee_FamilyName\",\"Value\":\"Гэжээ\"},{\"Name\":\"hrEmployee_FirstName\",\"Value\":\"Түвшинбаяр\"},{\"Name\":\"hrEmployee_LastName\",\"Value\":\"Цолмон\"},{\"Name\":\"hrEmployee_RegisterNo\",\"Value\":\"Цолмон\"},{\"Name\":\"Phone1\",\"Value\":\"9911-2233\"},{\"Name\":\"Phone2\",\"Value\":\"976-11-313233\"},{\"Name\":\"hrEmployee_BirthDate\",\"Value\":\"1976.12.02\"},{\"Name\":\"hrEmployee_Gender\",\"Value\":\"1\"},{\"Name\":\"IsEnabled2FA\",\"Value\":\"1\"},{\"Name\":\"2FA_ISSUER_NAME\",\"Value\":\"Optimflex Business Protal\"},{\"Name\":\"2FA_ISSUER_NOTE\",\"Value\":\"Optimflex Business Protal Note\"},{\"Name\":\"2FA_SECRET_KEY\",\"Value\":\"0pt1mFlex4\"},{\"Name\":\"2FA_QRCODE_WIDTH\",\"Value\":\"300\"},{\"Name\":\"2FA_QRCODE_HEIGHT\",\"Value\":\"300\"}]]}}");
            string aaa = "";
            //object[] objTest = myMainClass.getJsonHeader("admin", "nl");
            //string json = JsonConvert.SerializeObject(objTest);
            //string jj = json;
        }
    }
}