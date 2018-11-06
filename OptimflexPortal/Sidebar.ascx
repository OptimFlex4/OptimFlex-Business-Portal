<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sidebar.ascx.cs" Inherits="OptimflexPortal.Sidebar" %>
<%--<%@ Register TagName="Search" Src="~/Search.ascx" TagPrefix="demo" %>--%>
<section id="sidebar">
    <div class="sidebar-body">
        <%--<demo:Search runat="server" ID="Search"></demo:Search>--%>
        <dx:BootstrapTreeView runat="server" ID="navTreeView" ClientInstanceName="navTreeView"
            ClientIDMode="Static" Target="_top">
            <ClientSideEvents ExpandedChanging="dxbsDemo.expandedChanging" NodeClick="dxbsDemo.onSideBarNodeClick" />
            <CssClasses IconCollapseNode="fa fa-angle-down" IconExpandNode="fa fa-angle-right" />
        </dx:BootstrapTreeView>
    </div>
</section>
