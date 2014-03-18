<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.Listing1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Titlar
    </h1>
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
    </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <div>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=Format %>' Text="Gå till format listan" />
    </div>
    <div>
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%$ RouteUrl:routename=TekniskInfo %>' Text="Gå till tekniska info listan" />
    </div><br />
    <div>
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl='http://cdon.se/musik/hellacopters/rock_%26_roll_is_dead-494871' Text="Gå till försäljningssidan för Rock & Roll Is Dead albumet" />
    </div>
    <div>
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl='http://www.discshop.se/filmer/dvd/rocky_1_disc/P60963' Text="Gå till försäljningssidan för filmen Rocky 1 " />
    </div><br />
    <asp:ListView ID="TitelListView" runat="server"
        ItemType="IndividuelltArbete_Emil_K.Model.Title"
        SelectMethod="TitelListView_GetData"
        DataKeyNames="TitelID">
        <LayoutTemplate>
            <%-- Platshållare för titlar --%>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
           
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
                  <dt>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("TitelCreate", new { id = Item.TitelID })  %>' Text="Lägg till Titel" />
                </dt>
                <dt>
                <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl='<%# GetRouteUrl("TitelEdit", new { id = Item.TitelID })  %>' Text="Redigera Titel" />
                </dt>
                <dt>
                <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl='<%# GetRouteUrl("TitelDelete", new { id = Item.TitelID })  %>' Text="Ta bort Titel" />
                </dt><br />
                <dd>
                    TitelID
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("Titel", new { id = Item.TitelID })  %>' Text='<%# Item.TitelID %>' />

                </dd>
                <dd>
                    Titel
                </dd>
                <dd>
                    <%#: Item.Titel %>
                </dd><br>
                <dd>
                    TekniskInfoID
                </dd>
                <dd>
                    <%#: Item.TekniskInfoID %>
                </dd><br>
                <dd>
                    Beskrivning
                </dd>
                <dd>
                    <%#: Item.Beskrivning %>
                </dd><br>
                <dd>
                    Produktionsår
                </dd>
                <dd>
                    <%#: Item.Produktionsar %> 
                </dd><br>
                <dd>
                    Produktionsbolag
                </dd>
                <dd>
                    <%#: Item.Produktionsbolag %> 
                </dd><br>
                <dd>
                    Genre
                </dd>
                <dd>
                <%#: Item.Genre %>
                </dd>
                </dl>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Detta visas då titlar saknas i databasen. --%>
              <div>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=TitelCreate %>' Text="Lägg till ny titel" />
            </div>
             <div>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%$ RouteUrl:routename=TekniskInfo %>' Text="Gå till tekniska info listan" />
            </div>
            <div>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl='<%$ RouteUrl:routename=Format %>' Text="Gå till format listan" />
            </div>
            <p>
                Titlar saknas.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
