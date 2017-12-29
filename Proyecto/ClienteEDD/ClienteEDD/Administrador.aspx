<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina2.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="ClienteEDD.Administrador1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Bienvenido:"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <br />
        <br />
    </asp:View>
</asp:MultiView>
</asp:Content>
