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
        public Turno turno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                TurnoNegocio turNego = new TurnoNegocio();
                turno=turNego.buscar_por_id(id);
                LabelPaciente.Text += turno.paciente.nombre.ToString() + " " + turno.paciente.apellido.ToString();
            }
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            historia = new Historial();

            historia.id =Convert.ToInt32(Request.QueryString["id"]);
            historia.observacion = TextBoxObservacion.Text;
            historia.fecha = DateTime.Now;

            HistorialNegocio hisNego = new HistorialNegocio();
            hisNego.agregar(historia);
            string confirmacion = "agregado";

            Response.Redirect("inicio.aspx?accion=" + confirmacion);
        }
    }
}