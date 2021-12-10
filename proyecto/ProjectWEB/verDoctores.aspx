<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verDoctores.aspx.cs" Inherits="ProjectWEB.verPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1 class="text-center text-light mt-3 titulo2">Listado de Medicos</h1>
    </div>

    <div class="tabla-container mt-5">
        <table class="tabla">
            <thead>
                <tr>
                    <th colspan="4" class="cabeza-tabla">Medicos</th>
                </tr>
                <tr>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>DNI</th>
                    <th>Editar</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var doctor in doctoresList)
                    { %>
                    <tr>
                        <td> <%: doctor.nombre %> </td>
                        <td> <%: doctor.apellido %> </td>
                        <td> <%: doctor.dni %> </td>
                        <td style="height:1cm;" class="d-flex justify-content-center align-items-center flex-row">
                            <a href="/accionesDoctores.aspx?id=<%: doctor.id %>" class="editarDoctores d-none"><i class="fas fa-user-edit text-light rounded-circle bg-success p-2" style="font-size:15px;"></i></a>
                            <a href="/verHorarioDoctor.aspx?id=<%: doctor.id %>" class="verHorariosDoctores d-none"><i class="far fa-clock text-light rounded-circle bg-success p-2" style="font-size:15px;"></i></a>
                            <a href="/verEspecialidadDoctor.aspx?id=<%: doctor.id %>" class="verEspecialidadesDoctores d-none"><i class="fas fa-toolbox text-light rounded-circle bg-success p-2" style="font-size:15px;"></i></a>
                        </td>
                    </tr>
                <% } %>
                <% if (!doctoresList.Any())
                    { %>
                    <tr>
                        <td colspan="4"> No hay resultados </td>
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div> 
</asp:Content>
