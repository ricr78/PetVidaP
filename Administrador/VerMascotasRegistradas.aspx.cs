using ProyectoPetVida.Conexiones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPetVida.Administrador
{
    public partial class VerMascotasRegistradas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMascotas();
            }
        }
        

        private void CargarMascotas(string nombreMascota="")
        {
            Conexion conexion = new Conexion(); // Clase de conexión

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string query = @"
            SELECT 
                m.IdMascota, 
                m.NombreMascota, 
                m.TipoAnimal, 
                m.pesoKg, 
                m.Edad, 
                u.Nombre + ' ' + u.Apellido AS NombreUsuario
            FROM mascota m
            INNER JOIN usuario u ON m.IdUsuario = u.IdUsuario";
                
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    
                    

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            gvMascotas.DataSource = reader;
                            gvMascotas.DataBind();
                        }
                        else
                        {
                            gvMascotas.DataSource = null;
                            gvMascotas.DataBind();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                        "Swal.fire('Sin resultados', 'No se encontraron mascotas con ese nombre.', 'info');", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error al cargar las mascotas: {ex.Message}');</script>");
                    }
                }
            }
        }

    }
}