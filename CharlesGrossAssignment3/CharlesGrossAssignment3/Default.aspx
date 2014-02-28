<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="CharlesGrossAssignment3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td><asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="sdsUsers" DataTextField="CName" DataValueField="ID" AutoPostBack="True"></asp:DropDownList>
                <asp:SqlDataSource ID="sdsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [userchar]"></asp:SqlDataSource>
            </td>
            <td rowspan="4"><asp:Image ID="imgIcon" runat="server" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Gold<asp:Literal ID="lGold" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>XP<asp:Literal ID="lExp" runat="server"></asp:Literal></td>
        </tr>
         <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSelectCharacter" runat="server" Text="Select Character" CssClass="btn btn-primary" /></td>
        </tr>
    </table>

</asp:Content>
