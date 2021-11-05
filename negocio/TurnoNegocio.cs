using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class TurnoNegocio
    {
        public Turno buscar_por_id(int id)
        {
            Turno turno = new Turno();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT * FROM Turnos WHERE estado = 1 AND IDTurno = '" + id + "' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    turno.id = id;
                    turno.fecha = Convert.ToString(con.lector["fecha"]);
                    turno.hora = Convert.ToInt32(con.lector["hora"]);

                    turno.especialidad = new Especialidad();
                    turno.especialidad.id = Convert.ToInt32(con.lector["ID_Especialidad"]);

                    turno.doctor = new Doctor();
                    turno.doctor.id = Convert.ToInt32(con.lector["ID_Doctor"]);

                    turno.secretaria = new Secretaria();
                    turno.secretaria.id = Convert.ToInt32(con.lector["ID_Secretaria"]);

                    turno.paciente = new Paciente();
                    turno.paciente.id = Convert.ToInt32(con.lector["ID_Paciente"]);
                }

                return turno;
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
        
        public List<Turno> listar(string buscarPor, string buscar,int buscar2)
        {
            string consulta = "";
            switch (buscarPor)
            {
                case "dni":
                    consulta = "SELECT t.IDTurno,p.IDPaciente,e.IDEspecialidad,dp.dni,dp.nombre AS nombrePaciente,dp.apellido,e.nombre AS nombreEspecialidad,t.hora FROM Turnos t, Pacientes p,Datos_Personales dp , Especialidades e WHERE t.ID_Paciente = p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales AND t.ID_Especialidad = e.IDEspecialidad AND dp.dni = '" + buscar + "' AND t.estado='1' ";
                    break;
                case "lista":
                    consulta = "SELECT t.IDTurno,p.IDPaciente,e.IDEspecialidad,dp.dni,dp.nombre AS nombrePaciente,dp.apellido,e.nombre AS nombreEspecialidad,t.hora FROM Turnos t, Pacientes p,Datos_Personales dp ,Especialidades e WHERE t.ID_Paciente = p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales AND t.ID_Especialidad = e.IDEspecialidad AND t.estado='1' ";
                    break;
                case "turnos":
                    consulta = "SELECT t.IDTurno,p.IDPaciente,e.IDEspecialidad,dp.dni,dp.nombre AS nombrePaciente,dp.apellido,e.nombre AS nombreEspecialidad,t.hora FROM Turnos t, Pacientes p,Datos_Personales dp , Especialidades e, Doctor d WHERE t.ID_Paciente = p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales AND t.ID_Especialidad = e.IDEspecialidad AND d.IDDoctor='" + buscar2 + "' AND t.fecha= '" + buscar + "' AND t.estado='1' ";
                    break;
            }

            List<Turno> turnoList = new List<Turno>();
            ConexionDB con = new ConexionDB();
            try
            {
                
                con.consultar(consulta);

                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Turno tur = new Turno();
                    tur.id = Convert.ToInt32(con.lector["IDTurno"]);
                    tur.hora = Convert.ToInt32(con.lector["hora"]);

                    tur.especialidad = new Especialidad();
                    tur.especialidad.id = Convert.ToInt32(con.lector["IDEspecialidad"]);
                    tur.especialidad.nombre = (string)con.lector["nombreEspecialidad"];

                    tur.paciente = new Paciente();
                    tur.paciente.id = Convert.ToInt32(con.lector["IDPaciente"]);
                    tur.paciente.nombre = (string)con.lector["nombrePaciente"];
                    tur.paciente.apellido = (string)con.lector["apellido"];
                    tur.paciente.dni = (string)con.lector["dni"];

                    turnoList.Add(tur);
                }
                return turnoList;
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

        public List<Turno> turnos_de_medicos(int id)
        {
            List<Turno> turnosList = new List<Turno>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT dp.nombre,dp.apellido,dp.dni,t.fecha,t.hora FROM Turnos t, Pacientes p, Datos_Personales dp WHERE t.ID_Paciente=p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales  AND t.ID_Doctor='" + id + "' AND t.estado='1' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Turno tur = new Turno();
                    tur.fecha = con.lector["fecha"].ToString();
                    tur.hora =Convert.ToInt32(con.lector["hora"]);
                    tur.paciente = new Paciente();
                    tur.paciente.nombre = (string)con.lector["nombre"];
                    tur.paciente.apellido = (string)con.lector["apellido"];
                    tur.paciente.dni = (string)con.lector["dni"];
                    turnosList.Add(tur);
                }
                return turnosList;
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
                con.consultar("DELETE FROM Turnos WHERE IDTurno='" + id + "' ");
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
