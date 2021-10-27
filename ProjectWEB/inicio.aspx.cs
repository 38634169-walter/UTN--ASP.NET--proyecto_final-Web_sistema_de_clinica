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
        public string accion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["accion"] != null) {
                accion = Request.QueryString["accion"].ToString();
            }
        }

        
    }
}