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
    public partial class verInfoTurno : System.Web.UI.Page
    {
        public Turno turno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                TurnoNegocio turNego = new TurnoNegocio();
                turno = new Turno();
                turno=turNego.buscar_por_id(id);


                PacienteNegocio pacNego = new PacienteNegocio();
                List<Paciente> pacList = new List<Paciente>();
                pacList=pacNego.buscar("id",turno.paciente.id.ToString());
                turno.paciente.nombre = pacList[0].nombre;
                turno.paciente.apellido = pacList[0].apellido;
                turno.paciente.dni = pacList[0].dni;
            }
        }
    }
}