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
    public partial class SiteMaster : MasterPage
    {
        public Empleado empleado;
        public List<Permiso> permisosList;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["logged"] == null)
            {
                Response.Redirect("login.aspx");
            }
            empleado = new Empleado();
            empleado = (Empleado)Session["empleado"];
            LabelNombre.Text = empleado.nombre + " " + empleado.apellido;
            if (!IsPostBack) {
                validarMenu();
            }
        }

        protected void ButtonCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("login.aspx");
        }

        public void validarMenu()
        {
            permisosList=new List<Permiso>();
            permisosList = (List<Permiso>)Session["permisos"];

            foreach (var permiso in permisosList)
            {
                if (permiso.nombre == "Ver pacientes") verPacientes.Attributes["class"] = "d-block mt-3";
                if (permiso.nombre == "Agregar pacientes") agregarPacientes.Attributes["class"] = "d-block mt-3";
                if (permiso.nombre == "Ver turnos") verTurnos.Attributes["class"] = "d-block mt-3";
                if (permiso.nombre == "Agregar turnos") agregarTurnos.Attributes["class"] = "d-block mt-3";

                if (permiso.nombre == "Ver turnos para doctor") verTurnosDoctor.Attributes["class"] = "d-block mt-3";
                if (permiso.nombre == "Ver pacientes para doctor") verPacientesDoctor.Attributes["class"] = "d-block mt-3";

                if (permiso.nombre == "Agregar doctores") agregarDoctores.Attributes["class"] = "d-block mt-3";
                if (permiso.nombre == "Ver doctores") verDoctores.Attributes["class"] = "d-block mt-3";
                if (permiso.nombre == "Agregar especialidades") agregarEspecialidad.Attributes["class"] = "d-block mt-3";
            }

        }
    }
}