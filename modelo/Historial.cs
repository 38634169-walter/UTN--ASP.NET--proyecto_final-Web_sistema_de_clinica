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
        public Cliente cliente { get; set; }
        public string observacion { get; set; }
        public string fecha { get; set; }
        public Personal personal { get; set; }
    }
}
