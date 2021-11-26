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
    public partial class verPersonal : System.Web.UI.Page
    {
        public List<Doctor> doctoresList;
        public List<Permiso> permisosList;
        protected void Page_Load(object sender, EventArgs e)
        {
            validarAcciones();
            DoctorNegocio docNego = new DoctorNegocio();
            doctoresList = docNego.listar("todo",1);
        }
        public void validarAcciones()
        {
            permisosList = new List<Permiso>();
            permisosList = (List<Permiso>)Session["permisos"];
            bool val = false;
            if (permisosList != null)
            {
                foreach (var permiso in permisosList)
                {
                    if (permiso.nombre == "Ver horarios doctores") ScriptManager.RegisterStartupScript(this, typeof(Page), "editarHorarios", "validar_permiso('verHorariosDoctores');", true);
                    if (permiso.nombre == "Ver especialidades doctores") ScriptManager.RegisterStartupScript(this, typeof(Page), "eliminar", "validar_permiso('verEspecialidadesDoctores');", true);
                    if (permiso.nombre == "Editar doctores") ScriptManager.RegisterStartupScript(this, typeof(Page), "editar", "validar_permiso('editarDoctores');", true);
                    
                    if (permiso.nombre == "Ver doctores") val = true;
                }
            }
            if (val == false)
            {
                Response.Redirect("inicio.aspx");
            }
        }
    }
}