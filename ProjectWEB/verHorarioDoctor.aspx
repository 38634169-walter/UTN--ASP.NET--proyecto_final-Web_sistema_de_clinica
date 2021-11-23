<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verHorarioDoctor.aspx.cs" Inherits="ProjectWEB.agregarHorarioPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="d-flex justify-content-center align-items-center flex-column">
        <asp:Label class="h1 text-center text-light titulo mt-4 mb-5" ID="LabelTituloVer" runat="server" Text="Horarios"></asp:Label>
    </div>



    <asp:GridView ID="GridViewHorarios" 
        runat="server" 
        OnRowCommand="GridViewHorarios_RowCommand"
        DataKeyNames="id"
        AutoGenerateColumns="false"
        CssClass="gv"
        AllowPaging="true"
        PageSize="10"
        OnPageIndexChanging="GridViewHorarios_PageIndexChanging"
        GridLines="None"
        PagerStyle-CssClass="pgr">
            <Columns>

                <asp:BoundField HeaderText="Especialidad" DataField="horario.especialidad.nombre" />
                <asp:TemplateField HeaderText="Horario de entreda">
                    <ItemTemplate>
                        <asp:Label ID="LabelInicio" runat="server" Text='<% # Eval("horario.horaInicio") + ":00Hs" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Horario de salida">
                    <ItemTemplate>
                        <asp:Label ID="LabelFin" runat="server" Text='<% # Eval("horario.horaFin") + ":00Hs" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                

                <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="eliminarHorariosDoctores d-none" ItemStyle-CssClass="eliminarHorariosDoctores d-none">
                    <ItemTemplate>
                        <asp:LinkButton CommandName="Eliminar" runat="server" CssClass=" bg-transparent" OnClientClick="return eliminar_confirmacion(this)" CommandArgument='<% # Eval("horario.id") %>'  >
                            <i class="far fa-trash-alt text-light rounded-circle bg-danger p-2" style="font-size:15px;"></i>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
    </asp:GridView>


    <div class="asignarHorariosDoctores d-none">
        <div class="d-flex justify-content-center align-items-center flex-column">
            <asp:Label class="h1 text-center text-light titulo mt-5 mb-5" ID="LabelTituloAgregar" runat="server" Text="Agregar horario"></asp:Label>
        </div>

        <asp:Label ID="LabelError" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
        
        <div class="d-flex justify-content-center align-items-center flex-column">
            <asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
            <asp:DropDownList ID="DropDownListEspecilidad" runat="server"></asp:DropDownList>
        </div>
        <div class="d-flex justify-content-center align-items-center flex-column">
            <asp:Label ID="LabelHorarioInicio" runat="server" Text="Horario de Inicio: "></asp:Label>
            <asp:TextBox ClientIDMode="Static" CssClass="form-control w-25" ID="TextBoxHorarioInicio" runat="server"></asp:TextBox>
        </div>
        <div class="d-flex justify-content-center align-items-center flex-column">
            <asp:Label ID="LabelHorarioFin" runat="server" Text="Horario de Fin: "></asp:Label>
            <asp:TextBox ClientIDMode="Static" CssClass="form-control w-25" ID="TextBoxHorarioFin" runat="server"></asp:TextBox>
            <asp:Button Class="btn btn-success mt-3" ID="ButtonAsignar" runat="server" Text="Asignar horario" OnClientClick="return validar_horario_doctor()" OnClick="ButtonAsignar_Click"/>
        </div>
    </div>

    <script class="text-center" src="/Content/scripts/eliminarHorario.js"></script>
</asp:Content>
