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
        public Empleado empleado;
        public List<Permiso> permisosList;
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
            empleado = new Empleado();
            empleado = usuNego.validarUsu(usuario, clave, ref validar);
            if (validarInyeccion() != false)
            {
                if (validar == true)
                {
                    PermisoNegocio perNego = new PermisoNegocio();
                    permisosList = new List<Permiso>();
                    string id = empleado.usuario.id.ToString();
                    permisosList = perNego.listar("idUsuario", id);
                    Session.Add("empleado", empleado);
                    Session.Add("permisos", permisosList);
                    Session.Add("logged", true);
                    Response.Redirect("inicio.aspx", false);
                }
                else
                {
                    LabelIncorrecto.Text = "*Usuario o clave incorrectos";
                }
            }
        }
        public bool validarInyeccion()
        {
            string clave = TextBoxClave.Text;
            for (int i=0;i<clave.Length;i++)
            {
                if (clave[i] == '?' || clave[i] == ':' || clave[i] == '=' || clave[i] == '\'' || clave[i] == ')' || clave[i] == '(' )
                {
                    LabelIncorrecto.Text = "*No se puede utilizar los siguientes simbolos para la contraseña  ? , : , \' , = , ) , ( ";
                    return false;
                }
            }
            return true;
        }
    }
}