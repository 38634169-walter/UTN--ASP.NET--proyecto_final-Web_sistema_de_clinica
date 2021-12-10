<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verHistorialPaciente.aspx.cs" Inherits="ProjectWEB.historialPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h1 class="text-center text-light mt-3 titulo2"><%: paciente %> </h1>
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
                        <td> <%: historial.fecha.ToString("dd/MM/yyyy") %> </td>
                        <td> <%: historial.observacion %> </td>
                        <td> <%: historial.doctor.nombre %> <%: historial.doctor.apellido %> </td>
                    </tr>
                <% } %>
                <% if(!historialesList.Any())
                    { %>
                    <tr>
                        <td colspan="3" > No hay historias hasta el momento</td>
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div> 
</asp:Content>
