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
    public partial class verClientes : System.Web.UI.Page
    {
        public List<Paciente> pacientesList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                PacienteNegocio pacNego = new PacienteNegocio();
                string id = (string)Request.QueryString["id"];
                pacientesList = new List<Paciente>();
                pacientesList=pacNego.buscar("id", id);
            }
            else
            {
                PacienteNegocio pacNego = new PacienteNegocio();
                pacientesList = pacNego.listar();
            }
        }

        protected void ButtonBuscarCliente_Click(object sender, EventArgs e)
        {
            string dni = TextBoxDni.Text;
            PacienteNegocio pacNego = new PacienteNegocio();
            pacientesList = new List<Paciente>();
            pacientesList = pacNego.buscar("dni",dni);
            string id = "";
            if (pacientesList.Any()) {
                id = pacientesList[0].id.ToString(); ;
            }
            Response.Redirect("verPacientes.aspx?id=" + id);
        }
    }
}