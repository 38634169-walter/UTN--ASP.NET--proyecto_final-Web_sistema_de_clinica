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
    }
}
