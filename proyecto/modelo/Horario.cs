using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Horario
    {
        public int id { get; set; }
        public int horaInicio { get; set; }
        public int horaFin { get; set; }
        public Especialidad especialidad { get; set; }
    }
}
