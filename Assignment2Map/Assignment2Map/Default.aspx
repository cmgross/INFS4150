<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Assignment2Map._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="Table1" runat="server" CellPadding="5"
        GridLines="Both" HorizontalAlign="Center" />
    <br />
    <asp:Label ID="lblMessage" runat="server" Text="" Visible="False"></asp:Label>
</asp:Content>
