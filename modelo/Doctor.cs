using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Doctor : Empleado
    {
        public int id { get; set; }
        public Especialidad especialidad { get; set; }
    }
}
