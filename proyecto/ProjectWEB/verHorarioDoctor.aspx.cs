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
        public bool validar_horario(List<Doctor> doctoresList, int horaInicio, int horaFin)
        {
            LabelError.Text = "";
            bool validar = true;
            bool validarHorario = true;

            if (horaInicio > horaFin)
            {
                LabelError.Text += "*El horario de inicio no debe ser mayor al de fin </br>";
                validar = false;
            }
            else
            {
                if (horaInicio == horaFin)
                {
                    LabelError.Text += "*Los horarios de inicio y fin no deben ser iguales </br>";
                    validar = false;
                }
                if (horaInicio > 24 || horaFin > 24)
                {
                    LabelError.Text += "*El horario ingresado se encuentra fuera del rango de 24hs </br>";
                    validar = false;
                }
            }
            if (!(CheckBoxLunes.Checked) && !(CheckBoxMartes.Checked) && !(CheckBoxMiercoles.Checked) && !(CheckBoxJueves.Checked) && !(CheckBoxViernes.Checked) && !(CheckBoxSabado.Checked) && !(CheckBoxDomingo.Checked))
            {
                validar = false;
                LabelError.Text += "*Se debe ingresar al menos un dia para el horario del doctor";
            }
            DiaDeTrabajoNegocio dtNego = new DiaDeTrabajoNegocio();
            List<DiaDeTrabajo> diasTrabajoList = new List<DiaDeTrabajo>();


            string[] horarioDia = new string[7];
            bool[] bandederaHorario = new bool[7];
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
                                    validar = false;
                                    validarHorario = false;
                                    switch (dia.nombre)
                                    {
                                        case "lunes":
                                            if (bandederaHorario[0] == false)
                                            {
                                                horarioDia[0] = "<p class='text-light fw-bold mb-0 mt-1'>>Lunes: </p>";
                                                bandederaHorario[0] = true;
                                            }
                                            horarioDia[0] += x.ToString() + ":00Hs, ";
                                            break;
                                        case "martes":
                                            if (bandederaHorario[1] == false)
                                            {
                                                horarioDia[1] = "<p class='text-light fw-bold mb-0 mt-1'>>Martes: </p>";
                                                bandederaHorario[1] = true;
                                            }
                                            horarioDia[1] += x.ToString() + ":00Hs, ";
                                            break;
                                        case "miércoles":
                                            if (bandederaHorario[2] == false)
                                            {
                                                horarioDia[2] = "<p class='text-light fw-bold mb-0 mt-1'>>Miercoles: </p>";
                                                bandederaHorario[2] = true;
                                            }
                                            horarioDia[2] += x.ToString() + ":00Hs, ";
                                            break;
                                        case "jueves":
                                            if (bandederaHorario[3] == false)
                                            {
                                                horarioDia[3] = "<p class='text-light fw-bold mb-0 mt-1'>>Jueves: </p>";
                                                bandederaHorario[3] = true;
                                            }
                                            horarioDia[3] += x.ToString() + ":00Hs, ";
                                            break;
                                        case "viernes":
                                            if (bandederaHorario[4] == false)
                                            {
                                                horarioDia[4] = "<p class='text-light fw-bold mb-0 mt-1'>>Viernes: </p>";
                                                bandederaHorario[4] = true;
                                            }
                                            horarioDia[4] += x.ToString() + ":00Hs, ";
                                            break;
                                        case "sábado":
                                            if (bandederaHorario[5] == false)
                                            {
                                                horarioDia[5] = "<p class='text-light fw-bold mb-0 mt-1'>>Sabado: </p>";
                                                bandederaHorario[5] = true;
                                            }
                                            horarioDia[5] += x.ToString() + ":00Hs, ";
                                            break;
                                        case "domingo":
                                            if (bandederaHorario[6] == false)
                                            {
                                                horarioDia[6] = "<p class='text-light fw-bold mb-0 mt-1'>>Domingo: </p>";
                                                bandederaHorario[6] = true;
                                            }
                                            horarioDia[6] += x.ToString() + ":00Hs, ";
                                            break;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            if (validarHorario == false)
            {
                for (int j = 0; j < 7; j++)
                {
                    labelHorariOcupado.Text += horarioDia[j];
                }
                errorContainer.Style.Add("display", "block");
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