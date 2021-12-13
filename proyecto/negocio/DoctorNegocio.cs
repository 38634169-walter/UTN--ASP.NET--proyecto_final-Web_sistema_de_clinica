using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class DoctorNegocio
    {
        public List<Doctor> listar(string buscarPor, int buscar)
        {
            string consulta = "";
            switch (buscarPor)
            {
                case "todo":
                    consulta = "SELECT d.IDDoctor,dp.nombre AS nombreP, dp.apellido,dp.dni FROM Doctores d, Empleados e, Datos_Personales dp WHERE d.ID_Empleado = e.IDEmpleado AND e.ID_DatosPersonales = dp.IDDatosPersonales AND e.estado = 1";
                    break;
                case "especialidades con turno disponible":
                    consulta = "SELECT DISTINCT d.IDDoctor,dp.nombre AS nombreP, dp.apellido,dp.dni FROM Horarios h, Empleados em, Especialidades e, Datos_Personales dp, Doctores d WHERE em.IDEmpleado = h.ID_Empleado AND em.ID_DatosPersonales = dp.IDDatosPersonales AND d.ID_Empleado=em.IDEmpleado AND h.ID_Especialidad=e.IDEspecialidad AND em.estado=1 AND e.IDEspecialidad='" + buscar +"'  ";
                    break;
            }
            List<Doctor> doctoresList = new List<Doctor>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar(consulta);
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Doctor doc = new Doctor();
                    doc.id = Convert.ToInt32(con.lector["IDDoctor"]);
                    doc.nombre = (string)con.lector["nombreP"];
                    doc.apellido = (string)con.lector["apellido"];
                    doc.nombreCompleto = (string)con.lector["nombreP"];
                    doc.nombreCompleto += " ";
                    doc.nombreCompleto += (string)con.lector["apellido"];
                    doc.dni = (string)con.lector["dni"];
                    doctoresList.Add(doc);
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
        public Doctor buscar_por_id(int id)
        {
            Doctor doctor = new Doctor();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT dp.nombre, dp.apellido, dp.dni,dp.email,dp.telefono,dp.fechaNacimiento, u.usuario,u.clave,e.sueldo FROM Doctores d, Usuarios u, Empleados e, Datos_Personales dp WHERE d.ID_Empleado = e.IDEmpleado AND e.IDEmpleado = u.IDUsuario AND e.ID_DatosPersonales=dp.IDDatosPersonales AND d.IDDoctor='" + id + "'  AND e.estado='1' AND u.estado='1' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    doctor.id = id;
                    doctor.nombre = (string)con.lector["nombre"];
                    doctor.dni = (string)con.lector["dni"];
                    doctor.apellido = (string)con.lector["apellido"];
                    doctor.email = (string)con.lector["email"];
                    doctor.telefono = (string)con.lector["telefono"];
                    doctor.sueldo = Convert.ToDouble(con.lector["sueldo"]);
                    doctor.fechaNacimiento = Convert.ToDateTime(con.lector["fechaNacimiento"]);
                    doctor.usuario = new Usuario();
                    doctor.usuario.usuario = (string)con.lector["usuario"];
                    doctor.usuario.clave = (string)con.lector["clave"];
                }
                return doctor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
          
        public void agregar(Doctor doctor, bool lu, bool ma, bool mi, bool ju, bool vi, bool sa, bool dom)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("EXEC SP_AGREGAR_DOCTOR '" + doctor.nombre + "', '" + doctor.apellido + "','" + doctor.dni + "','" + doctor.email + "','" + doctor.telefono + "','" + doctor.sueldo + "','" + doctor.especialidad.id + "','" + doctor.horario.horaInicio + "','" + doctor.horario.horaFin + "','" + doctor.usuario.usuario + "','" + doctor.usuario.clave + "', '" + doctor.fechaNacimiento.ToString("yyyy-MM-dd") + "', '" + doctor.fechaIngreso.ToString("yyyy-MM-dd") + "','" + lu + "', '" + ma + "', '" + mi + "', '" + ju + "', '" + vi + "', '" + sa + "', '" + dom + "' ");
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

        public void modificar(Doctor doctor)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("EXEC SP_MODIFICAR_DOCTOR '" + doctor.id + "', '" +  doctor.nombre + "', '" + doctor.apellido + "', '" + doctor.email + "', '" + doctor.telefono + "', '" + doctor.sueldo + "', '" + doctor.usuario.usuario + "', '" + doctor.usuario.clave + "', '" + doctor.fechaNacimiento.ToString("yyyy-MM-dd") + "'  ");
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

        public void quitar_especialidad_doctor(int especialidadID,int doctorID)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("DELETE FROM Doctores_Especialidades WHERE ID_Doctor= '" + doctorID + "' AND ID_Especialidad='" + especialidadID + "' ");
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
