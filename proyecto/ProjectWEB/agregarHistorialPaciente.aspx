<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agregarHistorialPaciente.aspx.cs" Inherits="ProjectWEB.agregarHistorialPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="d-flex justify-content-center align-items-center">
        <asp:Label class="h1 text-center text-light titulo2 mt-4 mb-5" ID="LabelPaciente" runat="server" Text="Agregar observacion a "></asp:Label>
    </div>

    <div class="d-flex justify-content-center align-items-center flex-column">
            <asp:Label class="text-light" ID="LabelObservaciones" runat="server" Text="Observacion: "></asp:Label>
            <asp:TextBox CssClass=" form-control" ClientIDMode="Static" ID="TextBoxObservacion" runat="server" MaxLength="300" ViewStateMode="Disabled" Wrap="True" Height="220px" TabIndex="5" TextMode="MultiLine" Width="341px"></asp:TextBox>
        <asp:Button class="btn btn-success my-2" ID="ButtonAgregar" runat="server" Text="Agregar" OnClientClick="return validar_historial()" OnClick="ButtonAgregar_Click" />
    </div>
</asp:Content>