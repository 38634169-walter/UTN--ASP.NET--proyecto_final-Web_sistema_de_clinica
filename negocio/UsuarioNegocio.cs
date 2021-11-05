using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using conexion;
using modelo;

namespace negocio
{
    public class UsuarioNegocio
    {
        public Persona validarUsu(string usuario, string clave, ref bool validar)
        {
            ConexionDB con = new ConexionDB();
            Persona persona = new Persona();

            try
            {
                con.consultar("SELECT u.ID AS ID_Usuario,p.nombre AS nombrePersona,p.apellido AS apellido ,c.nombre AS cargo FROM Usuarios u, Personal p, Especialidades e,Personal_Especialidades pe,Cargos c WHERE u.ID=p.ID AND p.ID=pe.ID_Personal AND pe.ID_Especialidad=e.ID AND e.ID_Cargo=c.ID AND usuario = '" + usuario +"' AND clave = '" + clave +"' AND u.estado='1' ");
                con.ejecutar_lectura();

                while(con.lector.Read())
                {
                    persona.nombre = (string)con.lector["nombrePersona"];
                    persona.apellido = (string)con.lector["apellido"];
                    persona.usuario = new Usuario();
                    persona.usuario.id = Convert.ToInt32(con.lector["ID_Usuario"]);
                    persona.usuario.cargo = new Rol();
                    persona.usuario.cargo.nombre = (string)con.lector["cargo"];
                    validar = true;
                }
                return persona;
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
