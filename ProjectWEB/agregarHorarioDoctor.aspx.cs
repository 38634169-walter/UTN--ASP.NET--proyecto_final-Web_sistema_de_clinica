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
        public Doctor doctor;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                doctor = new Doctor();
                DoctorNegocio docNego = new DoctorNegocio();
                doctor = docNego.buscar_por_id(id);
                LabelTitulo.Text += doctor.nombre + " " + doctor.apellido;
            }
        }

        protected void ButtonAsignar_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(Request.QueryString["id"]);
            HorarioNegocio horNego = new HorarioNegocio();
            doctor.horario = new Horario();
            doctor.horario.horaInicio = TextBoxHorarioInicio.Text;
            doctor.horario.horaFin = TextBoxHorarioFin.Text;

            horNego.agregar(doctor);
            string confirmacion = "agregado";
            Response.Redirect("inicio.aspx?accion=" + confirmacion);
        }
    }
}