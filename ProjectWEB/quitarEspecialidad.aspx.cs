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
    public partial class quitarEspecialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idEsp"] != null && Request.QueryString["idDoc"] != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ranbomtext", "quitar_especialidad()", true);
                
                int esp = Convert.ToInt32(Request.QueryString["idEsp"]);
                int doc = Convert.ToInt32(Request.QueryString["idDoc"]);
                DoctorNegocio docNego = new DoctorNegocio();
                docNego.quitar_especialidad_doctor(esp,doc);
                string accion = "eliminado";
                Response.Redirect("inicio.aspx?accion=" + accion);

            }
        }
    }
}