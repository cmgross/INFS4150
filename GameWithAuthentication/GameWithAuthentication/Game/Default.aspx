<%@ Page Title="Character Select" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="GameWithAuthentication.Game._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well">
        <fieldset>
            <legend>Please select your character</legend>
            <div class="form-group">
                 <div class="alert alert-danger" runat="server" Visible="False" id="dNoCharacters">
                        You do not have any characters. Please create one to play!
                    </div>
                <asp:Label ID="lblCharacters" runat="server" Text="Characters"></asp:Label><br />
                <asp:DropDownList ID="ddlCharacters" runat="server" DataSourceID="sdsCharacters" DataTextField="CName" DataValueField="ID" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="sdsCharacters" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [userchar] where user = @uname">
                    <SelectParameters>
                        <asp:Parameter Name="uname" Type="String" DefaultValue="" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <table class="table table-striped table-hover table-condensed">
                        <tr>
                            <td class="rowHeader">Name:</td>
                            <td>
                                <asp:Literal ID="lName" runat="server"></asp:Literal></td>
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
                    </table>
                    <div class="form-group">
                        <asp:Button ID="btnSelectCharacter" runat="server" Text="Select Character" CssClass="btn btn-primary" />
                        <asp:Button ID="btnEditCharacter" runat="server" Text="Edit Character" CssClass="btn btn-info" />
                        <asp:Button ID="btnNewCharacter" runat="server" Text="New Character" CssClass="btn btn-success" PostBackUrl="~/Game/Character.aspx" />
                    </div>
                </div>
                <div class="col-md-6">
                    <asp:Image ID="imgIcon" runat="server" />
                </div>
            </div>
        </fieldset>

    </div>
</asp:Content>
