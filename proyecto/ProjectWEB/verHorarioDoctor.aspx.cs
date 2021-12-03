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
    public partial class agregarHorarioPersonal : System.Web.UI.Page
    {
        public static List<Doctor> doctoresList;
        public Doctor doctor;
        public List<Especialidad> especialidadList;
        public List<Permiso> permisosList;
        protected void Page_Load(object sender, EventArgs e)
        {
            validarAcciones();
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                cargar_grid();
                if (!IsPostBack) {
                    EspecialidadNegocio espNego = new EspecialidadNegocio();
                    especialidadList = espNego.especialidades_doctor_tiene(id);
                    DropDownListEspecilidad.DataSource = especialidadList;
                    DropDownListEspecilidad.DataValueField = "id";
                    DropDownListEspecilidad.DataTextField = "nombre";
                    DropDownListEspecilidad.DataBind();

                    if(doctoresList.Any()) {
                        LabelTituloVer.Text += " de " + doctoresList[0].nombre + " " + doctoresList[0].apellido;
                        LabelTituloAgregar.Text += " a " + doctoresList[0].nombre + " " + doctoresList[0].apellido;
                    }
                }
            }
        }

        protected void ButtonAsignar_Click(object sender, EventArgs e)
        {
            int horaInicio = Convert.ToInt32(TextBoxHorarioInicio.Text);
            int horaFin = Convert.ToInt32(TextBoxHorarioFin.Text);
            bool validar = validar_horario(doctoresList,horaInicio,horaFin);

            if (validar == true) {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                HorarioNegocio horNego = new HorarioNegocio();
                doctor = new Doctor();
                doctor.id = id;
                doctor.horario = new Horario();
                doctor.horario.horaInicio = horaInicio;
                doctor.horario.horaFin = horaFin;
                doctor.horario.especialidad = new Especialidad();
                doctor.horario.especialidad.id = Convert.ToInt32(DropDownListEspecilidad.SelectedValue);
                bool lunes = CheckBoxLunes.Checked;
                bool martes = CheckBoxMartes.Checked;
                bool miercoles = CheckBoxMiercoles.Checked;
                bool jueves = CheckBoxJueves.Checked;
                bool viernes = CheckBoxViernes.Checked;
                bool sabado = CheckBoxSabado.Checked;
                bool domingo = CheckBoxDomingo.Checked;
                horNego.agregar(doctor,lunes,martes,miercoles,jueves,viernes,sabado,domingo);
                string confirmacion = "agregado";
                Response.Redirect("inicio.aspx?accion=" + confirmacion);
            }
        }
        public bool validar_horario(List<Doctor> doctoresList,int horaInicio,int horaFin)
        {
            LabelError.Text = "";
            bool validar = true;
            
            if (horaInicio > horaFin)
            {
                LabelError.Text += "*El horario de inicio no debe ser mayor al de fin </br>";
                validar=false;
            }
            else
            {
                if(horaInicio == horaFin)
                {
                    LabelError.Text += "*Los horarios de inicio y fin no deben ser iguales </br>";
                    validar = false;
                }
                if(horaInicio > 24 || horaFin > 24)
                {
                    LabelError.Text += "*El horario ingresado se encuentra fuera del rango de 24hs </br>";
                    validar = false;
                }
            }
            if(!(CheckBoxLunes.Checked) && !(CheckBoxMartes.Checked) && !(CheckBoxMiercoles.Checked) && !(CheckBoxJueves.Checked) && !(CheckBoxViernes.Checked) && !(CheckBoxSabado.Checked) && !(CheckBoxDomingo.Checked))
            {
                validar = false;
                LabelError.Text += "*Se debe ingresar al menos un dia para el horario del doctor";
            }
            DiaDeTrabajoNegocio dtNego = new DiaDeTrabajoNegocio();
            List<DiaDeTrabajo> diasTrabajoList = new List<DiaDeTrabajo>();
            foreach (var doctor in doctoresList)
            {
                
                diasTrabajoList = dtNego.dias_trabajo(doctor.horario.id.ToString());

                foreach (var dia in diasTrabajoList)
                {
                    bool buscar = false;
                    
                    if (dia.nombre == "lunes" && CheckBoxLunes.Checked == true) buscar = true;
                    if (dia.nombre == "martes" && CheckBoxMartes.Checked == true) buscar = true;
                    if (dia.nombre == "miércoles" && CheckBoxMiercoles.Checked == true) buscar = true;
                    if (dia.nombre == "jueves" && CheckBoxJueves.Checked == true) buscar = true;
                    if (dia.nombre == "viernes" && CheckBoxViernes.Checked == true) buscar = true;
                    if (dia.nombre == "sábado" && CheckBoxSabado.Checked == true) buscar = true;
                    if (dia.nombre == "domingo" && CheckBoxDomingo.Checked == true) buscar = true;

                    if (buscar == true) {
                        for (int i = doctor.horario.horaInicio; i < doctor.horario.horaFin; i++)
                        {

                            for (int x = horaInicio; x <= horaFin; x++)
                            {
                                if (i == x)
                                {
                                    LabelError.Text += "*El dia " + dia.nombre + " esta ocupado a las " + i + ":00Hs" + "</br>";
                                    validar = false;
                                }
                            }

                        }
                    }
                }
            }
            return validar;
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
                    if (permiso.nombre == "Asignar horarios doctores") ScriptManager.RegisterStartupScript(this, typeof(Page), "asignar", "validar_permiso('asignarHorariosDoctores');", true);
                    if (permiso.nombre == "Eliminar horarios doctores") ScriptManager.RegisterStartupScript(this, typeof(Page), "eliminar", "validar_permiso('eliminarHorariosDoctores');", true);

                    if (permiso.nombre == "Ver horarios doctores") val = true;
                }
            }
            if (val == false)
            {
                Response.Redirect("inicio.aspx");
            }
        }

        protected void GridViewHorarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewHorarios.DataKeys[e.RowIndex].Value);
            HorarioNegocio horNego = new HorarioNegocio();
            horNego.eliminar(id);
            cargar_grid();
        }

        protected void GridViewHorarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewHorarios.PageIndex = e.NewPageIndex;
            cargar_grid();
        }
        public void cargar_grid()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            HorarioNegocio horNego = new HorarioNegocio();
            doctoresList = horNego.horarios_doctor(id);
            GridViewHorarios.EditIndex = -1;
            GridViewHorarios.DataSource = doctoresList;
            GridViewHorarios.DataBind();
        }

        protected void GridViewHorarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                HorarioNegocio horNego = new HorarioNegocio();
                horNego.eliminar(id);
                cargar_grid();
            }
            if (e.CommandName == "Ver")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("verDiasHorarios.aspx?id=" + id);
            }
        }
    }
}