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
    public partial class verDiasHorarios : System.Web.UI.Page
    {
        public List<DiaDeTrabajo> diaDeTrabajoList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();
                diaDeTrabajoList = new List<DiaDeTrabajo>();
                DiaDeTrabajoNegocio diaTNego = new DiaDeTrabajoNegocio();
                diaDeTrabajoList=diaTNego.dias_trabajo(id);

            }
        }
    }
}