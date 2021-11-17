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
        public static string pacienteDniEditar;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                LabelTitulo.Text = "Editar Paciente";
                ButtonAgregarModificar.Text = "Confirmar";

                paciente = new Paciente();
                string id = (string)Request.QueryString["id"];
                PacienteNegocio pacNego = new PacienteNegocio();
                paciente = pacNego.buscar("id",id);

                if (!IsPostBack)
                {
                    pacienteDniEditar = paciente.dni;

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
           bool validar = validar_paciente_existente();
            if (validar == true)
            {
                if (paciente == null) paciente = new Paciente();

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
        public bool validar_paciente_existente()
        {
            PacienteNegocio pacNego = new PacienteNegocio();
            paciente = pacNego.buscar("dni", TextBoxDni.Text);
            if (paciente != null)
            {
                if(pacienteDniEditar != null && pacienteDniEditar == TextBoxDni.Text)
                {
                    return true;
                }
                LabelError.Text = "*El paciente ya se encuentra registrado";
                return false;
            }
            return true;
        }
    }
}