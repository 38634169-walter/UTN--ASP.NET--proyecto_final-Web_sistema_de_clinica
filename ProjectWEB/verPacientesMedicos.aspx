<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verPacientesMedicos.aspx.cs" Inherits="ProjectWEB.verPacientesMedicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h1 class="text-center text-light mt-3 " style="font-family: 'Abril Fatface', cursive;">Listado de pacientes</h1>
    </div>

    <div class="tabla-container mt-5">
        <table class="tabla">
            <thead>
                <tr>
                    <th colspan="4" class="cabeza-tabla">Pacientes</th>
                </tr>
                <tr>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>DNI</th>
                    <th>Historial</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var cliente in clientesList)
                    { %>
                    <tr>
                        <td> <%: cliente.nombre %> </td>
                        <td> <%: cliente.apellido %> </td>
                        <td> <%: cliente.dni %> </td>
                        <td style="height:1cm;">
                            <a href="/historialPaciente.aspx?id=<%: cliente.id %>" class="m-1"><i class="far fa-eye text-light rounded-circle bg-primary p-2" style="font-size:15px;"></i></a>
                            <a href="/agregarHistorialPaciente.aspx?id=<%: cliente.id %>" class="m-1"><i class="fas fa-plus text-light rounded-circle bg-success p-2" style="font-size:15px;"></i></a>
                        </td>
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div> 

</asp:Content>
