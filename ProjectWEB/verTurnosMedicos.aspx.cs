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
        public List<Permiso> permisosList;
        public static Empleado empleado;
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            validar_permisos();
            
            empleado = new Empleado();
            empleado = (Empleado)Session["empleado"];
            TurnoNegocio turNego = new TurnoNegocio();
            turnosList=turNego.turnos_de_medicos(empleado.idEmpleado,"todo","");
        }

        protected void ButtonBuscarTurno_Click(object sender, EventArgs e)
        {
            if (TextBoxFecha.Text != "")
            {
                TurnoNegocio turNego = new TurnoNegocio();
                string fecha = TextBoxFecha.Text;
                turnosList=turNego.turnos_de_medicos(empleado.idEmpleado,"fecha",fecha);
            }
        }
        public void validar_permisos()
        {
            permisosList = new List<Permiso>();
            permisosList = (List<Permiso>)Session["permisos"];
            bool val = false;
            if (permisosList != null)
            {
                foreach (var permiso in permisosList)
                {
                    if (permiso.nombre == "Ver historiales") ScriptManager.RegisterStartupScript(this, typeof(Page), "editar", "validar_permiso('verHistoriales');", true);
                    if (permiso.nombre == "Agregar historiales") ScriptManager.RegisterStartupScript(this, typeof(Page), "eliminar", "validar_permiso('agregarHistoriales');", true);

                    if (permiso.nombre == "Ver turnos para doctor") val = true;
                }
            }
            
            if (val == false)
            {
                Response.Redirect("inicio.aspx");
            }
            
        }
    }
}