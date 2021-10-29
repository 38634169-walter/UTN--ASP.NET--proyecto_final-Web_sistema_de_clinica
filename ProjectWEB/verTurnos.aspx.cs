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
        public List<Turno> turnosList;
        protected void Page_Load(object sender, EventArgs e)
        {
            TurnoNegocio turNego = new TurnoNegocio();
            turnosList = turNego.listar();
        }

        protected void alert_eliminar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(),"ranbomtext","eliminar()",true);
        }
    }
}