<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="OptimflexPortal.Search" %>
<dx:BootstrapButtonEdit runat="server" ID="searchEditor" NullText="Search" ClientIDMode="Static">
    <ClearButton DisplayMode="Always" />
    <CssClasses Control="search" NullText="null-text" IconClearButton="icon icon-x" />
    <Buttons>
        <dx:BootstrapEditButton IconCssClass="icon icon-search" />
    </Buttons>
    <ClientSideEvents 
        LostFocus="dxbsDemo.search.onSearchBoxLostFocus"
        GotFocus="dxbsDemo.search.onSearchBoxGotFocus" />
</dx:BootstrapButtonEdit>
<dx:BootstrapCallbackPanel runat="server" ID="searchResults" ClientInstanceName="searchResults" ClientIDMode="Static" OnCallback="searchResults_Callback">
    <ClientSideEvents BeginCallback="dxbsDemo.search.onSearchPopupBeginCallback" EndCallback="dxbsDemo.search.onSearchPopupEndCallback" />
    <SettingsLoadingPanel Text="SEARCHING..." />
    <ContentCollection>
        <dx:ContentControl>
            <ul runat="server" id="resultsContainer">
                <asp:Repeater runat="server" ID="resultsRepeater" EnableViewState="false">
                    <ItemTemplate>
                        <li>
                            <a href='<%# GetSearchItemUrl(Container.DataItem) %>'><%# GetSearchItemTitle(Container.DataItem) %></a>
                            <asp:PlaceHolder runat="server" Visible="<%# GetSearchItemAdditionalInfoVisible(Container.DataItem) %>">                                
                                <a href='<%# GetSearchItemDemoGroupUrl(Container.DataItem) %>'><%# GetSearchItemDemoGroupTitle(Container.DataItem) %></a>
                                <span class="icon icon-right_arr"></span>
                                <a href='<%# GetSearchItemDemoUrl(Container.DataItem) %>'><%# GetSearchItemDemoTitle(Container.DataItem) %></a>
                            </asp:PlaceHolder>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div id="noResultsContainer" runat="server">
                No results found for <b runat="server" id="requestText"></b>.
            </div>
        </dx:ContentControl>
    </ContentCollection>
</dx:BootstrapCallbackPanel>
