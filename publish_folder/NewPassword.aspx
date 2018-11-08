<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="NewPassword.aspx.cs" Inherits="OptimflexPortal.NewPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
		<div class="col-xs-12 col-sm-12 col-md-5 col-lg-4 col-md-offset-4 col-lg-offset-4">
            <div class="well no-padding smart-form client-form">
                <header>
					Шинэ нууц үг
				</header>
                <div class="dx-fieldset">
                    <div class="row">
                        <div class="col-xs-12 margin-bottom-10">
                            <span>Шинэ нууц үг</span>
                            <div id="newpassword_inputNewPassword"></div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-xs-12">
                            <span>Шинэ нууц үг давт</span>
                            <div id="newpassword_inputNewPasswordConfirm"></div>
                        </div>
                    </div>
                </div>
                <div class="dx-fieldset">
                    <div id="newpassword_summary"></div>
                </div>
                <footer>
                    <div id="newpassword_btnSave"></div>
                </footer>
            </div>
            <p class="text-center"> - Эсвэл нийгмийн сүлжээгээр нэвтрэх -</p>										
			<ul class="list-inline text-center">
				<li>
					<div id="login_btnFacebook"></div>
				</li>
				<li>
					<div id="login_btnGoogle"></div>
				</li>
			</ul>
        </div>
    </div>
    <script>
        $(function () {
            $("#newpassword_summary").dxValidationSummary({ });
            $("#newpassword_inputNewPassword").dxTextBox({
                mode: "password"
            }).dxValidator({
                validationRules: [{
                    type: "required",
                    message: "Нууц үг оруулна уу"
                }]
            });
            $("#newpassword_inputNewPasswordConfirm").dxTextBox({
                mode: "password"
            }).dxValidator({
                validationRules: [{
                    type: "compare",
                    comparisonTarget: function(){ 
                        var password = $("#newpassword_inputNewPassword").dxTextBox("instance");
                        if(password) {
                            return password.option("value");        
                        }
                    },
                    message: "Шинэ нууц үг адилхан оруулна уу"
                },
                {
                    type: "required",
                    message: "Баталгаажуулах шинэ нууц үг оруулна уу"
                }]
            });
            $("#newpassword_btnSave").dxButton({
                text: "Хадгалах",
                type: "default",
                useSubmitBehavior: true
            });
            

            $("#login_btnFacebook").dxButton({
                type: "default",
                icon: "fa fa-facebook"
            });
            $("#login_btnGoogle").dxButton({
                type: "danger",
                icon: "fa fa-google"
            });
        });
    </script>
</asp:Content>
