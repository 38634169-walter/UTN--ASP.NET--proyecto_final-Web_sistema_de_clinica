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
        public Personal validarUsu(string usuario, string clave, ref bool validar)
        {
            ConexionDB con = new ConexionDB();
            Personal persona = new Personal();

            try
            {
                con.consultar("SELECT u.ID AS ID_Usuario,p.nombre AS nombrePersona,p.apellido AS apellido ,c.nombre AS cargo FROM Usuarios u, Personal p, Especialidades e,Cargos c WHERE u.ID=p.ID AND p.ID_Especialidad=e.ID AND e.ID_Cargo=c.ID AND usuario = '" + usuario +"' AND clave = '" + clave +"'");
                con.ejecutar_lectura();

                while(con.lector.Read())
                {
                    persona.nombre = (string)con.lector["nombrePersona"];
                    persona.apellido = (string)con.lector["apellido"];
                    persona.usuario = new Usuario();
                    persona.usuario.id = Convert.ToInt32(con.lector["ID_Usuario"]);
                    persona.especialidad = new Especialidad();
                    persona.especialidad.cargo = new Cargo();
                    persona.especialidad.cargo.nombre = (string)con.lector["cargo"];
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
