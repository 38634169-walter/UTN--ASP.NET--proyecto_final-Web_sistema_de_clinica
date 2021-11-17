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
        public Doctor doctor { get; set; }
        public Secretaria secretaria { get; set; }
        public Paciente paciente { get; set; }
        public EstadoTurno estado { get; set; }
        public Historial historia { get; set; }
        public DateTime fecha { get; set; }
        public int hora { get; set; }
        
    }
}

