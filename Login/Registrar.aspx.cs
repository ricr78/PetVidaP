using ProyectoPetVida.Conexiones;
using ProyectoPetVida.Datos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPetVida.Login
{
    public partial class Registrar : System.Web.UI.Page
    {
        private readonly Procedimientos procedimientos1 = new Procedimientos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cvDui_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string dui = args.Value;

            // Validar longitud y formato básico
            if (string.IsNullOrEmpty(dui) || dui.Length != 10 || !dui.Contains("-"))
            {
                args.IsValid = false; // Formato incorrecto
                return;
            }

            string[] partesDUI = dui.Split('-');
            string numerosDUI = partesDUI[0];

            if (!int.TryParse(numerosDUI, out _) || !int.TryParse(partesDUI[1], out int digitoVerificador))
            {
                args.IsValid = false; // Partes no numéricas
                return;
            }

            // Calcular el dígito verificador
            int suma = 0;
            int[] factores = { 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < 8; i++)
            {
                suma += (numerosDUI[i] - '0') * factores[i];
            }

            int modulo = suma % 10;
            int digitoCalculado = (modulo == 0) ? 0 : 10 - modulo;

            args.IsValid = digitoCalculado == digitoVerificador; // Validar resultado
        }
        protected void cvConfirmarClave_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string contrasena = txtContra.Text;
            string confirmarContrasena = txtConfirmarClave.Text;

            if(contrasena == confirmarContrasena)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                lblMensaje.Text = "Por favor corrija los apartados antes de continuar";
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string dui = txtDui.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string clave = txtContra.Text.Trim();


            //if (!ValidarDui(dui))
            //{
            //    lblMensaje.Text ="El Dui ingresado no es válido.Debe cumplir con el formato ########-#";
            //    return;
            //}

            Procedimientos procedimientos = new Procedimientos();
            string mensaje = procedimientos.RegistrarUsuario(nombre, apellido, correo, dui, telefono, clave);
            if (mensaje == "Usuario registrado exitosamente")
            {
                // Mostrar SweetAlert de éxito
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "Swal.fire({ title: '¡Éxito!', text: 'Usuario registrado exitosamente.', icon: 'success', confirmButtonText: 'Aceptar' }).then(() => { window.location = 'InicioSesion.aspx'; });", true);
            }
            else
            {
                // Mostrar SweetAlert de error
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    $"Swal.fire({{ title: 'Error', text: '{mensaje}', icon: 'error', confirmButtonText: 'Aceptar' }});", true);
            }





        }

        public bool ValidarDui(string dui)
        {
           
            if (string.IsNullOrEmpty(dui) || dui.Length != 10 || dui.Contains("-"))
            {
                return false;
            }


            string[] partesDUI = dui.Split('-');
            string numerosDUI = partesDUI[0];


            if (!int.TryParse(numerosDUI, out int numeroBase))
            {
                return false;
            }

            int digitoVerificador = int.Parse(partesDUI[1]);
            int suma = 0;
            int[] factores = { 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < 8; i++)
            {
                suma += (numerosDUI[i] - '0') * factores[i];
            }

            int modulo = suma % 10;
            int digitoCalculo = (modulo == 0) ? 0 : 10 - modulo;

            return digitoCalculo == digitoVerificador;
        }
    }
}