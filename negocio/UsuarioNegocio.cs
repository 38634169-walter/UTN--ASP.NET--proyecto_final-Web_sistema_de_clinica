using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> lista_usuarios()
        {
            List<Usuario> usuarioList = new List<Usuario>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT * FROM Usuarios WHERE estado = 1");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Usuario usuario= new Usuario();
                    usuario.usuario = (string)con.lector["usuario"];
                    usuario.clave = (string)con.lector["clave"];
                    usuarioList.Add(usuario);
                }
                return usuarioList;
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
        public Empleado validarUsu(string usuario,string  clave, ref bool validar)
        {
            Empleado empleado = new Empleado();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT u.IDUsuario,dp.nombre,dp.apellido FROM Empleados E, Datos_Personales dp, Usuarios u WHERE e.ID_DatosPersonales=dp.IDDatosPersonales AND e.IDEmpleado =u.IDUsuario AND u.usuario= '" + usuario + "' AND u.clave = '" + clave + "' AND u.estado=1");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    empleado.nombre = (string)con.lector["nombre"];
                    empleado.apellido = (string)con.lector["apellido"];
                    empleado.usuario = new Usuario();
                    empleado.usuario.id = Convert.ToInt32(con.lector["IDUsuario"]);
                    validar = true;
                }
                return empleado;
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
