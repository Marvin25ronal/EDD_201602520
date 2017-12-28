<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina2.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ClienteEDD.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <br />
        <br />
        <asp:View ID="View1" runat="server">
            Arbol:<br />
            <asp:Image ID="Image1" runat="server" Height="246px" Width="301px" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
           
        </asp:View>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </asp:MultiView>
</asp:Content>
