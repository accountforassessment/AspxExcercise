<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="grdXMLParse" runat="server" AutoGenerateColumns="true" Width="100%"  ViewStateMode="Enabled">
    </asp:GridView>
</asp:Content>
