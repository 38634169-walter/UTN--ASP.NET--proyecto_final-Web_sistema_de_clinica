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
    public partial class verInfoCliente : System.Web.UI.Page
    {
        public Paciente paciente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                string id = (string)Request.QueryString["id"];
                PacienteNegocio pacNego = new PacienteNegocio();
                List<Paciente> pacientesList = new List<Paciente>();
                paciente = new Paciente();
                pacientesList = pacNego.buscar("id",id);
                paciente=pacientesList[0];
            }
        }
    }
}