<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.Shared.Error" ViewStateMode="Disabled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<p>
   Vi är beklagar att ett fel inträffade och vi inte kunde hantera din förfrågan.
</p>
    <p>
        <a id="A1" href='<%$ RouteUrl:routename=Titel %>' runat="server">Tillbaka till listan med titlar</a>
    </p>
</asp:Content>
