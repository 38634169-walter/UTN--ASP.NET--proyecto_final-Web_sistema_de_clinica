<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verInfoPaciente.aspx.cs" Inherits="ProjectWEB.verInfoCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1 class="text-center text-light mt-3 " style="font-family: 'Abril Fatface', cursive;">Info de paciente</h1>
    </div>
    <div class="tabla-container">
        <table class="tabla">
            <thead>
                <tr>
                    <th colspan="2" class="cabeza-tabla">Paciente</th>
                </tr>
            </thead>
            <tbody>
                <tr><td><strong>Nombre: </strong></td><td> <%: paciente.nombre %> </td></tr>
                <tr><td><strong>Apellido: </strong></td><td> <%: paciente.apellido %></td></tr>
                <tr><td><strong>DNI: </strong></td><td><%: paciente.dni %> </td></tr>
                <tr><td><strong>Email: </strong></td><td><%: paciente.email %> </td></tr>
                <tr><td><strong>Telefono: </strong></td><td> <%: paciente.telefono %> </td></tr>
                </tbody>
        </table>
    </div>        
</asp:Content>
