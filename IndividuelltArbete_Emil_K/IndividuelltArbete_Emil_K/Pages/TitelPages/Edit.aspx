<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.Edit2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Redigera titel
    </h1>
         <div class="editor-field">
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl='<%$ RouteUrl:routename=Titel %>' Text="Återgå till titellistan" />
            </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:FormView ID="TitelFormView" runat="server"
        ItemType="IndividuelltArbete_Emil_K.Model.Title"
        DataKeyNames="TitelID"
        DefaultMode="Edit"
        RenderOuterTable="false"
        SelectMethod="TitelFormView_GetItem"
        UpdateMethod="TitelFormView_UpdateItem">
        <EditItemTemplate>
            <div class="editor-label">
                <label for="Titel">Titel</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="TitelTextBox" runat="server" Text='<%# BindItem.Titel %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet tomt, ange en titel" ControlToValidate="TitelTextBox"></asp:RequiredFieldValidator>
            </div>
            <div class="editor-label">
                <label for="TekniskInfoID">TekniskInfoID</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="TekniskInfoTextBox" runat="server" Text='<%# BindItem.TekniskInfoID %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Fältet tomt, ange ett tekniskinfoid nummer" ControlToValidate="TekniskInfoTextBox"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Fel, ange ett tekniskinfoid nummer" Operator="DataTypeCheck" Type="Integer" ControlToValidate="TekniskInfoTextBox"></asp:CompareValidator>
            </div>
             <div class="editor-label">
                <label for="Beskrivning">Beskrivning</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="BeskrivningTextBox" runat="server" Text='<%# BindItem.Beskrivning %>' TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Fältet tomt, ange en beskrivning" ControlToValidate="BeskrivningTextBox"></asp:RequiredFieldValidator>
            </div>
            <div class="editor-label">
                <label for="Produktionsar">Produktionsår</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="ProduktionsarTextBox" runat="server" Text='<%# BindItem.Produktionsar %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Fältet tomt, ange ett produktionsår" ControlToValidate="ProduktionsarTextBox"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Fel, ange produktionsår,månad och dag" Operator="DataTypeCheck" Type="Date" ControlToValidate="ProduktionsarTextBox"></asp:CompareValidator>
            </div>
            <div class="editor-label">
                <label for="Produktionsbolag">Produktionsbolag</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="ProduktionsbolagTextBox" runat="server" Text='<%# BindItem.Produktionsbolag %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Fältet tomt, ange ett produktionsbolag" ControlToValidate="ProduktionsbolagTextBox"></asp:RequiredFieldValidator>
            </div>
            <div class="editor-label">
                <label for="Genre">Genre</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="GenreTextBox" runat="server" Text='<%# BindItem.Genre %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Fältet tomt, ange en genre" ControlToValidate="GenreTextBox"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara" CommandName="Update" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Titel", new { id = Item.TitelID }) %>' />
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
