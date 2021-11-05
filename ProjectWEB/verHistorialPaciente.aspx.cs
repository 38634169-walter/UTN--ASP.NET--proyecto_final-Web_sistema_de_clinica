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
    public partial class historialPaciente : System.Web.UI.Page
    {
        public List<Historial> historialesList = null;
        public string paciente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( Request.QueryString["id"] != null) {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                HistorialNegocio hisNego = new HistorialNegocio();
                historialesList=hisNego.buscar_historial_paciente(id);
                if (!historialesList.Any())
                {
                    paciente = "";
                }
                else
                {
                    paciente = "Paciente " + historialesList[0].paciente.nombre.ToString() + " " + historialesList[0].paciente.apellido.ToString();
                }
            }
        }
    }
}