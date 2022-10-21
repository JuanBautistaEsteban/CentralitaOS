<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CentralitaOS.Web.Admin.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="title" runat="server" Text="Introduzca su nombre:"></asp:Label>
            <asp:TextBox ID="name" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="send" runat="server" Text="Enviar" OnClick="send_Click" />
            <br />
            <asp:Label ID="result" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
