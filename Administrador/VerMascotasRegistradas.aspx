<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="VerMascotasRegistradas.aspx.cs" Inherits="ProyectoPetVida.Administrador.VerMascotasRegistradas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo2" runat="server">
    Registros de mascotas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
    .table-mascotas {
        width: 80%;
        margin: 20px auto; /* Centramos la tabla */
        border-collapse: collapse;
        font-family: Arial, sans-serif;
        font-size: 16px;
        background-color: #fdfdfd;
        box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
        border: 1px solid #ddd;
    }

    .header-mascotas {
        background-color: #007BFF; /* Azul */
        color: white;
        text-transform: uppercase;
        font-weight: bold;
        text-align: center;
        padding: 10px;
        border: 1px solid #ddd;
    }

    .row-mascotas {
        text-align: center;
        border: 1px solid #ddd;
        padding: 8px;
    }

    .table-mascotas tr:nth-child(even) {
        background-color: #f2f2f2; /* Fondo alternativo para filas */
    }

    .table-mascotas tr:hover {
        background-color: #e9ecef; /* Efecto hover */
    }

    .table-mascotas td {
        padding: 10px;
    }

   

</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form9" runat="server">
        
        <asp:GridView ID="gvMascotas" runat="server" AutoGenerateColumns="False" CssClass="table-mascotas" HeaderStyle-CssClass="header-mascotas" RowStyle-CssClass="row-mascotas" GridLines="None">
    <Columns>
        <asp:BoundField DataField="IdMascota" HeaderText="ID Mascota" Visible="false" />
        <asp:BoundField DataField="NombreMascota" HeaderText="Nombre" />
        <asp:BoundField DataField="TipoAnimal" HeaderText="Tipo Animal" />
        <asp:BoundField DataField="pesoKg" HeaderText="Peso (Kg)" />
        <asp:BoundField DataField="Edad" HeaderText="Edad" />
        <asp:BoundField DataField="NombreUsuario" HeaderText="Propietario" />
    </Columns>
</asp:GridView>
    </form>
</asp:Content>
