<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="SocilitarCita.aspx.cs" Inherits="ProyectoPetVida.Usuario.SocilitarCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            display: flex;
            flex-direction: row;
            justify-content: space-between;
            padding: 20px;
        }

        .form-section,
        .mascotas-section {
            width: 48%;
        }

        .mascotas-list {
            border: 1px solid #ccc;
            padding: 15px;
            border-radius: 10px;
            background-color: #f9f9f9;
            height: auto;
        }

        .mascotas-list ul {
            list-style: none;
            padding: 0;
        }

        .mascotas-list li {
            padding: 8px;
            border-bottom: 1px solid #ccc;
        }

        .form-container {
            border: 1px solid #ccc;
            padding: 15px;
            border-radius: 10px;
            background-color: #f9f9f9;
        }

        .form-container input,
        .form-container select,
        .form-container button {
            width: 100%;
            margin: 10px 0;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .form-container button {
            background-color: #28a745;
            color: white;
            border: none;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form Id="form2" runat="server">
    <div class="container">
        <!-- Sección del formulario de citas -->
        <div class="form-section">
            <div class="form-container">
                <h2>Solicitar Cita</h2>
                <asp:TextBox ID="txtNombreMascota" runat="server" placeholder="Nombre de la Mascota"></asp:TextBox>
            
            <!-- Dropdown para seleccionar el motivo de la cita -->
            <asp:DropDownList ID="ddlMotivoCita" runat="server">
            </asp:DropDownList>
                
                <asp:Button ID="btnSolicitarCita" runat="server" Text="Solicitar Cita" OnClick="btnSolicitarCita_Click" />
            </div>
        </div>

        <!-- Sección de mascotas registradas -->
        <div class="mascotas-section">
            <div class="mascotas-list">
                <h2>Mascotas Registradas</h2>
                <asp:Repeater ID="rptMascotas" runat="server">
                    <ItemTemplate>
                        <li>
                            <%# Eval("NombreMascota") %> - Tipo: <%# Eval("TipoAnimal") %>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
        </form>
</asp:Content>
