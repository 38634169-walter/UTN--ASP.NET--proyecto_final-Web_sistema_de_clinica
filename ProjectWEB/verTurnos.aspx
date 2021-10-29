<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verTurnos.aspx.cs" Inherits="ProjectWEB.verTurnos1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <div>
        <h1 class="text-center text-light mt-3 " style="font-family: 'Abril Fatface', cursive;">Listado de turnos</h1>
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
                        <td> <%: turno.cliente.nombre  %> </td>
                        <td> <%: turno.cliente.apellido  %> </td>
                        <td><%: turno.cliente.dni %></td>
                        <td></td>
                        <td style="height:1cm;">
                            <a href="/accionesTurnos.aspx?id=<%: turno.id %>" class=""><i class="fas fa-user-edit text-light rounded-circle bg-success p-2" style="font-size:15px;"></i></a>
                            <asp:Button ID="alert_eliminar" runat="server" Text="Button" OnClick="alert_eliminar_Click" />
                            <a href="/eliminarTurnos.aspx?id=<%: turno.id %>" class=""><i class="far fa-trash-alt text-light rounded-circle bg-danger p-2" style="font-size:15px;"></i></a>
                        </td>
                    </tr>
                <% } %>
            </tbody>
        </table>
        <script>
            function eliminar() {
                Swal.fire({
                    title: 'Are you sure?',
                    text: "You won't be able to revert this!",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes, delete it!'
                }).then((result) => {
                    if (result.isConfirmed) {
                        Swal.fire(
                            'Deleted!',
                            'Your file has been deleted.',
                            'success'
                        )
                    }
                })
            }
        </script>
    </div> 
</asp:Content>
