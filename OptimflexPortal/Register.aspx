<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OptimflexPortal.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
		<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-md-offset-3 col-lg-offset-3">
            <div class="well no-padding smart-form client-form">
					<header>
						Бүртгүүлэх
					</header>
                    <div class="dx-fieldset">
                        <div class="row">
                            <div class="col-xs-12 margin-bottom-10">
                                <div id="register_selectUserType"></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 margin-bottom-10">
                                <div id="register_inputName"></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 margin-bottom-10">
                                <div id="register_inputEmail"></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 margin-bottom-10">
                                <div id="register_inputPassword"></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 margin-bottom-10">
                                <div id="register_inputPasswordConfirm"></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 margin-bottom-10 padding-right-5">
                                <div id="register_inputTel1"></div>
                            </div>
                            <div class="col-xs-6 margin-bottom-10 padding-left-5">
                                <div id="register_inputTel2"></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6 margin-bottom-10 padding-right-5">
                                <div id="register_selectGender"></div>
                            </div>
                            <div class="col-xs-6 margin-bottom-10 padding-left-5">
                                <div id="register_inputBirthday"></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div id="register_checkAgree"></div>
                            </div>
                        </div>
                    </div>
                    <div class="dx-fieldset">
                        <div id="register_summary"></div>
                    </div>
                <footer>
                    <div id="register_btnRegister"></div>
                </footer>
            </div>
        </div>
    </div>
    <script>
        $(function () {
            $("#register_summary").dxValidationSummary({ });
            $("#register_selectUserType").dxSelectBox({
                dataSource: [{ ID: 1, Name: "Хэрэглэгч" }, { ID:2, Name:"Харилцагч"} ],
                searchEnabled: true,
                placeholder: "Сонго...",
                value: "Хэрэглэгч",
                displayExpr: "Name",
                valueExpr: "ID"
            });
            $("#register_inputName").dxTextBox({
                placeholder: "Нэр"
            }).dxValidator({
                validationRules: [{
                    type: "required",
                    message: "Нэр оруулна уу"
                }]
            });
            $("#register_inputEmail").dxTextBox({
                placeholder: "И-мэйл"
            }).dxValidator({
                validationRules: [{
                    type: "required",
                    message: "И-мэйл оруулна уу"
                },
                {
                    type: "email",
                    message: "И-мэйл зөв оруулна уу"
                }]
            });
            $("#register_inputPassword").dxTextBox({
                mode: "password",
                placeholder: "Нууц үг",
                showClearButton: true
            }).dxValidator({
                validationRules: [{
                    type: "required",
                    message: "Нууц үг оруулна уу"
                }]
            });
            $("#register_inputPasswordConfirm").dxTextBox({
                mode: "password", 
                placeholder: "Нууц үг давт",
                showClearButton: true
            }).dxValidator({
                validationRules: [{
                    type: "compare",
                    comparisonTarget: function(){ 
                        var password = $("#register_inputPassword").dxTextBox("instance");
                        if(password) {
                            return password.option("value");        
                        }
                    },
                    message: "Нууц үг адилхан оруулна уу"
                },
                {
                    type: "required",
                    message: "Баталгаажуулах нууц үг оруулна уу"
                }]
            });
            $("#register_inputTel1").dxTextBox({
                mode: "tel", 
                placeholder: "Утас 1"
            }).dxValidator({
                validationRules: [{
                    type: "required",
                    message: "Утас 1 оруулна уу"
                }]
            });
            $("#register_inputTel2").dxTextBox({
                mode: "tel", 
                placeholder: "Утас 2"
            }).dxValidator({
                validationRules: [{
                    type: "required",
                    message: "Утас 2 оруулна уу"
                }]
            });
            $("#register_selectGender").dxSelectBox({
                dataSource: [ "Эрэгтэй", "Эмэгтэй", "Бусад"  ],
                searchEnabled: true,
                placeholder: "Хүйс"
            }).dxValidator({
                validationRules: [{
                    type: "required",
                    message: "Хүйс сонгоно уу"
                }]
            });
            $("#register_inputBirthday").dxDateBox({
                type: "date",
                displayFormat: "yyyy-MM-dd",
                placeholder: "Төрсөн огноо",
                width: "100%"
            }).dxValidator({
                validationRules: [{
                    type: "required",
                    message: "Төрсөн огноо оруулна уу"
                }]
            });
            $("#register_checkAgree").dxCheckBox({
                value: false,
                text: "Би гэрээний нөхцөлийг зөвшөөрч байна"
            }).dxValidator({
                validationRules: [{
                    type: "compare",
                    comparisonTarget: function(){ return true; },
                    message: "Та гэрээний нөвцөлийг зөвшөөрч байж бүртгүүлнэ үү"
                }]
                });
            $("#register_btnRegister").dxButton({
                text: "Бүргүүлэх",
                type: "default",
                useSubmitBehavior: true
            });
        });
    </script>
</asp:Content>
