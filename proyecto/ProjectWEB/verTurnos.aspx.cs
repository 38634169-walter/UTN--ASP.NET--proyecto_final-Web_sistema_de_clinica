﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using modelo;
using negocio;

namespace ProjectWEB
{
    public partial class verTurnos1 : System.Web.UI.Page
    {
        public Turno turno;
        public static List<Turno> turnosList;
        public List<Permiso> permisosList;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            validarAcciones();
            
            TurnoNegocio turNego = new TurnoNegocio();
            if (!IsPostBack)
            {
                turnosList = turNego.listar("lista", "", "");
                cargar_tabla();
            }
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            LabelError.Text = "";
            string dni = TextBoxDni.Text;
            string fecha = TextBoxFecha.Text;
            TurnoNegocio turNego = new TurnoNegocio();
            turnosList = new List<Turno>();
            if(TextBoxDni.Text != "" && TextBoxFecha.Text !="") {
                turnosList = turNego.listar("fecha y dni", fecha, dni);
                GridViewTurnos.DataSource = turnosList;
                GridViewTurnos.DataBind();
            }
            else
            {
                if (TextBoxDni.Text != "")
                {
                    turnosList = turNego.listar("dni", dni,"");
                    GridViewTurnos.DataSource = turnosList;
                    GridViewTurnos.DataBind();
                }
                if (TextBoxFecha.Text != "")
                {
                    turnosList = turNego.listar("fecha", fecha ,"");
                    GridViewTurnos.DataSource = turnosList;
                    GridViewTurnos.DataBind();
                }
            }
            if (!turnosList.Any() || turnosList[0].id == null)
            {
                GridViewTurnos.DataSource = turnosList;
                GridViewTurnos.DataBind();
            }
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
                    if (permiso.nombre == "Editar turnos") ScriptManager.RegisterStartupScript(this, typeof(Page), "editar", "validar_permiso('editarTurno');", true);
                    if (permiso.nombre == "Eliminar turnos") ScriptManager.RegisterStartupScript(this, typeof(Page), "eliminar", "validar_permiso('eliminarTurno');", true);
                    
                    if (permiso.nombre == "Ver turnos") val = true;
                }
            }
            if (val == false)
            {
                Response.Redirect("inicio.aspx");
            }
        }

        protected void eliminar_turno(object sender, GridViewDeleteEventArgs e)
        {
            int id =Convert.ToInt32(GridViewTurnos.DataKeys[e.RowIndex].Value);

            
            TurnoNegocio turNego = new TurnoNegocio();
            turNego.eliminar(id);
            turnosList = turNego.listar("lista", "", "");
            cargar_tabla();
        }
        protected void GridViewTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(GridViewTurnos.DataKeys[e.NewEditIndex].Values["id"].ToString());
            Response.Redirect("accionesTurnos.aspx?id=" + id);
        }


        protected void GridViewTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewTurnos.PageIndex = e.NewPageIndex;
            cargar_tabla();
        }

        public void cargar_tabla()
        {
            LabelError.Text = "";
            GridViewTurnos.EditIndex = -1;
            GridViewTurnos.DataSource = turnosList;
            GridViewTurnos.DataBind();
        }

        protected void GridViewTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ver")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("verInfoTurno.aspx?id=" + id);
            }
        }
    }
}