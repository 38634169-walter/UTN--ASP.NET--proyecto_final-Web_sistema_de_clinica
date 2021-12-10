<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verHistoriaPaciente.aspx.cs" Inherits="ProjectWEB.verHistoriaPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="d-flex justify-content-center align-items-center">
        <asp:Label CssClass="text-center text-light mt-3 titulo2 h1" ID="LabelTitulo" runat="server" Text=""></asp:Label>
    </div>

    <div class="tabla-container mt-5">
        <table class="tabla">
            <thead>
                <tr>
                    <th colspan="2" class="cabeza-tabla"> Observacion </th>
                </tr>
                <tr>
                    <th>Fecha</th>
                    <th>Observacion</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><%: historia.fecha.ToString("dd/MM/yyyy") %></td>
                    <td><%: historia.observacion %></td>   
                </tr>
            </tbody>
        </table>
    </div> 
</asp:Content>
