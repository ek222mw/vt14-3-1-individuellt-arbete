<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Projekt.Pages.TitelPages.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LinkButton ID="BackButton" runat="server" OnClick="BackButton_Click" CausesValidation="False">Bakåt</asp:LinkButton>
            <p>
        <asp:Label ID="ShowMessage" runat="server" Text="" Visible="false"></asp:Label>
        </p>
           <div id="addForm">
               </div>
             <asp:FormView ID="TitelFormView" runat="server"
        ItemType="Projekt.Model.Title"
        DefaultMode="Insert"
        RenderOuterTable="false"
        InsertMethod="TitelFormView_InsertItem">
                   <InsertItemTemplate>
                       <%-- Mall för rad i tabellen för att lägga till nya titeluppgifter. Visas bara om InsertItemPosition 
                     har värdet FirstItemPosition eller LasItemPosition.--%>
                    <div id="formContent">
                    <tr>
                        <div class="InsertForm">
                            <p>Titel</p>
                            <asp:TextBox ID="TitelTextBox" runat="server" Text='<%# BindItem.Titel %>' />
                            <asp:RequiredFieldValidator ID="TitelRequiredFieldValidator" runat="server" ErrorMessage="Du måste ange ett namn på titeln" ControlToValidate="TitelTextBox" Text="*"></asp:RequiredFieldValidator>
                        </div>
                        <div class="InsertForm">
                            <p>TekniskInfo</p>
                            <asp:TextBox ID="TekniskInfoTextBox" runat="server" Text='<%# BindItem.TekniskInfo %>' TextMode="MultiLine"/>
                            <asp:RequiredFieldValidator ID="LandRequiredFieldValidator" runat="server" ControlToValidate="TekniskInfoTextBox" ErrorMessage="Du måste ange en tekniskinfo" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        </div>
                        <div class="InsertForm">
                            <p>Produktionsår</p>
                            <asp:TextBox ID="ProduktionsarTextBox" runat="server" Text='<%# BindItem.Produktionsar %>' />
                            <asp:RequiredFieldValidator ID="ProduktionsarRequiredFieldValidator" runat="server" ErrorMessage="Du måste ange ett år" ControlToValidate="ProduktionsarTextBox" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Ange ett heltal med 4 siffror." ControlToValidate="ProduktionsarTextBox" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                        </div>
                        <div class="InsertForm">
                            <p>Produktionsbolag</p>
                            <asp:TextBox ID="ProduktionsbolagTextBox" runat="server" Text='<%# BindItem.Produktionsbolag %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Du måste ange ett Produktionsbolag" ControlToValidate="ProduktionsbolagTextBox" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        </div>
                        <div class="InsertForm">
                            <p>Beskrivning</p>
                            <asp:TextBox ID="BeskrivningTextBox" runat="server" Text='<%# BindItem.Beskrivning %>' TextMode="MultiLine" />
                            <asp:RequiredFieldValidator ID="BeskrivningRequiredFieldValidator" runat="server" ErrorMessage="Du måste ange en beskrivning av titeln." ControlToValidate="BeskrivningTextBox" Text="*"></asp:RequiredFieldValidator>
                        </div>
                        <div class="InsertForm">
                            <p>Genre</p>
                            <asp:TextBox ID="GenreTextBox" runat="server" Text='<%# BindItem.Genre %>'/>
                            <asp:RequiredFieldValidator ID="HyllplatsRequiredFieldValidator" runat="server" ErrorMessage="Du måste ange en Genre" ControlToValidate="GenreTextBox" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        </div>
                        <div class="InsertForm">
                            <p>format</p>
                            <asp:CheckBoxList 
                                ID="FormatCheckBoxList" 
                                runat="server" 
                                ItemType="Projekt.Model.Formats" 
                                SelectMethod="FormatCheckBoxList_GetData" 
                                DataTextField="Format" 
                                DataValueField="FormatID"
                                OnDataBinding="FormatCheckBoxList_DataBinding">
                            
                            </asp:CheckBoxList>
                            <asp:CustomValidator ID="CheckCustomValidator" runat="server" ErrorMessage="Du måste välja något!" OnServerValidate="CheckCustomValidator_ServerValidate"></asp:CustomValidator>
                           
                        </div>
                        <div id="AddButtons">
                            <%-- "Kommandknappar" för att lägga till en ny titeluppgift och rensa texfälten. Kommandonamnen är VIKTIGA! --%>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Insert" Text="Lägg till" />
                            <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                        </div>
                    </tr>
                        </div>
                   </InsertItemTemplate>
                   
               </asp:FormView>
</asp:Content>
