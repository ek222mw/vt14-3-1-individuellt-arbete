<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.Listing1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Titlar
    </h1>
     <div class="editor-field">
                <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl='<%$ RouteUrl:routename=TitelCreate %>' Text="Lägg till titel" />
            </div>
    <div class="editor-field">
                <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl='<%$ RouteUrl:routename=TitelEdit %>' Text="Redigera titel" />
            </div>
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
    </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <div class="editor-field">
        <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl='<%$ RouteUrl:routename=TitelDelete %>' Text="Ta bort en titel" />
    </div>
    <asp:ListView ID="TitelListView" runat="server"
        ItemType="IndividuelltArbete_Emil_K.Model.Customer"
        SelectMethod="TitelListView_GetData"
        DataKeyNames="TitelID">
        <LayoutTemplate>
            <%-- Platshållare för titlar --%>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dl class="titel-card">
                <dt>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("Titel", new { id = Item.TitelID })  %>' Text='<%# Item.Titel %>' /></dt>
                <dd>
                    <%#: Item.Beskrivning %>
                </dd>
                <dd>
                    <%#: Item.Produktionsar %> <%#: Item.Produktionsbolag %> <%#: Item.Genre %>
                </dd>
            </dl>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Detta visas då titlar saknas i databasen. --%>
            <p>
                Titlar saknas.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
</asp:Content>
