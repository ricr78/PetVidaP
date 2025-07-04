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
    public partial class EliminarCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                // Si no hay sesión activa, redirige al inicio de sesión
                Response.Redirect("~/Login/InicioSesion.aspx");
            }
            

        }
        protected void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(Session["IdUsuario"]); // Obtener el ID del usuario de la sesión
            if (EliminarCuentaUsuario(idUsuario))
            {
                // Si la eliminación fue exitosa, redirige al Home
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "Swal.fire('¡Cuenta Eliminada!', 'Tu cuenta ha sido eliminada correctamente.', 'success').then(() => { window.location.href = '/Home/index.aspx'; });", true);
            }
            else
            {
                // Si hubo un error, muestra un mensaje
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "Swal.fire('¡Error!', 'No se pudo eliminar tu cuenta. Inténtalo más tarde.', 'error');", true);
            }
        }
        private bool EliminarCuentaUsuario(int idUsuario)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                try
                {
                    conn.Open();

                    // Eliminar las relaciones asociadas primero
                    using (SqlCommand cmd = new SqlCommand("sp_eliminarUsuario", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    // Manejar errores (opcional: registrar en logs)
                    Console.WriteLine("Error al eliminar la cuenta: " + ex.Message);
                    return false;
                }
            }
        }
    }
}