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

        public List<Doctor> horarios_doctor(int id)
        {
            List<Doctor> doctoresList = new List<Doctor>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT dp.nombre,dp.apellido,h.horarioInicio,h.horarioFin,h.IDHorario FROM Doctores d, Empleados e, Empleados_Horarios eh, Horarios h, Datos_Personales dp WHERE d.ID_Empleado = e.IDEmpleado AND e.IDEmpleado=eh.ID_Empleado AND h.IDHorario = eh.ID_Horario AND e.ID_DatosPersonales = dp.IDDatosPersonales AND d.IDDoctor='" + id + "' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Doctor doctor = new Doctor();
                    doctor.nombre = (string)con.lector["nombre"];
                    doctor.apellido = (string)con.lector["apellido"];
                    doctor.horario = new Horario();
                    doctor.horario.id = Convert.ToInt32(con.lector["IDHorario"]);
                    doctor.horario.horaInicio = Convert.ToInt32(con.lector["horarioInicio"]);
                    doctor.horario.horaFin = Convert.ToInt32(con.lector["horarioFin"]);
                    doctoresList.Add(doctor);
                }
                return doctoresList;
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
        public void eliminar(int id)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                //con.consultar("DELETE FROM Horarios WHERE IDHorario = '" + id + "' ");
                //con.ejecutar_escritura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
