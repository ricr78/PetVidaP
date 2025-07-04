<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="EliminarCuenta.aspx.cs" Inherits="ProyectoPetVida.Usuario.EliminarCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo1" runat="server">
    Eliminar su cuenta
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div style="text-align: center; margin-top: 50px;">
            <h2>¿Estás seguro de que deseas eliminar tu cuenta?</h2>
            <p>Esta acción no se puede deshacer.</p>
            <asp:Button ID="btnEliminarCuenta" runat="server" Text="Eliminar mi Cuenta" CssClass="btn-rojo" OnClick="btnEliminarCuenta_Click" />
        </div>
    </form>

    <style>
        .btn-rojo {
            background-color: #d9534f; /* Botón rojo */
            color: white;
            border: none;
            padding: 10px 20px;
            font-size: 16px;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn-rojo:hover {
            background-color: #c9302c; /* Rojo más oscuro */
        }
    </style>
</asp:Content>
