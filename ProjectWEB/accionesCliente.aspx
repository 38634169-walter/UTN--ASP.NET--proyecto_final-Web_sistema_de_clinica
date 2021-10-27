﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="accionesCliente.aspx.cs" Inherits="ProjectWEB.agregarPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center">
        <asp:Label class="h1 text-center text-light titulo mt-4 mb-5" ID="LabelTitulo" runat="server" Text="Agregar Paciente"></asp:Label>
    </div>
    
    <div class="d-flex justify-content-center align-items-center flex-column">
        <div class="mt-2">
            <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
        </div>
        <div class="mt-2">
            <asp:Label ID="Label1" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="TextBoxApellido" runat="server"></asp:TextBox>
        </div>
        <asp:Button class="btn btn-success mt-2" ID="ButtonAgregarModificar" runat="server" Text="Agregar" OnClick="ButtonAgregarModificar_Click"/>
    </div>

</asp:Content>
