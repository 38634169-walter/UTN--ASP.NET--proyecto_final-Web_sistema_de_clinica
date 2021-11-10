<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="accionesPaciente.aspx.cs" Inherits="ProjectWEB.agregarPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center">
        <asp:Label class="h1 text-center text-light titulo mt-4 mb-5" ID="LabelTitulo" runat="server" Text="Agregar Paciente"></asp:Label>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="d-flex justify-content-center align-items-center flex-column">
                <div class="mt-2">
                    <asp:Label ID="Label2" runat="server" Text="Nombre: "></asp:Label>
                    <asp:TextBox CssClass=" form-control" ID="TextBoxNombre" runat="server" AutoPostBack="true" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="mt-2">
                    <asp:Label ID="Label1" runat="server" Text="Apellido: "></asp:Label>
                    <asp:TextBox CssClass=" form-control" ID="TextBoxApellido" runat="server" AutoPostBack="true" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="mt-2">
                    <asp:Label ID="Label3" runat="server" Text="DNI: " Type="Integer" MinimumValue="0" ></asp:Label>
                    <asp:TextBox CssClass=" form-control" ID="TextBoxDni" runat="server" TextMode="Number" AutoPostBack="true" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="mt-2">
                    <asp:Label ID="Label4" runat="server" Text="Email: " Type="Integer" ></asp:Label>
                    <asp:TextBox CssClass=" form-control" ID="TextBoxEmail" runat="server" TextMode="Email"  AutoPostBack="true" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="mt-2">
                    <asp:Label ID="Label5" runat="server" Text="Telefono: " Type="Integer" MinimumValue="0"></asp:Label>
                    <asp:TextBox CssClass=" form-control" ID="TextBoxTelefono" runat="server" TextMode="Phone" AutoPostBack="true" ClientIDMode="Static"></asp:TextBox>
                </div>
                <asp:Button class="btn btn-success mt-2" ID="ButtonAgregarModificar" OnClientClick="return validar_paciente()" runat="server" Text="Agregar" OnClick="ButtonAgregarModificar_Click"/>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
