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
        public List<Permiso> permisosList;
        protected void Page_Load(object sender, EventArgs e)
        {
            validarAcciones();
            TurnoNegocio turNego = new TurnoNegocio();
            turnosList = turNego.listar("lista", "","");
        }

        protected void alert_eliminar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ranbomtext", "eliminarTurno()", true);
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            string dni = TextBoxDni.Text;
            string fecha = TextBoxFecha.Text;
            TurnoNegocio turNego = new TurnoNegocio();
            turnosList = new List<Turno>();
            if(TextBoxDni.Text != "" && TextBoxFecha.Text !="") {
                turnosList = turNego.listar("fecha y dni", fecha, dni);
            }
            else
            {
                if (TextBoxDni.Text != "")
                {
                    turnosList = turNego.listar("dni", dni,"");
                }
                if (TextBoxFecha.Text != "")
                {
                    turnosList = turNego.listar("fecha", fecha ,"");
                }
            }
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
                    if (permiso.nombre == "Editar turnos") ScriptManager.RegisterStartupScript(this, typeof(Page), "editar", "validar_permiso('editarTurno');", true);
                    if (permiso.nombre == "Eliminar turnos") ScriptManager.RegisterStartupScript(this, typeof(Page), "eliminar", "validar_permiso('eliminarTurno');", true);
                    
                    if (permiso.nombre == "Ver turnos") val = true;
                }
            }
            if (val == false)
            {
                Response.Redirect("inicio.aspx");
            }
        }

    }
}