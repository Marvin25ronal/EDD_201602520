<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.Master" AutoEventWireup="true" CodeBehind="UsuarioN.aspx.cs" Inherits="ClienteEDD.UsuarioNormalaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width: 100%">
        <tr>
            <td class="center" colspan="2" style="height: 71px">
                <asp:Label ID="Label2" runat="server" Font-Names="Bowlby One SC" Font-Size="XX-Large" Text="Tableros"></asp:Label>
            </td>
            <td class="center" style="height: 71px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 120px">Submarinos:<br />
                <div id="listPlacement" style="height: 500px; overflow-y: scroll;">
                <asp:Image ID="Image1" runat="server" Height="559px" Width="500px" ImageAlign="Top" />
                    </div>
                <br />
                <br />
            </td>
            <td style="height: 120px">Barcos: <br />
                <div id="listPlacement2" style="height: 500px; overflow-y: scroll;">
                <asp:Image ID="Image2" runat="server" Height="559px" Width="500px" ImageAlign="AbsMiddle" />
                    </div>
            </td>
            <td style="height: 120px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                Jugador 1
                <asp:Label ID="Label3" runat="server"></asp:Label>
                <br />
                Jugador 2
                <asp:Label ID="Label4" runat="server"></asp:Label>
                <br />
                Colocar Elementos:<br />
                <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="163px">
                    <asp:ListItem>Neosatelite</asp:ListItem>
                    <asp:ListItem>Bombardero</asp:ListItem>
                    <asp:ListItem>Caza</asp:ListItem>
                    <asp:ListItem>Helicoptero</asp:ListItem>
                    <asp:ListItem>Fragata</asp:ListItem>
                    <asp:ListItem>Crucero</asp:ListItem>
                    <asp:ListItem>Submarino</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                Posicion en X:<br />
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                Posicion en Y:<br />
                <asp:TextBox ID="TextBox3" runat="server" Width="151px"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" Height="32px" OnClick="Button1_Click" Text="Button" Width="135px" />
                <br />
                <br />
                &nbsp;<br />
                <br />
            </td>
        </tr>
        <tr>
            <td>Aviones:<br />
                <div id="listPlacement3" style="height: 500px; overflow-y: scroll;">
                <asp:Image ID="Image3" runat="server" Height="559px" Width="500px" ImageAlign="TextTop" />
                    </div>
            </td>
            <td>Satelites:<br />
                <div id="listPlacement7" style="height: 500px; overflow-y: scroll;">
                <asp:Image ID="Image4" runat="server" Height="559px" Width="500px" ImageAlign="Baseline" />
                    </div>
                <br />
            </td>
            <td>Consola:<br />
                Mover:<br />
                <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="163px">
                    <asp:ListItem>Neosatelite</asp:ListItem>
                    <asp:ListItem>Bombardero</asp:ListItem>
                    <asp:ListItem>Caza</asp:ListItem>
                    <asp:ListItem>Helicoptero</asp:ListItem>
                    <asp:ListItem>Fragata</asp:ListItem>
                    <asp:ListItem>Crucero</asp:ListItem>
                    <asp:ListItem>Submarino</asp:ListItem>
                </asp:DropDownList>
                <br />
                Posicion AnteriorX:<br />
                <asp:TextBox ID="TextBox5" runat="server" Width="166px"></asp:TextBox>
                Posicion AnteriorY:<br />
                <asp:TextBox ID="TextBox6" runat="server" Width="166px"></asp:TextBox>
                <br />
                Nueva Posicion X:<br />
                <asp:TextBox ID="TextBox7" runat="server" Width="173px"></asp:TextBox>
&nbsp;Nueva Posicion Y:<br />
                <asp:TextBox ID="TextBox8" runat="server" Width="176px"></asp:TextBox>
                <br />
                <asp:Button ID="Button2" runat="server" Height="29px" OnClick="Button2_Click" Text="Mover" Width="177px" />
                <br />
                <asp:TextBox ID="TextBox4" runat="server" Height="355px" TextMode="MultiLine" Width="200px"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
