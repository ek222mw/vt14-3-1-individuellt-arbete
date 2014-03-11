<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.FormatPage.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Ta bort format
    </h1>
         <div class="editor-field">
                <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl='<%$ RouteUrl:routename=Format %>' Text="Återgå till formatlistan" />
            </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:PlaceHolder runat="server" ID="ConfirmationPlaceHolder">
        <p>
            Är du säker på att du vill ta bort formatet? <strong>
                <asp:Literal runat="server" ID="FormatName" ViewStateMode="Enabled" /></strong>?
        </p>
    </asp:PlaceHolder>
    <div>
        <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Ja, ta bort formatet"
            OnCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:id %>' />
        <asp:HyperLink runat="server" ID="CancelHyperLink" Text="Avbryt" />
    </div>
</asp:Content>
</asp:Content>
