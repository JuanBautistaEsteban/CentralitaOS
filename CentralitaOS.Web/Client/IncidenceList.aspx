<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenceList.aspx.cs" Inherits="CentralitaOS.Web.Client.IncidenceList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href ="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css" rel ="stylesheet" />
    <br />
    <asp:Label ID="Usuario" runat="server" Text="Prueba"></asp:Label>
    <br />
    <table id ="Incidences">
        <thead>
            <tr>
                <th>Mensaje</th>
                <th>Fecha</th>
                <th>Estado</th>
            </tr>
        </thead>
    </table>
   
    <script src ="https://cdn.datatables.net/1.13.1/js/jquery.dataTables.min.js"></script>
    
    <script type="text/javascript">
        //window.alert("Entramos en la función JavaScript.");
        $(document).ready(function () {
            //window.alert("Mensaje2");
            $('#Incidences').DataTable({
                'bProcessing': true,
                'bServerSide': true,
                'sAjaxSource': '/Client/IncidenceServiceList.ashx',
                'language': { "url": "//cdn.datatables.net/plug-ins/1.10.13/i18n/Spanish.json" },
                "columns": [
                    { "data": "Message", "Name": "Message", "autoWidth": true },
                    { "data": "Date", "Name": "Date", "autoWidth": true },
                    { "data": "Status", "Name": "Status", "autoWidth": true },
                ],
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            return "<a href='/Client/IncidenceEdit?id=" + row.Id + "' class='btn btn-pink'>" + data + "</a>";
                        },
                        "targets": 0
                    },
                    {
                        "render": function (data, type, row) {
                            var dateString = data.substr(6);
                            var currentTime = new Date(parseInt(dateString));
                            var month = currentTime.getMonth() + 1;
                            var day = currentTime.getDate();
                            var year = currentTime.getFullYear();
                            var date = day + "/" + month + "/" + year;
                            return date;
                        },
                        "targets": 1
                    }
                ]
            });
        });


    </script>
</asp:Content>
