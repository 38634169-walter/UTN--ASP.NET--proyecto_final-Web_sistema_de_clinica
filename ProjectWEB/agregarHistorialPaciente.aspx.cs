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
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ClienteNegocio cliNego = new ClienteNegocio();
            Cliente cli = new Cliente();
            cli=cliNego.buscar_por_id(id);
            LabelPaciente.Text += cli.nombre.ToString() + " " + cli.apellido.ToString();
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            historia = new Historial();
            historia.cliente = new Cliente();
            historia.cliente.id =Convert.ToInt32(Request.QueryString["id"]);

            historia.personal = new Personal();
            historia.personal.id = Convert.ToInt32(Session["ID_Usuario"]);
            historia.observacion = TextBoxObservacion.Text;

            HistorialNegocio hisNego = new HistorialNegocio();
            hisNego.agregar(historia);
            string confirmacion = "agregado";

            Response.Redirect("inicio.aspx?accion=" + confirmacion);
        }
    }
}