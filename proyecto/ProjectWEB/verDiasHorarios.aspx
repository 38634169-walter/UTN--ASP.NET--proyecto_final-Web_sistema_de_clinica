<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verDiasHorarios.aspx.cs" Inherits="ProjectWEB.verDiasHorarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div>
        <h1 class="text-center text-light my-5 titulo2" >Dias del Horario </h1>
    </div>
    <div class="tabla-container">
        <table class="tabla">
            <thead>
                <tr>
                    <th colspan="2" class="cabeza-tabla">Horario</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var dia in diaDeTrabajoList)
                    {%>
                        <tr><td> <%: dia.nombre %></td></tr>

                   <%  } %>
            </tbody>
        </table>
    </div>       

</asp:Content>
