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
                con.consultar("EXEC SP_AGREGAR_HORARIO_A_DOCTOR '" + doctor.id + "','" + doctor.horario.horaInicio + "','" + doctor.horario.horaFin + "', '" + doctor.horario.especialidad.id + "'  ");
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
                con.consultar("SELECT dp.nombre nomD,dp.apellido apeD,h.horarioInicio,h.horarioFin,h.IDHorario,es.nombre nomE FROM Doctores d, Empleados e, Empleados_Horarios eh, Horarios h, Datos_Personales dp, Especialidades es WHERE d.ID_Empleado = e.IDEmpleado AND e.IDEmpleado=eh.ID_Empleado AND h.IDHorario = eh.ID_Horario AND e.ID_DatosPersonales = dp.IDDatosPersonales AND h.ID_Especialidad = es.IDEspecialidad AND d.IDDoctor='" + id + "' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Doctor doctor = new Doctor();
                    doctor.id = id;
                    doctor.nombre = (string)con.lector["nomD"];
                    doctor.apellido = (string)con.lector["apeD"];
                    doctor.horario = new Horario();
                    doctor.horario.id = Convert.ToInt32(con.lector["IDHorario"]);
                    doctor.horario.horaInicio = Convert.ToInt32(con.lector["horarioInicio"]);
                    doctor.horario.horaFin = Convert.ToInt32(con.lector["horarioFin"]);
                    doctor.horario.especialidad = new Especialidad();
                    doctor.horario.especialidad.nombre = (string)con.lector["nomE"];
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
