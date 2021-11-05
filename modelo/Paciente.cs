using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Paciente : Persona
    {
        public int id { get; set; }
        public Turno turno { get; set; }
        public Historial historial { get; set; }
    }
}
