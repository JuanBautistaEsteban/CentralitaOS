<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenceEdit.aspx.cs" Inherits="CentralitaOS.Web.Client.IncidenceEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Bubble.css" rel="stylesheet" />
    <div class ="form-horizontal">
        <h4>Editar incidencia</h4>
        <asp:HiddenField ID="txtId" runat="server" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger "/>
        <div class ="form-group ">
            <asp:Label ID="Label1" runat="server" Text="Nombre del equipo:" CssClass ="col-md-3" AssociatedControlID ="txtEquiment"></asp:Label>
            <div class =" col-md-9 ">
                <asp:Label ID="txtEquiment" runat="server" Text="" CssClass ="form-control "></asp:Label>
            </div>
        </div>
         <div class ="form-group ">
            <asp:Label ID="Label2" runat="server" Text="Tipo de incidencia:" CssClass ="col-md-3" AssociatedControlID ="dllType"></asp:Label>
            <div class =" col-md-9 ">
                <asp:Label ID="dllType" runat="server" Text="" CssClass ="form-control "></asp:Label>
            </div>
        </div>
        <div class ="form-group ">
            <asp:Label ID="Label3" runat="server" Text="Añada información a la incidencia:" CssClass ="col-md-3" AssociatedControlID ="txtIncidence"></asp:Label>
            <div class =" col-md-9 ">
                <asp:TextBox ID="txtIncidence" runat="server" CssClass ="form-control " TextMode ="MultiLine" Rows ="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El texto de la incidencia es obligatorio" Text ="El texto de la incidencia es obligatorio" ControlToValidate ="txtIncidence" ></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class ="form-group ">
           <div class =" col-md-1 col-md-offset-3 ">
               <asp:Button ID="btnSubmit" runat="server" Text="Actualizar" CssClass="btn-default " OnClick="btnSubmit_Click"/>
           </div>
        </div>
    </div>
    <div class="speech-wrapper" style ="background-color : #ffd800" id="messages" runat="server" >
    </div>

</asp:Content>
