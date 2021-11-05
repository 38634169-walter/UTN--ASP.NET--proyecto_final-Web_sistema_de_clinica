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
    public partial class verPersonal : System.Web.UI.Page
    {
        public List<Doctor> doctoresList;
        protected void Page_Load(object sender, EventArgs e)
        {
            DoctorNegocio docNego = new DoctorNegocio();
            doctoresList = docNego.listar("todo",1);
        }
    }
}