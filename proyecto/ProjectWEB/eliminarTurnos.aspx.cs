using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using modelo;
using negocio;
using validarPermiso;

namespace ProjectWEB
{
    public partial class eliminarTurnos : System.Web.UI.Page
    {
        public List<Permiso> permisosList;
        protected void Page_Load(object sender, EventArgs e)
        {
            validar_permiso();
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                TurnoNegocio turNego = new TurnoNegocio();
                turNego.eliminar(id);
                string confirmacion = "eliminado";
                Response.Redirect("inicio.aspx?accion=" + confirmacion);   
            }
        }
        public void validar_permiso()
        {
            permisosList = new List<Permiso>();
            permisosList = (List<Permiso>)Session["permisos"];
            ValidarPermiso valPer = new ValidarPermiso();
            if (permisosList == null || valPer.validar_permiso(permisosList, "Eliminar turnos") == false)
            {
                Response.Redirect("inicio.aspx");
            }
        }
    }
}