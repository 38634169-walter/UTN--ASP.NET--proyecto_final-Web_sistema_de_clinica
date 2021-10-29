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
                con.consultar("SELECT h.observaciones,c.nombre AS nombreCliente,c.apellido AS apellidoCliente, p.nombre AS nombrePersonal, p.apellido AS apellidoPersonal FROM Historiales h, Clientes c, Personal p WHERE h.ID_Cliente=c.ID AND h.ID_Personal=p.ID AND h.ID_Cliente='" + id + "' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Historial his = new Historial();

                    his.observacion = (string)con.lector["observaciones"];
                    his.cliente = new Cliente();
                    his.cliente.nombre = (string)con.lector["nombreCliente"];
                    his.cliente.apellido = (string) con.lector["apellidoCliente"];

                    his.personal = new Personal();
                    his.personal.nombre = (string)con.lector["nombrePersonal"];
                    his.personal.apellido = (string) con.lector["apellidoPersonal"];
                    
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
                con.consultar("INSERT INTO Historiales (ID_Cliente,ID_Personal,observaciones) VALUES (@cliente,@personal,'" + historia.observacion + "') ");
                con.setear_parametros("@cliente",historia.cliente.id);
                con.setear_parametros("@personal",historia.personal.id);
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
