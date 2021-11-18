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
    public partial class verPacientesMedicos : System.Web.UI.Page
    {
        public static List<Paciente> pacientesList;
        public Paciente paciente;
        public List<Permiso> permisosList;
        protected void Page_Load(object sender, EventArgs e)
        {
            validar_permiso();
            PacienteNegocio pasNego = new PacienteNegocio();
            pacientesList = pasNego.listar();
        }

        protected void ButtonBuscarPaciente_Click(object sender, EventArgs e)
        {
            string dni = TextBoxDni.Text;
            PacienteNegocio pacNego = new PacienteNegocio();
            paciente = pacNego.buscar("dni",dni);
            pacientesList = new List<Paciente>();
            if (! String.IsNullOrEmpty(paciente.nombre))
            {
                pacientesList.Add(paciente);
            }
        }
        public void validar_permiso()
        {
            permisosList = new List<Permiso>();
            permisosList = (List<Permiso>)Session["permisos"];
            ValidarPermiso valPer = new ValidarPermiso();
            if (permisosList == null || valPer.validar_permiso(permisosList, "Ver historiales") == false)
            {
                Response.Redirect("inicio.aspx");
            }
        }

    }
}