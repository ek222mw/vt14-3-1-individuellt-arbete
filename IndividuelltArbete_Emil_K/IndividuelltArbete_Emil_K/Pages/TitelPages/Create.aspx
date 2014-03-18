<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.Create1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Ny Titel
    </h1>
         <div class="editor-field">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%$ RouteUrl:routename=Titel %>' Text="Återgå till titellistan" />
            </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:FormView ID="TitelFormView" runat="server"
        ItemType="IndividuelltArbete_Emil_K.Model.Title"
        DefaultMode="Insert"
        RenderOuterTable="false"
        InsertMethod="TitelFormView_InsertItem">
        <InsertItemTemplate>
            <div class="editor-label">
                <label for="Titel">Titel</label>
            </div>
            <div class="create-field">
                <asp:TextBox ID="TitelTextBox" runat="server" Text='<%# BindItem.Titel %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet tomt, ange ett titel namn." ControlToValidate="TitelTextBox"></asp:RequiredFieldValidator>
            </div>
            <div class="create-label">
                <label for="TekniskInfoID">TekniskInfoID</label>
            </div>
            <div class="create-field">
                <asp:TextBox ID="TekniskInfoTextBox" runat="server" Text='<%# BindItem.TekniskInfoID %>' />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Fältet tomt, ange ett teknisk info nummer" ControlToValidate="TekniskInfoTextBox"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Fel, ange ett heltal" Operator="DataTypeCheck" Type="Integer" ControlToValidate="TekniskInfoTextBox"></asp:CompareValidator>
            </div>
            <div class="create-label">
                <label for="Beskrivning">Beskrivning</label>
            </div>
            <div class="create-field">
                <asp:TextBox ID="BeskrivningTextBox" runat="server" Text='<%# BindItem.Beskrivning %>' TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Fältet tomt,ange en beskrivning" ControlToValidate="BeskrivningTextBox"></asp:RequiredFieldValidator>
            </div>
            <div class="create-label">
                <label for="Produktionsar">Produktionsår</label>
            </div>
            <div class="create-field">
                <asp:TextBox ID="ProduktionsarTextBox" runat="server" Text='<%# BindItem.Produktionsar %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Fältet tomt, ange ett datum" ControlToValidate="ProduktionsarTextBox"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Fel, ange ett datum med år,månad och dag" Operator="DataTypeCheck" Type="Date" ControlToValidate="ProduktionsarTextBox"></asp:CompareValidator>
            </div>
            <div class="create-label">
                <label for="Produktionsbolag">Produktionsbolag</label>
            </div>
            <div class="create-field">
                <asp:TextBox ID="ProduktionsbolagTextBox" runat="server" Text='<%# BindItem.Produktionsbolag %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Fältet tomt, ange ett produktionsbolag" ControlToValidate="ProduktionsbolagTextBox"></asp:RequiredFieldValidator>
            </div>
            <div class="create-label">
                <label for="Genre">Genre</label>
            </div>
            <div class="create-field">
                <asp:TextBox ID="GenreTextBox" runat="server" Text='<%# BindItem.Genre %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Fältet tomt, ange en genre" ControlToValidate="GenreTextBox"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Lägg till" CommandName="Insert" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Titel", null) %>' />
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
