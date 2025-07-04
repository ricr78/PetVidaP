using ProyectoPetVida.Conexiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPetVida.Usuario
{
    public partial class SocilitarCita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("~/Login/InicioSesion.aspx");
                return;
            }
            if (!IsPostBack)
            {
                CargarMascotas();

                CargarMotivos();

            }

        }

        private void CargarMascotas()
        {
            int idUsuario = Convert.ToInt32(Session["IdUsuario"]);
           
           
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string query = "SELECT NombreMascota,TipoAnimal FROM mascota WHERE IdUsuario = @IdUsuario";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    
                    
                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        rptMascotas.DataSource = reader;
                        rptMascotas.DataBind();

                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error al cargar mascotas: {ex.Message}');</script>");
                    }
                }
            }
        }


        private void CargarMotivos()
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string query = "SELECT IdMotivoCita, MotivoCita FROM motivoCita";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                       
                            ddlMotivoCita.DataSource = reader;
                            ddlMotivoCita.DataTextField = "MotivoCita";
                            ddlMotivoCita.DataValueField = "IdMotivoCita";
                            ddlMotivoCita.DataBind();
                            ddlMotivoCita.Items.Insert(0, new ListItem("-- Seleccionar el motivo --", "0"));
                        
                        

                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error al cargar motivos de cita: {ex.Message}');</script>");
                    }
                }
            }
        }
        protected void btnSolicitarCita_Click(object sender, EventArgs e)
        {
            // Capturar valores de los campos
            string nombreMascota = txtNombreMascota.Text.Trim();
            int idMotivoCita = Convert.ToInt32(ddlMotivoCita.SelectedValue);

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombreMascota))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Error', 'Por favor, ingrese el nombre de la mascota.', 'error');", true);
                return;
            }

            if (idMotivoCita == 0) // Validar que se haya seleccionado un motivo válido
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Error', 'Por favor, seleccione un motivo de cita.', 'error');", true);
                return;
            }

            // Obtener el IdUsuario desde la sesión
            int idUsuario;
            if (Session["IdUsuario"] == null || !int.TryParse(Session["IdUsuario"].ToString(), out idUsuario))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Error', 'Usuario no autenticado.', 'error');", true);
                return;
            }

            // Registrar la cita utilizando el método dedicado
            int resultado = RegistrarSolicitudCita(nombreMascota, idMotivoCita, idUsuario);
            if (resultado > 0)
            {
                // Mostrar SweetAlert de éxito
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('¡Éxito!', 'Solicitud de cita registrada con éxito.', 'success');", true);

                // Limpiar campos del formulario
                txtNombreMascota.Text = "";
                ddlMotivoCita.SelectedIndex = 0;
            }
            else
            {
                // Mostrar SweetAlert de error
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Error', 'No se pudo registrar la solicitud de cita. Intente nuevamente.', 'error');", true);
            }

        }

        private int RegistrarSolicitudCita(string nombreMascota, int idMotivoCita, int idUsuario)
        {
            Conexion conexion = new Conexion();
            int resultado = 0;

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_solicitarCita", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros al procedimiento almacenado
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@NombreMascota", nombreMascota);
                    cmd.Parameters.AddWithValue("@IdMotivoCita", idMotivoCita);

                    // Parámetro de salida para capturar el resultado
                    SqlParameter outputParam = new SqlParameter("@Resultado", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        // Obtener el resultado del procedimiento almacenado
                        resultado = Convert.ToInt32(outputParam.Value);
                    }
                    catch (Exception ex)
                    {
                        // Mostrar mensaje de error en la consola del servidor (o registro)
                        Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                    }
                }
            }

            return resultado;
        }
    }
}