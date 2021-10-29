using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class EspecialidadNegocio
    {
        public List<Especialidad> listar()
        {
            List<Especialidad> especialidadList = new List<Especialidad>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT e.ID AS ID_Especialidad, e.nombre AS nombreEspecialidad FROM Especialidades e, Cargos c WHERE e.ID_Cargo=c.ID AND c.nombre='Doctor' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.id = Convert.ToInt32(con.lector["ID_Especialidad"]);
                    esp.nombre = (string)con.lector["nombreEspecialidad"];
                    especialidadList.Add(esp);
                }
                return especialidadList;
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
