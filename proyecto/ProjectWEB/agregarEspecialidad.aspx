<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agregarEspecialidad.aspx.cs" Inherits="ProjectWEB.agregarEspecialidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center">
        <asp:Label class="h1 text-center text-light titulo mt-4 mb-5" ID="LabelTitulo" runat="server" Text="Agregar Especialidad"></asp:Label>
    </div>
    
    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label ID="LabelError" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
         <asp:Label ID="LabelEspecialidad" runat="server" Text="Nombre de especialidad: "></asp:Label>
         <asp:TextBox ClientIDMode="Static" CssClass="form-control w-50" ID="TextBoxEspecialidad" runat="server"></asp:TextBox>
        <asp:Button class="btn btn-success mt-2" ID="ButtonAgregar" runat="server" Text="Agregar"  OnClientClick="return validar_especialidad()" OnClick="ButtonAgregar_Click"/>
    </div>

</asp:Content>
