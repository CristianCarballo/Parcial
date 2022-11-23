using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Parcial.Models
{
    public class GestorBD              //Data Source = 172.16.140.13; Initial Catalog = ParcialPro3Noche; User Id = alumno1w1; Password = alumno1w1
    {

        private static string cadena = @"Data Source=CRISTIAN\EQUIPO;Initial Catalog=Autos;Integrated Security=True";

      public List<Marcas> Marcas()
      {
            List<Marcas> marcas = new List<Marcas>();
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = @"Select * from Marcas";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    Marcas m = new Marcas(id, nombre);
                    marcas.Add(m);
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            return marcas;
      }


        public void InsertarAuto(Autos nuevo)
        {
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = @"INSERT INTO Autos(patente,idMarca,km,promocion,precio)
                                           values(@patente,@idMarca,@km,@promocion,@precio)";
                cmd.Parameters.Add(new SqlParameter("@patente", nuevo.Patente));
                cmd.Parameters.Add(new SqlParameter("@idMarca", nuevo.Marca.IdMarca));
                cmd.Parameters.Add(new SqlParameter("@km", nuevo.Km));
                cmd.Parameters.Add(new SqlParameter("@promocion", nuevo.Promocion));
                cmd.Parameters.Add(new SqlParameter("@precio", nuevo.PrecioReal));
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }

        }


        public List<Autos> AutosOferta()
        {
            List<Autos> autos = new List<Autos>();
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();  
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = @"Select a.*, m.nombre 
                                    from Autos a inner join Marcas m on a.idMarca = m.idMarca 
                                    where promocion = 1   ";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string patente = reader.GetString(1);
                    int marca = reader.GetInt32(2);
                    int km = reader.GetInt32(3);
                    bool promocion = reader.GetBoolean(4);
                    float precio = reader.GetFloat(5);
                    string nomMarca = reader.GetString(6);
                    Autos a = new Autos(patente,marca,km,promocion,precio);
                    a.Marca.Nombre = nomMarca;
                    autos.Add(a);
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return autos;
        }



        public Autos AutoMenosKM()
        {
            Autos a = null;

            SqlConnection con = new SqlConnection(cadena);
            try
            {
               
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = @"Select *, m.nombre 
                                    from Autos a inner join Marcas m on a.idMarca = m.idMarca
                                    where km > 0
                                    ORDER BY 3
                                    ";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string patente = reader.GetString(1);
                    int marca = reader.GetInt32(2);
                    int km = reader.GetInt32(3);
                    bool promocion = reader.GetBoolean(4);
                    float precio = reader.GetFloat(5);
                    string nomMarca = reader.GetString(6);
                    a = new Autos(patente, marca, km, promocion, precio);
                    a.Marca.Nombre = nomMarca;
                   
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return a;
        }
    }
}