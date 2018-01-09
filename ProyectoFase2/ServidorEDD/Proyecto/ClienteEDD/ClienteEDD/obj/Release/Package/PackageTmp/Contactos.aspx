<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.Master" AutoEventWireup="true" CodeBehind="Contactos.aspx.cs" Inherits="ClienteEDD.Contactos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Contactos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:View ID="View1" runat="server">
        <table style="width: 100%">
            <tr>
                <td>Usuarios Existentes:<br />
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                        <asp:ListItem>Crear Contactos</asp:ListItem>
                        <asp:ListItem>Eliminar Contactos</asp:ListItem>
                        <asp:ListItem>Modificar Contactos</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <br />
        Nombre del Contacto:<br />
        <asp:TextBox ID="TextBox1" runat="server" Width="249px"></asp:TextBox>
        <br />
        Contraseña:<br />
        <asp:TextBox ID="TextBox2" runat="server" Width="250px"></asp:TextBox>
        <br />
        Correo:<br />
        <asp:TextBox ID="TextBox3" runat="server" Width="246px"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Aceptar" Width="173px" />
        <br />
    </asp:View>
    <asp:View ID="View3" runat="server">
        <table style="width: 100%">
            <tr>
                <td>Eliminar Contactos:<br />
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                    <br />
                </td>
                <td>Contacto a Eliminar:<br />
                    <asp:TextBox ID="TextBox4" runat="server" Width="223px"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button2" runat="server" Height="27px" OnClick="Button2_Click" Text="Borrar" Width="173px" />
                    <br />
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    </asp:View>
    <br />
    <br />
    <br />
    <asp:View ID="View4" runat="server">
        <table style="width: 100%">
            <tr>
                <td>Listado de usuarios:<br />
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
                <td style="width: 616px">Ingrese usuario:<br />
                    <asp:TextBox ID="TextBox8" runat="server" Width="183px"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button4" runat="server" Height="33px" OnClick="Button4_Click" Text="Cambiar" Width="160px" />
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
                <td>&nbsp;</td>
                <td style="width: 616px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 616px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
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
