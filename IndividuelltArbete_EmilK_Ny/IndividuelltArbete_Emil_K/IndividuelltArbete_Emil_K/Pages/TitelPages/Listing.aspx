<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.Listing1" ViewStateMode="Disabled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   <asp:LinkButton ID="AddRedirectButton" runat="server" OnClick="AddRedirectButton_Click" CausesValidation="False">Lägg till ny Titel</asp:LinkButton>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:Label ID="ShowMessage" runat="server" Text="" Visible="false"></asp:Label>

    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
    </asp:Panel>
        <asp:ListView ID="TitelListView" runat="server"
                ItemType="IndividuelltArbete_Emil_K.Model.Title"
                SelectMethod="TitelListView_GetData"
                DeleteMethod="TitelListView_DeleteItem"
                UpdateMethod="TitelListView_UpdateItem"
                DataKeyNames="TitelID" 
                OnItemDataBound="TitelListView_ItemDataBound">
                <LayoutTemplate>
                    <div class="TitelTable">
                    <table class="grid">
                        <tr><td>
                                TitelID
                            </td>
                            <td>
                                Titel
                            </td>
                            <td>
                                TekniskInfo
                            </td>
                            <td>
                                Produktionsår
                            </td>
                            <td>
                                Produktionsbolag
                            </td>
                            <td>
                                Beskrivning
                            </td>
                            <td>
                                Genre
                            </td>
                            <td>
                                Format
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <%-- Platshållare för nya rader --%>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <%-- Mall för nya rader. --%>
                    <tr>
                        <td>
                            <%#: Item.TitelID %>
                        </td>
                        <td>
                            <%#: Item.Titel %>
                        </td>
                        <td>
                            <%#: Item.TekniskInfo %>
                        </td>
                        <td>
                            <%#: Item.Produktionsar %>
                        </td>
                        <td>
                            <%#: Item.Produktionsbolag %>
                        </td>
                        <td>
                            <%#: Item.Beskrivning %>
                        </td>
                        <td>
                            <%#: Item.Genre %>
                        </td>
                        <td>
                            <asp:Literal ID="FormatLiteral" runat="server"></asp:Literal>
                            <%--<%#: Item.FormatID %>--%>
                        </td>
                        <td>
                           <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick="return confirm('Vill du ta bort titeln?')"/>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text="Redigera"  NavigateUrl='<%# "~/Pages/TitelPages/Edit.aspx?titelID=" + Item.TitelID %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <%-- Detta visas då titlar saknas i databasen. --%>
                    <table class="grid">
                        <tr>
                            <td>
                                Titlar saknas.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
</asp:Content>
