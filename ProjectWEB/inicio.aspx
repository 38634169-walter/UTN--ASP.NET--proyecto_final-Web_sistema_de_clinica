<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="ProjectWEB.inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="vh-100 position-relative d-flex align-items-center flex-column h-100 w-100">
        
        <div class="row d-flex justify-content-center align-items-center">
            <img class="w-50 text-align-center" src="/Content/img/fondo.PNG" />
        </div>
        <div class="row">
            <div class="d-flex justify-content-center align-items-center flex-row mt-0 pt-0">
                <img src="/Content/img/giftAnimado2.gif" alt="Imagen no disponible" width="150px" height="150px" />
                <img src="/Content/img/giftAnimado3.gif" alt="Imagen no disponible" width="150px" height="150px" />
                <img src="/Content/img/giftAnimado4.gif" alt="Imagen no disponible" width="150px" height="150px" />
            </div>
        </div>

        <div id="alerta" class="alert alert-success d-flex align-items-center pt-4 position-absolute top-50 start-50 translate-middle invisible " role="alert">
            <i class="far fa-check-circle text-success" ></i>
            <div id="texto"></div>
        </div>
    </div>

</asp:Content>
