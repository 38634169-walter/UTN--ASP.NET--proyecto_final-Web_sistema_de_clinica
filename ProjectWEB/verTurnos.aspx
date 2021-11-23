<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="verTurnos.aspx.cs" Inherits="ProjectWEB.verTurnos1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
    .tabla {
        margin: auto;
        width: 13cm;
        background: gold;
        margin-top:1cm;
        margin-bottom:1cm;
        border-radius: 5px;
    }
    .tabla th {
        background: gold;
        text-align: center;
        padding:10px;
        border:5px solid rgb(253, 237, 184);
        border-radius: 5px;
    }

    .tabla td{
        background: rgb(253, 237, 144);
        text-align: center;
        border:5px solid rgb(253, 237, 184);
        padding: 5px;
    }
    .tabla .alternadas{
        background: rgb(253, 217, 144);
    }

    .pgr{
        border-radius: 5px;
        border:5px solid rgb(253, 237, 184);
    }

    .pgr table{
        background:black;
    }

    .pgr td{
        color:white;
        background:black;
        border-radius: 5px;
        border:0px solid black;
    }

    .pgr a{
        color:black;
        background : white;
        text-decoration:none;
        padding:5px 10px;
        margin:2px;
        border:2px solid black;
    }

    .pgr a:hover{
        color:white;
        background:blue;
    }

</style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <div>
        <h1 class="text-center text-light mt-3 " style="font-family: 'Abril Fatface', cursive;">Listado de turnos</h1>
    </div>

    <div class="d-flex justify-content-start align-items-center flex-column">
        <div class="mt-3">
            <label class="text-light ">DNI: </label>
            <asp:TextBox CssClass="form-control" ID="TextBoxDni" runat="server"></asp:TextBox>
        </div>
        <div class="mt-3">
            <label class="text-light ">Fecha: </label>
            <asp:TextBox ID="TextBoxFecha" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <asp:Button class="btn btn-success mt-3" ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />
    </div>
    
    <div class="tabla-container mt-5">

    
   
    <script>
        var object = { status: false, ele: null };
        var b = 1;

        function eliminarTurno(e) {

            if (object.status) { return true; };


            Swal.fire({
                title: 'Seguro que deseas dar de baja el turno?',
                text: "Se dara de baja!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                confirmButtonText: 'Confirmar',
                showCancelButton: true,
                cancelButtonColor: '#3085d6',
                cancelButtonText: 'Cancelar',
                closeOnConfirm: true
                
            }).then((result) => {
                if (result.isConfirmed) {
                    object.status = true;
                    object.ele = e;
                    object.ele.click();
                    eliminarTurno(this);
                    b = 0;
                }
            })
            return false;
            
        };
    </script>



    <asp:GridView ID="GridViewTurnos" runat="server"
        OnRowDeleting="eliminar_turno" 
         OnRowEditing="GridViewTurnos_RowEditing"
        DataKeyNames="id" 
        AutoGenerateColumns="false"
        CssClass="tabla" 
        AllowSorting="true" 
        AllowPaging="true" 
        PageSize="5" 
        OnPageIndexChanging="GridViewTurnos_PageIndexChanging" 
        GridLines="None"
        AlternatingRowStyle-CssClass="alternadas"
         PagerStyle-CssClass="pgr" 
        OnRowCommand="GridViewTurnos_RowCommand">
            <Columns>

                <asp:BoundField HeaderText="ID" DataField="id"/>
                <asp:BoundField HeaderText="Nombre" DataField="paciente.nombre"/>
                <asp:BoundField HeaderText="Apellido" DataField="paciente.apellido"/>
                <asp:BoundField HeaderText="DNI" DataField="paciente.dni"/>
                <asp:BoundField HeaderText="Fecha" DataField="fecha"/>


                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <div class="d-flex justify-content-center align-items-center justify-content-center flex-row">
                            <asp:LinkButton CommandName="Delete" OnClientClick="return eliminarTurno(this);" CssClass=" bg-transparent" ID="buttonEliminar" ClientIDMode="Static" runat="server">
                                <i class="far fa-trash-alt text-light rounded-circle bg-danger p-2" style="font-size:15px;"></i>
                            </asp:LinkButton>
                            <asp:LinkButton CommandName="Edit" ID="buttonEditar" runat="server">
                                <i class="fas fa-user-edit text-light rounded-circle bg-success p-2" style="font-size: 15px;"></i>
                            </asp:LinkButton>
                            <asp:LinkButton ID="buttonVer" runat="server" CommandName="ver" CommandArgument='<%# Eval("id") %>' >
                                <i class="far fa-eye text-light rounded-circle bg-primary p-2" style="font-size: 15px;"></i>
                            </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
    </asp:GridView>







    
</asp:Content>
