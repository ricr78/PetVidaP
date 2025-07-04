<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EnviarFact.aspx.cs" Inherits="ProyectoPetVida.Administrador.EnviarFact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo2" runat="server">
    Generar Factura
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
    body {
        font-family: Arial, sans-serif;
        margin: 20px;
    }
    .formulario {
        margin-bottom: 20px;
        padding: 10px;
        border: 1px solid #ccc;
        /*border-radius: 5px;*/
        width: 300px;
    }
    .formulario input[type="text"] {
        width: 95%;
        margin-bottom: 10px;
        padding: 8px;
        border: 1px solid #ccc;
        border-radius: 5px;
    }
    .formulario button {
        background-color: #007bff;
        color: white;
        border: none;
        padding: 10px;
        border-radius: 5px;
        cursor: pointer;
    }
    .formulario button:hover {
        background-color: #0056b3;
    }
    .grid-container {
        margin-top: 20px;
    }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <form id="form1" runat="server">
        <div style="max-width: 800px; margin: auto;">
            <h1>Mi Compra - PetVida</h1>
            <hr />

            <!-- Formulario para agregar cita -->
            <h2>Agregar Cita</h2>
            <table>
                <tr>
                    <td><asp:Label ID="lblNombre" runat="server" Text="Nombre de la Mascota:" /></td>
                    <td><asp:TextBox ID="txtNombre" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblDueño" runat="server" Text="Dueño:" /></td>
                    <td><asp:TextBox ID="txtDueño" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblPrecioConsulta" runat="server" Text="Precio de la Consulta:" /></td>
                    <td><asp:TextBox ID="txtPrecioConsulta" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblMotivoConsulta" runat="server" Text="Motivo de la Consulta:" /></td>
                    <td><asp:TextBox ID="txtMotivoConsulta" runat="server" /></td>
                </tr>
            </table>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />

            <hr />

            <!-- Lista de citas -->
            <h2>Lista de Citas</h2>
            <asp:GridView ID="gvMascotas" runat="server" AutoGenerateColumns="True" />

            <!-- Total acumulado -->
            <h3>
                <asp:Label ID="lblTotalPrecio" runat="server" Text="Total Acumulado: $0.00" />
            </h3>

            <!-- Botón para descargar el PDF -->
            <asp:Button ID="btnDescargarPDF" runat="server" Text="Descargar PDF" OnClick="btnDescargarPDF_Click" />
        </div>
    </form>
</asp:Content>
