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
                con.consultar("SELECT * FROM Especialidades");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.id = Convert.ToInt32(con.lector["IDEspecialidad"]);
                    esp.nombre = (string)con.lector["nombre"];
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

        public void agregar(Especialidad especialidad)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("INSERT INTO Especialidades(nombre) VALUES ('" + especialidad.nombre + "' )");
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

        public void agregar_especialidad_doctor(Doctor doctor)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("INSERT INTO Doctores_Especialidades(ID_Doctor,ID_Especialidad) VALUES('" + doctor.id + "', '" + doctor.especialidad.id + "') ");
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
