<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="VerUsuariosRegistrados.aspx.cs" Inherits="ProyectoPetVida.Administrador.VerUsuariosRegistrados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo2" runat="server">
    Usuarios Registrados
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
    .table-usuarios {
        width: 90%;
        margin: 20px auto; /* Centrar la tabla */
        border-collapse: collapse;
        font-family: Arial, sans-serif;
        font-size: 16px;
        background-color: #fff;
        box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
        border: 1px solid #ddd;
    }

    .header-usuarios {
        background-color: #ff5722; /* Color naranja */
        color: white;
        text-transform: uppercase;
        font-weight: bold;
        text-align: center;
        padding: 10px;
        border: 1px solid #ddd;
    }

    .row-usuarios {
        text-align: center;
        border: 1px solid #ddd;
        padding: 8px;
    }

    .table-usuarios tr:nth-child(even) {
        background-color: #f9f9f9; /* Fondo alternativo */
    }

    .table-usuarios tr:hover {
        background-color: #ffe6e6; /* Fondo al pasar el mouse */
        cursor: pointer; /* Cambiar cursor */
    }

    .table-usuarios td {
        padding: 10px;
    }

    .btn-eliminar {
        background-color: #d9534f; /* Botón rojo */
        color: white;
        border: none;
        padding: 5px 10px;
        border-radius: 5px;
        font-size: 14px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }
     .btn-verde {
        background-color: #5cb85c; /* Botón verde */
        color: white;
        border: none;
        padding: 5px 10px;
        border-radius: 5px;
        font-size: 14px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

    .btn-verde:hover {
        background-color: #4cae4c; /* Verde más oscuro */
    }
    .btn-eliminar:hover {
        background-color: #c9302c; /* Rojo más oscuro */
    }
</style>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form8" runat="server">
       <asp:HiddenField ID="hdnIdUsuario" runat="server" />
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" CssClass="table-usuarios" 
    HeaderStyle-CssClass="header-usuarios" RowStyle-CssClass="row-usuarios" GridLines="None" OnRowCommand="gvUsuarios_RowCommand">
    <Columns>
        <asp:BoundField DataField="IdUsuario" HeaderText="ID Usuario" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
        <asp:BoundField DataField="Correo" HeaderText="Correo" />
        <asp:BoundField DataField="Dui" HeaderText="DUI" />
        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnEliminar" runat="server"  Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdUsuario") %>' CssClass="btn-eliminar" />

                <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" 
            CommandArgument='<%# Eval("IdUsuario") %>' CssClass="btn-verde" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

        


                <div id="modalEditarUsuario" class="modal">
    <div class="modal-content">
        <span class="close" onclick="cerrarModal()">&times;</span>
        <h2>Editar Usuario</h2>
        <asp:TextBox ID="txtEditarIdUsuario" runat="server" Placeholder="ID Usuario"></asp:TextBox>
        <asp:TextBox ID="txtEditarNombre" runat="server" Placeholder="Nombre"></asp:TextBox>
        <asp:TextBox ID="txtEditarApellido" runat="server" Placeholder="Apellido"></asp:TextBox>
        <asp:TextBox ID="txtEditarCorreo" runat="server" Placeholder="Correo"></asp:TextBox>
        <asp:TextBox ID="txtEditarDui" runat="server" Placeholder="DUI"></asp:TextBox>
        <asp:TextBox ID="txtEditarTelefono" runat="server" Placeholder="Teléfono"></asp:TextBox>
        <asp:TextBox ID="txtEditarClave" runat="server" TextMode="Password" Placeholder="Contraseña"></asp:TextBox>

        <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar Cambios" OnClick="btnGuardarCambios_Click" />
    </div>
</div>

<style>
    .modal {
        display: none;
        position: fixed;
        z-index: 1;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        overflow: auto;
        background-color: rgb(0,0,0);
        background-color: rgba(0,0,0,0.4);
    }

    .modal-content {
        background-color: #fefefe;
        margin: 15% auto;
        padding: 20px;
        border: 1px solid #888;
        width: 50%;
    }

    .close {
        color: #aaa;
        float: right;
        font-size: 28px;
        font-weight: bold;
    }

    .close:hover,
    .close:focus {
        color: black;
        text-decoration: none;
        cursor: pointer;
    }
</style>
        <script>
    function abrirModal() {
        document.getElementById('modalEditarUsuario').style.display = 'block';
    }

    function cerrarModal() {
        document.getElementById('modalEditarUsuario').style.display = 'none';
    }
        </script>

    </form>

</asp:Content>
