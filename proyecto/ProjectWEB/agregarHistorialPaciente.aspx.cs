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
    public partial class agregarHistorialPaciente : System.Web.UI.Page
    {
        public Historial historia;
        public Turno turno;
        public List<Permiso> permisosList;
        protected void Page_Load(object sender, EventArgs e)
        {
            validar_permiso();
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                TurnoNegocio turNego = new TurnoNegocio();
                turno=turNego.buscar_por_id(id);
                LabelPaciente.Text += turno.paciente.nombre.ToString() + " " + turno.paciente.apellido.ToString();
            }
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            historia = new Historial();

            historia.id =Convert.ToInt32(Request.QueryString["id"]);
            historia.observacion = TextBoxObservacion.Text;
            historia.fecha = DateTime.Now;

            HistorialNegocio hisNego = new HistorialNegocio();
            hisNego.agregar(historia);
            string confirmacion = "agregado";

            Response.Redirect("inicio.aspx?accion=" + confirmacion);
        }
        public void validar_permiso()
        {
            permisosList = new List<Permiso>();
            permisosList = (List<Permiso>)Session["permisos"];
            ValidarPermiso valPer = new ValidarPermiso();
            if (permisosList == null || valPer.validar_permiso(permisosList, "Agregar historiales") == false)
            {
                Response.Redirect("inicio.aspx");
            }
        }
    }
}