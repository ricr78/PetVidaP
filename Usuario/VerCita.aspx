<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="VerCita.aspx.cs" Inherits="ProyectoPetVida.Usuario.VerCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo1" runat="server">
    Citas Programadas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .table {
    width: 100%;
    border-collapse: collapse;
    margin: 20px 0;
    font-size: 18px;
    text-align: left;
}

.table th, .table td {
    border: 1px solid #ddd;
    padding: 8px;
}

.table th {
    background-color: #f2f2f2;
    font-weight: bold;
}

.table-striped tr:nth-child(even) {
    background-color: #f9f9f9;
}

.table-bordered {
    border: 1px solid #ddd;
}

    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form7" runat="server">
    <asp:GridView ID="gvCitasUsuario" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" GridLines="None">
    <Columns>
        
        <asp:BoundField DataField="FechaCita" HeaderText="Fecha de la Cita" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="HoraCita" HeaderText="Hora de la Cita" DataFormatString="{0:hh\\:mm tt}" />
       
    </Columns>
</asp:GridView>
        </form>
</asp:Content>
