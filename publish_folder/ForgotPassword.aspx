<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="OptimflexPortal.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
		<div class="col-xs-12 col-sm-12 col-md-5 col-lg-4 col-md-offset-4 col-lg-offset-4">
            <div class="well no-padding smart-form client-form">
                <header>
					Нууц үг мартсан
				</header>
                <div class="dx-fieldset">
                    <div class="row">
                        <div class="col-xs-12">
                            <span>И-мэйл</span>
                            <div id="forgotpassword_inputEmail"></div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-xs-12" style="margin-bottom:25px;">
                            <span class="timeline-seperator text-center text-primary"> <span class="font-sm">ЭСВЭЛ</span> 
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-xs-12">
                            <span>Картын дугаар</span>
                            <div id="forgotpassword_inputCardNumber"></div>
                        </div>
                    </div>
                </div>
                <div class="dx-fieldset">
                        <div id="forgotpassword_summary"></div>
                    </div>
                <footer>
                    <div id="forgotpassword_btnRecovery"></div>
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
            $("#forgotpassword_summary").dxValidationSummary({ });
            $("#forgotpassword_inputEmail").dxTextBox({
            });
            $("#forgotpassword_inputCardNumber").dxTextBox({
                mode: "tel"
            });
            $("#forgotpassword_btnRecovery").dxButton({
                text: "Нууц үг шинэчлэх",
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
