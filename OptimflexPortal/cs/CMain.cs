using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace OptimflexPortal.cs
{
    public class JsonValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Label
    {
        public string text { get; set; }
    }

    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class EditorOptions
    {
        public List<Item> items { get; set; }
        public string placeholder { get; set; }
        public string displayExpr { get; set; }
        public string valueExpr { get; set; }
        public string layout { get; set; }
    }
    public class ContentItem
    {
        public string dataField { get; set; }
        public Label label { get; set; }
        public string editorType { get; set; }
        public string value { get; set; }
        public EditorOptions editorOptions { get; set; }
    }
    public class FilterContentItems
    {
        public string visible { get; set; }
        public List<ContentItem> contentItems { get; set; }
    }
    public class RootObject
    {
        public string type { get; set; }
        public string name { get; set; }
        public FilterContentItems filterContentItems { get; set; }
    }

    public class CMain
    {
        public List<JsonValue> getJsonHeader(string username, string password)
        {
            CDevice myDevice = new CDevice();
            List<JsonValue> objJsonList = new List<JsonValue>();
            JsonValue jsonRow;
            jsonRow = new JsonValue();
            jsonRow.Name = "AppID";
            jsonRow.Value = WebConfigurationManager.AppSettings["AppID"];
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "VersionID";
            jsonRow.Value = WebConfigurationManager.AppSettings["VersionID"];
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "DeviceID";
            jsonRow.Value = myDevice.getDeviceID();
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "OSType";
            jsonRow.Value = myDevice.getOSType();
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "OSVersion";
            jsonRow.Value = myDevice.getOSVersion();
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "NetworkIP";
            jsonRow.Value = myDevice.getNetworkPublicIPAddress();
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "LocalIP";
            jsonRow.Value = myDevice.getNetworkLocalIPAddress();
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "MachineIP";
            jsonRow.Value = myDevice.getMachineIP();
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "NetworkType";
            jsonRow.Value = myDevice.getNetworkType();
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "NetworkSpeed";
            jsonRow.Value = myDevice.getNetworkSpeed();
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "NetworkMAC";
            jsonRow.Value = myDevice.getMACAddress();
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "BrowserType";
            jsonRow.Value = myDevice.getBrowserType();
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "BrowserName";
            jsonRow.Value = myDevice.getBrowserName();
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "BrowserVersion";
            jsonRow.Value = myDevice.getBrowserVersion();
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "UserID";
            jsonRow.Value = username;
            objJsonList.Add(jsonRow);
            jsonRow = new JsonValue();
            jsonRow.Name = "Password";
            jsonRow.Value = password;
            objJsonList.Add(jsonRow);
            return objJsonList;
        }
        public string SimpleGrid(string urlFuncname)
        {
            int iCnt = 0;
            int iCnt2 = 0;
            string strHTMLContent = string.Empty;
            string strHTMLHeaderContent = string.Empty;
            string strJSHeaderContent = string.Empty;
            //string urlJsonContent = @"{ type:""grid01"", name:""test01"", filterContentItems: { visible: ""true"", contentItems: [ { dataField:""City"", label: { text: ""Хот"" }, editorType: ""dxSelectBox"", editorOptions: { items: [{ ID: 1, Name: ""UB"" }, { ID:2, Name:""Darhan""} ], placeholder: ""Сонго..."", displayExpr: ""Name"", valueExpr: ""ID"", layout: ""horizontal"" } } ] } }";
            string urlJsonContent = "{ type: \"gridType01\", name: \"gridTest01\", filterContentItems: { visible: \"true\", contentItems: [ {  dataField: \"Firstname\",  label: {   text: \"Нэр\"  },  editorType: \"dxTextBox\",  value: \"\" }, {  dataField: \"Lastname\",  label: {   text: \"Овог\"  },  editorType: \"dxTextBox\",  value: \"\" }, {  dataField: \"Birthdate\",  label: {   text: \"Төрсөн огноо\"  },  editorType: \"dxDateBox\",  value: \"\" }, {  dataField: \"Gender\",  label: {   text:\"Хүйс\"  },  editorType: \"dxRadioGroup\",  editorOptions: {    items: [{ ID: 1, Name: \"Эр\" }, { ID:2, Name:\"Эм\"} ],   layout: \"horizontal\"  },  value: \"\" }, {  dataField: \"City\",  label: {   text:\"Хот\"  },  editorType: \"dxSelectBox\",  editorOptions: {    items: [{ ID: 1, Name: \"UB\" }, { ID:2, Name:\"Darhan\"} ]   },  value: \"\" }, {  dataField: \"HomeType\",  label: {   text:\"Байрны нөхцөл\"  },  editorType: \"dxCheckBox\",  value: false }, {  dataField: \"Address\",  label: {   text: \"Хаяг\"  },  editorType: \"dxTextArea\",  value: \"\" } ]} }";
            RootObject r = JsonConvert.DeserializeObject<RootObject>(urlJsonContent);
            if (r.type == "gridType01")
            {
                if (r.filterContentItems.visible == "true")
                {
                    strHTMLHeaderContent = @"<div class=""panel-group smart-accordion-default margin-bottom-10"" id=""accordion"">
	    <div class=""panel panel-default"">
		    <div class=""panel-heading"">
			    <h4 class=""panel-title""><a data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseOne""> <i class=""fa fa-lg fa-angle-down pull-right""></i> <i class=""fa fa-lg fa-angle-up pull-right""></i> <span lang=""mn"">Хүснэгтийн шүүлтүүр</span> </a></h4>
		    </div>
		    <div id=""collapseOne"" class=""panel-collapse collapse in"">
			    <div class=""panel-body"">
				    <div id=""dataSearchForm""></div>
			    </div>
		    </div>
	    </div>
    </div>";
                    strJSHeaderContent += @"$(""#dataSearchForm"").dxForm({
                formData: undefined,
                colCountByScreen: {
                    lg: 4,
                    md: 3,
                    sm: 2,
                    xs: 1
                },
                labelLocation: ""left"",
                hoverStateEnabled: true,
                items: [ ";
                    if (r.filterContentItems.contentItems.Count != 0)
                    {
                        iCnt = 0;
                        foreach (var contentItem in r.filterContentItems.contentItems)
                        {
                            if (iCnt > 0) strJSHeaderContent += ",";
                            strJSHeaderContent += "{";
                            strJSHeaderContent += "dataField: \"" + contentItem.dataField + "\"";
                            strJSHeaderContent += ",";
                            strJSHeaderContent += "label: {\"text\": \"" + contentItem.label.text + "\"}";
                            strJSHeaderContent += ",";
                            strJSHeaderContent += "editorType: \"" + contentItem.editorType + "\"";
                            strJSHeaderContent += ",";
                            strJSHeaderContent += "value: \"" + contentItem.value + "\"";
                            if (contentItem.editorType == "dxRadioGroup" || contentItem.editorType == "dxSelectBox")
                            {
                                strJSHeaderContent += ",";
                                strJSHeaderContent += "editorOptions: {";
                                strJSHeaderContent += "items: [";
                                if (contentItem.editorOptions.items.Count != 0)
                                {
                                    iCnt2 = 0;
                                    foreach (var item in contentItem.editorOptions.items)
                                    {
                                        if (iCnt2 > 0) strJSHeaderContent += ",";
                                        strJSHeaderContent += "{";
                                        strJSHeaderContent += "ID: " + item.ID + "";
                                        strJSHeaderContent += ",";
                                        strJSHeaderContent += "Name: \"" + item.Name + "\"";
                                        strJSHeaderContent += "}";
                                        iCnt2++;
                                    }
                                }
                                strJSHeaderContent += "]";
                                strJSHeaderContent += ",";
                                strJSHeaderContent += "displayExpr: \"Name\"";
                                strJSHeaderContent += ",";
                                strJSHeaderContent += "valueExpr: \"ID\"";
                                strJSHeaderContent += ",";
                                if (contentItem.editorType == "dxSelectBox")
                                {
                                    strJSHeaderContent += "placeholder: \"" + contentItem.editorOptions.placeholder + "\"";
                                }
                                else if (contentItem.editorType == "dxRadioGroup")
                                {
                                    strJSHeaderContent += "layout: \"" + contentItem.editorOptions.layout + "\"";
                                }
                                strJSHeaderContent += "}";
                            }
                            strJSHeaderContent += "}";
                            iCnt++;
                        }
                    }
                    strJSHeaderContent += "]";
                    strJSHeaderContent += "});";
                }
            }
            else
            {

            }



            strHTMLContent = @"" + strHTMLHeaderContent + @"
    <div id=""dataGrid""></div>
    <script>
        $(function () {
            " + strJSHeaderContent + @"
            $(""#dataGrid"").dxDataGrid({
                dataSource: [{
                    ID: 1,
                    CompanyName: ""Super Mart of the West"",
                    City: ""Bentonville"",
                    State: ""Arkansas""
                }, {
                    ID: 2,
                    CompanyName: ""Electronics Depot"",
                    City: ""Atlanta"",
                    State: ""Georgia""
                }, {
                    ID: 3,
                    CompanyName: ""Electronics Depot"",
                    City: ""Atlanta"",
                    State: ""Georgia""
                }, {
                    ID: 4,
                    CompanyName: ""Electronics Depot"",
                    City: ""Atlanta"",
                    State: ""Georgia""
                }, {
                    ID: 5,
                    CompanyName: ""Electronics Depot"",
                    City: ""Atlanta"",
                    State: ""Georgia""
                }, {
                    ID: 6,
                    CompanyName: ""Electronics Depot"",
                    City: ""Atlanta"",
                    State: ""Georgia""
                }, {
                    ID: 7,
                    CompanyName: ""Electronics Depot"",
                    City: ""Atlanta"",
                    State: ""Georgia""
                }, {
                    ID: 8,
                    CompanyName: ""Electronics Depot"",
                    City: ""Atlanta"",
                    State: ""Georgia""
                }, {
                    ID: 9,
                    CompanyName: ""Electronics Depot"",
                    City: ""Atlanta"",
                    State: ""Georgia""
                }, {
                    ID: 10,
                    CompanyName: ""Electronics Depot"",
                    City: ""Atlanta"",
                    State: ""Georgia""
                }, {
                    ID: 11,
                    CompanyName: ""Electronics Depot"",
                    City: ""Atlanta"",
                    State: ""Georgia""
                    }],
                keyExpr: ""ID"",
                showBorders: true,
                paging: {
                    pageSize: 10
                },
                pager: {
                    infoText: ""Хуудас {0} - {1} Нийт: {2}"",
                    showPageSizeSelector: true,
                    allowedPageSizes: [5, 10, 20],
                    showInfo: true
                },
                columns: [
                    {
                        dataField: ""CompanyName"",
                        dataType: ""string"",
                        alignnment: ""left"",
                        caption: ""Компани нэр""
                    }, ""City"", ""State""],
                allowColumnResizing: true,
                columnAutoWidth: true,
                filterRow: {
                    betweenEndText: ""Төгсөх"",
                    betweenStartText: ""Эхлэх"",
                    operationDescriptions: {
                    between: ""Хооронд"",
                    contains: ""Агуулсан"",
                    endsWith: ""Төгссөн"",
                    equal: ""Тэнцүү"",
                    greaterThan: ""Их"",
                    greaterThanOrEqual: ""Их болон тэнцүү"",
                    lessThan: ""Бага"",
                    lessThanOrEqual: ""Бага болон тэнцүү"",
                    notContains: ""Агуулаагүй"",
                    notEqual: ""Тэнцүү биш"",
                    startsWith: ""Эхэлсэн""
                    },
                    resetOperationText: ""Дахин тохируулах"",
                    showAllText: """",
                    showOperationChooser: true,
                    visible: true
                },
                hoverStateEnabled: true,
                loadPanel: {
                    enabled: true,
                    height: 90,
                    indicatorSrc: """",
                    showIndicator: true,
                    showPane: true,
                    text: ""Уншиж байна..."",
                    width: 200
                },
                noDataText: ""Илэрц байхгүй байна"",
                searchPanel: {
                    highlightCaseSensitive: false,
                    highlightSearchText: true,
                    placeholder: ""Хайх..."",
                    searchVisibleColumnsOnly: true,
                    text: """",
                    visible: true,
                    width: 200
                },
                columnChooser: {
                    enabled: true,
                    height: 260,
                    mode: ""select"",
                    searchTimeout: 500,
                    title: ""Харуулах багана сонгох"",
                    width: 300
                },
                editing: {
                    allowAdding: true,
                    allowDeleting: true,
                    allowUpdating: true,
                    mode: ""popup"",
                    texts: {
                        cancelRowChanges: ""Болих"",
                        confirmDeleteMessage: ""Мөр бичиглэл устгах уу?"",
                        saveRowChanges: ""Хадгалах""
                    },
                    useIcons: true,
                    popup: null,
                    form: {
                        showColonAfterLabel: true,
                        labelLocation: ""left"",
                        colCount: 2,
                        items: [
                            {
                                dataField: ""CompanyName"",
                                editorType: ""dxTextBox"",
                                validationRules: [{
                                    type: ""required"",
                                    message: ""Please, insert a CompanyName!""
                                }]
                            },
                            {
                                dataField: ""City"",
                                editorType: ""dxSelectBox"",
                                editorOptions: { 
                                    items: [
                                        ""Atlanta"",
                                        ""UB"",
                                        ""Darkhan"",
                                        ""Erdenet""
                                    ],
                                    value:""""
                                },
                                validationRules: [{
                                    type: ""required"",
                                    message: ""City is required""
                                }]
                            }
                        ]
                    }
                },
                onEditingStart: function(e) {
                    alert(""EditingStart"");
                },
                onInitNewRow: function(e) {
                    alert(""InitNewRow"");
                },
                onRowInserting: function(e) {
                    alert(""RowInserting"");
                },
                onRowInserted: function(e) {
                    alert(""RowInserted"");
                },
                onRowUpdating: function (e) {
                    e.cancel = true;
                    alert(""RowUpdating"");
                },
                onRowUpdated: function(e) {
                    alert(""RowUpdated"");
                },
                onRowRemoving: function(e) {
                    alert(""RowRemoving"");
                },
                onRowRemoved: function(e) {
                    alert(""RowRemoved"");
                }
            });
        });
    </script>";
            return strHTMLContent;
        }

        public void PageInit() {
            if (HttpContext.Current.Session["OptimflexPortalUserData"] != null)
            {
                CSession mySession = new CSession();
                var varUserData = mySession.getCurrentUserData();
                if (varUserData.USR_ISENABLED_2FA == 1)
                {
                    if (varUserData.USR_ISVERIFIED_2FA == 0)
                    {
                        HttpContext.Current.Response.Redirect("~/Verify2FA");
                    }
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Login");
            }
        }
    }
}