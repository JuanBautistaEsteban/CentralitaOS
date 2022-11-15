<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Bubble.ascx.cs" Inherits="CentralitaOS.Web.Controles.Bubble" %>
<link href="../Content/Bubble.css" rel="stylesheet" />
<div class="bubble <%=!IsAdmin ?"alt":""%>">
    <div class="txt">
        <p class="name"><asp:Label ID="name" runat="server" Text=""></asp:Label></p>
        <p class="text" runat ="server" ><asp:Label ID="text" runat="server" Text=""></asp:Label></p>
        <span class="timestamp"><asp:Label ID="date" runat="server" Text=""></asp:Label> </span>
    </div>
   <!-- <div class ="bubble-arrow <%=!IsAdmin ?"alt":""%>"></div> -->
</div>
<br />
