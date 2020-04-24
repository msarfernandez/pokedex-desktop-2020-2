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
                comando.CommandText = "select P.Id as IdPoke, P.Nombre, P.Numero, P.Imagen, T.Id,T.Descripcion from POKEMONS P, TIPOS T Where P.IdTipo=T.Id";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    //aux.Nombre = (string)lector["Nombre"];
                    aux.Nombre = lector.GetString(1);

                    if (!Convert.IsDBNull(lector["Numero"]))
                        aux.Numero = lector.GetInt32(2);

                    aux.ImagenURL = (string)lector[3];

                    aux.Tipo = new Tipo();
                    aux.Tipo.Id = (int)lector["Id"];
                    aux.Id = (int)lector["IdPoke"];
                    aux.Tipo.Descripcion = (string)lector["Descripcion"];

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
                comando.CommandText = "insert into POKEMONS (Nombre, Imagen, IdTipo, Precio) Values ('" + nuevo.Nombre + "', @Imagen, @IdTipo, @Precio)";
                // comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Imagen", nuevo.ImagenURL);
                comando.Parameters.AddWithValue("@IdTipo", nuevo.Tipo.Id);
                comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
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

        public void modificar(Pokemon nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "data source=MAXIMILIANO8285\\SQLEXPRESS; initial catalog=POKEMON_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "update POKEMONS set Nombre = @Nombre, Imagen = @Imagen, IdTipo = @IdTipo, Precio = @Precio Where Id=@Id";
                // comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                comando.Parameters.AddWithValue("@Imagen", nuevo.ImagenURL);
                comando.Parameters.AddWithValue("@IdTipo", nuevo.Tipo.Id);
                comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
                comando.Parameters.AddWithValue("@Id", nuevo.Id);

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
