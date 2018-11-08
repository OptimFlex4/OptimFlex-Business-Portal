<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="OptimflexPortal.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div lang="mn">Товч</div>
    <div id="btnTest"></div>
    <div class="row">
        <div id="pageContent" runat="server" class="col-xs-12 col-sm-12 col-md-12 col-lg-12"></div>
    </div>
    <script>
        //$("#btnTest").click(function () {
        //    alert($('#txt01').val());
            
        //});
        $("#btnTest").dxButton({
            text: "Товч",
            onClick: function() {
                globalAjaxVar = $.ajax({
                    type: "POST",
                    url: "../wcf/SMain.svc/CheckLoginAuth",
                    data: '{"pUsername":"admin", "pPassword":"nl"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        alert(data.d);
                    },
                    failure: function (response) {
                        alert('LOCAL FAILURE');
                    }
                });
            }
        });
    </script>
    <%--<div class="panel-group smart-accordion-default margin-bottom-10" id="accordion">
		<div class="panel panel-default">
			<div class="panel-heading">
				<h4 class="panel-title"><a data-toggle="collapse" data-parent="#accordion" href="#collapseOne"> <i class="fa fa-lg fa-angle-down pull-right"></i> <i class="fa fa-lg fa-angle-up pull-right"></i> Хүснэгтийн шүүлтүүр </a></h4>
			</div>
			<div id="collapseOne" class="panel-collapse collapse in">
				<div class="panel-body">
					<div id="dataSearchForm"></div>
				</div>
			</div>
		</div>
	</div>

    <div id="dataGrid"></div>
    <script>
        $(function () {
            $("#dataSearchForm").dxForm({
                formData: undefined,
                colCountByScreen: {
                    lg: 4,
                    md: 3,
                    sm: 2,
                    xs: 1
                },
                labelLocation: "left",
                hoverStateEnabled: true,
                items: [
                    {
                        dataField: "Firstname",
                        label: {
                            text: "Нэр"
                        },
                        editorType: "dxTextBox"
                    },
                    {
                        dataField: "Lastname",
                        label: {
                            text: "Овог"
                        },
                        editorType: "dxTextBox"
                    },
                    {
                        dataField: "Birthdate",
                        label: {
                            text: "Төрсөн огноо"
                        },
                        editorType: "dxDateBox",
                        editorOptions: { 
                            displayFormat: 'yyyy/MM/dd',
                            pickerType: "calendar",
                            format: "date",
                        }
                    },
                    {
                        dataField: "Gender",
                        label: {
                            text:"Хүйс"
                        },
                        editorType: "dxRadioGroup",
                        editorOptions: { 
                            items: [{ ID: 1, Name: "Эр" }, { ID:2, Name:"Эм"} ],
                            displayExpr: "Name",
                            valueExpr: "ID",
                            layout: "horizontal" // or "vertical"
                        }
                    },
                    {
                        dataField: "City",
                        label: {
                            text:"Хот"
                        },
                        editorType: "dxSelectBox",
                        editorOptions: { 
                            items: [{ ID: 1, Name: "UB" }, { ID:2, Name:"Darhan"} ],
                            placeholder: "Сонго...",
                            displayExpr: "Name",
                            valueExpr: "ID"
                        }
                    },
                    {
                        dataField: "HomeType",
                        label: {
                            text:"Байрны нөхцөл"
                        },
                        editorType: "dxCheckBox",
                        value: false // or true
                    },
                    {
                        dataField: "Address",
                        label: {
                            text: "Хаяг"
                        },
                        editorType: "dxTextArea",
                    }
                ]
            });
            $("#dataGrid").dxDataGrid({
                dataSource: [{
                    ID: 1,
                    Firstname: "Gundee",
                    Lastname: "Gantumur",
                    Birthdate: "2000/01/01",
                    GenderID: 1,
                    Gender: "Эрэгтэй",
                    CityID: 1,
                    City: "UB",
                    HomeType: true,
                    Address: "32-16"
                },
                {
                    ID: 2,
                    Firstname: "Gundee",
                    Lastname: "Gantumur",
                    Birthdate: "2000/01/01",
                    GenderID: 1,
                    Gender: "Эрэгтэй",
                    CityID: 1,
                    City: "UB",
                    HomeType: true,
                    Address: "32-16"
                },
                {
                    ID: 3,
                    Firstname: "Gundee",
                    Lastname: "Gantumur",
                    Birthdate: "2000/01/01",
                    GenderID: 1,
                    Gender: "Эрэгтэй",
                    CityID: 1,
                    City: "UB",
                    HomeType: true,
                    Address: "32-16"
                },
                {
                    ID: 4,
                    Firstname: "Gundee",
                    Lastname: "Gantumur",
                    Birthdate: "2000/01/01",
                    GenderID: 1,
                    Gender: "Эрэгтэй",
                    CityID: 1,
                    City: "UB",
                    HomeType: true,
                    Address: "32-16"
                },
                {
                    ID: 5,
                    Firstname: "Gundee",
                    Lastname: "Gantumur",
                    Birthdate: "2000/01/01",
                    GenderID: 1,
                    Gender: "Эрэгтэй",
                    CityID: 1,
                    City: "UB",
                    HomeType: true,
                    Address: "32-16"
                },
                {
                    ID: 6,
                    Firstname: "Gundee",
                    Lastname: "Gantumur",
                    Birthdate: "2000/01/01",
                    GenderID: 1,
                    Gender: "Эрэгтэй",
                    CityID: 1,
                    City: "UB",
                    HomeType: true,
                    Address: "32-16"
                },
                {
                    ID: 7,
                    Firstname: "Gundee",
                    Lastname: "Gantumur",
                    Birthdate: "2000/01/01",
                    GenderID: 1,
                    Gender: "Эрэгтэй",
                    CityID: 1,
                    City: "UB",
                    HomeType: true,
                    Address: "32-16"
                },
                {
                    ID: 8,
                    Firstname: "Gundee",
                    Lastname: "Gantumur",
                    Birthdate: "2000/01/01",
                    GenderID: 1,
                    Gender: "Эрэгтэй",
                    CityID: 1,
                    City: "UB",
                    HomeType: true,
                    Address: "32-16"
                },
                {
                    ID: 9,
                    Firstname: "Gundee",
                    Lastname: "Gantumur",
                    Birthdate: "2000/01/01",
                    GenderID: 1,
                    Gender: "Эрэгтэй",
                    CityID: 1,
                    City: "UB",
                    HomeType: true,
                    Address: "32-16"
                },
                {
                    ID: 10,
                    Firstname: "Gundee",
                    Lastname: "Gantumur",
                    Birthdate: "2000/01/01",
                    GenderID: 1,
                    Gender: "Эрэгтэй",
                    CityID: 1,
                    City: "UB",
                    HomeType: true,
                    Address: "32-16"
                },
                {
                    ID: 11,
                    Firstname: "Gundee",
                    Lastname: "Gantumur",
                    Birthdate: "2000/01/01",
                    GenderID: 1,
                    Gender: "Эрэгтэй",
                    CityID: 1,
                    City: "UB",
                    HomeType: true,
                    Address: "32-16"
                },
                {
                    ID: 12,
                    Firstname: "Gundee",
                    Lastname: "Gantumur",
                    Birthdate: "2000/01/01",
                    GenderID: 1,
                    Gender: "Эрэгтэй",
                    CityID: 1,
                    City: "UB",
                    HomeType: true,
                    Address: "32-16"
                },
                {
                    ID: 13,
                    Firstname: "Gundee",
                    Lastname: "Gantumur",
                    Birthdate: "2000/01/01",
                    GenderID: 1,
                    Gender: "Эрэгтэй",
                    CityID: 1,
                    City: "UB",
                    HomeType: true,
                    Address: "32-16"
                }],
                keyExpr: "ID",
                showBorders: true,
                paging: {
                    pageSize: 10
                },
                pager: {
                    infoText: "Хуудас {0} - {1} Нийт: {2}",
                    showPageSizeSelector: true,
                    allowedPageSizes: [5, 10, 20],
                    showInfo: true
                },
                columns: [
                    {
                        dataField: "Firstname",
                        dataType: "string",
                        alignnment: "left",
                        caption: "Нэр"
                    },
                    {
                        dataField: "Lastname",
                        dataType: "string",
                        alignnment: "left",
                        caption: "Овог"
                    },
                    {
                        dataField: "Birthdate",
                        dataType: "date",
                        format: 'yyyy/MM/dd',
                        alignnment: "center",
                        caption: "Төрсөн огноо"
                    },
                    {
                        dataField: "GenderID",
                        calculateDisplayValue: "Gender",
                        alignnment: "center",
                        caption: "Хүйс",
                        lookup: {
                            dataSource: [{ ID: 1, Name: "Эр" }, { ID:2, Name:"Эм"} ],
                            valueExpr: "ID",
                            displayExpr: "Name"
                        }
                    },
                    {
                        dataField: "CityID",
                        calculateDisplayValue: "City",
                        alignnment: "center",
                        caption: "Хот",
                        lookup: {
                            dataSource: [{ ID: 1, Name: "UB" }, { ID:2, Name:"Darhan"} ],
                            valueExpr: "ID",
                            displayExpr: "Name"
                        }
                    },
                    {
                        dataField: "HomeType",
                        alignnment: "center",
                        caption: "Байрны нөхцөл"
                    },
                    {
                        dataField: "Address",
                        alignnment: "center",
                        caption: "Хаяг"
                    }],
                allowColumnResizing: true,
                columnAutoWidth: true,
                filterRow: {
                    betweenEndText: "Төгсөх",
                    betweenStartText: "Эхлэх",
                    operationDescriptions: {
                    between: "Хооронд",
                    contains: "Агуулсан",
                    endsWith: "Төгссөн",
                    equal: "Тэнцүү",
                    greaterThan: "Их",
                    greaterThanOrEqual: "Их болон тэнцүү",
                    lessThan: "Бага",
                    lessThanOrEqual: "Бага болон тэнцүү",
                    notContains: "Агуулаагүй",
                    notEqual: "Тэнцүү биш",
                    startsWith: "Эхэлсэн"
                    },
                    resetOperationText: "Дахин тохируулах",
                    showAllText: "",
                    showOperationChooser: true,
                    visible: true
                },
                hoverStateEnabled: true,
                loadPanel: {
                    enabled: true,
                    height: 90,
                    indicatorSrc: "",
                    showIndicator: true,
                    showPane: true,
                    text: "Уншиж байна...",
                    width: 200
                },
                noDataText: "Илэрц байхгүй байна",
                searchPanel: {
                    highlightCaseSensitive: false,
                    highlightSearchText: true,
                    placeholder: "Хайх...",
                    searchVisibleColumnsOnly: true,
                    text: "",
                    visible: true,
                    width: 200
                },
                columnChooser: {
                    enabled: true,
                    height: 260,
                    mode: "select",
                    searchTimeout: 500,
                    title: "Харуулах багана сонгох",
                    width: 300
                },
                editing: {
                    allowAdding: true,
                    allowDeleting: true,
                    allowUpdating: true,
                    mode: "popup",
                    texts: {
                        cancelRowChanges: "Болих",
                        confirmDeleteMessage: "Мөр бичиглэл устгах уу?",
                        saveRowChanges: "Хадгалах"
                    },
                    useIcons: true,
                    popup: null,
                    form: {
                        showColonAfterLabel: true,
                        labelLocation: "left",
                        colCount: 2,
                        items: [
                            {
                                dataField: "Firstname",
                                editorType: "dxTextBox",
                                validationRules: [{
                                    type: "required",
                                    message: "Please, insert a Firstname!"
                                }]
                            },
                            {
                                dataField: "Lastname",
                                editorType: "dxTextBox",
                                validationRules: [{
                                    type: "required",
                                    message: "Please, insert a Lastname!"
                                }]
                            },
                            {
                                dataField: "Birthdate",
                                editorType: "dxDateBox",
                                validationRules: [{
                                    type: "required",
                                    message: "Please, insert a Birthdate!"
                                }]
                            },
                            {
                                dataField: "GenderID",
                                editorType: "dxSelectBox",
                                validationRules: [{
                                    type: "required",
                                    message: "Please, insert a Gender!"
                                }]
                            },
                            {
                                dataField: "CityID",
                                editorType: "dxSelectBox",
                                validationRules: [{
                                    type: "required",
                                    message: "Please, insert a City!"
                                }]
                            },
                            {
                                dataField: "HomeType",
                                editorType: "dxCheckBox",
                                validationRules: [{
                                    type: "required",
                                    message: "Please, insert a HomeType!"
                                }]
                            },
                            {
                                dataField: "Address",
                                editorType: "dxTextArea",
                                validationRules: [{
                                    type: "required",
                                    message: "Please, insert a Address!"
                                }]
                            }
                        ]
                    }
                },
                onEditingStart: function(e) {
                    alert("EditingStart");
                },
                onInitNewRow: function(e) {
                    alert("InitNewRow");
                },
                onRowInserting: function(e) {
                    alert("RowInserting");
                },
                onRowInserted: function(e) {
                    alert("RowInserted");
                },
                onRowUpdating: function (e) {
                    e.cancel = true;
                    alert("RowUpdating");
                },
                onRowUpdated: function(e) {
                    alert("RowUpdated");
                },
                onRowRemoving: function(e) {
                    alert("RowRemoving");
                },
                onRowRemoved: function(e) {
                    alert("RowRemoved");
                }
            });
        });
    </script>--%>
</asp:Content>
