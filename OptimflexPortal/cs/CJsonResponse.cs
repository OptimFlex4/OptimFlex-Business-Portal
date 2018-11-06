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
    public class CJsonResponse
    {
        public class JsonResponseDataD
        {
            public string __type { get; set; }
            public int RetType { get; set; }
            public string RetDesc { get; set; }
            public List<List<JsonValue>> RetData { get; set; }
        }
        public class JsonResponseData
        {
            public JsonResponseDataD d { get; set; }
        }
        public string JsonResponse(int RetType, string RetDesc, List<List<JsonValue>> RetData)
        {
            var objJsonData = new JsonResponseDataD
            {
                __type = "Diverse.OptimFlexPortal.Service.Local",
                RetType = RetType,
                RetDesc = RetDesc,
                RetData = RetData
            };
            var objJsonResponseData = new JsonResponseData
            {
                d = objJsonData
            };
            return (new JavaScriptSerializer().Serialize(objJsonResponseData));
        }
    }
}