using ProyectoPetVida.Conexiones;
using ProyectoPetVida.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPetVida.Login
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        private readonly Procedimientos procedimientos = new Procedimientos();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Session["IntentosFallidos"]==null)
            {
                Session["IntentosFallidos"] = 0;
            }
            
            
            
            int intentosFallidos = (int)Session["IntentosFallidos"];

            if(intentosFallidos >= 5)
            {
                Session["BloqueoActivo"] = true;
                Session["TiempoDesbloqueo"] = DateTime.Now.AddMinutes(5);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Error', 'Demasiado intentos fallidos. intente más tarde.', 'error');", true);
            }

            string correo = txtCorreo.Text.Trim();
            string clave = txtContra.Text.Trim();

            if(procedimientos.ValidarAdministrador(correo,clave))
            {
                Session["IntentosFallidos"] = 0;
                Session["BloqueoActivo"] = false;
                int idAdministrador = procedimientos.ObtenerIdAdministrador(correo,clave);
                if (idAdministrador >0)
                {
                    
                    Session["IdAdministrador"]=idAdministrador;
                    Response.Redirect("~/Administrador/InicioAdmin.aspx");
                }
                else
                {
                    Response.Write("<script>alert('No se pudo iniciar. Intente nuevamente.');</script>");
                }
            }
            else if(procedimientos.ValidarUsuario(correo,clave)) 
            {
                Session["IntentosFallidos"] = 0;
                Session["BloqueoActivo"] = false;
                int idUsuario = procedimientos.ObtenerIdUsuario(correo,clave);
                if(idUsuario > 0)
                {
                    Session["IdUsuario"] = idUsuario;
                    Response.Redirect("~/Usuario/InicioUser.aspx");
                }
                else
                {
                    Response.Write("<script>alert('No se pudo iniciar. Intente nuevamente.');</script>");
                }

            }
            else
            {
                Session["IntentosFallidos"] = intentosFallidos + 1;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Swal.fire('Error', 'Correo o contraseña incorrecta.', 'error');", true);
            }
        }
    }
}