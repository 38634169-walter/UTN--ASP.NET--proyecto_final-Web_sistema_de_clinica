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
    public partial class agregarEspecialidadPersonal : System.Web.UI.Page
    {
        public List<Especialidad> especialidadList;
        public Doctor doctor;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != null) {
                int id =Convert.ToInt32(Request.QueryString["id"]);
                doctor = new Doctor();
                DoctorNegocio docNego = new DoctorNegocio();
                doctor=docNego.buscar_por_id(id);
                LabelTitulo.Text += doctor.nombre + " " + doctor.apellido;

                EspecialidadNegocio espNego = new EspecialidadNegocio();
                especialidadList = espNego.listar();
                if (!IsPostBack)
                {
                    DropEspecialidad.DataSource = especialidadList;
                    DropEspecialidad.DataValueField = "id";
                    DropEspecialidad.DataTextField = "nombre";
                    DropEspecialidad.DataBind();
                }
            }
        }

        protected void ButtonAsignar_Click(object sender, EventArgs e)
        {
            EspecialidadNegocio espNego = new EspecialidadNegocio();

            doctor.especialidad = new Especialidad();
            doctor.especialidad.id =Convert.ToInt32(DropEspecialidad.SelectedValue);
            espNego.agregar_especialidad_doctor(doctor);
            string confirmacion = "agregado";
            Response.Redirect("inicio.aspx?accion=" + confirmacion);
        }
    }
}