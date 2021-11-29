<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verHorarioDoctor.aspx.cs" Inherits="ProjectWEB.agregarHorarioPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

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
        PagerStyle-CssClass="pgr"
        ShowHeaderWhenEmpty>
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
                    <div class="d-flex justify-content-center align-items-center flex-row">
                        <asp:LinkButton CommandName="Eliminar" runat="server" CssClass=" bg-transparent" OnClientClick="return eliminar_confirmacion(this)" CommandArgument='<% # Eval("horario.id") %>'>
                                <i class="far fa-trash-alt text-light rounded-circle bg-danger p-2" style="font-size:15px;"></i>
                        </asp:LinkButton>
                        <asp:LinkButton CommandName="Ver" runat="server" CssClass=" bg-transparent" CommandArgument='<% # Eval("horario.id") %>'>
                            <i class="far fa-eye text-light rounded-circle bg-primary p-2" style="font-size:15px;"></i>
                        </asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>


        <EmptyDataTemplate>
            <asp:Label ID="LabelVacio" runat="server" Text="No hay datos" ForeColor="Black"></asp:Label>
        </EmptyDataTemplate>

    </asp:GridView>



    <div class="row">
        <div class=" col-sm-3 col-2">
        </div>

        <div class=" col-sm-6 col-8 asignarHorariosDoctores d-none">
            <div class="d-flex justify-content-center align-items-center flex-column">
                <asp:Label class="h1 text-center text-light titulo mt-5 mb-5" ID="LabelTituloAgregar" runat="server" Text="Agregar horario"></asp:Label>
            </div>

            <asp:Label ID="LabelError" runat="server" Text="" ForeColor="#CC0000"></asp:Label>

            <div class="d-flex justify-content-center align-items-center flex-column my-2">
                <asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
                <asp:DropDownList CssClass="form-select" ID="DropDownListEspecilidad" runat="server"></asp:DropDownList>
            </div>

            

            <div class="row my-4">
                
                <div class="col-6">
                    <div>
                        <asp:CheckBox ID="CheckBoxLunes" runat="server" Text="Lunes" />
                    </div>
                    <div>
                        <asp:CheckBox ID="CheckBoxMartes" runat="server" Text="Martes" />
                    </div>
                    <div>
                        <asp:CheckBox ID="CheckBoxMiercoles" runat="server" Text="Miercoles" />
                    </div>
                    <div>
                        <asp:CheckBox ID="CheckBoxJueves" runat="server" Text="Jueves" />
                    </div>
                </div>
                
                <div class="col-6">
                    <div>
                        <asp:CheckBox ID="CheckBoxViernes" runat="server" Text="Viernes" />
                    </div>
                    <div>
                        <asp:CheckBox ID="CheckBoxSabado" runat="server" Text="Sabado" />
                    </div>
                    <div>
                        <asp:CheckBox ID="CheckBoxDomingo" runat="server" Text="Domingo" />
                    </div>
                </div>
                
            </div>





            <div class="d-flex justify-content-center align-items-center flex-column my-2">
                <asp:Label ID="LabelHorarioInicio" runat="server" Text="Horario de Inicio: "></asp:Label>
                <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxHorarioInicio" runat="server"></asp:TextBox>
            </div>
            <div class="d-flex justify-content-center align-items-center flex-column my-2">
                <asp:Label ID="LabelHorarioFin" runat="server" Text="Horario de Fin: "></asp:Label>
                <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxHorarioFin" runat="server"></asp:TextBox>
                <asp:Button Class="btn btn-success my-3" ID="ButtonAsignar" runat="server" Text="Asignar horario" OnClientClick="return validar_horario_doctor()" OnClick="ButtonAsignar_Click" />
            </div>
        </div>

        <div class=" col-sm-3 col-2">
        </div>

    </div>
                </ContentTemplate>
    </asp:UpdatePanel>
    <script class="text-center" src="/Content/scripts/eliminarHorario.js"></script>
</asp:Content>
