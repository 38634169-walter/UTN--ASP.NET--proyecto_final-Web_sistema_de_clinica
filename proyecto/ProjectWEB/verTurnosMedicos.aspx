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
                    <th colspan="6" class="cabeza-tabla">Turnos</th>
                </tr>
                <tr>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>DNI</th>
                    <th>Fecha</th>
                    <th>Hora</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var turno in turnosList)
                    { %>
                    <tr>
                        <td> <%: turno.paciente.nombre  %> </td>
                        <td> <%: turno.paciente.apellido  %> </td>
                        <td><%: turno.paciente.dni %></td>
                        <td><%: turno.fecha.ToString("dd/MM/yyyy") %></td>
                        <td><%: turno.hora %>:00Hs</td>   
                        
                        <% if (turno.estado.nombre == "Modificado" || turno.estado.nombre == "Esperando") { %>
                            <td style="height:1cm;">
                                <a href="/agregarHistorialPaciente.aspx?id=<%: turno.id %>" class="agregarHistoriales d-none m-1"><i class="fas fa-plus text-light rounded-circle bg-success p-2" style="font-size:15px;"></i></a>
                            </td>
                        <% } %>
                        <%else { %>
                            <td style="height:1cm;">
                                <a href="/verHistoriaPaciente.aspx?id=<%: turno.id %>" class="verHistoriales d-none m-1"><i class="far fa-eye text-light rounded-circle bg-primary p-2" style="font-size:15px;"></i></a>
                            </td>
                        <%} %>

                    </tr>
                <% } %>
                <% if(!turnosList.Any())
                    { %>
                    <tr>
                        <td colspan="6">No hay resultados</td>                        
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div> 
</asp:Content>
