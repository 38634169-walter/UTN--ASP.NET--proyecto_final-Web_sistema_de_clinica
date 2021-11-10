using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class PersonaNegocio
    {
        public List<Persona> listar_datos_personales()
        {
            List<Persona> personaList = new List<Persona>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT * FROM Datos_Personales");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Persona persona = new Persona();
                    persona.dni = (string)con.lector["dni"];
                    personaList.Add(persona);
                }
                return personaList;
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
