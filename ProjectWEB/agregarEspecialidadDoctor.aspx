<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agregarEspecialidadDoctor.aspx.cs" Inherits="ProjectWEB.agregarEspecialidadPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label class="h1 text-center text-light titulo mt-5 mb-5" ID="LabelTituloVer" runat="server" Text="Especialidades"></asp:Label>
    </div>
    
    <div class="tabla-container mt-1">
        <table class="tabla">
            <thead>
                <tr>
                    <th colspan="2" class="cabeza-tabla">Especialidades</th>
                </tr>
                <tr>
                    <th>Especialidad</th>
                    <th>Quitar</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var doctor in doctoresList)
                    { %>
                    <tr>
                        <td> <%: doctor.especialidad.nombre  %> </td>
                        <td style="height:1cm;">
                            <a href="quitarEspecialidad.aspx?idEsp=<%: doctor.especialidad.id %> &idDoc= <%: doctor.id %>">
                                <i class="far fa-trash-alt text-light rounded-circle bg-danger p-2" style="font-size:15px;"></i>
                            </a>



                            <asp:LinkButton ID="ButtonQuitarEspecialidad" runat="server" OnClick="ButtonQuitarEspecialidad_Click">
                                <i class="far fa-trash-alt text-light rounded-circle bg-success p-2" style="font-size:15px;"></i>
                            </asp:LinkButton>
                            <input id="especialidad" value="<%: doctor.especialidad.id %>" type="text" style="display:none"></input>
                            <input id="doctor" value="<%: doctor.id %>" type="text" style="display:none"></input>
                        </td>
                    </tr>
                <% } %>
                <% if (!doctoresList.Any())
                    { %>
                        <tr>
                            <td colspan="2" >No hay especialidades agregadas</td>
                        </tr>
                <%} %>
            </tbody>
        </table>
    </div> 
    
    
    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label class="h1 text-center text-light titulo mt-5 mb-5" ID="LabelTituloAgregar" runat="server" Text="Agregar especialidad"></asp:Label>
    </div>

    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
        <asp:DropDownList ID="DropEspecialidad" runat="server"></asp:DropDownList>
        <asp:Button Class="btn btn-success mt-3" ID="ButtonAsignar" runat="server" Text="Asignar especilidad" OnClick="ButtonAsignar_Click" />
    </div>
    <script class="text-center" src="/Content/scripts/quitarEsp.js"></script>
</asp:Content>
