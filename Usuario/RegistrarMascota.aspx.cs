using ProyectoPetVida.Conexiones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ProyectoPetVida.Usuario
{
    public partial class RegistrarMascota : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("~/Login/InicioSesion.aspx"); // Redirigir al inicio de sesión si no está autenticado
                return;
            }

            if (!IsPostBack)
            {
                txtNombreMascota.Attributes.Add("placeholder","Nombre de la mascota");
                txtPesoKg.Attributes.Add("placeholder", "Peso (Kg)");
                txtEdad.Attributes.Add("placeholder", "Edad");
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombreMascota = txtNombreMascota.Text;
            string tipoAnimal = ddlTipoAnimal.SelectedValue;
            decimal pesoKg;
            int edad;

            if(string.IsNullOrEmpty(nombreMascota) || string.IsNullOrEmpty(tipoAnimal) || 
                !decimal.TryParse(txtPesoKg.Text,out pesoKg) || !int.TryParse(txtEdad.Text, out edad))
            {
                // SweetAlert para campos incompletos
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Error', 'Por favor, complete todos los campos correctamente.', 'error');", true); return;
            }

            int idUsuario;
            if (Session["IdUsuario"] == null || !int.TryParse(Session["IdUsuario"].ToString(),out idUsuario) )
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Error', 'Usuario no autenticado.', 'error');", true);
                return;
            }


            int resultado = RegistrarMascotas(nombreMascota,tipoAnimal,pesoKg,edad,idUsuario);
            if(resultado > 0 )
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('¡Éxito!', 'Mascota registrada con éxito.', 'success');", true);

                // Limpiar campos del formulario después del éxito
                txtNombreMascota.Text = "";
                ddlTipoAnimal.SelectedIndex = 0;
                txtPesoKg.Text = "";
                txtEdad.Text = "";
            }
            else
            {
                // SweetAlert para error al registrar
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Error', 'No se pudo registrar la mascota. Intente nuevamente.', 'error');", true);
            }
        }

        private int RegistrarMascotas(string nombreMascota, string tipoAnimal,decimal pesoKg, int edad, int idUsuario)
        {
            Conexion conexion = new Conexion();
            
            int resultado = 0;
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                using(SqlCommand cmd = new SqlCommand("sp_registrarmascota",conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreMascota",nombreMascota);
                    cmd.Parameters.AddWithValue("@TipoAnimal", tipoAnimal);
                    cmd.Parameters.AddWithValue("@pesoKg", pesoKg);
                    cmd.Parameters.AddWithValue("@Edad", edad);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    SqlParameter outputParam = new SqlParameter("@resultado", System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        resultado = Convert.ToInt32(outputParam.Value);
                        if (resultado == 0)
                        {
                            // Manejar error cuando no se puede registrar la mascota
                            Response.Write("<script>alert('No se pudo registrar la mascota. Verifique los datos.');</script>");
                        }
                    }
                    catch(Exception ex)
                    {
                        Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                    }
                }
            }
            return resultado;
        }
    }
}