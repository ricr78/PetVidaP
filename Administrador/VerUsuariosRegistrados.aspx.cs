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
    public partial class VerUsuariosRegistrados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

                CargarUsuarios();
            }

        }





        private void CargarUsuarios()
        {
            Conexion conexion = new Conexion(); // Clase de conexión

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string query = @"
            SELECT 
                IdUsuario, 
                Nombre, 
                Apellido, 
                Correo, 
                Dui, 
                Telefono
            FROM usuario";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            gvUsuarios.DataSource = reader;
                            gvUsuarios.DataBind();
                        }
                        else
                        {
                            
                            gvUsuarios.DataSource = null;
                            gvUsuarios.DataBind();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                        "Swal.fire('Aviso', 'No hay usuarios registrados. El ID ha sido reiniciado.', 'info');", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error al cargar los usuarios: {ex.Message}');</script>");
                    }
                }
            }
        }

        private void EliminarUsuario(int idUsuario)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_eliminarUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        
                        // Mostrar mensaje de éxito
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                            "Swal.fire('¡Éxito!', 'El usuario y sus datos relacionados se eliminaron correctamente.', 'success');", true);
                    }
                    catch (Exception ex)
                    {
                        // Manejar errores
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                            $"Swal.fire('¡Error!', 'No se pudo eliminar el usuario: {ex.Message}', 'error');", true);
                    }
                }
            }
        }


        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                // Obtener el ID del usuario desde CommandArgument
                int idUsuario = Convert.ToInt32(e.CommandArgument);
                
                // Llamar al método para eliminar el usuario
                EliminarUsuario(idUsuario);

                // Recargar la lista de usuarios
                CargarUsuarios();
            }else if (e.CommandName =="Editar")
            {
                int idUsuario = Convert.ToInt32(e.CommandArgument);
                EditarUsuario( idUsuario );
            }
        }

        private void EditarUsuario1(int idUsuario)
        {
            // Redirigir a la página de edición con el ID del usuario como parámetro
            Response.Redirect($"EditarUsuario.aspx?IdUsuario={idUsuario}");
        }



        private void EditarUsuario(int idUsuario)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string query = "SELECT IdUsuario,Nombre, Apellido, Correo, Dui, Telefono,Clave FROM usuario WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtEditarIdUsuario.Text = reader["IdUsuario"].ToString();
                            txtEditarNombre.Text = reader["Nombre"].ToString();
                            txtEditarApellido.Text = reader["Apellido"].ToString();
                            txtEditarCorreo.Text = reader["Correo"].ToString();
                            txtEditarDui.Text = reader["Dui"].ToString();
                            txtEditarTelefono.Text = reader["Telefono"].ToString();
                            txtEditarClave.Text = reader["Clave"].ToString();
                            hdnIdUsuario.Value = idUsuario.ToString();
                        }

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "abrirModal();", true);
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                            $"Swal.fire('¡Error!', 'No se pudo cargar el usuario: {ex.Message}', 'error');", true);
                    }
                }
            }
        }
        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion();
            int idUsuarioOriginal = int.Parse(hdnIdUsuario.Value);
            int nuevoIdUsuario = int.Parse(txtEditarIdUsuario.Text.Trim());

            if (string.IsNullOrWhiteSpace(txtEditarClave.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "Swal.fire('¡Error!', 'La contraseña no puede estar vacía.', 'error');", true);
                return;
            }

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string query = @"
    UPDATE usuario
    SET Nombre = @Nombre, Apellido = @Apellido, Correo = @Correo, 
        Dui = @Dui, Telefono = @Telefono, Clave =@Clave
    WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", hdnIdUsuario.Value);
                    cmd.Parameters.AddWithValue("@Nombre", txtEditarNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Apellido", txtEditarApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@Correo", txtEditarCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Dui", txtEditarDui.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telefono", txtEditarTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@Clave", txtEditarClave.Text.Trim());
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                            "Swal.fire('¡Éxito!', 'Usuario actualizado correctamente.', 'success');", true);

                        // Recargar la lista de usuarios
                        CargarUsuarios();
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                            $"Swal.fire('¡Error!', 'No se pudo actualizar el usuario: {ex.Message}', 'error');", true);
                    }
                }
            }
        }

        //private string EncriptarContraseña(string contraseña)
        //{
        //    using (var sha256 = System.Security.Cryptography.SHA256.Create())
        //    {
        //        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(contraseña);
        //        byte[] hash = sha256.ComputeHash(bytes);
        //        return Convert.ToBase64String(hash);
        //    }
        //}



    }
}