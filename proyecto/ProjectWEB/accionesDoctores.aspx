<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="accionesDoctores.aspx.cs" Inherits="ProjectWEB.agregarPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <div class=" row">

                <div class="col-1">
                </div>

                <div class="col-10 d-flex justify-content-start align-items-center flex-column">

                    <div class="d-flex justify-content-center align-items-center">
                        <asp:Label class="h1 text-center titulo2 mt-4 mb-5" ID="LabelTitulo" runat="server" Text="Agregar Medico"></asp:Label>
                    </div>


                    <div class=" row">

                        <div class="col-sm-6 col-12">

                            <div class="mt-2">
                                <asp:Label ID="Label2" runat="server" Text="Nombre: "></asp:Label>
                                <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxNombre" runat="server"></asp:TextBox>
                            </div>

                            <div class="mt-2">
                                <asp:Label ID="Label1" runat="server" Text="Apellido: "></asp:Label>
                                <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxApellido" runat="server"></asp:TextBox>
                            </div>

                            <div class="mt-2">
                                <asp:Label ID="LabelDni" runat="server" Text="DNI: " ViewStateMode="Enabled"></asp:Label>
                                <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxDni" runat="server" ValidateRequestMode="Enabled" TextMode="Number"></asp:TextBox>
                            </div>

                            <div class="mt-2">
                                <asp:Label ID="LabelClave" runat="server" Text="Contraseña: "></asp:Label>
                                <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxClave" runat="server"></asp:TextBox>
                                <asp:Label ID="errorClave" runat="server" Text="" ForeColor="#CC0000" ClientIDMode="Static"></asp:Label>
                            </div>

                        </div>

                        <div class="col-sm-6 col-12">
                            <div class="mt-2">
                                <asp:Label ID="LabelSueldo" runat="server" Text="Sueldo: " ViewStateMode="Enabled"></asp:Label>
                                <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxSueldo" runat="server" ValidateRequestMode="Enabled" TextMode="Number"></asp:TextBox>
                            </div>

                            <div class="mt-2">
                                <asp:Label ID="LabelTelefono" runat="server" Text="Telefono: " ViewStateMode="Enabled"></asp:Label>
                                <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxTelefono" runat="server" ValidateRequestMode="Enabled" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="mt-2">
                                <asp:Label ID="LabelEmail" runat="server" Text="Email: " ViewStateMode="Enabled"></asp:Label>
                                <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxEmail" runat="server" ValidateRequestMode="Enabled" TextMode="Email"></asp:TextBox>
                            </div>


                            <div class="mt-2">
                                <asp:Label ID="LabelUsuario" runat="server" Text="Usuario: "></asp:Label>
                                <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxUsuario" runat="server"></asp:TextBox>
                            </div>

                        </div>

                    </div>


                    <div class="text-center text-light mt-5">
                        <asp:Label CssClass="titulo2 h1" ID="tituloHorarios" runat="server" Text="Agregar especialidad con horarios"></asp:Label>
                    </div>


                    <div class="mb-4 w-75">
                        <asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
                        <asp:DropDownList ClientIDMode="Static" CssClass="form-select" ID="DropEspecilidad" runat="server"></asp:DropDownList>
                    </div>


                    <div class="row my-4 d-flex justify-content-start align-items-start flex-row w-75">

                        <div class="col-sm-6  w-50">
                            <div>
                                <asp:CheckBox ID="CheckBoxLunes" runat="server" Text="Lunes" ClientIDMode="Static" />
                            </div>
                            <div>
                                <asp:CheckBox ID="CheckBoxMartes" runat="server" Text="Martes" ClientIDMode="Static" />
                            </div>
                            <div>
                                <asp:CheckBox ID="CheckBoxMiercoles" runat="server" Text="Miercoles" ClientIDMode="Static" />
                            </div>
                            <div>
                                <asp:CheckBox ID="CheckBoxJueves" runat="server" Text="Jueves" ClientIDMode="Static"/>
                            </div>
                        </div>

                        <div class="col-6 w-50">
                            <div>
                                <asp:CheckBox ID="CheckBoxViernes" runat="server" Text="Viernes" ClientIDMode="Static"/>
                            </div>
                            <div>
                                <asp:CheckBox ID="CheckBoxSabado" runat="server" Text="Sabado" ClientIDMode="Static"/>
                            </div>
                            <div>
                                <asp:CheckBox ID="CheckBoxDomingo" runat="server" Text="Domingo" ClientIDMode="Static"/>
                            </div>
                        </div>

                    </div>

                    <div class="d-flex justify-content-start align-items-center flex-sm-row flex-column">
                
                        <div class="my-1 mx-1">
                            <asp:Label ID="LabelHorarioEntrada" runat="server" Text="Horario de entrada: "></asp:Label>
                            <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxHorarioEntrada" runat="server" TextMode="Number"></asp:TextBox>
                        </div>

                        <div class="my-1 mx-1">
                            <asp:Label ID="LabelHorarioSalida" runat="server" Text="Horario de salida: "></asp:Label>
                            <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxHorarioSalida" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <asp:Label ID="LabelError" runat="server" Text="" ForeColor="#CC0000" ClientIDMode="Static"></asp:Label>

                    <asp:Button class="btn btn-success my-4" ID="ButtonAgregar" runat="server" Text="Agregar" OnClientClick="return validar_agregar_doctor()" OnClick="ButtonAgregarModificar_Click" />
                    <asp:Button class="btn btn-success my-4" ID="ButtonModificar" runat="server" Text="Modificar" OnClientClick="return validar_modificar_doctor()" OnClick="ButtonAgregarModificar_Click" />


                </div>
                <div class="col-1">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
