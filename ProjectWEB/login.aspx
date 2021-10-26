<%@ Page Title="login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProjectWEB.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body{
            background: linear-gradient(90deg, rgba(2,0,36,1) 0%, rgba(9,121,55,1) 0%, rgba(0,212,255,1) 100%);
        }
    </style>

    <div class="container text-center text-light mt-5">
        <h1 class="text-center mt-3" style="font-family: 'Abril Fatface', cursive;">Iniciar Sesion</h1>
        <i class="fas fa-users" style="font-size:5rem;"></i>
    </div>

    <div class="container mt-3">
        <form>
            <div class="m-auto shadow p-3 wmio">
                <li>
                    <label class="form-label">Usuario: </label>
                    <asp:TextBox class="form-control" ID="TextBoxUsuario" runat="server"></asp:TextBox>
                </li>
                <li>
                    <label class="form-label">Contaseña: </label>
                    <asp:TextBox ID="TextBoxClave" runat="server" class="form-control"></asp:TextBox>
                </li>
                <asp:Button class="btn btn-success mt-3" ID="ButtonIngresar" runat="server" Text="Ingresar" OnClick="Button1_Click" />
            </div>
        </form>
    </div>
</asp:Content>
