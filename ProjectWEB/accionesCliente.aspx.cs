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
        public Cliente cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                cliente = new Cliente();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                ClienteNegocio cliNego = new ClienteNegocio();
                cliente = cliNego.buscar_por_id(id);
                LabelTitulo.Text = "Editar Paciente";

                if (!IsPostBack)
                {
                        TextBoxApellido.Text = cliente.apellido;
                        TextBoxNombre.Text = cliente.nombre;
                }
            }
        }

        protected void ButtonAgregarModificar_Click(object sender, EventArgs e)
        {
            string confirmacion = "";
            ClienteNegocio cliNego = new ClienteNegocio();

            if(cliente == null)
            {
                cliente = new Cliente();
            }
            cliente.nombre = TextBoxNombre.Text;
            cliente.apellido = TextBoxApellido.Text;
            if (cliente.id != 0)
            {
                cliNego.modificar(cliente);
                confirmacion = "modificado";
            }
            else
            {
                cliNego.agregar(cliente);
                confirmacion = "agregado";
            }
            Response.Redirect("inicio.aspx?accion=" + confirmacion);
        }
    }
}