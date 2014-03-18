<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.TitelPages.TekniskInfoPage.Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Tekniska infos
    </h1>
    <asp:Panel runat="server" ID="SuccessMessagePanel" Visible="false" CssClass="icon-ok">
        <asp:Literal runat="server" ID="SuccessMessageLiteral" />
    </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
     <div>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=Titel %>' Text="Gå till titel listan" />
    </div>
    <div>
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%$ RouteUrl:routename=Format %>' Text="Gå till format listan" />
    </div>
    <asp:ListView ID="TekniskInfoListView" runat="server"
        ItemType="IndividuelltArbete_Emil_K.Model.TekniskInfos"
        SelectMethod="TekniskInfoListView_GetData"
        DataKeyNames="TekniskInfoID">
        <LayoutTemplate>
            <%-- Platshållare för teknisk info --%>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dl class="tekniskinfo-card">
                 <dt>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl='<%# GetRouteUrl("TekniskInfoCreate", new { id = Item.TekniskInfoID })  %>' Text="Lägg till teknisk Info" />
                </dt>
                <dt>
                <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl='<%# GetRouteUrl("TekniskInfoEdit", new { id = Item.TekniskInfoID })  %>' Text="Redigera teknisk Info" />
                </dt>
                <dt>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# GetRouteUrl("TekniskInfoDelete", new { id = Item.TekniskInfoID })  %>' Text="Ta bort teknisk info" />
                 </dt><br />
                <dd>
                    TekniskInfoID
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("TekniskInfo", new { id = Item.TekniskInfoID })  %>' Text='<%# Item.TekniskInfoID %>' />

                </dd>
                <dd>
                    Teknisk Info
                </dd>
                <dd>
                    <%#: Item.TekniskInfo %>
                </dd><br />
                <dd>
                    FormatID
                </dd>
                <dd>
                    <%#: Item.FormatID %>
                </dd>
            </dl>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=TekniskInfoCreate %>' Text="Lägg till ny teknisk info" />
            </div>
             <div>
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl='<%$ RouteUrl:routename=Titel %>' Text="Gå till titel listan" />
            </div>
             <div>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%$ RouteUrl:routename=Format %>' Text="Gå till format listan" />
            </div>
            <%-- Detta visas då teknisk info saknas i databasen. --%>
            <p>
                Tekniskinfo saknas.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
