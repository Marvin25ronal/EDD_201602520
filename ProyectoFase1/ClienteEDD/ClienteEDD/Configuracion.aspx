<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina2.Master" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs" Inherits="ClienteEDD.Configuracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Configuracion
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:View ID="View1" runat="server">
            <br />
            <br />
            <table style="width: 100%">
                <tr>
                    <td style="width: 383px">Jugador 1:
                        <br />
                        &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="210px"></asp:TextBox>
                        <br />
                        Jugador 2:<br />
                        <asp:TextBox ID="TextBox2" runat="server" Width="210px"></asp:TextBox>
                        <br />
                        Submarinos Maximos:<br />
                        <asp:TextBox ID="TextBox3" runat="server" Width="220px"></asp:TextBox>
                        <br />
                        Barcos Maximos:<br />
                        <asp:TextBox ID="TextBox4" runat="server" Width="228px"></asp:TextBox>
                        Aviones Maximos:<br />
                        <asp:TextBox ID="TextBox5" runat="server" Width="230px"></asp:TextBox>
                        Satelites Maximos:<br />
                        <asp:TextBox ID="TextBox6" runat="server" Width="228px"></asp:TextBox>
                        <br />
                        Tamaño del tablero en X:<br />
                        <asp:TextBox ID="TextBox7" runat="server" Width="229px"></asp:TextBox>
                        Tamaño del tablero en Y:<br />
                        <asp:TextBox ID="TextBox8" runat="server" Width="224px"></asp:TextBox>
                        Tipo de juego:<br />
                        <asp:TextBox ID="TextBox9" runat="server" Width="228px"></asp:TextBox>
                        Tiempo:<br />
                        <asp:TextBox ID="TextBox10" runat="server" Width="225px"></asp:TextBox>
                        <br />
                        <asp:Button ID="Button1" runat="server" Height="33px" OnClick="Button1_Click" Text="Guardar" Width="195px" />
                        <br />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 383px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <br />
        <br />
        <br />
        <br />
        <br />
    </asp:MultiView>
    <br />
</p>
</asp:Content>
