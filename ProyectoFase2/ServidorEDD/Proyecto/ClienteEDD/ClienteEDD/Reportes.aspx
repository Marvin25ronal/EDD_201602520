<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina2.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ClienteEDD.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" OnActiveViewChanged="MultiView1_ActiveViewChanged">
        <br />
        <br />
        <asp:View ID="View1" runat="server">
            Reporte Arbol:<br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br /> <br />
            <div id="listPlac" style="height: 500px; overflow-y: scroll; width: 800px;">
            <asp:Image ID="Image1" runat="server" Height="900px" Width="1199px" ImageAlign="TextTop" />
                </div>
            <br />
           
        </asp:View>
        <br />
        <br />
        <asp:View ID="View2" runat="server">
            Arbol Espejo:<br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div id="listPlacement" style="height: 500px; overflow-y: scroll; width:800px;">
            <asp:Image ID="Image2" runat="server" Height="600px" Width="1256px" ImageAlign="AbsBottom" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                </div>
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
        <asp:View ID="View3" runat="server">
            <table style="width: 100%">
                <tr>
                    <td class="center" colspan="2" style="height: 69px">
                        <asp:Label ID="Label4" runat="server" Font-Names="Bowlby One SC" Font-Size="XX-Large" Text="Unidades destruidas"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 120px">Submarinos:<br />
                        <div id="listPlacement8" style="height: 500px; overflow-y: scroll;">
                            <asp:Image ID="Image5" runat="server" Height="559px" ImageAlign="Top" Width="500px" />
                        </div>
                        <br />
                        <br />
                    </td>
                    <td style="height: 120px">Barcos:
                        <br />
                        <div id="listPlacement2" style="height: 500px; overflow-y: scroll;">
                            <asp:Image ID="Image6" runat="server" Height="559px" ImageAlign="AbsMiddle" Width="500px" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>Aviones:<br />
                        <div id="listPlacement3" style="height: 500px; overflow-y: scroll;">
                            <asp:Image ID="Image3" runat="server" Height="559px" ImageAlign="TextTop" Width="500px" />
                        </div>
                    </td>
                    <td>Satelites:<br />
                        <div id="listPlacement7" style="height: 500px; overflow-y: scroll;">
                            <asp:Image ID="Image4" runat="server" Height="559px" ImageAlign="Baseline" Width="500px" />
                        </div>
                        <br />
                    </td>
                </tr>
            </table>
        </asp:View>
        <br />
        <br />
        <br />
        <br />
        <asp:View ID="View4" runat="server">
            <table style="width: 100%">
                <tr>
                    <td class="center" colspan="2" style="height: 69px">
                        <asp:Label ID="Label5" runat="server" Font-Names="Bowlby One SC" Font-Size="XX-Large" Text="Unidades Sobrevivientes"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 120px">Submarinos:<br />
                        <div id="listPlacement9" style="height: 500px; overflow-y: scroll;">
                            <asp:Image ID="Image7" runat="server" Height="559px" ImageAlign="Top" Width="500px" />
                        </div>
                        <br />
                        <br />
                    </td>
                    <td style="height: 120px">Barcos:
                        <br />
                        <div id="listPlacement10" style="height: 500px; overflow-y: scroll;">
                            <asp:Image ID="Image8" runat="server" Height="559px" ImageAlign="AbsMiddle" Width="500px" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>Aviones:<br />
                        <div id="listPlacement11" style="height: 500px; overflow-y: scroll;">
                            <asp:Image ID="Image9" runat="server" Height="559px" ImageAlign="TextTop" Width="500px" />
                        </div>
                    </td>
                    <td>Satelites:<br />
                        <div id="listPlacement12" style="height: 500px; overflow-y: scroll;">
                            <asp:Image ID="Image10" runat="server" Height="559px" ImageAlign="Baseline" Width="500px" />
                        </div>
                        <br />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View5" runat="server">
            <table style="width: 100%">
                <tr>
                    <td>Usuarios<br />
                        <asp:Label ID="Label6" runat="server"></asp:Label>
                    </td>
                    <td>Nickname:<asp:TextBox ID="TextBox1" runat="server" Height="17px" Width="265px"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label8" runat="server"></asp:Label>
                        <asp:Button ID="Button1" runat="server" Height="29px" OnClick="Button1_Click" Text="Ver Arbol" Width="265px" />
                    </td>
                    <td>
                        <div id="listPlacement15" style="height: 500px; overflow-y: scroll;">
                            </div>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <br />
        <asp:View ID="View6" runat="server">
            <asp:Image ID="Image11" runat="server" Height="365px" Visible="False" Width="390px" />
        </asp:View>
        <br />
        <asp:View ID="View7" runat="server">
            <asp:Label ID="Label7" runat="server" Font-Names="Bowlby One SC" Font-Size="XX-Large" Text="Tabla Hash"></asp:Label>
            <br />
            <br />
            <div id="listPlacement13" style="height: 406px; overflow-y: scroll; width: 548px;" class="center">
            <asp:Image ID="Image12" runat="server" Height="923px" Width="269px" ImageAlign="Baseline" />
                </div>
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
        <br />
        <br />
        <asp:View ID="View8" runat="server">
        </asp:View>
        <br />
        <br />
        <br />
        <br />
        <br />
    </asp:MultiView>
</asp:Content>
