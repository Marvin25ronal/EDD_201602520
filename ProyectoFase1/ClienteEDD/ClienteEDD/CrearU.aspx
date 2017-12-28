<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina2.Master" AutoEventWireup="true" CodeBehind="CrearU.aspx.cs" Inherits="ClienteEDD.CrearU" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        &nbsp;Nombre:<br />
        <asp:TextBox ID="TextBox1" runat="server" Width="223px"></asp:TextBox>
        &nbsp;<br /> Contraseña:<br />
        <asp:TextBox ID="TextBox2" runat="server" Width="218px"></asp:TextBox>
        Correo:<br />
        <asp:TextBox ID="TextBox3" runat="server" Width="215px"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Crear" Width="204px" OnClick="Button1_Click" />
        <br />
        <br />
        <br />
        <br />
    </asp:View>
        <asp:View ID="View3" runat="server">
            <table style="width: 100%">
                <tr>
                    <td>Eliminar:<br />
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server" Height="29px" Width="281px"></asp:TextBox>
                        <br />
                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Eliminar" Width="170px" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
        </asp:View>
    <asp:View ID="View2" runat="server">
        <table style="width: 100%">
            <tr>
                <td>Listado de usuarios:<br />
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 616px">Ingrese usuario:<br />
                    <asp:TextBox ID="TextBox4" runat="server" Width="183px"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button2" runat="server" Height="33px" OnClick="Button2_Click" Text="Cambiar" Width="160px" />
                    <br />
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Panel ID="Panel1" runat="server" Height="357px" Visible="False" Width="199px">
                        Nickname:<br />
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        <br />
                        Correo:<br />
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        <br />
                        Contraseña:<br />
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="Button3" runat="server" Height="42px" OnClick="Button3_Click" Text="Cambiar" Width="128px" />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td style="width: 616px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 616px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
    </asp:View>
</asp:MultiView>
</asp:Content>
