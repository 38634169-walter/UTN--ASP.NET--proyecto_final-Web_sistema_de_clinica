<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agregarHorarioDoctor.aspx.cs" Inherits="ProjectWEB.agregarHorarioPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label class="h1 text-center text-light titulo mt-4 mb-5" ID="LabelTituloVer" runat="server" Text="Horarios"></asp:Label>
    </div>

     <div class="tabla-container mt-1">
        <table class="tabla">
            <thead>
                <tr>
                    <th colspan="4" class="cabeza-tabla">Horarios</th>
                </tr>
                <tr>
                    <th>Especialidad</th>
                    <th>Horario de entrada</th>
                    <th>Horario de salida</th>
                    <th>Quitar</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var doctor in doctoresList)
                    { %>
                    <tr>
                        <td> <%: doctor.horario.especialidad.nombre %> </td>
                        <td> <%: doctor.horario.horaInicio %>:00Hs </td>
                        <td> <%: doctor.horario.horaFin %>:00Hs </td>
                        <td>
                            <a href="/eliminarHorario.aspx?id=<%: doctor.horario.id %>">
                                <i class="far fa-trash-alt text-light rounded-circle bg-danger p-2" style="font-size:15px;"></i>
                            </a>

                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                <i class="far fa-trash-alt text-light rounded-circle bg-success p-2" style="font-size:15px;"></i>
                            </asp:LinkButton>

                            <input id="eliminarHorario" value="<%: doctor.horario.id %>" type="text" style="display:none"></input>
                        </td>
                    </tr>
                <% } %>
                <% if(!doctoresList.Any())
                    { %>
                    <tr>
                        <td colspan="4" > No hay horarios asignados</td>
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div> 


    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label class="h1 text-center text-light titulo mt-5 mb-5" ID="LabelTituloAgregar" runat="server" Text="Agregar horario"></asp:Label>
    </div>

    <asp:Label ID="LabelError" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
    
    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
        <asp:DropDownList  ID="DropDownListEspecilidad" runat="server"></asp:DropDownList>
    </div>
    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label ID="LabelHorarioInicio" runat="server" Text="Horario de Inicio: "></asp:Label>
        <asp:TextBox ClientIDMode="Static" CssClass="form-control w-25" ID="TextBoxHorarioInicio" runat="server"></asp:TextBox>
    </div>
    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label ID="LabelHorarioFin" runat="server" Text="Horario de Fin: "></asp:Label>
        <asp:TextBox ClientIDMode="Static" CssClass="form-control w-25" ID="TextBoxHorarioFin" runat="server"></asp:TextBox>
        <asp:Button Class="btn btn-success mt-3" ID="ButtonAsignar" runat="server" Text="Asignar horario" OnClientClick="return validar_horario_doctor()" OnClick="ButtonAsignar_Click"/>
    </div>

    <script class="text-center" src="/Content/scripts/eliminarHorario.js"></script>
</asp:Content>
