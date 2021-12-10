<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verHistoriales.aspx.cs" Inherits="ProjectWEB.verPacientesMedicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h1 class="text-center text-light mt-3 titulo2">Listado de pacientes</h1>
    </div>




    <div class="row">
        <div class="col-sm-3 col-2">
        </div>
        <div class="col-sm-6 col-8 d-flex justify-content-start align-items-center flex-column">
            <div class="input-group mt-3">
                <span class="input-group-text" id="basic-addon1">DNI: </span>
                <asp:TextBox CssClass="form-control" ID="TextBoxDni" runat="server"></asp:TextBox>
            </div>
            <asp:Button class="btn btn-success text-light mt-2" ID="ButtonBuscarPaciente" runat="server" Text="Buscar" OnClick="ButtonBuscarPaciente_Click"/>
        </div>
        <div class="col-sm-3 col-2">
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
