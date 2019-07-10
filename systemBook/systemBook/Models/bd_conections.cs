using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace systemBook.Models
{
    public static class Bd_conections
    {
        static string conexion = "Data source=DESKTOP-637FMM1\\SQLEXPRESS;Initial Catalog = libros; Integrated Security = True";

        public static List<Escritor> AllEscritores()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("allUsers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = 1;

                conn.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    List<Escritor> escritores = new List<Escritor>();
                    while (r.Read())
                    {
                        escritores.Add(new Escritor()
                        {
                            Id_escritor = (int)r["id_escritor"],
                            Nombre = (string)r["Nombre"],
                            Apellido = (string)r["Apellido"],
                            Direccion = (string)r["Direccion"]
                        });
                    }
                    return escritores;
                }
            }

        }

        public static Escritor singleEscritor(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("allUsers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();
                    Escritor es = new Escritor()
                    {
                        Id_escritor = (int)r["id_escritor"],
                        Nombre = (string)r["Nombre"],
                        Apellido = (string)r["Apellido"],
                        Direccion = (string)r["Direccion"]
                    };
                    return es;
                }
            }
        }
        public static void AddEscritores(Escritor NewEscritor)
        {
            if (NewEscritor == null)
            {
                throw new ArgumentNullException(nameof(NewEscritor));
            }

            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("addEscritor", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@nombre", NewEscritor.Nombre);
                cmd.Parameters.AddWithValue("@apellido", NewEscritor.Apellido);
                cmd.Parameters.AddWithValue("@direccion", NewEscritor.Direccion);
                //cmd.Parameters.Add("@idLibro", SqlDbType.Int).Value = 1;

                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }
        
    }
}
