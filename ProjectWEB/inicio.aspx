<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="ProjectWEB.inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class=" vh-100" style="background: linear-gradient(90deg, rgba(2,0,36,1) 0%, rgba(9,121,55,1) 0%, rgba(0,212,255,1) 100%);">
        <% if (accion == "agregado") { %>
            <h1>Agregado</h1>
        <% } %>
        
        <% if (accion == "modificado") { %>
            <h1>Modificado</h1>
        <% } %>
        <div class="cuerpo d-flex justify-content-center align-content-center">
            <img class="w-50" src="/Content/imagenes/fondo.PNG"/>
        </div>
    </div>
   
</asp:Content>
