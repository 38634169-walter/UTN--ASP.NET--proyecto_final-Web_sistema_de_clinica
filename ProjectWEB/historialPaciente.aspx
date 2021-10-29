<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="historialPaciente.aspx.cs" Inherits="ProjectWEB.historialPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h1 class="text-center text-light mt-3 " style="font-family: 'Abril Fatface', cursive;">Paciente <%: paciente %> </h1>
    </div>

    <div class="tabla-container mt-5">
        <table class="tabla">
            <thead>
                <tr>
                    <th colspan="3" class="cabeza-tabla">Observaciones</th>
                </tr>
                <tr>
                    <th>Fecha</th>
                    <th>Observaciones</th>
                    <th>Atendio</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var historial in historialesList)
                    { %>
                    <tr>
                        <td> </td>
                        <td> <%: historial.observacion %> </td>
                        <td> <%: historial.personal.nombre %> <%: historial.personal.apellido %> </td>
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div> 
</asp:Content>
