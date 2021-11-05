<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agregarEspecialidadDoctor.aspx.cs" Inherits="ProjectWEB.agregarEspecialidadPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label class="h1 text-center text-light titulo mt-4 mb-5" ID="LabelTitulo" runat="server" Text="Agregar especialidad a "></asp:Label>
    </div>

    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
        <asp:DropDownList ID="DropEspecialidad" runat="server"></asp:DropDownList>
        <asp:Button Class="btn btn-success mt-3" ID="ButtonAsignar" runat="server" Text="Asignar especilidad" OnClick="ButtonAsignar_Click" />
    </div>

</asp:Content>
