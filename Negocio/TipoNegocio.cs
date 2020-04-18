using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class TipoNegocio
    {
        public List<Tipo> listar()
        {
            List<Tipo> listado = new List<Tipo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source=MAXIMILIANO8285\\SQLEXPRESS; initial catalog=POKEMON_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Id, Descripcion from TIPOS";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Tipo aux = new Tipo();
                    aux.Id = lector.GetInt32(0);
                    aux.Descripcion = lector.GetString(1);

                    listado.Add(aux);
                }

                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
