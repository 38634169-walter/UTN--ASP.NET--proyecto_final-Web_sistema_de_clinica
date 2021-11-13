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
        
        public List<Especialidad> listar_especilidades_para_turnos()
        {
            List<Especialidad> especialidadList = new List<Especialidad>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT DISTINCT e.nombre, e.IDEspecialidad FROM Especialidades e, Horarios h WHERE h.ID_Especialidad=e.IDEspecialidad");
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

        public List<Doctor> listar_especialidad_doctor(int id)
        {
            List<Doctor> doctorList = new List<Doctor>();
            ConexionDB con = new ConexionDB();

            try
            {
                con.consultar("SELECT e.nombre nomE, e.IDEspecialidad, dp.nombre nomD, dp.apellido apeD,d.IDDoctor FROM Doctores d, Doctores_Especialidades de, Especialidades e, Empleados em, Datos_Personales dp WHERE d.IDDoctor=de.ID_Doctor AND de.ID_Especialidad=e.IDEspecialidad AND d.ID_Empleado=em.IDEmpleado AND em.ID_DatosPersonales=dp.IDDatosPersonales AND d.IDDoctor =  '" + id + "' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Doctor doctor = new Doctor();
                    doctor.id = Convert.ToInt32(con.lector["IDDoctor"]);
                    doctor.nombre = (string)con.lector["nomD"];
                    doctor.apellido = (string)con.lector["apeD"];
                    doctor.especialidad = new Especialidad();
                    doctor.especialidad.id = Convert.ToInt32(con.lector["IDEspecialidad"]);
                    doctor.especialidad.nombre = (string)con.lector["nomE"];
                    doctorList.Add(doctor);
                }
                return doctorList;
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
        public List<Especialidad> especialidades_doctor_no_tiene(int id)
        {
            List<Especialidad> especialidadList = new List<Especialidad>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT nombre, IDEspecialidad FROM Especialidades WHERE IDEspecialidad <> ALL ( SELECT es.IDEspecialidad FROM Doctores do, Doctores_Especialidades dee, Especialidades es WHERE do.IDDoctor=dee.ID_Doctor AND dee.ID_Especialidad=es.IDEspecialidad AND do.IDDoctor = '" + id + "' )");
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

        public List<Especialidad> especialidades_doctor_tiene(int id)
        {
            List<Especialidad> especialidadList = new List<Especialidad>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT e.nombre,e.IDEspecialidad FROM Especialidades e, Doctores d, Doctores_Especialidades de WHERE d.IDDoctor=de.ID_Doctor AND de.ID_Especialidad=e.IDEspecialidad AND d.IDDoctor = '" + id + "' ");
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
