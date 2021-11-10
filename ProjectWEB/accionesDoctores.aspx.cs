﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using modelo;
using negocio;

namespace ProjectWEB
{
    public partial class agregarPersonal : System.Web.UI.Page
    {
        public List<Especialidad> especialidadList;
        public List<Persona> personaList;
        public List<Usuario> usuarioList;
        public Doctor doctor;
        public static string usuarioEditar;
        public bool editando;
        protected void Page_Load(object sender, EventArgs e)
        {
            editando = false;
            EspecialidadNegocio espNego = new EspecialidadNegocio();
            especialidadList = espNego.listar();
            if(!IsPostBack) {
                DropEspecilidad.DataSource = especialidadList;
                DropEspecilidad.DataValueField = "id";
                DropEspecilidad.DataTextField = "nombre";
                DropEspecilidad.DataBind();
            }

            if (Request.QueryString["id"] != null)
            {
                editando = true;
                int id = Convert.ToInt32(Request.QueryString["id"]);
                DoctorNegocio docNego = new DoctorNegocio();
                doctor = new Doctor();
                doctor=docNego.buscar_por_id(id);
                if (!IsPostBack)
                {

                    usuarioEditar = doctor.usuario.usuario;
                    TextBoxNombre.Text = doctor.nombre;
                    TextBoxApellido.Text = doctor.apellido;
                    TextBoxEmail.Text = doctor.email;
                    TextBoxTelefono.Text = doctor.telefono;
                    TextBoxSueldo.Text = doctor.sueldo.ToString();
                    TextBoxDni.Style.Add("display", "none");
                    LabelDni.Style.Add("display", "none");
                    DropEspecilidad.Style.Add("display", "none");
                    TextBoxHorarioEntrada.Style.Add("display", "none");
                    TextBoxHorarioSalida.Style.Add("display", "none");
                    LabelHorarioEntrada.Style.Add("display", "none");
                    LabelHorarioSalida.Style.Add("display", "none");
                    LabelEspecialidad.Style.Add("display", "none");
                    TextBoxUsuario.Text = doctor.usuario.usuario;
                    TextBoxClave.Text = doctor.usuario.clave;
                    ButtonAgregarModificar.Text = "Modificar";
                    LabelTitulo.Text = "Modificar medico";
                }
            }
        }

        protected void ButtonAgregarModificar_Click(object sender, EventArgs e)
        {
            if (doctor == null) doctor = new Doctor();

            doctor.nombre = TextBoxNombre.Text;
            doctor.apellido = TextBoxApellido.Text;
            doctor.telefono = TextBoxTelefono.Text;
            doctor.email = TextBoxEmail.Text;
            doctor.sueldo = Convert.ToDouble(TextBoxSueldo.Text);

            DoctorNegocio docNego = new DoctorNegocio();
            string confirmacion="";
            bool validar=true;
             if (doctor.id != 0)
             {
                validar=validar_usuario();
                if (validar == true)
                {
                    doctor.usuario.usuario = TextBoxUsuario.Text;
                    doctor.usuario.clave = TextBoxClave.Text;
                    docNego.modificar(doctor);
                    confirmacion = "modificado";
                }
             }
             else
             {
                validar = validar_doctor();
                if (validar == true)
                {
                    doctor.dni = TextBoxDni.Text;
                    doctor.especialidad = new Especialidad();
                    doctor.especialidad.id = Convert.ToInt32(DropEspecilidad.SelectedValue);
                    doctor.usuario = new Usuario();
                    doctor.usuario.usuario = TextBoxUsuario.Text;
                    doctor.usuario.clave = TextBoxClave.Text;
                    doctor.horario = new Horario();
                    doctor.horario.horaInicio = Convert.ToInt32(TextBoxHorarioEntrada.Text);
                    doctor.horario.horaFin = Convert.ToInt32(TextBoxHorarioSalida.Text);

                    docNego.agregar(doctor);
                    confirmacion = "agregado";
                }
             }
            if (validar == true) {
                Response.Redirect("inicio.aspx?accion=" + confirmacion);
            }
        }

        public bool validar_usuario()
        {
            LabelError.Text = "";
            bool validar = true;
            string usu = TextBoxUsuario.Text;
            UsuarioNegocio usuNego = new UsuarioNegocio();
            usuarioList = usuNego.lista_usuarios();
            foreach (var usuario in usuarioList)
            {
                if (usuario.usuario == usu && usu != usuarioEditar)
                {
                    LabelError.Text += "*El Usuario ingresado ya existe. <br/> ";
                    validar = false;
                }
            }
            return validar;
        }
        public bool validar_doctor()
        {
            bool validar = true;
            LabelError.Text = "";

            string dni = TextBoxDni.Text;
            string usu = TextBoxUsuario.Text;
            PersonaNegocio perNego = new PersonaNegocio();
            personaList = perNego.listar_datos_personales();
            foreach (var persona in personaList)
            {
                if(persona.dni == dni)
                {
                    LabelError.Text += "*El DNI ingresado ya existe. <br/>";
                    validar = false;
                }
            }
            UsuarioNegocio usuNego = new UsuarioNegocio();
            usuarioList=usuNego.lista_usuarios();
            foreach (var usuario in usuarioList)
            {
                if (usuario.usuario == usu)
                {
                    LabelError.Text += "*El Usuario ingresado ya existe. <br/> ";
                    validar = false;
                }
            }
            int entrada = Convert.ToInt32(TextBoxHorarioEntrada.Text);
            int salida = Convert.ToInt32(TextBoxHorarioSalida.Text);
            if(entrada > salida)
            {
                validar = false;
                LabelError.Text += "*El Horario de entrada no puede ser mayor al de salida. <br/> ";
            }
            else
            {
                if(entrada == salida)
                {
                    validar = false;
                    LabelError.Text += "*El horario de entrada y salida no pueden ser iguales. <br/>";
                }
                else
                {
                    if (entrada > 24 || salida > 24)
                    {
                        validar = false;
                        LabelError.Text += "*El horario ingresado se encuentra fuera del rango de 24hs.";
                    }
                }
            }
            
            return validar;
        }
    }
}