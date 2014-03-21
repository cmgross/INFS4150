<%@ Page Title="Success" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Success.aspx.vb" Inherits="GameWithAuthentication.Game.Success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>You've selected
        <asp:Literal ID="lName" runat="server"></asp:Literal>!</h4>
    <hr />
    <div class="row">
        <div class="col-md-6">
            <table class="table table-striped table-hover table-condensed">
                <tr>
                    <td class="rowHeader">Current Row:</td>
                    <td>
                        <asp:Literal ID="lRow" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td class="rowHeader">Current Column:</td>
                    <td>
                        <asp:Literal ID="lCol" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td class="rowHeader">Current Hit Points:</td>
                    <td>
                        <asp:Literal ID="lHp" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td class="rowHeader">Current Exp:</td>
                    <td>
                        <asp:Literal ID="lExp" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td class="rowHeader">Current Gold:</td>
                    <td>
                        <asp:Literal ID="lGold" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
        <div class="col-md-6">
            <asp:Image ID="imgIcon" runat="server" />
        </div>
    </div>


    <div class="form-group">
        <asp:Button ID="btnEnterGame" runat="server" Text="Enter Game" CssClass="btn btn-success" Enabled="False" />
    </div>
</asp:Content>
