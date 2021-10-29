using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelo;
using conexion;

namespace negocio
{
    public class CargoNegocio
    {
        public List<Cargo> listar()
        {
            List<Cargo> cargoList = new List<Cargo>();
            ConexionDB con = new ConexionDB();
            try
            {
                con.consultar("SELECT ID, nombre FROM Cargos");
                con.ejecutar_lectura();
                while (con.lector.Read())
                {
                    Cargo car = new Cargo();
                    car.id = Convert.ToInt32(con.lector["ID"]);
                    car.nombre = (string)con.lector["nombre"];
                    cargoList.Add(car);
                }
                return cargoList;
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
