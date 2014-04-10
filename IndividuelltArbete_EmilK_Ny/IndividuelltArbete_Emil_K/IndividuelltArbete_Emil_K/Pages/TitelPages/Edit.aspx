<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.Edit2" ViewStateMode="Disabled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   <asp:Label ID="ShowMessage" runat="server" Text="" Visible="false"></asp:Label>
        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" OnClick="AddRedirectButton_Click">Bakåt</asp:LinkButton>
    <div id="addForm">
    <asp:FormView ID="TitelFormView" runat="server"
                ItemType="IndividuelltArbete_Emil_K.Model.Title"
                DefaultMode="Edit"
                RenderOuterTable="false"
                UpdateMethod="TitelFormView_UpdateItem"
                DataKeyNames="TitelID"
                SelectMethod="TitelFormView_GetData">

            <EditItemTemplate>
                    <%-- Mall för rad i tabellen för att redigera titeluppgifter. --%>
                    <tr>
                        <td>
                            <p>Titel</p>
                            <asp:TextBox ID="TitelTextBox" runat="server" Text='<%# BindItem.Titel %>'/>
                            <asp:RequiredFieldValidator ID="TitelRequiredFieldValidator" runat="server" ErrorMessage="Du måste ange ett namn på titeln" ControlToValidate="TitelTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                       </td>
                        <td><p>TekniskInfo</p>
                            <asp:TextBox ID="TekniskInfoTextBox" runat="server" Text='<%# BindItem.TekniskInfo %>'/>
                            <asp:RequiredFieldValidator ID="TekniskInfoRequiredFieldValidator" runat="server" ControlToValidate="TekniskInfoTextBox" ErrorMessage="Du måste ange en TekniskInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <p>Produktionsår</p>
                            <asp:TextBox ID="ProduktionsarTextBox" runat="server" Text='<%# BindItem.Produktionsar %>'/>
                            <asp:RequiredFieldValidator ID="ProduktionsarRequiredFieldValidator" runat="server" ErrorMessage="Du måste ange ett år" ControlToValidate="ProduktionsarTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <p>Produktionsbolag</p>
                            <asp:TextBox ID="ProduktionsbolagTextBox" runat="server" Text='<%# BindItem.Produktionsbolag %>'/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Du måste ange ett produktionsbolag" ControlToValidate="ProduktionsbolagTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <p>Beskrivning</p>
                            <asp:TextBox ID="BeskrivningTextBox" runat="server" Text='<%# BindItem.Beskrivning %>'/>
                            <asp:RequiredFieldValidator ID="BeskrivningRequiredFieldValidator" runat="server" ErrorMessage="Du måste ange en beskrivning" ControlToValidate="BeskrivningTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <p>Genre</p>
                            <asp:TextBox ID="GenreTextBox" runat="server" Text='<%# BindItem.Genre %>'/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Du måste ange en Genre" ControlToValidate="GenreTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                        
<%--                        <td>
                            <asp:TextBox ID="Filmformat" runat="server" Text='<%# BindItem.FormatID %>'/>
                        </td>--%>
                            <asp:CheckBoxList 
                                ID="FormatCheckBoxList" 
                                runat="server" 
                                ItemType="IndividuelltArbete_Emil_K.Model.Formats" 
                                SelectMethod="FormatCheckboxList_GetData" 
                                DataTextField="Formattyp" 
                                DataValueField="FormatID"
                                OnDataBinding="FormatCheckBoxList_DataBinding"
                                OnDataBound="FormatCheckBoxList_DataBound">
                            
                            </asp:CheckBoxList>
                         <asp:CustomValidator ID="CheckCustomValidator" runat="server" ErrorMessage="Du måste välja något!" OnServerValidate="CheckCustomValidator_ServerValidate"></asp:CustomValidator>
                        <td>
                            <%-- "Kommandknappar" för att uppdatera en kunduppgift och avbryta. Kommandonamnen är VIKTIGA! --%>
                            <asp:LinkButton ID="SaveButton" runat="server" CommandName="Update" Text="Spara" CausesValidation="true"/>
                            <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:FormView>
        </div>
</asp:Content>
