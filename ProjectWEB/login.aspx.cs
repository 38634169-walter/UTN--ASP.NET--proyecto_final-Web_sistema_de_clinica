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
        public Personal persona = null;
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
            persona = usuNego.validarUsu(usuario, clave, ref validar);
            if (validar == true)
            {
                Session.Add("nombreUsuario", persona.nombre);
                Session.Add("apellidoUsuario", persona.apellido);
                Session.Add("ID_Usuario", persona.usuario.id);
                Session.Add("especialidadUsuario", persona.especialidad.nombre);
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