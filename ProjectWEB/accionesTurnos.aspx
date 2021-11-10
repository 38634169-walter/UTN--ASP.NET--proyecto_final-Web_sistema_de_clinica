<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="accionesTurnos.aspx.cs" Inherits="ProjectWEB.verTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-center align-items-center">
        <asp:Label class="h1 text-center text-light titulo mt-4 mb-5" ID="LabelTitulo" runat="server" Text="Agregar Turno"></asp:Label>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="m-auto w-25">
                <div class="m-2 rounded-circle d-flex justify-content-start align-items-center">
                    <asp:Label ID="LabelDni" runat="server" Text="DNI: "></asp:Label>
                    <asp:TextBox CssClass="form-control ms-2" ID="TextBoxDni" runat="server" AutoPostBack="True" OnTextChanged="TextBoxDni_TextChanged"></asp:TextBox>
                    <asp:Label ID="LabelValidar" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>

                <div class="m-2 rounded-circle d-flex justify-content-start align-items-center">
                    <asp:Label ID="LabelEspecilidad" runat="server" Text="Especialidad: "></asp:Label>
                    <asp:DropDownList CssClass="form-select ms-2" ID="DropEspecialidad" runat="server" OnSelectedIndexChanged="DropEspecialidad_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>

                <div class="m-2 rounded-circle d-flex justify-content-start align-items-center">
                    <asp:Label ID="LabelPersonal" runat="server" Text="Doctor: "></asp:Label>
                    <asp:DropDownList CssClass="form-select ms-2" ID="DropPersonalDisponible" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropPersonalDisponible_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="m-2 rounded-circle">
                    <asp:Label ID="LabelFecha" runat="server" Text="Fecha: "></asp:Label>
                    <asp:TextBox CssClass="form-control ms-2" ID="TextBoxfecha" runat="server" TextMode="Date" OnTextChanged="TextBoxfecha_TextChanged" AutoPostBack="True" ></asp:TextBox>   
                </div>


                <div class="m-2 rounded-circle d-flex justify-content-start align-items-center">
                    <asp:Label ID="LabelHora" runat="server" Text="Horario: "></asp:Label>
                    <asp:DropDownList CssClass="form-select ms-2" ID="DropHora" runat="server"></asp:DropDownList>
                </div>

                <asp:Button class="btn btn-success mt-2" ID="ButtonReservar" runat="server" Text="Reservar" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

