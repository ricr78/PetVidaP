<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="ProyectoPetVida.Login.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registrarse</title>
 
    <link href="../css/restilo.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

</head>
<body>
    <form id="form1" runat="server">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Name="jquery" />
            </Scripts>
        </asp:ScriptManager>--%>
        <div class="container">
            <h2>Registrarse</h2>

            <div class="form-group">
                <label for="nombre">Nombre:</label>

                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvNombre"
                    runat="server"
                    ControlToValidate="txtNombre"
                    ErrorMessage="Este Campo es obligatorio"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </div>
            <div class="form-group">

                <label for="apellido">Apellido:</label>

                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvApellido"
                    runat="server"
                    ControlToValidate="txtApellido"
                    ErrorMessage="Este Campo es obligatorio"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <div class="form-group">
                    <label for="telefono">Telefono:</label>

                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvTelefono"
                        runat="server"
                        ControlToValidate="txtTelefono"
                        ErrorMessage="Este Campo es obligatorio"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="dui">Dui:</label>
                    <asp:RegularExpressionValidator
                        ID="regexValidatorDui"
                        runat="server"
                        ControlToValidate="txtDui"
                        ErrorMessage="Formato incorrecto. Deber ser ########-#"
                        ValidationExpression="^\d{8}-\d{1}$"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtDui" runat="server"></asp:TextBox>

                    <asp:CustomValidator
                        ID="cvDui"
                        runat="server"
                        ControlToValidate="txtDui"
                        OnServerValidate="cvDui_ServerValidate"
                       
                        ErrorMessage="El Dui no es valido."
                        ForeColor="Red"
                        Display="Dynamic"></asp:CustomValidator>
                    <%--<script>
                        function validarDuiCliente(sender, args) {
                            const dui = args.Value;

                            if (dui.length !== 10 || !dui.includes("-")) {
                                args.IsValid = false;
                                return;
                            }

                            const partesDUI = dui.split("-");
                            const numerosDUI = partesDUI[0];
                            const digitoVerificador = parseInt(partesDUI[1], 10);

                            if (isNaN(numerosDUI) || isNaN(digitoVerificador)) {
                                args.IsValid = false;
                                return;
                            }
                            const factores = [9, 8, 7, 6, 5, 4, 3, 2];
                            let suma = 0;
                            for (let i = 0; i < 8; i++) {
                                suma += parseInt(numerosDUI[i], 10) * factores[i];
                            }
                            const modulo = suma % 10;
                            const digitoCalculo = modulo === 0 ? 0 : 10 - modulo;

                            args.IsValid = digitoCalculo === digitoVerificador;
                        }
                    </script>--%>

                </div>
                <label for="email">Correo:</label>

                <asp:TextBox ID="txtCorreo" runat="server" requerid="Complete este campo"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvCorreo"
                    runat="server"
                    ControlToValidate="txtCorreo"
                    ErrorMessage="Este Campo es obligatorio"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="password">Contraseña:</label>
                <asp:TextBox ID="txtContra" runat="server" type="password" requerid="Complete este campo"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvContra"
                    runat="server"
                    ControlToValidate="txtContra"
                    ErrorMessage="Este Campo es obligatoria."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="password">Confirmar Contraseña:</label>

                <asp:TextBox ID="txtConfirmarClave" runat="server" type="password" requerid="Complete este campo"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvConfirmarClave"
                    runat="server"
                    ControlToValidate="txtConfirmarClave"
                    ErrorMessage="Debe confirmar la contraseña."
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:CustomValidator
                    ID="cvConfirmarClave"
                    runat="server"
                    ControlToValidate="txtConfirmarClave"
                    OnServerValidate="cvConfirmarClave_ServerValidate"
                    ClientValidationFunction="validarConfirmarClave"
                    ErrorMessage="Las contraseñas no coinciden."
                    ForeColor="Red">
                </asp:CustomValidator>

                <%--<script>
                    function validarConfirmarClave(sender, args) {
                        var contrasena = document.getElementById('<%=txtContra.ClientID%>').Value;
                        var confirmarContrasena = document.getElementById('<%=txtConfirmarClave.ClientID%>');

                        args.IsValid = (contrasena === confirmarContrasena);
                    }
                </script>--%>
            </div>


            <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" OnClick="btnRegistrarse_Click" />
            <div>
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <center>
                 <div class="centro">
                    <p>¿Tienes cuenta?</p>
                    <asp:HyperLink ID="lnkInicio" runat="server" href="InicioSesion.aspx">Iniciar Sesión</asp:HyperLink>
                </div>
            </center>
           
        </div>
    </form>
</body>
</html>
