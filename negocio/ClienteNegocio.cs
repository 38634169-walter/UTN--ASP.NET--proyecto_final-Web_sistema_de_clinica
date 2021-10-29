using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class ClienteNegocio
    {
        public Cliente buscar_por_id(int id)
        {
            Cliente cli = new Cliente();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT * FROM Clientes WHERE ID = '" + id + "' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    cli.id = id;
                    cli.nombre = (string)con.lector["nombre"];
                    cli.apellido = (string)con.lector["apellido"];
                    cli.dni = (string)con.lector["dni"];
                }
                return cli;
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

        public void modificar(Cliente cliente)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("UPDATE Clientes SET nombre=@nombre, apellido=@apellido, dni=@dni WHERE ID = '" + cliente.id + "' ");
                con.setear_parametros("@nombre",cliente.nombre);
                con.setear_parametros("@apellido",cliente.apellido);
                con.setear_parametros("@dni",cliente.dni);
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

        public void agregar(Cliente cliente)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("INSERT INTO Clientes(nombre,apellido,dni) VALUES ('" + cliente.nombre + "', '" + cliente.apellido +"', '" + cliente.dni + "'  ) " );
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

        public List<Cliente> listar()
        {
            List<Cliente> clienteList = new List<Cliente>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT ID,nombre,apellido,dni FROM Clientes");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Cliente cli = new Cliente();
                    cli.id = Convert.ToInt32(con.lector["ID"]);
                    cli.nombre = (string)con.lector["nombre"];
                    cli.apellido = (string)con.lector["apellido"];
                    cli.dni = (string)con.lector["dni"];
                    clienteList.Add(cli);
                }
                return clienteList; 
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
        
        public List<Cliente> listar_historial_clientes()
        {
            List<Cliente> clienteList = new List<Cliente>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT ID,nombre,apellido,dni, FROM Clientes");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Cliente cli = new Cliente();
                    cli.id = Convert.ToInt32(con.lector["ID"]);
                    cli.nombre = (string)con.lector["nombre"];
                    cli.apellido = (string)con.lector["apellido"];
                    cli.dni = (string)con.lector["dni"];
                    clienteList.Add(cli);
                }
                return clienteList; 
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
