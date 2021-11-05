<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="accionesDoctores.aspx.cs" Inherits="ProjectWEB.agregarPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-center align-items-center">
        <asp:Label class="h1 text-center text-light titulo mt-4 mb-5" ID="LabelTitulo" runat="server" Text="Agregar Medico"></asp:Label>
    </div>
    
    <div class="d-flex justify-content-start align-items-center flex-column">
        
        <div class="mt-2">
            <asp:Label ID="Label2" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
        </div>
        
        <div class="mt-2">
            <asp:Label ID="Label1" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="TextBoxApellido" runat="server"></asp:TextBox>
        </div>
        
        <div class="mt-2">
            <asp:Label ID="LabelDni" runat="server" Text="DNI: " ViewStateMode="Enabled"></asp:Label>
            <asp:TextBox ID="TextBoxDni" runat="server" ValidateRequestMode="Enabled" TextMode="Number"></asp:TextBox>
        </div>
        <div class="mt-2">
            <asp:Label ID="LabelTelefono" runat="server" Text="Telefono: " ViewStateMode="Enabled"></asp:Label>
            <asp:TextBox ID="TextBoxTelefono" runat="server" ValidateRequestMode="Enabled" TextMode="Phone"></asp:TextBox>
        </div>
        <div class="mt-2">
            <asp:Label ID="LabelEmail" runat="server" Text="Email: " ViewStateMode="Enabled"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server" ValidateRequestMode="Enabled" TextMode="Email"></asp:TextBox>
        </div>
        <div class="mt-2">
            <asp:Label ID="LabelSueldo" runat="server" Text="Sueldo: " ViewStateMode="Enabled"></asp:Label>
            <asp:TextBox ID="TextBoxSueldo" runat="server" ValidateRequestMode="Enabled" TextMode="Number"></asp:TextBox>
        </div>
        
        <div class="mt-2">
            <asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
            <asp:DropDownList ID="DropEspecilidad" runat="server"></asp:DropDownList>    
        </div>
        
        <div class="mt-2">
            <asp:Label ID="LabelHorarioEntrada" runat="server" Text="Horario de entrada: "></asp:Label>
            <asp:TextBox ID="TextBoxHorarioEntrada" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        
        <div class="mt-2">
            <asp:Label ID="LabelHorarioSalida" runat="server" Text="Horario de salida: "></asp:Label>
            <asp:TextBox ID="TextBoxHorarioSalida" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        
        <div class="mt-2">
            <asp:Label ID="LabelUsuario" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="TextBoxUsuario" runat="server"></asp:TextBox>
        </div>
        
        <div class="mt-2">
            <asp:Label ID="LabelClave" runat="server" Text="Contraseña: "></asp:Label>
            <asp:TextBox ID="TextBoxClave" runat="server"></asp:TextBox>
        </div>
        
    
        <asp:Button class="btn btn-success mt-2" ID="ButtonAgregarModificar" runat="server" Text="Agregar" OnClick="ButtonAgregarModificar_Click"/>
    
    </div>

</asp:Content>
