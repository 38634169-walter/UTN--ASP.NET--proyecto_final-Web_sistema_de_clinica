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
                con.consultar("SELECT h.observaciones,h.fecha,dPaciente.nombre nomP,dPaciente.apellido apeP,dDoctor.nombre nomD,dDoctor.apellido apeD FROM Historiales h, Pacientes p, Doctores d, Datos_Personales dPaciente,Datos_Personales dDoctor,Empleados e WHERE h.ID_Paciente=p.IDPaciente AND p.ID_DatosPersonales=dPaciente.IDDatosPersonales AND h.ID_Doctor=d.IDDoctor AND d.ID_Empleado = e.IDEmpleado AND e.ID_DatosPersonales=dDoctor.IDDatosPersonales AND h.ID_Paciente = '" + id + "' ");
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
        }
        public void agregar(Historial historia)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("INSERT INTO Historiales (ID_Paciente,ID_Doctor,observaciones,fecha) VALUES (@cliente,@personal,'" + historia.observacion + "','" + historia.fecha.ToString("yyyy-MM-dd") + "' )");
                con.setear_parametros("@cliente",historia.paciente.id);
                con.setear_parametros("@personal",historia.doctor.id);
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
