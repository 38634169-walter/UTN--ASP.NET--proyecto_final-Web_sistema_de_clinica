using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using negocio;

namespace validarPermiso
{
    public class ValidarPermiso
    {
        public bool validar_permiso(List<Permiso> permisosList,string perm)
        {
            foreach (var permiso in permisosList)
            {
                if (permiso.nombre == perm)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
