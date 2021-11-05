 public class PersonaNegocio
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    {
        public Persona buscar_por_id(int id)
        {
            Persona persona = new Persona();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT p.nombre, p.apellido, p.dni, u.usuario,u.clave FROM Personal p, Usuarios u WHERE u.ID=p.ID AND p.ID = '" + id + "'  AND p.estado='1' ");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    persona.id = id; 
                    persona.nombre = (string)con.lector["nombre"];
                    persona.dni = (string)con.lector["dni"];
                    persona.apellido = (string)con.lector["apellido"];
                    persona.usuario = new Usuario();
                    persona.usuario.usuario = (string)con.lector["usuario"];
                    persona.usuario.clave = (string)con.lector["clave"];
                }
                return persona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregar(Persona personal)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("INSERT INTO Personal(nombre,apellido,dni,estado) VALUES ('" + personal.nombre + "','" + personal.apellido + "', '" + personal.dni + "','1' ) ");
                con.ejecutar_escritura();
                con.cerrar_conexion();
                
                int id=obtener_ultimo_id();

                ConexionDB con2 = new ConexionDB();
                con2.consultar("INSERT INTO Personal_Especialidades(ID_Personal,ID_Especialidad) VALUES (@personal,@especialidad) ");
                con2.setear_parametros("@personal", id);
                con2.setear_parametros("@especialidad", personal.especialidad.id);
                con2.ejecutar_escritura();
                con2.cerrar_conexion();

                ConexionDB con3 = new ConexionDB();
                con3.consultar("INSERT INTO TurnosTrabajo(ID_Personal,horarioInicio,horarioFin) VALUES (@personal,'" + personal.horario.horaInicio + "', '" + personal.horario.horaFin + "') ");
                con3.setear_parametros("@personal",id);
                con3.ejecutar_escritura();
                con3.cerrar_conexion();
                
                ConexionDB con4 = new ConexionDB();
                con4.consultar("INSERT INTO Usuarios(ID,usuario,clave,estado) VALUES (@usuario,'" + personal.usuario.usuario + "', '" + personal.usuario.clave + "',@estado ) ");
                con4.setear_parametros("@usuario",id);
                con4.setear_parametros("@estado",1);
                con4.ejecutar_escritura();
                con4.cerrar_conexion();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificar(Persona personal)
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("UPDATE Personal SET nombre=@nombre,apellido=@apellido,dni=@dni WHERE ID = '" + personal.id + "' ");
                con.setear_parametros("@nombre",personal.nombre);
                con.setear_parametros("@apellido",personal.apellido);
                con.setear_parametros("@dni",personal.dni);
                con.ejecutar_escritura();

                con.cerrar_conexion();

                ConexionDB con2 = new ConexionDB();
                con2.consultar("UPDATE Usuarios SET usuario=@usuario,clave=@clave WHERE ID = '" + personal.id + "' ");
                con2.setear_parametros("@usuario",personal.usuario.usuario);
                con2.setear_parametros("@clave",personal.usuario.clave);
                con2.ejecutar_escritura();
                
                con2.cerrar_conexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Persona> listar(string buscarPor,string buscar)
        {
            string consulta = "";
            switch (buscarPor)
            {
                case "todo":
                    consulta = "SELECT DISTINCT p.ID AS ID_Personal,p.nombre AS nombreP, p.apellido,p.dni FROM Personal p, Especialidades e, Cargos c, Personal_Especialidades pe WHERE p.ID=pe.ID_Personal AND pe.ID_Especialidad=e.ID AND e.ID_Cargo=c.ID AND c.nombre='Doctor'  AND p.estado='1' ";
                    break;
                case "especialidad":
                    consulta = "SELECT DISTINCT p.ID AS ID_Personal,p.nombre AS nombreP, p.apellido,p.dni FROM Personal p, Especialidades e, Cargos c, Personal_Especialidades pe WHERE p.ID=pe.ID_Personal AND pe.ID_Especialidad=e.ID AND e.ID_Cargo=c.ID AND c.nombre='Doctor' AND e.ID='" + buscar + "' AND p.estado='1' ";
                    break;
            }
            List<Persona> personalList = new List<Persona>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar(consulta);
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Persona per = new Persona();
                    per.id = Convert.ToInt32(con.lector["ID_Personal"]);
                    per.nombre = (string)con.lector["nombreP"];
                    per.apellido = (string)con.lector["apellido"];
                    per.nombreCompleto = (string)con.lector["nombreP"];
                    per.nombreCompleto += " ";
                    per.nombreCompleto += (string)con.lector["apellido"];
                    per.dni = (string)con.lector["dni"];
                    personalList.Add(per);
                }
                return personalList;
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

        public int obtener_ultimo_id()
        {
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT TOP 1 * FROM Personal ORDER BY ID DESC");
                con.ejecutar_lectura();
                int id=1;
                while (con.lector.Read())
                {
                    id = Convert.ToInt32(con.lector["ID"]);
                }
                return id;
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
 