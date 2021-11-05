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
                con.consultar("SELECT h.observaciones,h.fecha,dp.nombre,dp.apellido,d.IDDoctor FROM Historiales h, Pacientes p, Doctores d, Datos_Personales dp WHERE h.ID_Paciente=p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales AND h.ID_Doctor=d.IDDoctor AND h.ID_Paciente='" + id + "' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Historial his = new Historial();

                    his.observacion = (string)con.lector["observaciones"];
                    his.fecha = Convert.ToString(con.lector["fecha"]);
                    his.paciente= new Paciente();
                    his.paciente.nombre = (string)con.lector["nombre"];
                    his.paciente.apellido = (string) con.lector["apellido"];

                    his.doctor = new Doctor();
                    his.doctor.id = Convert.ToInt32(con.lector["IDDoctor"]);
                    
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
                con.consultar("INSERT INTO Historiales (ID_Paciente,ID_Doctor,observaciones,fecha) VALUES (@cliente,@personal,'" + historia.observacion + "','" + historia.fecha + "' )");
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
