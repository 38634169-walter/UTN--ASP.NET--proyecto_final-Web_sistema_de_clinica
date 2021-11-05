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
    public partial class agregarEspecialidad : System.Web.UI.Page
    {
        public Especialidad especialidad;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            especialidad = new Especialidad();
            especialidad.nombre = TextBoxEspecialidad.Text;
            EspecialidadNegocio espNego = new EspecialidadNegocio();
            espNego.agregar(especialidad);
            string confirmacion = "agregado";
            Response.Redirect("inicio.aspx?accion=" + confirmacion);
        }
    }
}