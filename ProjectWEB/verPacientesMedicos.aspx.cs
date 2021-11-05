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
    }
}