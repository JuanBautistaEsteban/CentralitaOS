<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenceCreate.aspx.cs" Inherits="CentralitaOS.Web.Client.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4>Crear Incidencia.</h4>
        <hr />
        <!-- Metemos un validador y añadimnos una clase de Boostrap-->
        <asp:ValidationSummary ID="ValidationSummary1" runat="server"  CssClass ="alert alert-danger"/>
        <div class="form-group ">
            <asp:Label ID="Label1" runat="server" Text="Introduzca el nombre del equipo:" CssClass ="col-md-3" AssociatedControlID ="txtEquipment"></asp:Label>
            <div class ="col-md-9 ">
                <asp:TextBox ID="txtEquipment" runat="server" CssClass ="form-control "></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El nombre del equipo es obligatorio." ControlToValidate="txtEquipment" Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group ">
            <asp:Label ID="Label2" runat="server" Text="Introduzca la descripción de la incidencia:" CssClass ="col-md-3" AssociatedControlID ="txtIncidence"></asp:Label>
            <div class ="col-md-9 ">
                <asp:TextBox ID="txtIncidence" runat="server" CssClass ="form-control " TextMode ="MultiLine" Rows ="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="La descripción de la incidencia es obligatorio." ControlToValidate="txtIncidence" Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group ">
            <asp:Label ID="Label3" runat="server" Text="Seleccione el tipo de la incidencia:" CssClass ="col-md-3" AssociatedControlID ="ddlType"></asp:Label>
            <div class ="col-md-9 ">
                <asp:DropDownList ID="ddlType" runat="server" CssClass ="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group ">
           <div class ="col-md-1 col-md-offset-3 ">
               <asp:Button ID="btnSubmit" runat="server" Text="Alta" CssClass ="btn btn-default " OnClick="btnSubmit_Click" />
           </div>
        </div> 

    </div>

</asp:Content>
