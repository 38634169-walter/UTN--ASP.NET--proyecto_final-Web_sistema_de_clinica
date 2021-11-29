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

        public void agregar(Doctor doctor,bool lu, bool ma, bool mi, bool ju, bool vi, bool sa, bool dom)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("EXEC SP_AGREGAR_HORARIO_A_DOCTOR '" + doctor.id + "','" + doctor.horario.horaInicio + "','" + doctor.horario.horaFin + "', '" + doctor.horario.especialidad.id + "', '" + lu + "', '" + ma + "', '" + mi + "', '" + ju + "', '" + vi + "', '" + sa + "', '" + dom + "'  ");
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
                con.consultar("SELECT dp.nombre nomD,dp.apellido apeD,h.horarioInicio,h.horarioFin,h.IDHorario,es.nombre nomE FROM Doctores d, Empleados e, Horarios h, Datos_Personales dp, Especialidades es WHERE d.ID_Empleado = e.IDEmpleado AND h.ID_Empleado = e.IDEmpleado AND e.ID_DatosPersonales = dp.IDDatosPersonales AND h.ID_Especialidad = es.IDEspecialidad AND d.IDDoctor= '" + id + "'  ");
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
        
        public List<Doctor> horarios_doctor_especialidad(string buscarPor,int id,int especialidad,string dia)
        {
            List<Doctor> doctoresList = new List<Doctor>();
            ConexionDB con = new ConexionDB();
            string consulta = "";
            switch (buscarPor)
            {
                case "con dia":
                    consulta = "SELECT dp.nombre nomD,dp.apellido apeD,h.horarioInicio,h.horarioFin,h.IDHorario,es.nombre nomE, dt.nombre nomDT FROM Doctores d, Empleados e, Horarios h, Datos_Personales dp, Especialidades es, Dias_Trabajo dt, Horarios_DiasTrabajo hdt WHERE d.ID_Empleado = e.IDEmpleado AND h.ID_Empleado=e.IDEmpleado AND e.ID_DatosPersonales = dp.IDDatosPersonales AND h.ID_Especialidad = es.IDEspecialidad AND hdt.ID_Horario=h.IDHorario AND hdt.ID_DiasTrabajo=dt.IDDiasTrabajo AND dt.nombre = '" + dia + "' AND d.IDDoctor='" + id + "' AND h.ID_Especialidad = '" + especialidad + "'  ";
                    break;
                case "sin dia":
                    consulta = "SELECT dp.nombre nomD,dp.apellido apeD,h.horarioInicio,h.horarioFin,h.IDHorario,es.nombre nomE, dt.nombre nomDT FROM Doctores d, Empleados e, Horarios h, Datos_Personales dp, Especialidades es, Dias_Trabajo dt, Horarios_DiasTrabajo hdt WHERE d.ID_Empleado = e.IDEmpleado AND h.ID_Empleado=e.IDEmpleado AND e.ID_DatosPersonales = dp.IDDatosPersonales AND h.ID_Especialidad = es.IDEspecialidad AND hdt.ID_Horario=h.IDHorario AND hdt.ID_DiasTrabajo=dt.IDDiasTrabajo AND d.IDDoctor='" + id + "' AND h.ID_Especialidad = '" + especialidad + "' ";
                    break;
            }
            try
            {
                con.consultar(consulta);
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
                    if (buscarPor == "sin dia") doctor.horario.horaFin = doctor.horario.horaFin - 1;
                    doctor.horario.dias = (string)con.lector["nomDT"];
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
                con.consultar("DELETE FROM Horarios WHERE IDHorario = '" + id + "' ");
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
