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
        public List<Doctor> doctoreslList;
        public List<Turno> turnosList;
        public List<Paciente> pacientesList;
        public string noRegistrado ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                EspecialidadNegocio espNego = new EspecialidadNegocio();
                DropEspecialidad.DataSource = espNego.listar();
                DropEspecialidad.DataValueField = "id";
                DropEspecialidad.DataTextField = "nombre";
                DropEspecialidad.DataBind();
                DropEspecialidad.Items.Insert(0,new ListItem("[Seleccionar]","0"));
            }

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
                    TextBoxDni.Text = turno.doctor.dni;
                    DropEspecialidad.SelectedIndex= turno.especialidad.id;
                }
            }
            else
            {
                if (!IsPostBack) {
                    DropEspecialidad.Visible = false;
                    LabelEspecilidad.Visible = false;
                    TextBoxfecha.Visible = false;
                    LabelFecha.Visible = false;
                    DropHora.Visible = false;
                    LabelHora.Visible = false;
                    DropPersonalDisponible.Visible = false;
                    LabelPersonal.Visible = false;
                }
            }
        }
        protected void TextBoxDni_TextChanged(object sender, EventArgs e)
        {
            if (validar_dni()) {
                DropEspecialidad.Visible = true;
                LabelEspecilidad.Visible = true;
            }
        }
        protected void DropEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DropEspecialidad.SelectedValue);

            DoctorNegocio docNego = new DoctorNegocio();
            doctoreslList = new List<Doctor>();
            doctoreslList = docNego.listar("especialidad", id);
            
            DropPersonalDisponible.DataSource = doctoreslList;
            DropPersonalDisponible.DataValueField = "id";
            DropPersonalDisponible.DataTextField = "nombreCompleto";
            DropPersonalDisponible.DataBind();
            DropPersonalDisponible.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            
            DropPersonalDisponible.Visible = true;
            LabelPersonal.Visible = true;
        }

        protected void DropPersonalDisponible_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxfecha.Visible = true;
            LabelFecha.Visible = true;
        }
        protected void TextBoxfecha_TextChanged(object sender, EventArgs e)
        {
            int idEspecialidad = Convert.ToInt32(DropEspecialidad.SelectedValue);
            int idDoctor = Convert.ToInt32(DropPersonalDisponible.SelectedValue);
            string fecha = TextBoxfecha.Text;


            //TurnoNegocio turNego = new TurnoNegocio();
            //turnosList=turNego.buscar_horarios(idEspecialidad,idDoctor, fecha);
            int[] n = new int[3];
            n[0] = 1;
            n[1] = 2;
            n[2] = 4;


            DropHora.Visible = true;
            LabelHora.Visible = true;
            DropHora.DataSource = n;
            //DropHora.DataValueField = "id";
            //DropHora.DataTextField = "hora";
            DropHora.DataBind();
            DropHora.Items.Insert(0, new ListItem("Seleccionar", "0"));
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        public bool validar_dni()
        {
            if (TextBoxDni.Text == "")
            {
                LabelValidar.Text = "*Ingresar DNI del paciente";
                
                DropPersonalDisponible.Visible = false;
                LabelPersonal.Visible = false;
                TextBoxfecha.Visible = false;
                LabelFecha.Visible = false;
                DropHora.Visible = false;
                LabelHora.Visible = false;

                return false;
            }
            else
            {
                PacienteNegocio pacNego = new PacienteNegocio();
                pacientesList = pacNego.buscar("dni", TextBoxDni.Text);
                if (pacientesList.Any())
                {
                    LabelValidar.Text = "";
                    return true;
                }
                Response.Redirect("accionesPaciente.aspx?noRegistrado=" + "noRegistrado");
                return false;
            }
        }

    }
}