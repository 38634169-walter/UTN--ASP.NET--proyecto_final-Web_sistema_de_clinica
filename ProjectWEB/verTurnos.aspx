<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verTurnos.aspx.cs" Inherits="ProjectWEB.verTurnos1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1 class="text-center text-light mt-3 " style="font-family: 'Abril Fatface', cursive;">Listado de turnos</h1>
    </div>

    <div class="tabla-container mt-5">
        <table class="tabla">
            <thead>
                <tr>
                    <th colspan="5" class="cabeza-tabla">Turnos</th>
                </tr>
                <tr>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>DNI</th>
                    <th>Fecha</th>
                    <th>Editar</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var turno in turnosList)
                    { %>
                    <tr>
                        <td> <%: turno.cliente.nombre  %> </td>
                        <td> <%: turno.cliente.apellido  %> </td>
                        <td><%: turno.cliente.dni %></td>
                        <td></td>
                        <td style="height:1cm;">
                            <a href="/accionesTurnos.aspx?id=<%: turno.id %>" class=""><i class="fas fa-user-edit text-light rounded-circle bg-success p-2" style="font-size:15px;"></i></a>
                        </td>
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div> 
</asp:Content>
