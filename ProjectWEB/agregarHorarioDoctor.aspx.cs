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
                LabelTituloAgregar.Text += doctoresList[0].nombre + " " + doctoresList[0].apellido;
                LabelTituloVer.Text += doctoresList[0].nombre + " " + doctoresList[0].apellido;
            }
        }

        protected void ButtonAsignar_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(Request.QueryString["id"]);
            HorarioNegocio horNego = new HorarioNegocio();
            doctor = new Doctor();
            doctor.id = id;
            doctor.horario = new Horario();
            doctor.horario.horaInicio = Convert.ToInt32(TextBoxHorarioInicio.Text);
            doctor.horario.horaFin = Convert.ToInt32(TextBoxHorarioFin.Text);

            horNego.agregar(doctor);
            string confirmacion = "agregado";
            Response.Redirect("inicio.aspx?accion=" + confirmacion);
        }
    }
}