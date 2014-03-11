<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="IndividuelltArbete_Emil_K.Pages.Shared.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <p>
        Vi är beklagar att ett fel inträffade och vi inte kunde hantera din förfrågan.
    </p>
    <p>
        <a id="A1" href='<%$ RouteUrl:routename=Titels %>' runat="server">Tillbaka till listan med titlar</a>
    </p>
</asp:Content>
    </form>
</body>
</html>
