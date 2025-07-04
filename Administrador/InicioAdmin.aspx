<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="InicioAdmin.aspx.cs" Inherits="ProyectoPetVida.Administrador.InicioAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titulo2" runat="server">
    Registro solicitudes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .table {
            border-collapse: collapse;
            width: 100%;
            text-align: left;
            font-size: 16px;
            background-color: #f9f9f9;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
            margin: 10 auto;
            border: 1px solid black;
        }

            .table th, .table td {
                border: 1px solid #ddd;
                padding: 8px;
                text-align: left;
            }

            .table th {
                background-color: #f2f2f2;
                color: black;
                text-align: left;
                padding: 10px;
                font-weight: bold;
                text-transform: uppercase;
            }

            .table td {
                padding: 10px; /* Espaciado interno de las celdas */
                border-bottom: 1px solid #ddd; /* Línea divisoria entre filas */
                color: #333; /* Texto oscuro */
            }

            .table tr:nth-child(even) {
                background-color: #f2f2f2; /* Fondo alternativo para filas */
            }

            .table tr:hover {
                background-color: #e9ecef; /* Fondo al pasar el mouse */
                cursor: pointer; /* Cambia el cursor */
            }

           .btn-aprobar {
    background-color: #28a745; /* Botón verde */
    color: white; /* Texto blanco */
    border: none; /* Sin borde */
    padding: 5px 10px;
    border-radius: 5px; /* Bordes redondeados */
    font-size: 14px; /* Tamaño de texto */
    cursor: pointer;
    transition: background-color 0.3s ease; /* Animación suave */
}

.btn-aprobar:hover {
    background-color: #218838; /* Verde más oscuro al pasar el mouse */
}


        .flex-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100%;
            padding: -150px;
            box-sizing: border-box;
        }

        h2 {
            margin-bottom: 20px;
            font-family: Arial, sans-serif;
            color: #333;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Solicitudes de Citas</h2>
    <form id="form5" runat="server">
        <div class="flex-container">

            <asp:GridView ID="GridViewSolicitudes" runat="server" AutoGenerateColumns="False" CssClass="table" OnRowCommand="GridViewSolicitudes_RowCommand">
                <Columns>
                    <asp:BoundField DataField="IdSolicitudCita" HeaderText="ID Solicitud" ReadOnly="True" visible="true"/>
                    <asp:BoundField DataField="IdUsuario" HeaderText="ID Usuario" ReadOnly="True" />
                    <asp:BoundField DataField="NombreMascota" HeaderText="Nombre de la Mascota" />
                    <asp:BoundField DataField="MotivoCita" HeaderText="Motivo" />
                    <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha de Solicitud" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnAprobar" runat="server" CssClass="btn-aprobar" CommandName="Aprobar" CommandArgument="<%# Container.DisplayIndex %>" Text="Aprobar"  />
                        </ItemTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
                
        </div>
        
    </form>
</asp:Content>
