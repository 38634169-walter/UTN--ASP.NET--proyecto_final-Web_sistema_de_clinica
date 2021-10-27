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
        public List<Cliente> clientesList;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio cliNego = new ClienteNegocio();
            clientesList = cliNego.listar();
        }
    }
}