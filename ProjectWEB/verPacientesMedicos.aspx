<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verPacientesMedicos.aspx.cs" Inherits="ProjectWEB.verPacientesMedicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h1 class="text-center text-light mt-3 " style="font-family: 'Abril Fatface', cursive;">Listado de pacientes</h1>
    </div>

    <div class="d-flex justify-content-start align-items-center flex-column">
        <div class="mt-3">
            <label class="text-light "> DNI: </label>
            <asp:TextBox CssClass="form-control" ID="TextBoxDni" runat="server"></asp:TextBox>
        </div>
        <asp:Button class="btn btn-success text-light mt-2" ID="ButtonBuscarPaciente" runat="server" Text="Buscar" OnClick="ButtonBuscarPaciente_Click"/>
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
                <% foreach (var paciente in pacientesList)
                    { %>
                    <tr>
                        <td> <%: paciente.nombre %> </td>
                        <td> <%: paciente.apellido %> </td>
                        <td> <%: paciente.dni %> </td>
                        <td style="height:1cm;">
                            <a href="/verHistorialPaciente.aspx?id=<%: paciente.id %>" class="m-1"><i class="far fa-eye text-light rounded-circle bg-primary p-2" style="font-size:15px;"></i></a>
                        </td>
                    </tr>
                <% } %>
                <% if (!pacientesList.Any())
                    { %>
                        <tr>
                            <td colspan="4">No hay resultados</td>                        
                        </tr>
                <% } %>
            </tbody>
        </table>
    </div> 

</asp:Content>
