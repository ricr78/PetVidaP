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
    public partial class EnviarCita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["IdAdministrador"] == null)
            {
                Response.Redirect("~/Login/InicioSesion.aspx"); // Redirigir al inicio de sesión si no está autenticado
                return;
            }
            if (!IsPostBack)
            {
                CargarVeterinarios();
               
            }

        }
        private void CargarVeterinarios()
        {
            Conexion conexion = new Conexion();
            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string query = "SELECT IdVeterinario, Nombre FROM veterinario";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        ddlVeterinario.DataSource = reader;
                        ddlVeterinario.DataTextField = "Nombre";
                        ddlVeterinario.DataValueField = "IdVeterinario";
                        ddlVeterinario.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error al cargar veterinarios: {ex.Message}');</script>");
                    }
                }
            }
            ddlVeterinario.Items.Insert(0, new ListItem("Seleccionar Veterinario", ""));
        }



        private int RegistrarCitaProgramada(int idUsuario, int idVeterinario, DateTime fechaCita, TimeSpan horaCita, int idSolicitudCita, int idAdministrador)
        {
            Conexion conexion = new Conexion();
            int resultado = 0;

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_enviarCita", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaCita", fechaCita);
                    cmd.Parameters.AddWithValue("@HoraCita", horaCita);
                    cmd.Parameters.AddWithValue("@IdVeterinario", idVeterinario);
                    cmd.Parameters.AddWithValue("@IdSolicitudCita", idSolicitudCita);
                    cmd.Parameters.AddWithValue("@IdAdministrador", idAdministrador);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario); // Incluye el ID del usuario

                    SqlParameter outputParam = new SqlParameter("@Resultado", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        resultado = Convert.ToInt32(outputParam.Value);
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error al registrar la cita: {ex.Message}');</script>");
                    }
                }
            }

            return resultado;
        }



        protected void btnEnviarCita_Click(object sender, EventArgs e)
        {
            // Validar campos del formulario
            if (string.IsNullOrEmpty(txtIdUsuario.Text) || ddlVeterinario.SelectedValue == "" ||
                string.IsNullOrEmpty(txtFechaCita.Text) || string.IsNullOrEmpty(txtHoraCita.Text))
            {
                MostrarAlerta("Por favor, complete todos los campos correctamente.", "error");
                return;
            }

            // Validar y capturar valores
            int idUsuario, idVeterinario, idAdministrador;
            DateTime fechaCita;
            TimeSpan horaCita;

            if (!int.TryParse(txtIdUsuario.Text, out idUsuario))
            {
                MostrarAlerta("El ID del usuario no es válido.", "error");
                return;
            }

            if (!DateTime.TryParse(txtFechaCita.Text, out fechaCita) || !TimeSpan.TryParse(txtHoraCita.Text, out horaCita))
            {
                MostrarAlerta("La fecha u hora ingresada no es válida.", "error");
                return;
            }

            idVeterinario = Convert.ToInt32(ddlVeterinario.SelectedValue);

            if (Session["IdAdministrador"] == null || !int.TryParse(Session["IdAdministrador"].ToString(), out idAdministrador))
            {
                MostrarAlerta("Administrador no autenticado.", "error");
                return;
            }

            int idSolicitudCita = ObtenerIdSolicitudCita(idUsuario);

            if (idSolicitudCita <= 0)
            {
                MostrarAlerta("No se encontró una solicitud de cita válida para el usuario especificado.", "error");
                return;
            }

            // Registrar la cita en la base de datos
            int resultado = RegistrarCitaProgramada(idUsuario, idVeterinario, fechaCita, horaCita, idSolicitudCita, idAdministrador);
            if (resultado > 0)
            {
                MostrarAlerta("Cita programada registrada correctamente.", "success");
                LimpiarFormulario();
            }
            else
            {
                MostrarAlerta("No se pudo registrar la cita programada. Intente nuevamente.", "error");
            }
        }
        private int ObtenerIdSolicitudCita(int idUsuario)
        {
            Conexion conexion = new Conexion();
            int idSolicitudCita = 0;

            using (SqlConnection conn = conexion.ObtenerConexion())
            {
                string query = "SELECT TOP 1 IdSolicitudCita FROM solicitudCita WHERE IdUsuario = @IdUsuario ORDER BY IdSolicitudCita DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            idSolicitudCita = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error al obtener IdSolicitudCita: {ex.Message}');</script>");
                    }
                }
            }

            return idSolicitudCita;
        }
        private void MostrarAlerta(string mensaje, string tipo)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"Swal.fire('{mensaje}', '', '{tipo}');", true);
        }

        private void LimpiarFormulario()
        {
            txtIdUsuario.Text = "";
            ddlVeterinario.SelectedIndex = 0;
            txtFechaCita.Text = "";
            txtHoraCita.Text = "";
        }

    }
}