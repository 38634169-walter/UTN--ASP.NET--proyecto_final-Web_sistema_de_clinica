using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Turno
    {
        public int id { get; set; }
        public Especialidad especialidad { get; set; }
        public Personal personal { get; set; }
        public Personal recepcionista { get; set; }
        public string fecha { get; set; }
        public int hora { get; set; }
        public Cliente cliente { get; set; }
    }
}

