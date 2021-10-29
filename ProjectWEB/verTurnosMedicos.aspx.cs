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
    public partial class verTurnosMedicos : System.Web.UI.Page
    {
        public List<Turno> turnosList;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["ID_Usuario"]);
            TurnoNegocio turNego = new TurnoNegocio();
            turnosList=turNego.turnos_de_medicos(id);
        }
    }
}