<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="RegistrarMascota.aspx.cs" Inherits="ProyectoPetVida.Usuario.RegistrarMascota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <form  id="form1" runat="server">
        <div class="form-container">
            <h2>Registrar Mascota</h2>
            <asp:TextBox ID="txtNombreMascota" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlTipoAnimal" runat="server">
                <asp:ListItem Value="" Text="Seleccionar Tipo Animal"></asp:ListItem>
                <asp:ListItem Value="Perro" Text="Perro"></asp:ListItem>
                <asp:ListItem Value="Gato" Text="Gato"></asp:ListItem>
                <asp:ListItem Value="Ave" Text="Ave"></asp:ListItem>
                <asp:ListItem Value="Roedor" Text="Roedor"></asp:ListItem>
                <asp:ListItem Value="Reptil" Text="Reptil"></asp:ListItem>
                <asp:ListItem Value="Otro" Text="Otro"></asp:ListItem>
            </asp:DropDownList>

            <asp:TextBox ID="txtPesoKg" runat="server"  TextMode="Number"></asp:TextBox>
            <asp:TextBox ID="txtEdad" runat="server"  TextMode="Number"></asp:TextBox>
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click"  />
        </div>
    </form>
</asp:Content>
