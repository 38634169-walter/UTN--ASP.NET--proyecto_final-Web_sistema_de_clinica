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
        public List<Historial> historialesList;
        public string paciente;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            HistorialNegocio hisNego = new HistorialNegocio();
            historialesList = hisNego.buscar_historial_paciente(id);
            paciente = historialesList[0].cliente.nombre.ToString() + " " + historialesList[0].cliente.apellido.ToString();
        }
    }
}