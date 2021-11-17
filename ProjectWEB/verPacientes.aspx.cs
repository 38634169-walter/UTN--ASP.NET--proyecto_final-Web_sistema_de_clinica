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
        public static List<Paciente> pacientesList;
        public Paciente paciente=null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PacienteNegocio pacNego = new PacienteNegocio();
                pacientesList = pacNego.listar();
            }
        }

        protected void ButtonBuscarCliente_Click(object sender, EventArgs e)
        {
            string dni = TextBoxDni.Text;
            PacienteNegocio pacNego = new PacienteNegocio();
            paciente = pacNego.buscar("dni",dni);
            pacientesList = new List<Paciente>();
            if(! String.IsNullOrEmpty(paciente.nombre)) {
                pacientesList.Add(paciente);
            }
        }
    }
}