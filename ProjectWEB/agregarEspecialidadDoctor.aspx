<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agregarEspecialidadDoctor.aspx.cs" Inherits="ProjectWEB.agregarEspecialidadPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label class="h1 text-center text-light titulo mt-5 mb-5" ID="LabelTituloVer" runat="server" Text="Especialidades de "></asp:Label>
    </div>
    
    <div class="tabla-container mt-1">
        <table class="tabla">
            <thead>
                <tr>
                    <th colspan="5" class="cabeza-tabla">Especialidades</th>
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
                            <asp:LinkButton ID="LinkButton1" runat="server">
                                <i class="far fa-trash-alt text-light rounded-circle bg-danger p-2" style="font-size:15px;"></i>
                            </asp:LinkButton>
                            <input id="quitarEspecilidad" value="<%: doctor.especialidad.id %>" type="text" style="display:none"></input>
                        </td>
                    </tr>
                <% } %>
                <% if (!doctoresList.Any())
                    { %>
                        <tr>
                            <td colspan="5" >No hay resultados</td>
                        </tr>
                <%} %>
            </tbody>
        </table>
    </div> 
    
    
    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label class="h1 text-center text-light titulo mt-5 mb-5" ID="LabelTituloAgregar" runat="server" Text="Agregar especialidad a "></asp:Label>
    </div>

    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
        <asp:DropDownList ID="DropEspecialidad" runat="server"></asp:DropDownList>
        <asp:Button Class="btn btn-success mt-3" ID="ButtonAsignar" runat="server" Text="Asignar especilidad" OnClick="ButtonAsignar_Click" />
    </div>

</asp:Content>
