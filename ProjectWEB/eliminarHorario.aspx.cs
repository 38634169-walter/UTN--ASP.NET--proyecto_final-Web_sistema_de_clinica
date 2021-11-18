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
    public partial class eliminarHorario : System.Web.UI.Page
    {
        public List<Permiso> permisosList;
        protected void Page_Load(object sender, EventArgs e)
        {
            validar_permiso();
            if (Request.QueryString["id"] != null)
            {
                int id =Convert.ToInt32(Request.QueryString["id"]);
                HorarioNegocio horNego = new HorarioNegocio();
                horNego.eliminar(id);
                string accion = "eliminado";
                Response.Redirect("inicio.aspx?accion=" + accion);
            }
        }
        public void validar_permiso()
        {
            permisosList = new List<Permiso>();
            permisosList = (List<Permiso>)Session["permisos"];
            ValidarPermiso valPer = new ValidarPermiso();
            if (permisosList == null || valPer.validar_permiso(permisosList, "Eliminar horarios doctores") == false)
            {
                Response.Redirect("inicio.aspx");
            }
        }
    }
}