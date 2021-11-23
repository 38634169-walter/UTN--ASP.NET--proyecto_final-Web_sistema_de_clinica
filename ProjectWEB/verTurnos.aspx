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




            <asp:GridView ID="GridViewTurnos" runat="server"
                OnRowDeleting="eliminar_turno" 
                OnRowEditing="GridViewTurnos_RowEditing"
                OnRowCommand="GridViewTurnos_RowCommand"
                OnPageIndexChanging="GridViewTurnos_PageIndexChanging" 
                AllowPaging="true" 
                PageSize="5" 
                DataKeyNames="id" 
                AutoGenerateColumns="false"
                GridLines="None"
                AlternatingRowStyle-CssClass="alternadas"
                CssClass="gv" 
                PagerStyle-CssClass="pgr">
                    <Columns>

                        <asp:BoundField HeaderText="ID" DataField="id"/>
                        <asp:BoundField HeaderText="Nombre" DataField="paciente.nombre"/>
                        <asp:BoundField HeaderText="Apellido" DataField="paciente.apellido"/>
                        <asp:BoundField HeaderText="DNI" DataField="paciente.dni"/>
                        <asp:TemplateField HeaderText="Fecha">
                            <ItemTemplate>
                                <asp:Label ID="LabelFechaa" runat="server" Text=' <% # Eval("fecha") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <div class="d-flex justify-content-center align-items-center justify-content-center flex-row">
                                    
                                    <asp:LinkButton CommandName="Delete" OnClientClick="return eliminar_confirmacion(this);" CssClass="eliminarTurno d-none bg-transparent " ID="buttonEliminar" ClientIDMode="Static" runat="server">
                                        <i class="far fa-trash-alt text-light rounded-circle bg-danger p-2" style="font-size:15px;"></i>
                                    </asp:LinkButton>

                                    <asp:LinkButton CommandName="Edit" ID="buttonEditar" runat="server" CssClass="editarTurno d-none">
                                        <i class="fas fa-user-edit text-light rounded-circle bg-success p-2" style="font-size: 15px;"></i>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="buttonVer" runat="server" CommandName="ver" CommandArgument='<%# Eval("id") %>' >
                                        <i class="far fa-eye text-light rounded-circle bg-primary p-2" style="font-size: 15px;"></i>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
            </asp:GridView>







    
</asp:Content>
