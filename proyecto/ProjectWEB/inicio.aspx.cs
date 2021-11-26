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
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "agregado", "agregado();", true);
                }
                if (accion == "eliminado")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "eliminado", "eliminado();", true);
                }
                if (accion == "modificado")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "modificado", "modificado();", true);
                }
                
            }
        }

        
    }
}