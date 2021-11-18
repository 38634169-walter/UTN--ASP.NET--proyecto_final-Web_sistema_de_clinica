using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using modelo;
using negocio;

namespace ProjectWEB
{
    public partial class agregarHorarioPersonal : System.Web.UI.Page
    {
        public List<Doctor> doctoresList;
        public Doctor doctor;
        public List<Especialidad> especialidadList;
        public List<Permiso> permisosList;
        protected void Page_Load(object sender, EventArgs e)
        {
            validarAcciones();
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                HorarioNegocio horNego = new HorarioNegocio();
                doctoresList = horNego.horarios_doctor(id);
                if (!IsPostBack) {
                    EspecialidadNegocio espNego = new EspecialidadNegocio();
                    especialidadList = espNego.especialidades_doctor_tiene(id);
                    DropDownListEspecilidad.DataSource = especialidadList;
                    DropDownListEspecilidad.DataValueField = "id";
                    DropDownListEspecilidad.DataTextField = "nombre";
                    DropDownListEspecilidad.DataBind();

                    if(doctoresList.Any()) {
                        LabelTituloVer.Text += " de " + doctoresList[0].nombre + " " + doctoresList[0].apellido;
                        LabelTituloAgregar.Text += " a " + doctoresList[0].nombre + " " + doctoresList[0].apellido;
                    }
                }
            }
        }

        protected void ButtonAsignar_Click(object sender, EventArgs e)
        {
            int horaInicio = Convert.ToInt32(TextBoxHorarioInicio.Text);
            int horaFin = Convert.ToInt32(TextBoxHorarioFin.Text);
            bool validar = validar_horario(doctoresList,horaInicio,horaFin);

            if (validar == true) {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                HorarioNegocio horNego = new HorarioNegocio();
                doctor = new Doctor();
                doctor.id = id;
                doctor.horario = new Horario();
                doctor.horario.horaInicio = horaInicio;
                doctor.horario.horaFin = horaFin;
                doctor.horario.especialidad = new Especialidad();
                doctor.horario.especialidad.id = Convert.ToInt32(DropDownListEspecilidad.SelectedValue);
                horNego.agregar(doctor);
                string confirmacion = "agregado";
                Response.Redirect("inicio.aspx?accion=" + confirmacion);
            }
        }
        public bool validar_horario(List<Doctor> doctoresList,int horaInicio,int horaFin)
        {
            LabelError.Text = "";
            if (horaInicio > horaFin)
            {
                LabelError.Text = "*El horario de inicio no debe ser mayor al de fin";
                return false;
            }
            else
            {
                if(horaInicio == horaFin)
                {
                    LabelError.Text = "*Los horarios de inicio y fin no deben ser iguales";
                    return false;
                }
                if(horaInicio > 24 || horaFin > 24)
                {
                    LabelError.Text = "*El horario ingresado se encuentra fuera del rango de 24hs";
                    return false;
                }
            }
            foreach (var doctor in doctoresList)
            {
                for(int i=doctor.horario.horaInicio + 1;i<doctor.horario.horaFin;i++)
                {
                    for (int x=horaInicio;x<=horaFin;x++)
                    {
                        if (i == x)
                        {
                            LabelError.Text = "*El rango de ese horario ya se encuentra en uso por el doctor";
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public void validarAcciones()
        {
            permisosList = new List<Permiso>();
            permisosList = (List<Permiso>)Session["permisos"];
            bool val = false;
            if (permisosList != null)
            {
                foreach (var permiso in permisosList)
                {
                    if (permiso.nombre == "Asignar horarios doctores") ScriptManager.RegisterStartupScript(this, typeof(Page), "asignar", "validar_permiso('asignarHorariosDoctores');", true);
                    if (permiso.nombre == "Eliminar horarios doctores") ScriptManager.RegisterStartupScript(this, typeof(Page), "eliminar", "validar_permiso('eliminarHorariosDoctores');", true);

                    if (permiso.nombre == "Ver horarios doctores") val = true;
                }
            }
            if (val == false)
            {
                Response.Redirect("inicio.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ranbomtext", "eliminarHorario()", true);
        }
    }
}