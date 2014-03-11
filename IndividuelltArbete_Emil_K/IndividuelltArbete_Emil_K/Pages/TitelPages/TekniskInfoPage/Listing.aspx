<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.TekniskInfoPage.Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Tekniska infos
    </h1>
        <div class="editor-field">
                <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl='<%$ RouteUrl:routename=TekniskInfoCreate %>' Text="Lägg till teknisk info" />
            </div>
         <div class="editor-field">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%$ RouteUrl:routename=TekniskInfoEdit %>' Text="Redigera teknisk info" />
            </div>
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
    </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <div class="editor-field">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=TekniskInfoDelete %>' Text="Ta bort teknisk info" />
    </div>
    <asp:ListView ID="TekniskInfoListView" runat="server"
        ItemType="IndividuelltArbete_Emil_K.Model.TekniskInfo"
        SelectMethod="TekniskInfoListView_GetData"
        DataKeyNames="TekniskInfoID">
        <LayoutTemplate>
            <%-- Platshållare för teknisk info --%>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dl class="tekniskinfo-card">
                <dt>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("TekniskInfo", new { id = Item.TekniskInfoID })  %>' Text='<%# Item.TekniskInfoID %>' /></dt>
                <dd>
                    <%#: Item.TekniskInfo %>
                </dd>
                <dd>
                    <%#: Item.FormatID %>
                </dd>
            </dl>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Detta visas då teknisk info saknas i databasen. --%>
            <p>
                Tekniskinfo saknas.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
</asp:Content>
