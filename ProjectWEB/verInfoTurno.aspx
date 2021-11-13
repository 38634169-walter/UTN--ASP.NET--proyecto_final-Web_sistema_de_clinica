<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verInfoTurno.aspx.cs" Inherits="ProjectWEB.verInfoTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1 class="text-center text-light mt-3 " style="font-family: 'Abril Fatface', cursive;">Info de Turno</h1>
    </div>
    <div class="tabla-container">
        <table class="tabla">
            <thead>
                <tr>
                    <th colspan="2" class="cabeza-tabla">Turno</th>
                </tr>
            </thead>
            <tbody>
                <tr><td><strong>Nombre: </strong></td><td> <%: turno.paciente.nombre %></td></tr>
                <tr><td><strong>Apellido: </strong></td><td><%: turno.paciente.apellido %></td></tr>
                <tr><td><strong>DNI: </strong></td><td><%: turno.paciente.dni %></td></tr>
                <tr><td><strong>Fecha: </strong></td><td> <%: turno.fecha.ToString("dd/MM/yyyy") %>  </td></tr>
                <tr><td><strong>Hora: </strong></td><td>  <%: turno.hora %>:00 Hs</td></tr>
                <tr><td><strong>Doctor/a: </strong></td><td><%: turno.doctor.nombre %> <%: turno.doctor.apellido %></td></tr>
                <tr><td><strong>Especialidad: </strong></td><td><%: turno.especialidad.nombre %></td></tr>
                <tr><td><strong>Turno dado por: </strong></td><td><%: turno.secretaria.nombre %> <%: turno.secretaria.apellido %></td></tr>
            </tbody>
        </table>
    </div>        
</asp:Content>
