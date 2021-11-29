using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class DiaDeTrabajoNegocio
    {
        public List<DiaDeTrabajo> dias_trabajo(string id)
        {
            List<DiaDeTrabajo> diaTrabajoList = new List<DiaDeTrabajo>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT * FROM Horarios_DiasTrabajo hdt, Dias_Trabajo dt, Horarios h WHERE hdt.ID_DiasTrabajo=dt.IDDiasTrabajo AND hdt.ID_Horario=h.IDHorario AND hdt.ID_Horario='" + id + "' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    DiaDeTrabajo diaT = new DiaDeTrabajo();
                    diaT.id = Convert.ToInt32(con.lector["IDDiasTrabajo"]);
                    diaT.nombre = (string)con.lector["nombre"];
                    diaTrabajoList.Add(diaT);
                }
                return diaTrabajoList;
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
