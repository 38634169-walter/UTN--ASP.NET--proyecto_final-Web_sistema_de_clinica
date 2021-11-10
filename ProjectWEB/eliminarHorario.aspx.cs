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
    public partial class eliminarHorario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id =Convert.ToInt32(Request.QueryString["id"]);
                HorarioNegocio horNego = new HorarioNegocio();
                horNego.eliminar(id);
                string accion = "eliminado";
                Response.Redirect("inicio.aspx?accion=" + accion);
            }
        }
    }
}