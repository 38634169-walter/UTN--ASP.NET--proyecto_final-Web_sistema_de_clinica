using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using modelo;
using negocio;
using validarPermiso;

namespace ProjectWEB
{
    public partial class verTurnos : System.Web.UI.Page
    {
        public static Turno turno;
        public Paciente paciente;
        public static int horaEditando=99;
        public List<Doctor> doctoresList;
        public List<Doctor> doctoresList2;
        public List<Paciente> pacientesList;
        public List<Turno> turnosList;
        public List<Horario> horariosList;
        public List<Permiso> permisosList;
        public string noRegistrado ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EspecialidadNegocio espNego = new EspecialidadNegocio();
                DropEspecialidad.DataSource = espNego.listar_especilidades_para_turnos();
                DropEspecialidad.DataValueField = "id";
                DropEspecialidad.DataTextField = "nombre";
                DropEspecialidad.DataBind();
                DropEspecialidad.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

                if (Request.QueryString["id"] != null)
                {
                    validar_permisos("Editar turnos");

                    LabelTitulo.Text = "Editar Turno";
                    ButtonReservar.Text = "Confirmar";
                    turno = new Turno();
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    TurnoNegocio turNego = new TurnoNegocio();
                    turno = turNego.buscar_por_id(id);

                    TextBoxDni.Text = turno.paciente.dni;
                    TextBoxfecha.Text = String.Format("{0:yyyy-MM-dd}", turno.fecha);
                    DropEspecialidad.SelectedIndex = turno.especialidad.id;

                    horaEditando = turno.hora;
                    int[] horariosDisponibles = horarios_disponibles();
                    DropHora.DataSource = horariosDisponibles;
                    DropHora.DataBind();
                    DropHora.SelectedValue=horaEditando.ToString();
                    horaEditando = 99;


                    //
                    DoctorNegocio docNego = new DoctorNegocio();
                    doctoresList = new List<Doctor>();
                    doctoresList = docNego.listar("especialidades con turno disponible", turno.especialidad.id);

                    DropPersonalDisponible.DataSource = doctoresList;
                    DropPersonalDisponible.DataValueField = "id";
                    DropPersonalDisponible.DataTextField = "nombreCompleto";
                    DropPersonalDisponible.DataBind();
                    DropPersonalDisponible.SelectedValue = turno.doctor.id.ToString();
                    //
                }
                else
                {
                    validar_permisos("Agregar turnos");

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
            TextBoxfecha.Text = "";
            DropHora.Visible = false;
            LabelHora.Visible = false;
            int id = Convert.ToInt32(DropEspecialidad.SelectedValue);
            turno.especialidad = new Especialidad();
            turno.especialidad.id = Convert.ToInt32(DropEspecialidad.SelectedValue);


            //
            DoctorNegocio docNego = new DoctorNegocio();
            doctoresList = new List<Doctor>();
            doctoresList = docNego.listar("especialidades con turno disponible", id);

            DropPersonalDisponible.DataSource = doctoresList;
            DropPersonalDisponible.DataValueField = "id";
            DropPersonalDisponible.DataTextField = "nombreCompleto";
            DropPersonalDisponible.DataBind();
            DropPersonalDisponible.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            //
            
            DropPersonalDisponible.Visible = true;
            LabelPersonal.Visible = true;
        }

        protected void DropPersonalDisponible_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxfecha.Text = "";
            DropHora.Visible = false;
            LabelHora.Visible = false;

            turno.doctor = new Doctor();
            turno.doctor.id = Convert.ToInt32(DropPersonalDisponible.SelectedValue);
            TextBoxfecha.Visible = true;
            LabelFecha.Visible = true;
        }
        protected void TextBoxfecha_TextChanged(object sender, EventArgs e)
        {
            
            int[] horariosDisponibles = horarios_disponibles();

            DropHora.Visible = true;
            LabelHora.Visible = true;
            DropHora.DataSource = horariosDisponibles;
            DropHora.DataBind();
        }

        protected void ButtonReservar_Click(object sender, EventArgs e)
        {
            turno.secretaria = new Secretaria();
            turno.secretaria.id = 1;
            turno.hora = Convert.ToInt32(DropHora.SelectedValue);
            
            string accion = "";
            if (turno.id != 0)
            {
                turno.estado = new EstadoTurno();
                turno.estado.id = 4;
                TurnoNegocio turNego = new TurnoNegocio();
                turNego.modificar(turno);
                accion = "modificado";
            }
            else{ 


                turno.estado = new EstadoTurno();
                turno.estado.id = 2;
                TurnoNegocio turNego = new TurnoNegocio();
                turNego.agregar(turno);
                accion = "agregado";
            }
            Response.Redirect("inicio.aspx?accion=" + accion); 
        }







        public bool validar_dni()
        {
            PacienteNegocio pacNego = new PacienteNegocio();
            paciente = new Paciente();
            paciente = pacNego.buscar("dni", TextBoxDni.Text);
            if (paciente != null)
            {
                if(turno == null) turno = new Turno();
                turno.paciente = new Paciente();
                turno.paciente.id = paciente.id;
                return true;
            }
            Response.Redirect("accionesPaciente.aspx?noRegistrado=" + "noRegistrado");
            return false;
            
        }

        public int[] horarios_disponibles()
        {
            turno.fecha = Convert.ToDateTime(TextBoxfecha.Text);
            TurnoNegocio turNego = new TurnoNegocio();
            turnosList = turNego.turnos_medico_especialidad_fecha(turno);
            HorarioNegocio horNego = new HorarioNegocio();
            doctoresList2 = horNego.horarios_doctor_especialidad(turno.doctor.id, turno.especialidad.id);


            int cont = 0;
            foreach (var doctor in doctoresList2)
            {
                for (int i = doctor.horario.horaInicio; i < doctor.horario.horaFin; i++)
                {
                    cont++;
                    foreach (var turno in turnosList)
                    {
                        if (turno.hora == i)
                        {
                            cont--;
                        }
                    }
                }
            }
            if (horaEditando != 99)
            {
                cont++;
            }
            int[] horariosDisponibles = new int[cont];

            cont = 0;
            bool b = false;
            foreach (var doctor in doctoresList2)
            {
                for (int i = doctor.horario.horaInicio; i < doctor.horario.horaFin; i++)
                {
                    foreach (var turno in turnosList)
                    {
                        if (turno.hora == i)
                        {
                            b = true;
                            if (horaEditando == turno.hora)
                            {
                                horariosDisponibles[cont] = horaEditando;
                                cont++;
                            }
                        }
                    }
                    if (b == false)
                    {
                        horariosDisponibles[cont] = i;
                        cont++;
                    }
                    b = false;
                }
            }
            return horariosDisponibles;
        }

        public void validar_permisos(string val)
        {
            
            permisosList = new List<Permiso>();
            permisosList = (List<Permiso>)Session["permisos"];
            ValidarPermiso valPer = new ValidarPermiso();
            if (permisosList == null || valPer.validar_permiso(permisosList, val) == false)
            {
                Response.Redirect("inicio.aspx");
            }
        }

    }
}