<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Character.aspx.vb" Inherits="GameWithAuthentication.Character" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well">
        <fieldset>
            <legend>
                <asp:Literal runat="server" ID="lPageAction" /></legend>

            <div class="row">
                <div class="col-md-6">
                    <table class="table table-striped table-hover table-condensed">
                        <tr>
                            <td class="rowHeader">Name:</td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name required" ControlToValidate="txtName"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="rowHeader">Hit Points:</td>
                            <td>
                                <asp:Literal ID="lHp" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td class="rowHeader">Exp:</td>
                            <td>
                                <asp:Literal ID="lExp" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td class="rowHeader">Gold:</td>
                            <td>
                                <asp:Literal ID="lGold" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td class="rowHeader">Icon:</td>
                            <td>
                                <asp:DropDownList ID="ddlImages" runat="server" DataSourceID="sdsImages" DataTextField="IconName" DataValueField="Id" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="sdsImages" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Icon]">
                                </asp:SqlDataSource>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvIcon" runat="server" ErrorMessage="Icon required" ControlToValidate="ddlImages"></asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                    <div class="form-group">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" />
                    </div>
                </div>
                <div class="col-md-6">
                    <asp:Image ID="imgIcon" runat="server" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
