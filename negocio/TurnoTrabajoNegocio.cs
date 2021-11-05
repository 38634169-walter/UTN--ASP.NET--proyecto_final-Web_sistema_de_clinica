using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class TurnoTrabajoNegocio
    {
        public void agregar(Horario horario)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("INSERT INTO TurnosTrabajo(horarioInicio,horarioFin) VALUES ('" + horario.horaInicio +"','" + horario.horaFin +"' ) ");
                con.ejecutar_escritura();
                con.cerrar_conexion();

                int id=obtener_ultimo_id();

                ConexionDB con2 = new ConexionDB();
                con2.consultar("INSERT INTO Personal_TurnosTrabajo(ID_Personal,ID_TurnoTrabajo) VALUES (@personal,@turnoTrabajo) ");
                con2.setear_parametros("@personal",horario.personal.id);
                con2.setear_parametros("@turnoTrabajo",id);
                con2.ejecutar_escritura();
                con2.cerrar_conexion();
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
        public int obtener_ultimo_id()
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT TOP 1 * FROM TurnosTrabajo ORDER BY ID DESC");
                con.ejecutar_lectura();
                int id = 1;
                while (con.lector.Read())
                {
                    id = Convert.ToInt32(con.lector["ID"]);
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
