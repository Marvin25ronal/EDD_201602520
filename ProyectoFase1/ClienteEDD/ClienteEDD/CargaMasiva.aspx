<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina2.Master" AutoEventWireup="true" CodeBehind="CargaMasiva.aspx.cs" Inherits="ClienteEDD.CargaMasiva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Carga Masiva
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <br />
    <asp:View ID="View5" runat="server">
        <br />
        Seleccione que tipo de carga:<br />
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Width="405px">
            <asp:ListItem Value="0">Cargar Usuarios</asp:ListItem>
            <asp:ListItem Value="1">Cargar Juegos</asp:ListItem>
            <asp:ListItem Value="2">Cargar Tablero</asp:ListItem>
            <asp:ListItem Value="3">Cargar juego</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <br />
    </asp:View>
    <br />
    <br />
    <asp:View ID="View4" runat="server">
        Cargar Usuarios:<br />
        <asp:FileUpload ID="FileUpload1" runat="server" Width="343px" />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cargar" Width="138px" />
        <br />
        <br />
        <br />
    </asp:View>
    <br />
    <asp:View ID="View3" runat="server">
        <br />
        Carga de juegos:<br />
        <asp:FileUpload ID="FileUpload3" runat="server" Height="31px" Width="304px" />
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Button2" runat="server" Height="44px" OnClick="Button2_Click" Text="Cargar" Width="166px" />
        <br />
        <br />
    </asp:View>
    <asp:View ID="View1" runat="server">
        <br />
        Carga de Tablero:<br />
        <asp:FileUpload ID="FileUpload4" runat="server" Width="292px" />
        <br />
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cargar" Width="127px" />
        <br />
        <br />
    </asp:View>
    <asp:View ID="View2" runat="server">
        <br />
        Carga Configuracion:<br />
        <asp:FileUpload ID="FileUpload5" runat="server" />
        <br />
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" Height="28px" OnClick="Button4_Click" Text="Cargar" Width="151px" />
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
</asp:MultiView>
</asp:Content>
=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina2.Master" AutoEventWireup="true" CodeBehind="CargaMasiva.aspx.cs" Inherits="ClienteEDD.CargaMasiva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Carga Masiva
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <br />
    <asp:View ID="View5" runat="server">
        <br />
        Seleccione que tipo de carga:<br />
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Width="405px">
            <asp:ListItem Value="0">Cargar Usuarios</asp:ListItem>
            <asp:ListItem Value="1">Cargar Juegos</asp:ListItem>
            <asp:ListItem Value="2">Cargar Tablero</asp:ListItem>
            <asp:ListItem Value="3">Cargar juego</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <br />
    </asp:View>
    <br />
    <br />
    <asp:View ID="View4" runat="server">
        Cargar Usuarios:<br />
        <asp:FileUpload ID="FileUpload1" runat="server" Width="343px" />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cargar" Width="138px" />
        <br />
        <br />
        <br />
    </asp:View>
    <br />
    <asp:View ID="View3" runat="server">
        <br />
        Carga de juegos:<br />
        <asp:FileUpload ID="FileUpload3" runat="server" Height="31px" Width="304px" />
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Button2" runat="server" Height="44px" OnClick="Button2_Click" Text="Cargar" Width="166px" />
        <br />
        <br />
    </asp:View>
    <asp:View ID="View1" runat="server">
        <br />
        Carga de Tablero:<br />
        <asp:FileUpload ID="FileUpload4" runat="server" Width="292px" />
        <br />
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cargar" Width="127px" />
        <br />
        <br />
    </asp:View>
    <asp:View ID="View2" runat="server">
        <br />
        Carga Configuracion:<br />
        <asp:FileUpload ID="FileUpload5" runat="server" />
        <br />
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" Height="28px" OnClick="Button4_Click" Text="Cargar" Width="151px" />
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
</asp:MultiView>
</asp:Content>
>>>>>>> dd5dfac4819ebdd8ebdbef72dbeef126d5d02568
