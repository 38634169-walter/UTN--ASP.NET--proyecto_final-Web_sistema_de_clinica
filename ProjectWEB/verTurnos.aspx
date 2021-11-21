<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verTurnos.aspx.cs" Inherits="ProjectWEB.verTurnos1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <div>
        <h1 class="text-center text-light mt-3 " style="font-family: 'Abril Fatface', cursive;">Listado de turnos</h1>
    </div>

    <div class="d-flex justify-content-start align-items-center flex-column">
        <div class="mt-3">
            <label class="text-light ">DNI: </label>
            <asp:TextBox CssClass="form-control" ID="TextBoxDni" runat="server"></asp:TextBox>
        </div>
        <div class="mt-3">
            <label class="text-light ">Fecha: </label>
            <asp:TextBox ID="TextBoxFecha" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <asp:Button class="btn btn-success mt-3" ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />
    </div>

    <div class="tabla-container mt-5">
        <table class="tabla">
            <thead>
                <tr>
                    <th colspan="5" class="cabeza-tabla">Turnos</th>
                </tr>
                <tr>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>DNI</th>
                    <th>Fecha</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var turno in turnosList)
                    { %>
                <tr>
                    <td><%: turno.paciente.nombre  %> </td>
                    <td><%: turno.paciente.apellido  %> </td>
                    <td><%: turno.paciente.dni %></td>
                    <td><%: turno.fecha.ToString("dd/MM/yyyy") %></td>
                    <td style="height: 1cm;" class="d-flex justify-content-center align-items-center flex-row">
                        <a href="/accionesTurnos.aspx?id=<%: turno.id %>" class="editarTurno d-none"><i class="fas fa-user-edit text-light rounded-circle bg-success p-2" style="font-size: 15px;"></i></a>



                        <!-- Eliminar -->
                        <a href="/eliminarTurnos.aspx?id=<%: turno.id %>" class="eliminarTurno d-none"><i class="far fa-trash-alt text-light rounded-circle bg-danger p-2" style="font-size: 15px;"></i></a>
                        <a href="/verTurnos.aspx?eliminarID=<%: turno.id %>" class="eliminarTurno d-none"><i class="far fa-trash-alt text-light rounded-circle bg-primary p-2" style="font-size: 15px;"></i></a>


                        <!-- Button trigger modal -->
                        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
                            Elim
                        </button>

                        <!-- Modal -->
                        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="staticBackdropLabel">Modal title</h5>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        ...
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">No</button>
                                        <a type="button" href="/eliminarTurnos.aspx?id=<%: turno.id %>" class="btn btn-primary">Si</a>
                                    </div>
                                </div>
                            </div>
                        </div>


















                        <a href="/verInfoTurno.aspx?id=<%: turno.id %>" class=""><i class="far fa-eye text-light rounded-circle bg-primary p-2" style="font-size: 15px;"></i></a>
                    </td>
                </tr>
                <% } %>
                <% if (!turnosList.Any())
                    { %>
                <tr>
                    <td colspan="5">No hay resultados</td>
                </tr>
                <%} %>
            </tbody>
        </table>
    </div>



    <asp:GridView ID="GridViewTurnos" runat="server"
        OnRowDeleting="eliminarTurno" DataKeyNames="id" AutoGenerateColumns="false">
            <Columns>

                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label ID="LabelNombre" runat="server" Text='<% # Bind("paciente.nombre")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Apellido">
                    <ItemTemplate>
                        <asp:Label ID="LabelApellido" runat="server" Text='<% # Bind("paciente.apellido")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="DNI">
                    <ItemTemplate>
                        <asp:Label ID="LabelDni" runat="server" Text='<% # Bind("paciente.dni")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fecha">
                    <ItemTemplate>
                        <asp:Label ID="LabelFecha" runat="server" Text='<% # Bind("fecha")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ControlStyle-CssClass="btn btn-success" ButtonType="Link" ShowDeleteButton="true" />


            </Columns>
    </asp:GridView>




    <script class="text-center" src="/Content/scripts/eliminarTurno.js"></script>
</asp:Content>
