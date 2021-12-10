<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="accionesPaciente.aspx.cs" Inherits="ProjectWEB.agregarPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <div class="col-2">

        </div>
        <div class=" col-8 d-flex justify-content-center align-items-center flex-column">

            <div class="d-flex justify-content-center align-items-center">
                <asp:Label class="h1 text-center text-light titulo mt-4 mb-5" ID="LabelTitulo" runat="server" Text="Agregar Paciente"></asp:Label>
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                        
                    <asp:Label ID="LabelError" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                    
                    <div class="row">
                        <div class="col-6">
                            <div class="mt-2">
                                <asp:Label ID="Label2" runat="server" Text="Nombre: "></asp:Label>
                                <asp:TextBox CssClass=" form-control" ID="TextBoxNombre" runat="server" AutoPostBack="true" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="mt-2">
                                <asp:Label ID="Label1" runat="server" Text="Apellido: "></asp:Label>
                                <asp:TextBox CssClass=" form-control" ID="TextBoxApellido" runat="server" AutoPostBack="true" ClientIDMode="Static"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-6">

                            <div class="mt-2">
                                <asp:Label ID="Label3" runat="server" Text="DNI: " Type="Integer" MinimumValue="0" ></asp:Label>
                                <asp:TextBox CssClass=" form-control" ID="TextBoxDni" runat="server" TextMode="Number" AutoPostBack="true" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="mt-2">
                                <asp:Label ID="Label4" runat="server" Text="Email: " Type="Integer" ></asp:Label>
                                <asp:TextBox CssClass=" form-control" ID="TextBoxEmail" runat="server" TextMode="Email"  AutoPostBack="true" ClientIDMode="Static"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <div class="mt-2">
                        <asp:Label ID="Label5" runat="server" Text="Telefono: " Type="Integer" MinimumValue="0"></asp:Label>
                        <asp:TextBox CssClass=" form-control" ID="TextBoxTelefono" runat="server" TextMode="Number" AutoPostBack="true" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    
                    <div class="d-flex justify-content-center align-items-center">
                        <asp:Button class="btn btn-success my-4" ID="ButtonAgregarModificar" OnClientClick="return validar_paciente()" runat="server" Text="Agregar" OnClick="ButtonAgregarModificar_Click"/>
                    </div>       
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        
        <div class="col-2">

        </div>
    </div>

</asp:Content>
