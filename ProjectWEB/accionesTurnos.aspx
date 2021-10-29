﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="accionesTurnos.aspx.cs" Inherits="ProjectWEB.verTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center">
        <asp:Label class="h1 text-center text-light titulo mt-4 mb-5" ID="LabelTitulo" runat="server" Text="Agregar Turno"></asp:Label>
    </div>




    <div class="m-auto w-25">
        <div class="m-2 rounded-circle d-flex justify-content-start align-items-center">
            <asp:Label ID="LabelDni" runat="server" Text="DNI Cliente: "></asp:Label>
            <asp:TextBox ID="TextBoxDni" runat="server"></asp:TextBox>
        </div>

        <div class="m-2 rounded-circle d-flex justify-content-start align-items-center">
            <asp:Label ID="LabelEspecilidad" runat="server" Text="Especialidad: "></asp:Label>
            <asp:DropDownList ID="DropEspecialidad" runat="server"></asp:DropDownList>
        </div>

        <!--
        <div class="m-2 rounded-circle">
            
        </div>
        -->


        <div class="m-2 rounded-circle d-flex justify-content-start align-items-center">
            <asp:Label ID="LabelHora" runat="server" Text="Horario: "></asp:Label>
            <asp:DropDownList ID="DropHora" runat="server"></asp:DropDownList>
        </div>

        <div class="m-2 rounded-circle d-flex justify-content-start align-items-center">
            <asp:Label ID="LabelPersonal" runat="server" Text="Personal disponible"></asp:Label>
            <asp:DropDownList ID="DropPersonalDisponible" runat="server"></asp:DropDownList>
        </div>
        <asp:Button class="btn btn-success mt-2" ID="ButtonReservar" runat="server" Text="Reservar" />
    </div>


</asp:Content>
