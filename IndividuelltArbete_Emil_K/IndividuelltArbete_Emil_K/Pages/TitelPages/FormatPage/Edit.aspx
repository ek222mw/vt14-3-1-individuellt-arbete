<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.FormatPage.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Redigera format
    </h1>
         <div class="editor-field">
                <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl='<%$ RouteUrl:routename=Format %>' Text="Återgå till formatlistan" />
            </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:FormView ID="FormatFormView" runat="server"
        ItemType="IndividuelltArbete_Emil_K.Model.Format"
        DataKeyNames="FormatID"
        DefaultMode="Edit"
        RenderOuterTable="false"
        SelectMethod="FormatFormView_GetItem"
        UpdateMethod="FormatFormView_UpdateItem">
        <EditItemTemplate>
            <div class="editor-label">
                <label for="Format">Format</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="FormatTextBox" runat="server" Text='<%# BindItem.Format %>' />
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara" CommandName="Update" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Format", new { id = Item.FormatID }) %>' />
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
</asp:Content>
