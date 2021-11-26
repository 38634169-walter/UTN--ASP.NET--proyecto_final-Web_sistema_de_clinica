using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class PersonalEspecialidadNegocio
    {
        public void agregar_especialidad_personal(PersonalEspecialidad perEsp)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("INSERT INTO Personal_Especialidades(ID_Especialidad,ID_Personal) VALUES(@especialidad,@personal) ");
                con.setear_parametros("@especialidad",perEsp.especialidad.id);
                con.setear_parametros("@personal",perEsp.personal.id);
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
