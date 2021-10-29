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
    public partial class verTurnos : System.Web.UI.Page
    {
        public Turno turno;
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadNegocio espNego = new EspecialidadNegocio();
            DropEspecialidad.DataSource = espNego.listar();
            DropEspecialidad.DataValueField = "id";
            DropEspecialidad.DataTextField = "nombre";
            DropEspecialidad.DataBind();

            if (Request.QueryString["id"] != null)
            {
                LabelTitulo.Text = "Editar Turno";
                ButtonReservar.Text = "Confirmar";
                turno = new Turno();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                TurnoNegocio turNego = new TurnoNegocio();
                turno = turNego.buscar_por_id(id);
                if (!IsPostBack)
                {
                    TextBoxDni.Text = turno.cliente.dni;
                    DropEspecialidad.SelectedIndex= turno.especialidad.id;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}