<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agregarHorarioDoctor.aspx.cs" Inherits="ProjectWEB.agregarHorarioPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label class="h1 text-center text-light titulo mt-4 mb-5" ID="LabelTitulo" runat="server" Text="Agregar horario a "></asp:Label>
    </div>

    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label ID="LabelHorarioInicio" runat="server" Text="Horario de Inicio: "></asp:Label>
        <asp:TextBox ID="TextBoxHorarioInicio" runat="server"></asp:TextBox>
    </div>
    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label ID="LabelHorarioFin" runat="server" Text="Horario de Fin: "></asp:Label>
        <asp:TextBox ID="TextBoxHorarioFin" runat="server"></asp:TextBox>
        <asp:Button Class="btn btn-success mt-3" ID="ButtonAsignar" runat="server" Text="Asignar horario" OnClick="ButtonAsignar_Click"/>
    </div>

</asp:Content>
