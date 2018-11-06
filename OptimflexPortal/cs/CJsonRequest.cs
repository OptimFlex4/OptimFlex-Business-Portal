using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace OptimflexPortal.cs
{
    public class CJsonRequest
    {
        public class JsonRequestDataD
        {
            public string __type { get; set; }
            public int RetType { get; set; }
            public string RetDesc { get; set; }
            public List<List<JsonValue>> RetData { get; set; }
        }
        public class JsonRequestData
        {
            public JsonRequestDataD d { get; set; }
        }
        public JsonRequestData DiverseJsonRequest(string pFuncName, object[] pData, bool isLogin = false)
        {
            object[] objArr;
            if (isLogin)
            {
                objArr = new object[1];
                objArr[0] = (new JavaScriptSerializer().Serialize(pData));
            }
            else
            {
                CMain myMainClass = new CMain();
                objArr = new object[pData.Length + 1];
                UserData currentUserData = new UserData();
                CSession mySession = new CSession();
                currentUserData = mySession.getCurrentUserData();
                objArr[0] = myMainClass.getJsonHeader(currentUserData.USR_USERNAME, mySession.Decrypt(currentUserData.USR_PASSWORD));
                if (pData.Length > 0)
                {
                    for (int i = 0; i < pData.Length; i++)
                    {
                        objArr[i + 1] = pData[i];
                    }
                }
            }
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["DiverseWebServiceUrl"]);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write("{\"pFuncName\": \"" + pFuncName + "\",\"pParams\": " + (new JavaScriptSerializer().Serialize(objArr)) + "}");
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string strRetData = streamReader.ReadToEnd().ToString();
                return JsonConvert.DeserializeObject<JsonRequestData>(strRetData);
            }
        }
    }
}