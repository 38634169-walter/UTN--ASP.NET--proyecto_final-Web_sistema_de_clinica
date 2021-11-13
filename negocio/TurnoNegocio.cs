﻿using System;
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
                con.consultar("SELECT p.IDPaciente,d.IDDoctor,s.IDSecretaria,e.IDEspecialidad,dPaciente.nombre nomP,dPaciente.apellido apeP,dPaciente.dni dniP,dDoctores.nombre nomD, dDoctores.apellido apeD,dSecretaria.nombre nomS,dSecretaria.apellido apeS,e.nombre nomE,t.fecha, t.hora FROM Turnos t, Pacientes p, Datos_Personales dPaciente,Doctores d,Empleados eDoctores, Datos_Personales dDoctores,Secretarias s, Empleados eSecretaria, Datos_Personales dSecretaria,Especialidades e WHERE t.ID_Paciente = p.IDPaciente AND p.ID_DatosPersonales=dPaciente.IDDatosPersonales AND t.ID_Doctor =d.IDDoctor AND d.ID_Empleado=eDoctores.IDEmpleado AND eDoctores.ID_DatosPersonales=dDoctores.IDDatosPersonales AND t.ID_Secretaria=s.IDSecretaria AND s.ID_Empleado=eSecretaria.IDEmpleado AND eSecretaria.ID_DatosPersonales=dSecretaria.IDDatosPersonales AND t.ID_Especialidad=e.IDEspecialidad AND t.IDTurno = '" + id + "' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    turno.id = id;
                    turno.fecha =Convert.ToDateTime(con.lector["fecha"]);
                    turno.hora = Convert.ToInt32(con.lector["hora"]);

                    turno.especialidad = new Especialidad();
                    turno.especialidad.id = Convert.ToInt32(con.lector["IDEspecialidad"]);
                    turno.especialidad.nombre = (string)con.lector["nomE"];

                    turno.doctor = new Doctor();
                    turno.doctor.id = Convert.ToInt32(con.lector["IDDoctor"]);
                    turno.doctor.nombre = (string)con.lector["nomD"];
                    turno.doctor.apellido = (string)con.lector["apeD"];

                    turno.secretaria = new Secretaria();
                    turno.secretaria.id = Convert.ToInt32(con.lector["IDSecretaria"]);
                    turno.secretaria.nombre = (string)con.lector["nomS"];
                    turno.secretaria.apellido = (string)con.lector["apeS"];

                    turno.paciente = new Paciente();
                    turno.paciente.id = Convert.ToInt32(con.lector["IDPaciente"]);
                    turno.paciente.nombre = (string)con.lector["nomP"];
                    turno.paciente.apellido = (string)con.lector["apeP"];
                    turno.paciente.dni = (string)con.lector["dniP"];
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
        
        public List<Turno> listar(string buscarPor, string buscar,string buscar2)
        {
            string consulta = "";
            switch (buscarPor)
            {
                case "lista":
                    consulta = "SELECT t.IDTurno,p.IDPaciente,e.IDEspecialidad,dp.dni,dp.nombre AS nombrePaciente,dp.apellido,e.nombre AS nombreEspecialidad,t.hora,t.fecha FROM Turnos t, Pacientes p,Datos_Personales dp ,Especialidades e WHERE t.ID_Paciente = p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales AND t.ID_Especialidad = e.IDEspecialidad AND t.estado='1' ";
                    break;
                case "dni":
                    consulta = "SELECT t.IDTurno,p.IDPaciente,e.IDEspecialidad,dp.dni,dp.nombre AS nombrePaciente,dp.apellido,e.nombre AS nombreEspecialidad,t.hora,t.fecha FROM Turnos t, Pacientes p,Datos_Personales dp , Especialidades e WHERE t.ID_Paciente = p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales AND t.ID_Especialidad = e.IDEspecialidad AND dp.dni = '" + buscar + "' AND t.estado='1' ";
                    break;
                case "fecha":
                    consulta = "SELECT t.IDTurno,p.IDPaciente,e.IDEspecialidad,dp.dni,dp.nombre AS nombrePaciente,dp.apellido,e.nombre AS nombreEspecialidad,t.hora,t.fecha FROM Turnos t, Pacientes p,Datos_Personales dp , Especialidades e WHERE t.ID_Paciente = p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales AND t.ID_Especialidad = e.IDEspecialidad AND t.fecha = '" + buscar + "' AND t.estado='1' ";
                    break;
                case "fecha y dni":
                    consulta = "SELECT t.IDTurno,p.IDPaciente,e.IDEspecialidad,dp.dni,dp.nombre AS nombrePaciente,dp.apellido,e.nombre AS nombreEspecialidad,t.hora,t.fecha FROM Turnos t, Pacientes p,Datos_Personales dp , Especialidades e WHERE t.ID_Paciente = p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales AND t.ID_Especialidad = e.IDEspecialidad AND t.fecha = '" + buscar + "' AND dp.dni = '" + buscar2 + "' AND t.estado='1' ";
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
                    tur.fecha = Convert.ToDateTime(con.lector["fecha"]);
                    

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

        public List<Turno> turnos_de_medicos(int id,string buscarPor,string buscar)
        {
            List<Turno> turnosList = new List<Turno>();
            ConexionDB con = new ConexionDB();

            string consulta = "";
            switch (buscarPor)
            {
                case "todo":
                    consulta = "SELECT dp.nombre,dp.apellido,dp.dni,t.fecha,t.hora FROM Turnos t, Pacientes p, Datos_Personales dp WHERE t.ID_Paciente=p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales  AND t.ID_Doctor='" + id + "' AND t.estado='1' ";
                    break;
                case "fecha":
                    consulta = "SELECT dp.nombre,dp.apellido,dp.dni,t.fecha,t.hora FROM Turnos t, Pacientes p, Datos_Personales dp WHERE t.ID_Paciente=p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales  AND t.ID_Doctor='" + id + "' AND t.fecha='" + buscar + "' AND t.estado='1' ";
                    break;
            }

            try
            {
                con.consultar(consulta);
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Turno tur = new Turno();
                    tur.fecha = Convert.ToDateTime(con.lector["fecha"]);
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
        public List<Turno> turnos_medico_especialidad_fecha(Turno turno)
        {
            List<Turno> turnoList = new List<Turno>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT * FROM Turnos WHERE ID_Doctor = '" + turno.doctor.id + "' AND ID_Especialidad = '" + turno.especialidad.id + "' AND fecha = '" + turno.fecha.ToString("yyyy-MM-dd") + "' AND estado = 1 ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Turno tur = new Turno();
                    tur.id = Convert.ToInt32(con.lector["IDTurno"]);
                    tur.hora = Convert.ToInt32(con.lector["hora"]);
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

        public void agregar(Turno turno)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("INSERT INTO Turnos(ID_Paciente,ID_Especialidad,ID_Doctor,ID_Secretaria,fecha,hora,estado) VALUES(@paciente,@especialidad,@doctor,@secretaria,'" + turno.fecha.ToString("yyyy-MM-dd") + "','" + turno.hora + "', '1' ) ");
                con.setear_parametros("@paciente",turno.paciente.id);
                con.setear_parametros("@especialidad",turno.especialidad.id);
                con.setear_parametros("@doctor",turno.doctor.id);
                con.setear_parametros("@secretaria",turno.secretaria.id);
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
