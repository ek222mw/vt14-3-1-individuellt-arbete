<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.Create1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Ny Titel
    </h1>
         <div class="editor-field">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%$ RouteUrl:routename=Titel %>' Text="Återgå till titellistan" />
            </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:FormView ID="TitelFormView" runat="server"
        ItemType="IndividuelltArbete_Emil_K.Model.Titel"
        DefaultMode="Insert"
        RenderOuterTable="false"
        InsertMethod="TitelFormView_InsertItem">
        <InsertItemTemplate>
            <div class="editor-label">
                <label for="Titel">Titel</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="TitelTextBox" runat="server" Text='<%# BindItem.Titel %>' />
            </div>
            <div class="editor-label">
                <label for="Beskrivning">Beskrivning</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="BeskrivningTextBox" runat="server" Text='<%# BindItem.Beskrivning %>' />
            </div>
            <div class="editor-label">
                <label for="Produktionsar">Produktionsår</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="ProduktionsarTextBox" runat="server" Text='<%# BindItem.Produktionsar %>' />
            </div>
            <div class="editor-label">
                <label for="Produktionsbolag">Produktionsbolag</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="ProduktionsbolagTextBox" runat="server" Text='<%# BindItem.Produktionsbolag %>' />
            </div>
            <div class="editor-label">
                <label for="Genre">Genre</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="GenreTextBox" runat="server" Text='<%# BindItem.Genre %>' />
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Lägg till" CommandName="Insert" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Titel", null) %>' />
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
</asp:Content>
