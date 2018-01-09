<%@ Page Title="" Language="C#" MasterPageFile="~/EnBlanco.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ClienteEDD.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <br />
    <asp:View ID="View1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Nickname:" ForeColor="#000099"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Width="317px" BackColor="#000066"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Contraseña:" ForeColor="#003399"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Width="307px" BackColor="#000066"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Ingresar" Width="241px" BackColor="#003366" ForeColor="White" OnClick="Button1_Click" />
        <asp:Label ID="Label3" runat="server" ForeColor="#003366"></asp:Label>
        <br />
        <br />
    </asp:View>
    <br />
    <br />
    <br />
</asp:MultiView>
</asp:Content>
