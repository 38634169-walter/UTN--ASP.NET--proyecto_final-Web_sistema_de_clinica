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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                HorarioNegocio horNego = new HorarioNegocio();
                doctoresList = horNego.horarios_doctor(id);
                if (!IsPostBack) {
                    LabelTituloAgregar.Text += doctoresList[0].nombre + " " + doctoresList[0].apellido;
                    LabelTituloVer.Text += doctoresList[0].nombre + " " + doctoresList[0].apellido;
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
                horNego.agregar(doctor);
                string confirmacion = "agregado";
                Response.Redirect("inicio.aspx?accion=" + confirmacion);
            }
            else
            {
            }
        }
        public bool validar_horario(List<Doctor> doctoresList,int horaInicio,int horaFin)
        {
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
    }
}