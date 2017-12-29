<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.Master" AutoEventWireup="true" CodeBehind="UsuarioN.aspx.cs" Inherits="ClienteEDD.UsuarioNormalaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table style="width: 100%">
        <tr>
            <td class="center" colspan="2" style="height: 69px">
                <asp:Label ID="Label2" runat="server" Font-Names="Bowlby One SC" Font-Size="XX-Large" Text="Tableros"></asp:Label>
            </td>
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
        </tr>
    </table>
</asp:Content>
