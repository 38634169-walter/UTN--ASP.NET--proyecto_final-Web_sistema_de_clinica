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
    public partial class SiteMaster : MasterPage
    {
        public string cargo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logged"] == null)
            {
                Response.Redirect("login.aspx");
            }
            string nombre = Session["nombreUsuario"].ToString();
            string apellido = Session["apellidoUsuario"].ToString();
            LabelNombre.Text = nombre + " " + apellido;

            string car = Session["cargoUsuario"].ToString();
            cargo = car;
        }

        protected void ButtonCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("login.aspx");
        }
    }
}