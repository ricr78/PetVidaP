using ProyectoPetVida.Conexiones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPetVida.Usuario
{
    public partial class VerCita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCitas();
            }
        }
        private void CargarCitas()
        {
            // Verifica que el usuario esté autenticado y obtén su ID
            int idUsuario;
            if (Session["IdUsuario"] == null || !int.TryParse(Session["IdUsuario"].ToString(), out idUsuario))
            {
                Response.Redirect("~/Login/InicioSesion.aspx"); // Redirigir al login si no está autenticado
                return;
            }

            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string query = @"
                            SELECT 
                            CONVERT(VARCHAR, ec.FechaCita, 103) AS FechaCita, -- Convierte la fecha al formato dd/MM/yyyy
                            CONVERT(VARCHAR(5), ec.HoraCita, 108) AS HoraCita -- Convierte la hora al formato HH:mm
                            FROM enviarCitas ec
                            
                            WHERE ec.IdUsuario = @IdUsuario
                            ORDER BY ec.FechaCita, ec.HoraCita";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if(reader.HasRows)
                        {
                            // Enlaza los datos a la GridView
                            gvCitasUsuario.DataSource = reader;
                            gvCitasUsuario.DataBind();
                        }
                        else
                        {
                            gvCitasUsuario.DataSource = null;
                            gvCitasUsuario.DataBind();
                            MostrarAlerta("No hay citas programadas para este usuario.", "info");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error al cargar citas: {ex.Message}');</script>");
                    }
                }
            }
        }

        private void MostrarAlerta(string mensaje, string tipo)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"Swal.fire('{mensaje}', '', '{tipo}');", true);
        }
    }
}