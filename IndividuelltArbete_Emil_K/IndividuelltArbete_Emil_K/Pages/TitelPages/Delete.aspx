<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.Delete1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Ta bort titel
    </h1>
         <div class="editor-field">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%$ RouteUrl:routename=Titel %>' Text="Återgå till titellistan" />
            </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:PlaceHolder runat="server" ID="ConfirmationPlaceHolder">
        <p>
            Är du säker på att du vill ta bort titeln? <strong>
                <asp:Literal runat="server" ID="TitelName" ViewStateMode="Enabled" /></strong>?
        </p>
    </asp:PlaceHolder>
    <div>
        <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Ja, ta bort titeln"
            OnCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:id %>' />
        <asp:HyperLink runat="server" ID="CancelHyperLink" Text="Avbryt" />
    </div>
</asp:Content>
