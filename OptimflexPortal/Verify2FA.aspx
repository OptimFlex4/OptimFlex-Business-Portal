<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Verify2FA.aspx.cs" Inherits="OptimflexPortal.Verify2FA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-10 col-lg-10 col-md-offset-1 col-lg-offset-1">
            <div class="row">
                <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9">
                    <form id="verify2fa_formVerify"action="javascript:void(0);">
                        <h3>1. Google Authenticator руу Optimflex Business Portal-ийг нэмэх </h3>
                        <p>Google Authenticator-ийг нээж баруун талд харагдаж байгаа QR Кодыг Optimflex Business Portal-ийг нэмээрэй.</p>
                        <h3>2. Google Authenticator-с үүсгэж өгсөн 6 оронтой тоог оруулна уу.</h3>
                        <p>Optimflex Business Portal-ийг баталгаажуулахад Google Authenticator-с Optimflex Business Portal-д үүсгэж өгсөн 6 оронтой тоог доор байрлах код гэсэн талбарт оруулан Нэвтрэх товч дарна уу.</p>
                        <div class="row margin-bottom-10">
                            <div class="col-xs-2 text-align-right"><strong>Код</strong></div>
                            <div class="col-xs-4">
                                <div id="verify2fa_inputCode"></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-4 col-xs-offset-2">
                                <div id="verify2fa_btnLogin"></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-4 col-xs-offset-2">
                                <div id="verify2fa_summary"></div>
                            </div>
                        </div>
                    </form>
                </div>
                <div class="col-xs-12 col-sm-9 col-md-3 col-lg-3">
                    <div class="row">
                        <div class="col-xs-12">
                            <img id="verify2fa_imgQRCode" runat="server" src="" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <p>Гараар оруулах код: <code id="verify2fa_spanEntryCode" runat="server"></code></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(function () {
            $("#verify2fa_summary").dxValidationSummary({ });
            $("#verify2fa_inputCode").dxTextBox({
                maxLength: 6
            }).dxValidator({
                validationRules: [{
                    type: "required",
                    message: "Баталгаалуулах код оруулна уу"
                }]
            });
            $("#verify2fa_btnLogin").dxButton({
                text: "Нэвтрэх",
                type: "default",
                useSubmitBehavior: true
            });
            var loadPanel = $(".loadpanel").dxLoadPanel({
                shadingColor: "rgba(0,0,0,0.4)",
                position: { of: "body" },
                message: "Уншиж байна ...",
                visible: false,
                showIndicator: true,
                showPane: true,
                shading: true,
                closeOnOutsideClick: false,
                maxWidth: "350px"
            }).dxLoadPanel("instance");
            $("#verify2fa_formVerify").submit(function (e) {
                loadPanel.show();
                globalAjaxVar = $.ajax({
                    type: "POST",
                    url: "../wcf/SMain.svc/Check2FAAuth",
                    data: '{"pCode":"'+$.trim($('#verify2fa_inputCode').dxTextBox('instance').option('value'))+'"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var resData = jQuery.parseJSON(data.d);
                        loadPanel.hide();
                        if (resData.d.RetType == 0) {
                            window.location = '../'; 
                        }
                        else {
                            DevExpress.ui.notify({message:resData.d.RetDesc, type: "error", displayTime: 3000, width: 300});
                        }
                    },
                    failure: function (response) {
                        alert('LOCAL FAILURE');
                    }
                });
            });
        });
    </script>
</asp:Content>
