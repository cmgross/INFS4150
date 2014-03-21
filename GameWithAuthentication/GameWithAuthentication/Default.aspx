<%@ Page Title="Home" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="GameWithAuthentication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/middle-earth-map.jpg" Height="75%" Width="75%" />
        <br /><br />
        <asp:Button ID="Button1" runat="server" Text="ENTER GAME" PostBackUrl="~/Game/Default.aspx" />
    </div>
</asp:Content>
