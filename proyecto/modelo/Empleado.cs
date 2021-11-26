using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Empleado : Persona
    {
        public int idEmpleado { get; set; }
        public double sueldo { get; set; }
        public Horario horario { get; set; }
        public Usuario usuario { get; set; }
        public Rol rol { get; set; }


    }
}
