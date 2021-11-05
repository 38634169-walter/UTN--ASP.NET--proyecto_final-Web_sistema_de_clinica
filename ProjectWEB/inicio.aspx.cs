using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectWEB
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["accion"] != null) {
                string accion = Request.QueryString["accion"].ToString();
                
                if (accion == "agregado")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ranbomtext", "agregado()", true);
                }
                if (accion == "eliminado")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ranbomtext", "eliminado()", true);
                }
                if (accion == "modificado")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ranbomtext", "modificado()", true);
                }
                
            }
        }

        
    }
}