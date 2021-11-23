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
        public List<Doctor> doctoresList;
        public List<Permiso> permisosList;
        public Doctor doctor;
        protected void Page_Load(object sender, EventArgs e)
        {
            validarAcciones();
            if (Request.QueryString["id"] != null) {
                int id =Convert.ToInt32(Request.QueryString["id"]);
                cargar_grid();
                EspecialidadNegocio espNego = new EspecialidadNegocio();
                especialidadList = espNego.especialidades_doctor_no_tiene(id);
                if (!IsPostBack)
                {
                    DropEspecialidad.DataSource = especialidadList;
                    DropEspecialidad.DataValueField = "id";
                    DropEspecialidad.DataTextField = "nombre";
                    DropEspecialidad.DataBind();
                    if(doctoresList.Any()) {
                        LabelTituloVer.Text += " de " + doctoresList[0].nombre + " " + doctoresList[0].apellido;
                        LabelTituloAgregar.Text += " a " + doctoresList[0].nombre + " " + doctoresList[0].apellido;
                    }
                }
            }
        }

        protected void ButtonAsignar_Click(object sender, EventArgs e)
        {
            EspecialidadNegocio espNego = new EspecialidadNegocio();
            doctor = new Doctor();
            doctor.id =Convert.ToInt32(Request.QueryString["id"]);
            doctor.especialidad = new Especialidad();
            doctor.especialidad.id =Convert.ToInt32(DropEspecialidad.SelectedValue);
            espNego.agregar_especialidad_doctor(doctor);
            string confirmacion = "agregado";
            Response.Redirect("inicio.aspx?accion=" + confirmacion);
            
        }

        public void validarAcciones()
        {
            permisosList = new List<Permiso>();
            permisosList = (List<Permiso>)Session["permisos"];
            bool val = false;
            if (permisosList != null)
            {
                foreach (var permiso in permisosList)
                {
                    if (permiso.nombre == "Asignar especilidades doctores") ScriptManager.RegisterStartupScript(this, typeof(Page), "asignar", "validar_permiso('asignarEspecilidadesDoctores');", true);
                    if (permiso.nombre == "Quitar especialidades doctores") ScriptManager.RegisterStartupScript(this, typeof(Page), "quitar", "validar_permiso('quitarEspecialidadesDoctores');", true);

                    if (permiso.nombre == "Ver especialidades doctores") val = true;
                }
            }
            if (val == false)
            {
                Response.Redirect("inicio.aspx");
            }
        }

        protected void ButtonQuitarEspecialidad_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ranbomtext", "quitar_especialidad()", true);
        }

        protected void GridViewEspecialidad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(';');
            int esp =Convert.ToInt32(arg[0]);
            int doc = Convert.ToInt32(arg[1]);
            DoctorNegocio docNego = new DoctorNegocio();
            docNego.quitar_especialidad_doctor(esp, doc);
            cargar_grid();
        }

        protected void GridViewEspecialidad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEspecialidad.PageIndex = e.NewPageIndex;

        }

        public void cargar_grid()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            EspecialidadNegocio espNego = new EspecialidadNegocio();
            doctoresList = espNego.listar_especialidad_doctor(id);
            GridViewEspecialidad.DataSource = doctoresList;
            GridViewEspecialidad.DataBind();
        }
    }
}