using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Historial
    {
        public int id { get; set; }
        public string observacion { get; set; }
        public DateTime fecha { get; set; }
        public Doctor doctor { get; set; }
        public Paciente paciente { get; set; }
    }
}
