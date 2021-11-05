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
    public partial class agregarPaciente : System.Web.UI.Page
    {
        public Paciente paciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                LabelTitulo.Text = "Editar Paciente";
                ButtonAgregarModificar.Text = "Confirmar";

                paciente = new Paciente();
                string id = (string)Request.QueryString["id"];
                PacienteNegocio pacNego = new PacienteNegocio();
                List<Paciente> pacientesList = new List<Paciente>();
                pacientesList = pacNego.buscar("id",id);
                paciente = pacientesList[0];

                if (!IsPostBack)
                {
                    TextBoxApellido.Text = paciente.apellido;
                    TextBoxNombre.Text = paciente.nombre;
                    TextBoxDni.Text = paciente.dni;
                    TextBoxTelefono.Text = paciente.telefono;
                    TextBoxEmail.Text = paciente.email;
                }
            }
            
            if (Request.QueryString["noRegistrado"] != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ranbomtext", "no_registrado()", true);
            }
        }

        protected void ButtonAgregarModificar_Click(object sender, EventArgs e)
        {
            if(paciente == null)
            {
                paciente = new Paciente();
            }
            paciente.nombre = TextBoxNombre.Text;
            paciente.apellido = TextBoxApellido.Text;
            paciente.dni = TextBoxDni.Text;
            paciente.telefono = TextBoxTelefono.Text;
            paciente.email = TextBoxEmail.Text;
         
            
            string confirmacion = "";
            PacienteNegocio cliNego = new PacienteNegocio();
            if (paciente.id != 0)
            {
                cliNego.modificar(paciente);
                confirmacion = "modificado";
            }
            else
            {
                cliNego.agregar(paciente);
                confirmacion = "agregado";
            }
            Response.Redirect("inicio.aspx?accion=" + confirmacion);
        }
    }
}