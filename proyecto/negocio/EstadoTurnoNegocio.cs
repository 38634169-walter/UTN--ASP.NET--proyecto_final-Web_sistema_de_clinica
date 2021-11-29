using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class EstadoTurnoNegocio
    {
        public int listar(string buscar)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                int id = 0;
                con.consultar("SELECT * FROM Estados_Turno WHERE nombre = '" + buscar + "' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    id = Convert.ToInt32(con.lector["IDEstadoTurno"]);
                }
                return id;
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
