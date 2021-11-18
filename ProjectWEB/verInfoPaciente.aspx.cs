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
    public partial class verInfoCliente : System.Web.UI.Page
    {
        public Paciente paciente;
        public List<Permiso> permisosList;
        protected void Page_Load(object sender, EventArgs e)
        {

            validar_permiso();
            if (Request.QueryString["id"] != null)
            {
                string id = (string)Request.QueryString["id"];
                PacienteNegocio pacNego = new PacienteNegocio();
                paciente = new Paciente();
                paciente = pacNego.buscar("id",id);
            }
        }
        public void validar_permiso()
        {
            permisosList = new List<Permiso>();
            permisosList = (List<Permiso>)Session["permisos"];
            ValidarPermiso valPer = new ValidarPermiso();
            if(permisosList == null || valPer.validar_permiso(permisosList,"Ver pacientes") == false){
                Response.Redirect("inicio.aspx");
            }
        }
    }
}