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
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            // NO BORRRAR // int id = Convert.ToInt32(Session["ID_Usuario"]);
            id = 1;
            TurnoNegocio turNego = new TurnoNegocio();
            turnosList=turNego.turnos_de_medicos(id,"todo","");
        }

        protected void ButtonBuscarTurno_Click(object sender, EventArgs e)
        {
            if (TextBoxFecha.Text != "")
            {
                // NO BORRRAR // int id = Convert.ToInt32(Session["ID_Usuario"]);
                TurnoNegocio turNego = new TurnoNegocio();
                string fecha = TextBoxFecha.Text;
                turnosList=turNego.turnos_de_medicos(id,"fecha",fecha);
            }
        }
    }
}