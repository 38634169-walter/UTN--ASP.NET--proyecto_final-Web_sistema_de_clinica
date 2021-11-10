<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verTurnosMedicos.aspx.cs" Inherits="ProjectWEB.verTurnosMedicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h1 class="text-center text-light mt-3 " style="font-family: 'Abril Fatface', cursive;">Mis turnos</h1>
    </div>

    <div class="d-flex justify-content-start align-items-center flex-column">
        <div class="mt-3">
            <label class="text-light "> Fecha: </label>
            <asp:TextBox ID="TextBoxFecha" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <asp:Button class="btn btn-success text-light mt-2" ID="ButtonBuscarTurno" runat="server" Text="Buscar" OnClick="ButtonBuscarTurno_Click"/>
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
                    <th>Hora</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var turno in turnosList)
                    { %>
                    <tr>
                        <td> <%: turno.paciente.nombre  %> </td>
                        <td> <%: turno.paciente.apellido  %> </td>
                        <td><%: turno.paciente.dni %></td>
                        <td><%: turno.fecha %></td>
                        <td><%: turno.hora %>:00Hs</td>                        
                    </tr>
                <% } %>
                <% if(!turnosList.Any())
                    { %>
                    <tr>
                        <td colspan="5">No hay resultados</td>                        
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div> 
</asp:Content>
