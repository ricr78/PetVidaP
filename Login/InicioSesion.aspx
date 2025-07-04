<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="ProyectoPetVida.Login.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio sesión</title>
    
    <link href="../css/iestilos.css" rel="stylesheet" />
    <link href="../css/esstilos.css" rel="stylesheet" />
    
    
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    
</head>
<body>
    

   

    <div class="background">
        <div class="login-container">
             <div id="mensajeCronometro" style="color: red; font-weight: bold;"></div>
            <h2>Iniciar Sesión</h2>
            <form id="loginForm" runat="server">
                <div class="input-group">
                    <label for="txtCorreo">Correo</label>
                    <asp:TextBox id="txtCorreo" name="Correo" runat="server" required=""></asp:TextBox>
                </div>
                <div class="input-group">
                    <label for="password">Contraseña</label>
                    <asp:TextBox ID="txtContra" runat="server" Type="password"></asp:TextBox>
                    
                </div>
                <asp:Button ID="btnIngresar" runat="server" Text="Iniciar Sesión" OnClick="btnIngresar_Click"  />
            </form>
            <p>¿No tienes una cuenta?
                <asp:HyperLink ID="lnkRegistra" runat="server" href="Registrar.aspx">Registrate</asp:HyperLink>
            </p>

            
        </div>
    </div>
</body>
</html>

