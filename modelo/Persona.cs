using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Persona
    {
        public int idDatosPersonales { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nombreCompleto { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
    }
}
