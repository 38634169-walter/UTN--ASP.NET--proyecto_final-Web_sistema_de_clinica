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
    public partial class verTurnos1 : System.Web.UI.Page
    {
        public Turno turno;
        public List<Turno> turnosList;
        protected void Page_Load(object sender, EventArgs e)
        {
            TurnoNegocio turNego = new TurnoNegocio();
            turnosList = turNego.listar("lista", "",1);
        }

        protected void alert_eliminar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ranbomtext", "eliminar()", true);
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            string dni = TextBoxDni.Text;
            TurnoNegocio turNego = new TurnoNegocio();
            turnosList = new List<Turno>();
            turnosList = turNego.listar("dni", dni,2);
        }
       
    }
}