using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class EmpleadoNegocio
    {
        public Empleado buscar(string dni)
        {
            ConexionDB con = new ConexionDB();
            Empleado empleado = new Empleado();
            try
            {
                con.consultar("SELECT e.IDEmpleado, dp.nombre, dp.apellido, dp.dni,dp.email,dp.telefono FROM Empleados e, Datos_Personales dp WHERE e.ID_DatosPersonales=dp.IDDatosPersonales AND dp.dni='" + dni + "'  AND e.estado='1' AND dp.estado='1' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    empleado.idEmpleado = Convert.ToInt32(con.lector["IDEmpleado"]);
                    empleado.nombre = (string)con.lector["nombre"];
                    empleado.apellido = (string)con.lector["apellido"];
                    empleado.dni = (string)con.lector["dni"];
                    empleado.email = (string)con.lector["email"];
                    empleado.telefono = (string)con.lector["telefono"];
                }
                return empleado;
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
