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
    public partial class verInfoTurno : System.Web.UI.Page
    {
        public Turno turno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                TurnoNegocio turNego = new TurnoNegocio();
                turno = new Turno();
                turno=turNego.buscar_por_id(id);
            }
        }
    }
}