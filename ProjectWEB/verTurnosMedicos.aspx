<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verTurnosMedicos.aspx.cs" Inherits="ProjectWEB.verTurnosMedicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h1 class="text-center text-light mt-3 " style="font-family: 'Abril Fatface', cursive;">Mis turnos</h1>
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
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div> 
</asp:Content>
