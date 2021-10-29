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
                con.consultar("SELECT t.ID AS ID_Turno, e.ID AS ID_Especialidad, c.ID AS ID_Cliente, c.dni, e.nombre AS nombreEspecialidad FROM Turnos t, Clientes c, Especialidades e WHERE t.ID_Cliente=c.ID AND t.ID_Especialidad = e.ID AND t.ID = '" + id + "' " );
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    turno.id = id;
                    
                    turno.especialidad = new Especialidad();
                    turno.especialidad.id = Convert.ToInt32(con.lector["ID_Especialidad"]);
                    turno.especialidad.nombre = (string)con.lector["nombreEspecialidad"];

                    turno.cliente = new Cliente();
                    turno.cliente.id = Convert.ToInt32(con.lector["ID_Cliente"]);
                    turno.cliente.dni = (string)con.lector["dni"];
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
        public List<Turno> listar()
        {
            List<Turno> turnoList = new List<Turno>();
            ConexionDB con = new ConexionDB();
            try
            {
                
                con.consultar("SELECT t.ID AS ID_Turno, e.ID AS ID_Especialidad, c.ID AS ID_Cliente, c.dni,c.nombre AS nombreCliente,c.apellido AS apellidoCliente,e.nombre AS nombreEspecialidad FROM Turnos t, Clientes c, Especialidades e WHERE t.ID_Cliente = c.ID AND t.ID_Especialidad = e.ID");

                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Turno tur = new Turno();
                    tur.id = Convert.ToInt32(con.lector["ID_Turno"]);
                    
                    tur.especialidad = new Especialidad();
                    tur.especialidad.id = Convert.ToInt32(con.lector["ID_Especialidad"]);
                    tur.especialidad.nombre = (string)con.lector["nombreEspecialidad"];

                    tur.cliente = new Cliente();
                    tur.cliente.id = Convert.ToInt32(con.lector["ID_Cliente"]);
                    tur.cliente.nombre = (string)con.lector["nombreCliente"];
                    tur.cliente.apellido = (string)con.lector["apellidoCliente"];
                    tur.cliente.dni = (string)con.lector["dni"];

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
                con.consultar("SELECT c.nombre AS nombreC,c.apellido AS apellidoC,c.dni AS dniC FROM Turnos t, Clientes c WHERE t.ID_Cliente=c.ID AND t.ID_Personal='" + id + "' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Turno tur = new Turno();
                    tur.cliente = new Cliente();
                    tur.cliente.nombre = (string)con.lector["nombreC"];
                    tur.cliente.apellido = (string)con.lector["apellidoC"];
                    tur.cliente.dni = (string)con.lector["dniC"];
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
    }
}
