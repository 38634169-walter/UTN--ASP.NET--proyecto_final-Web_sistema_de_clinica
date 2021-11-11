<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="accionesDoctores.aspx.cs" Inherits="ProjectWEB.agregarPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-center align-items-center">
        <asp:Label class="h1 text-center text-light titulo mt-4 mb-5" ID="LabelTitulo" runat="server" Text="Agregar Medico"></asp:Label>
    </div>
    
    <div class="d-flex justify-content-start align-items-center flex-column">
        <asp:Label ID="LabelError" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
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
            <asp:Label ID="LabelTelefono" runat="server" Text="Telefono: " ViewStateMode="Enabled"></asp:Label>
            <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxTelefono" runat="server" ValidateRequestMode="Enabled" TextMode="Phone"></asp:TextBox>
        </div>
        <div class="mt-2">
            <asp:Label ID="LabelEmail" runat="server" Text="Email: " ViewStateMode="Enabled"></asp:Label>
            <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxEmail" runat="server" ValidateRequestMode="Enabled" TextMode="Email"></asp:TextBox>
        </div>
        <div class="mt-2">
            <asp:Label ID="LabelSueldo" runat="server" Text="Sueldo: " ViewStateMode="Enabled"></asp:Label>
            <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxSueldo" runat="server" ValidateRequestMode="Enabled" TextMode="Number"></asp:TextBox>
        </div>
        
        <div class="mt-2">
            <asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
            <asp:DropDownList ClientIDMode="Static" CssClass="form-select" ID="DropEspecilidad" runat="server"></asp:DropDownList>    
        </div>
        
        <div class="mt-2">
            <asp:Label ID="LabelHorarioEntrada" runat="server" Text="Horario de entrada: "></asp:Label>
            <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxHorarioEntrada" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        
        <div class="mt-2">
            <asp:Label ID="LabelHorarioSalida" runat="server" Text="Horario de salida: "></asp:Label>
            <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxHorarioSalida" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        
        <div class="mt-2">
            <asp:Label ID="LabelUsuario" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxUsuario" runat="server"></asp:TextBox>
        </div>
        
        <div class="mt-2">
            <asp:Label ID="LabelClave" runat="server" Text="Contraseña: "></asp:Label>
            <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxClave" runat="server"></asp:TextBox>
        </div>
    
        <asp:Button class="btn btn-success mt-2" ID="ButtonAgregar" runat="server" Text="Agregar" OnClientClick="return validar_agregar_doctor()" OnClick="ButtonAgregarModificar_Click"/>
        <asp:Button class="btn btn-success mt-2" ID="ButtonModificar" runat="server" Text="Modificar" OnClientClick="return validar_modificar_doctor()" OnClick="ButtonAgregarModificar_Click"/>


    
    </div>

</asp:Content>
