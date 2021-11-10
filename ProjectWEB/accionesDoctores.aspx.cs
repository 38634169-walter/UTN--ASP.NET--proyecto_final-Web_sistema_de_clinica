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
    public partial class agregarPersonal : System.Web.UI.Page
    {
        public List<Especialidad> especialidadList;
        public Doctor doctor;
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadNegocio espNego = new EspecialidadNegocio();
            especialidadList = espNego.listar();
            if(!IsPostBack) {
                DropEspecilidad.DataSource = especialidadList;
                DropEspecilidad.DataValueField = "id";
                DropEspecilidad.DataTextField = "nombre";
                DropEspecilidad.DataBind();
            }

            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                DoctorNegocio docNego = new DoctorNegocio();
                doctor = new Doctor();
                doctor=docNego.buscar_por_id(id);
                if (!IsPostBack)
                {
                    TextBoxNombre.Text = doctor.nombre;
                    TextBoxApellido.Text = doctor.apellido;
                    TextBoxEmail.Text = doctor.email;
                    TextBoxTelefono.Text = doctor.telefono;
                    TextBoxSueldo.Text = doctor.sueldo.ToString();
                    TextBoxDni.Text = doctor.dni;
                    DropEspecilidad.Style.Add("display", "none");
                    TextBoxHorarioEntrada.Style.Add("display", "none");
                    TextBoxHorarioSalida.Style.Add("display", "none");
                    LabelHorarioEntrada.Style.Add("display", "none");
                    LabelHorarioSalida.Style.Add("display", "none");
                    LabelEspecialidad.Style.Add("display", "none");
                    TextBoxUsuario.Text = doctor.usuario.usuario;
                    TextBoxClave.Text = doctor.usuario.clave;
                    ButtonAgregarModificar.Text = "Modificar";
                    LabelTitulo.Text = "Modificar medico";
                }
            }
        }

        protected void ButtonAgregarModificar_Click(object sender, EventArgs e)
        {         
            if (doctor == null) doctor = new Doctor();

            doctor.nombre = TextBoxNombre.Text;
            doctor.apellido = TextBoxApellido.Text;
            doctor.dni = TextBoxDni.Text;
            doctor.sueldo =Convert.ToDouble(TextBoxSueldo.Text);
            doctor.telefono = TextBoxTelefono.Text;
            doctor.email = TextBoxEmail.Text;

            DoctorNegocio docNego = new DoctorNegocio();
            string confirmacion;
            if (doctor.id != 0)
            {
                doctor.usuario.usuario = TextBoxUsuario.Text;
                doctor.usuario.clave = TextBoxClave.Text;
                docNego.modificar(doctor);
                confirmacion = "modificado";
            }
            else
            {
                doctor.especialidad= new Especialidad();
                doctor.especialidad.id = Convert.ToInt32(DropEspecilidad.SelectedValue);
                doctor.usuario = new Usuario();
                doctor.usuario.usuario = TextBoxUsuario.Text;
                doctor.usuario.clave = TextBoxClave.Text;
                doctor.horario = new Horario();
                doctor.horario.horaInicio= Convert.ToInt32(TextBoxHorarioEntrada.Text);
                doctor.horario.horaFin = Convert.ToInt32(TextBoxHorarioSalida.Text);

                docNego.agregar(doctor);
                confirmacion = "agregado";
            }
            Response.Redirect("inicio.aspx?accion=" + confirmacion);
        }
    }
}