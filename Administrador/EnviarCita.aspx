<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EnviarCita.aspx.cs" Inherits="ProyectoPetVida.Administrador.EnviarCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            background-color: #f9f9f9; /* Fondo claro */
            border: 1px solid #ddd; /* Borde gris claro */
            border-radius: 10px;
            padding: 20px;
            margin: 50px auto; /* Centrado */
            width: 50%; /* Más ancho */
            box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1); /* Sombra */
        }

        .form-container h2 {
            text-align: center;
            color: #007bff; /* Azul claro */
            font-size: 24px;
            margin-bottom: 20px;
        }

        .form-container label {
            font-weight: bold;
            color: #333; /* Gris oscuro */
            display: block;
            margin-bottom: 5px;
            margin-top: 15px;
        }

        .form-container .form-control {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc; /* Borde claro */
            border-radius: 5px;
            font-size: 16px;
            box-sizing: border-box;
        }

        .btn {
            width: 100%;
            padding: 10px;
            background-color: #28a745; /* Verde */
            color: white;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn:hover {
            background-color: #218838; /* Verde más oscuro */
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form id="form1" runat="server">
        <div class="form-container">
            <h2>Enviar Cita Programada</h2>

            <!-- Ingresar o seleccionar el Usuario -->
            <label for="txtIdUsuario">ID del Usuario:</label>
            <asp:TextBox ID="txtIdUsuario" runat="server" CssClass="form-control" TextMode="Number" placeholder="Ingrese el ID del Usuario" Min="1" Step="1"></asp:TextBox>

            <!-- Seleccionar Veterinario -->
            <label for="ddlVeterinario">Veterinario:</label>
            <asp:DropDownList ID="ddlVeterinario" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccionar Veterinario" Value="" />
            </asp:DropDownList>

            <!-- Fecha de la Cita -->
            <label for="txtFechaCita">Fecha de la Cita:</label>
            <asp:TextBox ID="txtFechaCita" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>

            <!-- Hora de la Cita -->
            <label for="txtHoraCita">Hora de la Cita:</label>
            <asp:TextBox ID="txtHoraCita" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>

            <!-- Botón para enviar la cita -->
            <asp:Button ID="btnEnviarCita" runat="server" Text="Enviar Cita" CssClass="btn" OnClick="btnEnviarCita_Click" />
        </div>
    </form>




</asp:Content>
