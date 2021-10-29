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
    public partial class log : System.Web.UI.Page
    {
        public Personal personal = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logged"] != null)
            {
                Response.Redirect("inicio.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string usuario = TextBoxUsuario.Text;
            string clave = TextBoxClave.Text;

            UsuarioNegocio usuNego = new UsuarioNegocio();
            bool validar = false;
            personal = usuNego.validarUsu(usuario, clave, ref validar);
            if (validar == true)
            {
                Session.Add("nombreUsuario", personal.nombre);
                Session.Add("apellidoUsuario", personal.apellido);
                Session.Add("ID_Usuario", personal.usuario.id);
                Session.Add("cargoUsuario", personal.especialidad.cargo.nombre);
                Session.Add("logged", true);
                Response.Redirect("inicio.aspx", false);
            }
            else
            {
                LabelIncorrecto.Text = "*Usuario o clave incorrectos";
            }
        }
    }
}