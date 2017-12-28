<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina2.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ClienteEDD.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" OnActiveViewChanged="MultiView1_ActiveViewChanged">
        <br />
        <br />
        <asp:View ID="View1" runat="server">
            Reporte Arbol:<br /> <br />
            <div id="listPlacement" style="height: 500px; overflow-y: scroll;">
            <asp:Image ID="Image1" runat="server" Height="578px" Width="750px" />
                </div>
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
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </asp:MultiView>
</asp:Content>
