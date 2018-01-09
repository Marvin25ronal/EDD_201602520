<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina2.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="ClienteEDD.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:View ID="View3" runat="server">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem>Top 10 usuarios con partidas ganadas</asp:ListItem>
            <asp:ListItem>Top 10 de usuarios con mayor porcentaje de unidades destruidas</asp:ListItem>
            <asp:ListItem>Top 10 de usuarios con mas contactos</asp:ListItem>
            <asp:ListItem>Top 10 usuario con mas unidades eliminadas</asp:ListItem>
        </asp:RadioButtonList>
    </asp:View>
    <asp:View ID="View1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" Height="252px" Width="485px" TextMode="MultiLine"></asp:TextBox>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Height="208px" Width="502px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </asp:View>
    <br />
        <asp:View ID="View4" runat="server">
            <asp:TextBox ID="TextBox3" runat="server" Height="208px" TextMode="MultiLine" Width="502px"></asp:TextBox>
        </asp:View>
        <br />
        <br />
        <asp:View ID="View5" runat="server">
            <asp:TextBox ID="TextBox4" runat="server" Height="208px" OnTextChanged="TextBox4_TextChanged" TextMode="MultiLine" Width="502px"></asp:TextBox>
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
</asp:MultiView>
</asp:Content>
