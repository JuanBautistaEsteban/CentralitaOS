<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAdmins.aspx.cs" Inherits="CentralitaOS.Web.Admin.AddAdmins" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="name" runat="server" Text="Introduzca el nombre de usuario:"></asp:Label>
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="pass" runat="server" Text="Introduzca la contraseña:"></asp:Label>
            <asp:TextBox ID="UserPass" runat="server" TextMode="Password" ViewStateMode="Enabled"></asp:TextBox>
            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Mostrar Pass" />
            <br />
            <asp:Button ID="send" runat="server" Text="Enviar" OnClick="send_Click" />
            <br />
            <asp:Label ID="result" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
