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
        public List<Especialidad> especialidadList;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            bool validar = validar_especialidad_existente();
            if (validar == true) {
                especialidad = new Especialidad();
                especialidad.nombre = TextBoxEspecialidad.Text;
                EspecialidadNegocio espNego = new EspecialidadNegocio();
                espNego.agregar(especialidad);
                string confirmacion = "agregado";
                Response.Redirect("inicio.aspx?accion=" + confirmacion);
            }
        }
        public bool validar_especialidad_existente()
        {
            LabelError.Text = "";
            bool validar = true;
            EspecialidadNegocio espNego = new EspecialidadNegocio();
            especialidadList = espNego.listar();
            foreach (var especialidad in especialidadList)
            {
                if(especialidad.nombre.ToUpper() == TextBoxEspecialidad.Text.ToUpper())
                {
                    LabelError.Text = "*La especialidad ingresada ya existe";
                    validar = false;
                }
            }
            return validar;
        }
    }
}