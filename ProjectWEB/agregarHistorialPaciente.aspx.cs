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
    public partial class agregarHistorialPaciente : System.Web.UI.Page
    {
        public Historial historia;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = (string)Request.QueryString["id"];
            PacienteNegocio pacNego = new PacienteNegocio();
            List<Paciente> pac = new List<Paciente>();
            pac=pacNego.buscar("id",id);
            LabelPaciente.Text += pac[0].nombre.ToString() + " " + pac[0].apellido.ToString();
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            historia = new Historial();
            historia.paciente = new Paciente();
            historia.paciente.id =Convert.ToInt32(Request.QueryString["id"]);

            historia.doctor = new Doctor();
            //NO BORRAR//historia.doctor.id = Convert.ToInt32(Session["ID_Usuario"]);
            historia.doctor.id = 1;
            historia.observacion = TextBoxObservacion.Text;
            historia.fecha = DateTime.Now;

            HistorialNegocio hisNego = new HistorialNegocio();
            hisNego.agregar(historia);
            string confirmacion = "agregado";

            Response.Redirect("inicio.aspx?accion=" + confirmacion);
        }
    }
}