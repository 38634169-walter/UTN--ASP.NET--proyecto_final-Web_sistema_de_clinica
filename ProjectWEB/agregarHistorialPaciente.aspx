<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agregarHistorialPaciente.aspx.cs" Inherits="ProjectWEB.agregarHistorialPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="d-flex justify-content-center align-items-center">
        <asp:Label class="h1 text-center text-light titulo mt-4 mb-5" ID="LabelPaciente" runat="server" Text="Agregar observacion a "></asp:Label>
    </div>

    <div class="d-flex justify-content-center align-items-center flex-column">
            <asp:Label class="text-light" ID="LabelObservaciones" runat="server" Text="Observacion: "></asp:Label>
            <asp:TextBox class="rounded-2" ID="TextBoxObservacion" runat="server" MaxLength="300"></asp:TextBox>
        <asp:Button class="btn btn-success my-2" ID="ButtonAgregar" runat="server" Text="Agregar" OnClick="ButtonAgregar_Click" />
    </div>
</asp:Content>