<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="OptimflexPortal.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="row">
		<div class="col-xs-5 col-sm-5 col-md-3 col-lg-2 text-center">
            <img src="img/avatar.jpg" style="border-radius:50%; width:75px; height:75px;" />
            <br />
            <h3><span id="spanUserLastname" runat="server"></span> <span id="spanUserFirstname" runat="server" class="text-uppercase"></span></h3>
            <br />
            <br />
            <div id="profile_btnLogout"></div>
            <hr />
            <div id="slideOutView">
                <div data-options="dxTemplate: { name: 'treeView' }">
                    <div id="profile_menu"></div>
                </div>
            </div>
            <input id="inputProfileData" runat="server" type="hidden" />
        </div>
        <div id="profile_divProfile" class="col-xs-7 col-sm-7 col-md-6 col-lg-4" style="background-color: #fafbfc; border: 1px solid #e1e4e8; border-radius: 3px; box-shadow: inset 0 0 10px rgba(27,31,35,0.05); padding:30px;">
            <form action="javascript:void(0);" id="profile_fromProfile">
                <div id="formProfile"></div>
            </form>
        </div>
        <div id="profile_divAuth" class="col-xs-7 col-sm-7 col-md-6 col-lg-4 d-none" style="background-color: #fafbfc; border: 1px solid #e1e4e8; border-radius: 3px; box-shadow: inset 0 0 10px rgba(27,31,35,0.05); padding:30px;">
            <form action="javascript:void(0);" id="profile_fromPassword" style="height:auto;">
                <div id="formPassword"></div>
            </form>
            <br />
            <form action="javascript:void(0);" id="profile_from2FA" style="height:auto;">
                <div id="form2FA"></div>
            </form>
        </div>
    </div>
    <script>
        $(function () {
            var loadPanel = $(".loadpanel").dxLoadPanel({
                shadingColor: "rgba(0,0,0,0.4)",
                position: { of: "login" },
                message: "Уншиж байна ...",
                visible: false,
                showIndicator: true,
                showPane: true,
                shading: true,
                closeOnOutsideClick: false
            }).dxLoadPanel("instance");
            $("#profile_btnLogout").dxButton({
                text: "Гарах",
                type: "normal"
            });
            $("#profile_menu").dxMenu({
                dataSource: [{
                    name: "Профайл"
                }, {
                    name: "Хамгаалалт"
                }],
                displayExpr: "name",
                orientation: "vertical",
                hoverStateEnabled: true,
                onItemClick: function (e) {
                    if (e.itemData.name == "Профайл") {
                        $("#profile_divProfile").removeClass("d-none");
                        $("#profile_divAuth").addClass("d-none");
                        $("#profile_menu").find("ul li:eq(0) .dx-menu-item").addClass("menu_profile_item_active");
                        $("#profile_menu").find("ul li:eq(1) .dx-menu-item").removeClass("menu_profile_item_active");
                    }
                    else if (e.itemData.name == "Хамгаалалт") {
                        $("#profile_divAuth").removeClass("d-none");
                        $("#profile_divProfile").addClass("d-none");
                        $("#profile_menu").find("ul li:eq(0) .dx-menu-item").removeClass("menu_profile_item_active");
                        $("#profile_menu").find("ul li:eq(1) .dx-menu-item").addClass("menu_profile_item_active");
                    }
                },
                width: "100%",
                selectionMode: "single",
                cssClass: "menu_profile"
            });


            var formWidgetProfile = $("#formProfile").dxForm({
                formData: $.parseJSON($.trim($('#Content_inputProfileData').val())),
                readOnly: false,
                showColonAfterLabel: true,
                showValidationSummary: true,
                validationGroup: "profileData",
                items: [{
                    itemType: "group",
                    caption: "Профайл",
                    items: [
                        {
                            dataField: "profile_selectUserType",
                            editorType: "dxSelectBox",
                            editorOptions: {
                                dataSource: [{ ID: "1", Name: "Хэрэглэгч" }, { ID: "2", Name: "Харилцагч" }],
                                displayExpr: "Name",
                                valueExpr: "ID",
                                searchEnabled: true,
                                placeholder: "Сонго..."
                            },
                            label: {
                                text: "Хэрэглэгчийн төрөл"
                            },
                            validationRules: [{
                                type: "required",
                                message: "Хэрэглэгчийн төрөл сонгоно уу"
                            }]
                        },
                        {
                            dataField: "profile_inputUserMiddleName",
                            editorType: "dxTextBox",
                            editorOptions: {
                                placeholder: "Ургийн овог"
                            },
                            label: {
                                text: "Ургийн овог"
                            }
                        },
                        {
                            dataField: "profile_inputUserLastName",
                            editorType: "dxTextBox",
                            editorOptions: {
                                placeholder: "Эцэг/эхийн нэр"
                            },
                            label: {
                                text: "Эцэг/эхийн нэр"
                            },
                            validationRules: [{
                                type: "required",
                                message: "Эцэг/эхийн нэр оруулна уу"
                            }]
                        },
                        {
                            dataField: "profile_inputUserFirstName",
                            editorType: "dxTextBox",
                            editorOptions: {
                                placeholder: "Өөрийн нэр"
                            },
                            label: {
                                text: "Өөрийн нэр"
                            },
                            validationRules: [{
                                type: "required",
                                message: "Өөрийн нэр оруулна уу"
                            }]
                        },
                        {
                            dataField: "profile_inputUserEmail",
                            editorType: "dxTextBox",
                            editorOptions: {
                                placeholder: "И-мэйл"
                            },
                            label: {
                                text: "И-мэйл"
                            },
                            validationRules: [{
                                type: "required",
                                message: "И-мэйл оруулна уу"
                            },
                            {
                                type: "email",
                                message: "И-мэйл зөв оруулна уу"
                            }]
                        },
                        {
                            dataField: "profile_inputUserTel1",
                            editorType: "dxTextBox",
                            editorOptions: {
                                placeholder: "Утас 1"
                            },
                            label: {
                                text: "Утас 1"
                            },
                            validationRules: [{
                                type: "required",
                                message: "Утас 1 оруулна уу"
                            }]
                        },
                        {
                            dataField: "profile_inputUserTel2",
                            editorType: "dxTextBox",
                            editorOptions: {
                                placeholder: "Утас 2"
                            },
                            label: {
                                text: "Утас 2"
                            }
                        },
                        {
                            dataField: "profile_selectUserGender",
                            editorType: "dxSelectBox",
                            editorOptions: {
                                dataSource: [{ ID: "1", Name: "Эрэгтэй" }, { ID: "2", Name: "Эмэгтэй" }, { ID: "3", Name: "Бусад" }],
                                displayExpr: "Name",
                                valueExpr: "ID",
                                searchEnabled: true,
                                placeholder: "Сонго..."
                            },
                            label: {
                                text: "Хүйс"
                            }
                        },
                        {
                            dataField: "profile_inputUserBirthday",
                            editorType: "dxDateBox",
                            editorOptions: {
                                type: "date",
                                displayFormat: "yyyy.MM.dd",
                                placeholder: "Төрсөн огноо",
                                width: "100%"
                            },
                            label: {
                                text: "Төрсөн огноо"
                            }
                        }
                    ]
                    }, {
                    itemType: "button",
                    horizontalAlignment: "right",
                    buttonOptions: {
                        text: "Профайл хадгалах",
                        type: "default",
                        useSubmitBehavior: true
                    }
                }]
            }).dxForm("instance");
            $("#profile_fromProfile").submit(function (e) {
                loadPanel.show();
                alert('profile test');
                loadPanel.hide();
            });
            var formWidgetPassword = $("#formPassword").dxForm({
                formData: {
                    "profile_inputOldPassword": "",
                    "profile_inputNewPassword": "",
                    "profile_inputNewPasswordConfirm": ""
                },
                readOnly: false,
                showColonAfterLabel: true,
                showValidationSummary: true,
                validationGroup: "passwordData",
                items: [{
                    itemType: "group",
                    caption: "Нууц үг өөрчлөх",
                    items: [{
                        dataField: "profile_inputOldPassword",
                        editorType: "dxTextBox",
                        editorOptions: {
                            type: "password",
                            placeholder: "Хуучин нууц үг"
                        },
                        label: {
                            text: "Хуучин нууц үг"
                        },
                        validationRules: [
                            {
                                type: "required",
                                message: "Хуучин нууц үг оруулна уу"
                            }
                        ]
                    }, {
                        dataField: "profile_inputNewPassword",
                        editorType: "dxTextBox",
                        editorOptions: {
                            type: "password",
                            placeholder: "Шинэ нууц үг"
                        },
                        label: {
                            text: "Шинэ нууц үг"
                        },
                        validationRules: [
                            {
                                type: "required",
                                message: "Шинэ нууц үг оруулна уу"
                            }
                        ]
                    }, {
                        dataField: "profile_inputNewPasswordConfirm",
                        editorType: "dxTextBox",
                        editorOptions: {
                            type: "password",
                            placeholder: "Шинэ нууц үг баталгаажуул"
                        },
                        label: {
                            text: "Шинэ нууц үг давт"
                        },
                        validationRules: [{
                            type: "required",
                            message: "Шинэ нууц үг баталгаажуулна уу"
                        }, {
                            type: "compare",
                            message: "Шинэ нууц үгтэй адилхан оруулна уу",
                            comparisonTarget: function() {
                                return formWidgetPassword.option("formData").profile_inputNewPassword;
                            }
                        }]
                    }]
                }, {
                    itemType: "button",
                    horizontalAlignment: "right",
                    buttonOptions: {
                        text: "Нууц үг хадгалах",
                        type: "default",
                        useSubmitBehavior: true
                    }
                }]
            }).dxForm("instance");
            var formWidget2FA = $("#form2FA").dxForm({
                formData: $.parseJSON($.trim($('#Content_inputProfileData').val())),
                readOnly: false,
                showColonAfterLabel: true,
                showValidationSummary: true,
                validationGroup: "2FAData",
                items: [{
                    itemType: "group",
                    caption: "2 шатлалтат баталгаажуулалт",
                    items: [{
                        dataField: "profile_check2FAuth",
                        editorType: "dxCheckBox",
                        //editorOptions: {
                        //    text: "password",
                        //    placeholder: "Хуучин нууц үг"
                        //},
                        label: {
                            text: "Идэвхжүүлэх"
                        }
                    }]
                }, {
                    itemType: "button",
                    horizontalAlignment: "right",
                    buttonOptions: {
                        text: "Тохиргоог хадгалах",
                        type: "default",
                        useSubmitBehavior: true
                    }
                }]
            }).dxForm("instance");
            

            
            //$("#profile_summaryPassword").dxValidationSummary({ });
            //$("#profile_inputOldPassword").dxTextBox({
            //    mode: "password",
            //    placeholder: "Хуучин нууц үг",
            //    showClearButton: true
            //}).dxValidator({
            //    validationRules: [{
            //        type: "required",
            //        message: "Хуучин нууц үг оруулна уу"
            //    }]
            //    });
            //$("#profile_inputNewPassword").dxTextBox({
            //    mode: "password",
            //    placeholder: "Шинэ нууц үг",
            //    showClearButton: true
            //}).dxValidator({
            //    validationRules: [{
            //        type: "required",
            //        message: "Шинэ нууц үг оруулна уу"
            //    }]
            //});
            //$("#profile_inputNewPasswordConfirm").dxTextBox({
            //    mode: "password", 
            //    placeholder: "Нууц үг давт",
            //    showClearButton: true
            //}).dxValidator({
            //    validationRules: [{
            //        type: "compare",
            //        comparisonTarget: function(){ 
            //            var password = $("#profile_inputNewPassword").dxTextBox("instance");
            //            if(password) {
            //                return password.option("value");        
            //            }
            //        },
            //        message: "Шинэ нууц үг адилхан оруулна уу"
            //    },
            //    {
            //        type: "required",
            //        message: "Баталгаажуулах шинэ нууц үг оруулна уу"
            //    }]
            //});
            //$("#profile_btnPasswordSave").dxButton({
            //    text: "Нууц үг хадгалах",
            //    type: "default",
            //    useSubmitBehavior: true
            //});

            //$("#profile_check2FAuth").dxCheckBox({
            //    value: false,
            //    text: "Идэвхижүүлэх"
            //}).dxValidator({
            //    validationRules: [{
            //        type: "compare",
            //        comparisonTarget: function(){ return true; },
            //        message: "Та гэрээний нөвцөлийг зөвшөөрч байж бүртгүүлнэ үү"
            //    }]
            //});
            //$("#profile_btn2FASave").dxButton({
            //    text: "Хадгалах",
            //    type: "default",
            //    useSubmitBehavior: true
            //});
        });
    </script>
</asp:Content>
