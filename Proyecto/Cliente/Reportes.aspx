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
