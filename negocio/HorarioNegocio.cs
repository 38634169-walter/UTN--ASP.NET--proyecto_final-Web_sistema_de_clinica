using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class HorarioNegocio
    {

        public void agregar(Doctor doctor)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("EXEC SP_AGREGAR_HORARIO_A_DOCTOR '" + doctor.id + "','" + doctor.horario.horaInicio + "','" + doctor.horario.horaFin + "' ");
                con.ejecutar_escritura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.cerrar_conexion();
            }
        }
    }
}
