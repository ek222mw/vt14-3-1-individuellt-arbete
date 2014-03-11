<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.FormatPage.Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Format
    </h1>
     <div class="editor-field">
                <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl='<%$ RouteUrl:routename=FormatCreate %>' Text="Lägg till format" />
            </div>
        <div class="editor-field">
                <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl='<%$ RouteUrl:routename=FormatDelete %>' Text="Ta bort format" />
            </div>
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
    </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <div class="editor-field">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=FormatEdit %>' Text="Redigera format" />
    </div>
    <asp:ListView ID="FormatListView" runat="server"
        ItemType="IndividuelltArbete_Emil_K.Model.Format"
        SelectMethod="FormatListView_GetData"
        DataKeyNames="FormatID">
        <LayoutTemplate>
            <%-- Platshållare för format --%>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dl class="format-card">
                <dt>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("Format", new { id = Item.FormatID })  %>' Text='<%# Item.FormatID %>' /></dt>
                <dd>
                    <%#: Item.Format %>
                </dd>
            </dl>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Detta visas då format saknas i databasen. --%>
            <p>
                Format saknas.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>

</asp:Content>
