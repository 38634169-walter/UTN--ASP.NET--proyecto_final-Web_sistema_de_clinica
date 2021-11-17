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
    public partial class verHistoriaPaciente : System.Web.UI.Page
    {
        public Historial historia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                HistorialNegocio hisNego = new HistorialNegocio();
                historia = new Historial();
                historia = hisNego.buscar_historia_paciente(id);
                LabelTitulo.Text += historia.paciente.nombre + " " + historia.paciente.apellido;
            }
        }
    }
}