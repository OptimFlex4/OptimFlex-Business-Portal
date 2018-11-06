using Google.Authenticator;
using Newtonsoft.Json;
using OptimflexPortal.cs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using static OptimflexPortal.cs.CJsonRequest;
using static OptimflexPortal.cs.CJsonResponse;

namespace OptimflexPortal.wcf
{
    public class SMain : ISMain
    {
        int intJsonStatusSuccess = Int32.Parse(ConfigurationManager.AppSettings["JsonStatusSuccess"].ToString());
        int intJsonStatusFailed = Int32.Parse(ConfigurationManager.AppSettings["JsonStatusFailed"].ToString());
        public string Check2FAAuth(string pCode)
        {
            CJsonResponse jsonResClass = new CJsonResponse();
            try
            {
                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                CSession mySession = new CSession();
                var varUserData = mySession.getCurrentUserData();
                bool isCorrectPIN = tfa.ValidateTwoFactorPIN(varUserData.AUTH_2FA_SECRET_KEY, pCode);
                if (isCorrectPIN)
                {
                    varUserData.USR_ISVERIFIED_2FA = 1;
                    mySession.setUserData(varUserData);
                    return jsonResClass.JsonResponse(intJsonStatusSuccess, "Амжилттай", null);
                }
                return jsonResClass.JsonResponse(intJsonStatusFailed, "Код буруу байна", null);
            }
            catch (Exception ex)
            {
                return jsonResClass.JsonResponse(intJsonStatusFailed, "Системд алдаа гарлаа", null);
            }
        }
        public string CheckLoginAuth(string pUsername, string pPassword)
        {
            try
            {
                string strResData = string.Empty;
                object[] objArr = new object[1];
                CJsonRequest jsonReqClass = new CJsonRequest();
                CJsonResponse jsonResClass = new CJsonResponse();
                JsonRequestData myReqData = new JsonRequestData();
                CMain myMainClass = new CMain();
                CSession mySession = new CSession();
                objArr[0] = myMainClass.getJsonHeader(pUsername, mySession.Encrypt(pPassword));
                myReqData = jsonReqClass.DiverseJsonRequest("login", objArr, true);
                if (myReqData.d.RetType == 0)
                {
                    var objUserData = new UserData
                    {
                        USR_ID = 0,
                        USR_USERNAME = "",
                        USR_PASSWORD = "",
                        USR_TYPE = 0,
                        USR_FAMILYNAME = "",
                        USR_FIRSTNAME = "",
                        USR_LASTNAME = "",
                        USR_REGISTERNO = "",
                        USR_TEL1 = "",
                        USR_TEL2 = "",
                        USR_GENDER = 0,
                        USR_BIRTHDATE = "",
                        USR_ISENABLED_2FA = 0,
                        AUTH_2FA_ISSUER_NAME = "",
                        AUTH_2FA_ISSUER_NOTE = "",
                        AUTH_2FA_SECRET_KEY = "",
                        AUTH_2FA_QRCODE_WIDTH = 0,
                        AUTH_2FA_QRCODE_HEIGHT = 0,
                        USR_ISVERIFIED_2FA = 0
                    };
                    foreach (var elData in myReqData.d.RetData[0])
                    {
                        objUserData.USR_USERNAME = pUsername;
                        objUserData.USR_PASSWORD = mySession.Encrypt(pPassword);
                        if (elData.Name == "CustomerType") objUserData.USR_TYPE = Int32.Parse(elData.Value);
                        else if (elData.Name == "hrEmployee_EmployeeID") objUserData.USR_ID = Int32.Parse(elData.Value);
                        else if (elData.Name == "hrEmployee_FamilyName") objUserData.USR_FAMILYNAME = elData.Value;
                        else if (elData.Name == "hrEmployee_FirstName") objUserData.USR_FIRSTNAME = elData.Value;
                        else if (elData.Name == "hrEmployee_LastName") objUserData.USR_LASTNAME = elData.Value;
                        else if (elData.Name == "hrEmployee_RegisterNo") objUserData.USR_REGISTERNO = elData.Value;
                        else if (elData.Name == "Phone1") objUserData.USR_TEL1 = elData.Value;
                        else if (elData.Name == "Phone2") objUserData.USR_TEL2 = elData.Value;
                        else if (elData.Name == "hrEmployee_Gender") objUserData.USR_GENDER = Int32.Parse(elData.Value);
                        else if (elData.Name == "hrEmployee_BirthDate") objUserData.USR_BIRTHDATE = elData.Value;
                        else if (elData.Name == "IsEnabled2FA") objUserData.USR_ISENABLED_2FA = Int32.Parse(elData.Value);
                        else if (elData.Name == "2FA_ISSUER_NAME") objUserData.AUTH_2FA_ISSUER_NAME = elData.Value;
                        else if (elData.Name == "2FA_ISSUER_NOTE") objUserData.AUTH_2FA_ISSUER_NOTE = elData.Value;
                        else if (elData.Name == "2FA_SECRET_KEY") objUserData.AUTH_2FA_SECRET_KEY = mySession.Encrypt(elData.Value);
                        else if (elData.Name == "2FA_QRCODE_WIDTH") objUserData.AUTH_2FA_QRCODE_WIDTH = Int32.Parse(elData.Value);
                        else if (elData.Name == "2FA_QRCODE_HEIGHT") objUserData.AUTH_2FA_QRCODE_HEIGHT = Int32.Parse(elData.Value);
                    }
                    mySession.setUserData(objUserData);
                    return jsonResClass.JsonResponse(intJsonStatusSuccess, "Амжилттай", null);
                }
                else {
                    return jsonResClass.JsonResponse(intJsonStatusFailed, myReqData.d.RetDesc, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string LogoutAuth()
        {
            try
            {
                CJsonResponse jsonResClass = new CJsonResponse();
                CSession mySession = new CSession();
                mySession.setUserData(null);
                return jsonResClass.JsonResponse(intJsonStatusSuccess, "Амжилттай", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
