using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OptimflexPortal.wcf
{
    [ServiceContract]
    public interface ISMain
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string Check2FAAuth(string pCode);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string CheckLoginAuth(string pUsername, string pPassword);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string LogoutAuth();
    }
}
