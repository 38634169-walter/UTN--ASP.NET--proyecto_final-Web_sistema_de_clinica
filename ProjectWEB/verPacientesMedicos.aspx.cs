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
    public partial class verPacientesMedicos : System.Web.UI.Page
    {
        public List<Paciente> pacientesList;
        protected void Page_Load(object sender, EventArgs e)
        {
            PacienteNegocio pasNego = new PacienteNegocio();
            pacientesList = pasNego.listar();
        }

        protected void ButtonBuscarPaciente_Click(object sender, EventArgs e)
        {
            if (TextBoxDni.Text != "")
            {
                string dni = TextBoxDni.Text;
                PacienteNegocio pacNego = new PacienteNegocio();
                pacientesList = pacNego.buscar("dni",dni);
            }
        }
    }
}