using ProyectoPetVida.Conexiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPetVida.Administrador
{
    public partial class InicioAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSolicitudes();
            }

        }
        protected void GridViewSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Aprobar")
            {
                try
                {


                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridViewSolicitudes.Rows[rowIndex];
                    if (int.TryParse(row.Cells[0].Text, out int idSolicitudCita))
                    {
                        AprobarSolicitud(idSolicitudCita);
                        CargarSolicitudes();
                    }
                    else
                    {
                        // Muestra un mensaje de error si el valor no es válido
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                            "Swal.fire('Error', 'El ID de la solicitud no es válido.', 'error');", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                $"Swal.fire('Error', 'Ocurrió un error al aprobar la solicitud: {ex.Message}', 'error');", true);
                }
            }
        }
        private void AprobarSolicitud(int idSolicitudCita)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"UPDATE solicitudCita SET Estado = 'Aprobada' WHERE IdSolicitudCita = @IdSolicitudCita";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdSolicitudCita", idSolicitudCita);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        private void CargarSolicitudes()
        {
            Conexion conexion = new Conexion();
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                string query = @"SELECT sc.IdSolicitudCita,sc.IdUsuario, sc.NombreMascota, mc.MotivoCita, sc.FechaSolicitud,sc.Estado
                                 FROM solicitudCita sc
                                 INNER JOIN motivoCita mc ON sc.IdMotivoCita = mc.IdMotivoCita";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridViewSolicitudes.DataSource = dt;
                        GridViewSolicitudes.DataBind();
                    }
                }
            }
        }
        
    }
}