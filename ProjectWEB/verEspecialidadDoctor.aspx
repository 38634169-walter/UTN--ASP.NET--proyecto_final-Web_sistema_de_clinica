﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verEspecialidadDoctor.aspx.cs" Inherits="ProjectWEB.agregarEspecialidadPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label class="h1 text-center text-light titulo mt-5 mb-5" ID="LabelTituloVer" runat="server" Text="Especialidades"></asp:Label>
    </div>
    





    <asp:GridView 
        ID="GridViewEspecialidad" 
        runat="server"
        OnRowCommand="GridViewEspecialidad_RowCommand"
        OnPageIndexChanging="GridViewEspecialidad_PageIndexChanging"
        AllowPaging="true"
        PageSize="5"
        DataKeyNames="id"
        AutoGenerateColumns="false"
        GridLines="None"
        CssClass="gv"
        PagerStyle-CssClass="pgr"
        >
            <Columns>
                <asp:BoundField HeaderText="Especialidad" DataField="especialidad.nombre"/>
                
                <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="quitarEspecialidadesDoctores d-none" ItemStyle-CssClass="quitarEspecialidadesDoctores d-none">
                    <ItemTemplate>
                        <asp:LinkButton ID="Eliminar" runat="server" OnClientClick="return eliminar_confirmacion(this);" CommandArgument='<% # Eval("especialidad.id") + ";" + Eval("id") %>' > 
                            <i class="far fa-trash-alt text-light rounded-circle bg-danger p-2" style="font-size:15px;"></i>                    
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

    </asp:GridView>

    
    <div class="asignarEspecilidadesDoctores d-none">
        <div class="d-flex justify-content-center align-items-center flex-column">
            <asp:Label class="h1 text-center text-light titulo mt-5 mb-5" ID="LabelTituloAgregar" runat="server" Text="Agregar especialidad"></asp:Label>
        </div>

        <div class="d-flex justify-content-center align-items-center flex-column">
            <asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
            <asp:DropDownList ID="DropEspecialidad" runat="server"></asp:DropDownList>
            <asp:Button Class="btn btn-success mt-3" ID="ButtonAsignar" runat="server" Text="Asignar especilidad" OnClick="ButtonAsignar_Click" />
        </div>
    </div>
    <script class="text-center" src="/Content/scripts/quitarEsp.js"></script>
</asp:Content>