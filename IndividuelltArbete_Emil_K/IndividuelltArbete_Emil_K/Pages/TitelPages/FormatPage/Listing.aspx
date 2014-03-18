<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.FormatPage.Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Format
    </h1>
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
    </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <div>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=Titel %>' Text="Gå till titel listan" />
    </div>
    <div>
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%$ RouteUrl:routename=TekniskInfo %>' Text="Gå till tekniska info listan" />
    </div>
    <asp:ListView ID="FormatListView" runat="server"
        ItemType="IndividuelltArbete_Emil_K.Model.Formats"
        SelectMethod="FormatListView_GetData"
        DataKeyNames="FormatID">
        <LayoutTemplate>
            <%-- Platshållare för format --%>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
                 <dt>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# GetRouteUrl("FormatCreate", new { id = Item.FormatID })  %>' Text="Lägg till format"  />
                </dt>
                <dt>
                <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl='<%# GetRouteUrl("FormatEdit", new { id = Item.FormatID })  %>' Text="Redigera format"  />
                </dt>
                <dt>
                <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl='<%# GetRouteUrl("FormatDelete", new { id = Item.FormatID })  %>' Text="Ta bort format" />
                </dt><br />
                <dd>
                    FormatID
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("Format", new { id = Item.FormatID })  %>' Text='<%# Item.FormatID %>' />
                </dd>
                <dd>
                    Format
                </dd>
                <dd>
                    <%#: Item.Format %>
                </dd>
            </dl>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div class="editor-field">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=FormatCreate %>' Text="Lägg till nytt format" />
            </div>
             <div>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl='<%$ RouteUrl:routename=Titel %>' Text="Gå till titel listan" />
            </div>
            <div>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%$ RouteUrl:routename=TekniskInfo %>' Text="Gå till tekniska info listan" />
            </div>
            <%-- Detta visas då format saknas i databasen. --%>
            <p>
                Format saknas.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>

</asp:Content>
