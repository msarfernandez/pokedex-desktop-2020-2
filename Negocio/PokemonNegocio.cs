using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> listado = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source=MAXIMILIANO8285\\SQLEXPRESS; initial catalog=POKEMON_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Nombre, Numero, Imagen from POKEMONS";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    //aux.Nombre = (string)lector["Nombre"];
                    aux.Nombre = lector.GetString(0);

                    if (!Convert.IsDBNull(lector["Numero"]))
                        aux.Numero = lector.GetInt32(1);

                    aux.ImagenURL = (string)lector[2];

                    listado.Add(aux);
                }

            return listado;
            }
            catch (SqlException ex2)
            {
                //throw ex2;
                throw new NoMeGustaException("No me gusta lo que estas haciendo...");
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

        public void agregar(Pokemon nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "data source=MAXIMILIANO8285\\SQLEXPRESS; initial catalog=POKEMON_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into POKEMONS (Nombre, Imagen, IdTipo) Values ('" + nuevo.Nombre + "', @Imagen, @IdTipo)";
                // comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Imagen", nuevo.ImagenURL);
                comando.Parameters.AddWithValue("@IdTipo", nuevo.Tipo.Id.ToString());
                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();

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
