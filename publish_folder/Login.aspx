<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OptimflexPortal.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
		<div class="col-xs-12 col-sm-12 col-md-5 col-lg-4 col-md-offset-4 col-lg-offset-4">
            <div class="well no-padding">
				<form id="login_formLogin" class="smart-form client-form" action="javascript:void(0);">
					<header>
						Нэвтрэх
					</header>
                    <div class="dx-fieldset">
                        <div class="dx-field">
                            <span>Төрөл</span>
                            <div id="login_selectUserType"></div>
                        </div>
                        <div class="dx-field">
                            <span>Нэвтрэх нэр</span>
                            <div id="login_inputUsername"></div>
                        </div>
                        <div class="dx-field">
                            <span>Нууц үг</span><a class="pull-right cursor-pointer" href="javascript:void(0);">Нууц үг мартсан</a>
                            <div id="login_inputPassword"></div>
                        </div>
                    </div>
					<footer>
                        <div id="login_btnLogin"></div>
					</footer>
				</form>
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
            $("#login_inputUsername").dxTextBox({
                
            }).dxValidator({
                validationRules: [{
                    type: "required",
                    message: "Нэвтрэх нэр оруулна уу"
                }]
            });
            $("#login_inputPassword").dxTextBox({
                mode: "password", 
                showClearButton: true
            }).dxValidator({
                validationRules: [{
                    type: "required",
                    message: "Нууц үг оруулна уу"
                }]
            });
            $("#login_btnLogin").dxButton({
                text: "Нэвтрэх",
                type: "default",
                useSubmitBehavior: true
            });
            $("#login_selectUserType").dxSelectBox({
                dataSource: [{ ID: 1, Name: "Хэрэглэгч" }, { ID:2, Name:"Харилцагч"} ],
                searchEnabled: true,
                placeholder: "Сонго...",
                value: 1,
                displayExpr: "Name",
                valueExpr: "ID"
            });
            $("#login_btnFacebook").dxButton({
                type: "default",
                icon: "fa fa-facebook",
                onClick: function () {

                }
            });
            $("#login_btnGoogle").dxButton({
                type: "danger",
                icon: "fa fa-google",
                onClick: function () {

                }
            });

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
            $("#login_formLogin").submit(function (e) {
                loadPanel.show();
                globalAjaxVar = $.ajax({
                    type: "POST",
                    url: "../wcf/SMain.svc/CheckLoginAuth",
                    data: '{"pUsername":"'+$.trim($('#login_inputUsername').dxTextBox('instance').option('value'))+'", "pPassword":"'+$.trim($('#login_inputPassword').dxTextBox('instance').option('value'))+'"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var resData = jQuery.parseJSON(data.d);
                        loadPanel.hide();
                        if (resData.d.RetType == 0) {
                            window.location = '../'; 
                        }
                        else {
                            DevExpress.ui.notify({message:resData.d.RetDesc, type: "error", displayTime: 3000, width: 350});
                        }
                    },
                    failure: function (response) {
                        alert('LOCAL FAILURE');
                    },
                    error: function (xhr, status, error) {
                        alert('LOCAL ERROR');
                    }
                });
            });
        });
    </script>
</asp:Content>
