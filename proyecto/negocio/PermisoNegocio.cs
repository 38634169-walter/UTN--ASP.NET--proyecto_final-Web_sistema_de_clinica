using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class PermisoNegocio
    {
        public List<Permiso> listar(string listarPor,string buscar)
        {
            List<Permiso> permisosList = new List<Permiso>();
            ConexionDB con = new ConexionDB();
            string consulta = "";
            switch (listarPor)
            {
                case "todos":
                    consulta = "SELECT DISTINCT p.nombre AS nombreP, IDPermiso FROM Permisos p, Roles r, Roles_Permisos rp, Usuarios u WHERE u.ID_Rol=r.IDRol AND r.IDRol=rp.ID_Rol AND rp.ID_Permiso=p.IDPermiso";
                    break;
                case "idUsuario":
                    consulta = "SELECT p.nombre AS nombreP, IDPermiso FROM Permisos p, Roles r, Roles_Permisos rp, Usuarios u WHERE u.ID_Rol=r.IDRol AND r.IDRol=rp.ID_Rol AND rp.ID_Permiso=p.IDPermiso AND u.IDUsuario='" + buscar + "' ";
                    break;
            }
            try
            {
                con.consultar(consulta);
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Permiso permiso = new Permiso();
                    permiso.id = Convert.ToInt32(con.lector["IDPermiso"]);
                    permiso.nombre = (string)con.lector["nombreP"];
                    permisosList.Add(permiso);
                }
                return permisosList;
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
