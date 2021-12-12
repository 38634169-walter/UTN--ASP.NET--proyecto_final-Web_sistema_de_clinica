<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="accionesTurnos.aspx.cs" Inherits="ProjectWEB.verTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class=" row">

        <div class="col-3">

         </div>
        <div class="col-6">
            <div class="d-flex justify-content-center align-items-center">
                <asp:Label class="h1 text-center titulo2 mt-4 mb-5" ID="LabelTitulo" runat="server" Text="Agregar Turno"></asp:Label>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                        
                    <asp:Label ID="LabelError" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                    
                    <div class=" input-group m-2 rounded-circle">
                        <span class="input-group-text" ID="tDni" runat="server"> DNI: </span>
                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxDni" runat="server" AutoPostBack="True" OnTextChanged="TextBoxDni_TextChanged"></asp:TextBox>
                        <asp:Label ID="LabelValidar" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="m-2 rounded-circle ">
                        <asp:Label ID="LabelEspecilidad" runat="server" Text="Especialidad: "></asp:Label>
                        <asp:DropDownList ClientIDMode="Static" CssClass="form-select ms-2" ID="DropEspecialidad" runat="server" OnSelectedIndexChanged="DropEspecialidad_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    </div>

                    <div class="m-2 rounded-circle">
                        <asp:Label ID="LabelPersonal" runat="server" Text="Doctor: "></asp:Label>
                        <asp:DropDownList ClientIDMode="Static" CssClass="form-select ms-2" ID="DropPersonalDisponible" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropPersonalDisponible_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    

                                <div ID="horariosDoctorContainer" runat="server" class="bg-primary p-3 my-2" style="border-radius:10px; border:3px solid white; box-shadow:10px 10px 10px black;display:none">
                                    <p class="h1 text-light titulo"><i class="fas fa-clock"></i>Horarios del Doctor</p>
                                    <asp:Label runat="server" ID="labelHorariosDoctor" Text=""></asp:Label>
                                </div>

                    <div class="input-group mt-4 rounded-circle">
                        <span class="input-group-text" ID="TFecha" runat="server"> Fecha: </span>
                        <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="TextBoxfecha" runat="server" TextMode="Date" OnTextChanged="TextBoxfecha_TextChanged" AutoPostBack="True" ></asp:TextBox>   
                    </div>


                    <div class="m-2 rounded-circle">
                        <asp:Label ID="LabelHora" runat="server" Text="Horario: "></asp:Label>
                        <asp:DropDownList ClientIDMode="Static" CssClass="form-select ms-2" ID="DropHora" runat="server"></asp:DropDownList>
                    </div>
                    <div class="m-2 rounded-circle text-center">
                        <asp:Label ID="LabelSinHorario" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                    </div>



                    <div class="d-flex justify-content-center align-items-center">
                        <asp:Button class="btn btn-success my-4" ID="ButtonReservar" runat="server" Text="Reservar" OnClientClick="return validar_turno()" OnClick="ButtonReservar_Click" />
                    </div>
                
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

         <div class="col-3">

         </div>
     </div>

</asp:Content>

