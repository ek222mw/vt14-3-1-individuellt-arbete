<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="Projekt.Pages.TitelPages.Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=TitelCreate %>' Text="Lägg till ny titel" />
  
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
    </asp:Panel>
        <asp:ListView ID="TitelListView" runat="server"
                ItemType="Projekt.Model.Title"
                SelectMethod="TitelListView_GetData"
                DeleteMethod="TitelListView_DeleteItem"
                UpdateMethod="TitelListView_UpdateItem"
                DataKeyNames="TitelID" 
                OnItemDataBound="TitelListView_ItemDataBound">
                <LayoutTemplate>
                    <div class="TitelTable">
                    <table class="grid">
                        <tr>
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
                        <asp:Literal ID="literal" runat="server"></asp:Literal>
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
