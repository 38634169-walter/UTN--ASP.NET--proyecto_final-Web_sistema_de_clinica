using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class HistorialNegocio
    {
        public List<Historial> buscar_historial_paciente(int id)
        {
            List<Historial> historialList = new List<Historial>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT h.observaciones,h.fecha,dPaciente.nombre nomP,dPaciente.apellido apeP,dDoctor.nombre nomD,dDoctor.apellido apeD FROM Historiales h, Pacientes p, Doctores d, Datos_Personales dPaciente,Datos_Personales dDoctor,Empleados e, Turnos t WHERE t.ID_Paciente=p.IDPaciente AND t.IDTurno=h.IDHistorial AND p.ID_DatosPersonales=dPaciente.IDDatosPersonales AND t.ID_Doctor=d.IDDoctor AND d.ID_Empleado = e.IDEmpleado AND e.ID_DatosPersonales=dDoctor.IDDatosPersonales AND t.ID_Paciente = '" + id + "'  ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Historial his = new Historial();

                    his.observacion = (string)con.lector["observaciones"];
                    his.fecha = Convert.ToDateTime(con.lector["fecha"]);
                    his.paciente= new Paciente();
                    his.paciente.nombre = (string)con.lector["nomP"];
                    his.paciente.apellido = (string) con.lector["apeP"];

                    his.doctor = new Doctor();
                    his.doctor.nombre = (string)con.lector["nomD"];
                    his.doctor.apellido = (string)con.lector["apeD"];
                    
                    historialList.Add(his);
                }
                return historialList;
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

        public Historial buscar_historia_paciente(int id)
        {
            Historial his = new Historial();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT h.observaciones,h.fecha,dp.nombre nomP,dp.apellido apeP FROM Historiales h, Pacientes p, Datos_Personales dp, Turnos t WHERE t.ID_Paciente=p.IDPaciente AND t.IDTurno=h.IDHistorial AND p.ID_DatosPersonales=dp.IDDatosPersonales AND t.IDTurno = '" + id + "' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    his.observacion = (string)con.lector["observaciones"];
                    his.fecha = Convert.ToDateTime(con.lector["fecha"]);
                    his.paciente = new Paciente();
                    his.paciente.nombre = (string)con.lector["nomP"];
                    his.paciente.apellido = (string)con.lector["apeP"];
                }
                return his;
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

        public void agregar(Historial historia)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("INSERT INTO Historiales (IDHistorial,observaciones,fecha) VALUES ('" + historia.id + "','" + historia.observacion + "','" + historia.fecha.ToString("yyyy-MM-dd") + "' )");
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
