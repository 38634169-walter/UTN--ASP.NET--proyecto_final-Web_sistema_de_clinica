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
        public static List<Paciente> pacientesList;
        public Paciente paciente;
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}