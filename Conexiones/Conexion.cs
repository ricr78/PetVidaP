using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoPetVida.Conexiones
{
    public class Conexion
    {
        private readonly string conexionSQL;

        public Conexion()
        {
            conexionSQL = "Data source=Ricardo\\SQLEXPRESS; Database=PetVida; Integrated security=true; Encrypt=false;";
           // conexionSQL = "Data source=DESKTOP-R8G4RT1\\VE_SERVER ; Database=PetVida; Integrated security=true; Encrypt=false;";
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(conexionSQL);
        }

        // Método para ejecutar comandos (INSERT, UPDATE, DELETE)
        public void EjecutarComando(string query, Dictionary<string, object> parametros)
        {
            using (SqlConnection conn = ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parametros != null)
                {
                    foreach (var param in parametros)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Método para ejecutar consultas que devuelven datos (SELECT)
        public DataTable EjecutarConsulta(string query, Dictionary<string, object> parametros = null)
        {
            using (SqlConnection conn = ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parametros != null)
                {
                    foreach (var param in parametros)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}