<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.TekniskInfoPage.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Redigera teknisk info
    </h1>
        <div class="editor-field">
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl='<%$ RouteUrl:routename=TekniskInfo %>' Text="Återgå till teknisk info listan" />
            </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:FormView ID="TekniskInfoFormView" runat="server"
        ItemType="IndividuelltArbete_Emil_K.Model.TekniskInfo"
        DataKeyNames="TekniskInfoID"
        DefaultMode="Edit"
        RenderOuterTable="false"
        SelectMethod="TekniskInfoFormView_GetItem"
        UpdateMethod="TekniskInfoFormView_UpdateItem">
        <EditItemTemplate>
            <div class="editor-label">
                <label for="TekniskInfo">TekniskInfo</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="TekniskInfoTextBox" runat="server" Text='<%# BindItem.TekniskInfo %>' />
            </div>
           
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara" CommandName="Update" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("TekniskInfo", new { id = Item.TekniskInfoID }) %>' />
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>

</asp:Content>
