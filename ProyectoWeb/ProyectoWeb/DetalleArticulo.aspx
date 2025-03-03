<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="ProyectoWeb.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Detalles de articulo</h1>

    <asp:GridView ID="Detalle" runat="server" CssClass="table">
        <Columns>  
        <asp:BoundField DataField="Codigo" HeaderText="Código" />  
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />  
        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />  
        <asp:BoundField DataField="Categoria" HeaderText="Categoría" />  
        <asp:BoundField DataField="Marca" HeaderText="Marca" />  
        <asp:BoundField DataField="ImagenUrl" HeaderText="Imagen URL" />  
        <asp:BoundField DataField="Precio" HeaderText="Precio" />  
    </Columns>  

    </asp:GridView>
</asp:Content>
