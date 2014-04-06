<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Map.aspx.vb" Inherits="GameWithAuthentication.Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" class="gameTable" border>
        <tbody class="gameBody">
            <tr class="gameRow">
                <td width="25%">
                    <table style="padding-left:10px; padding-bottom: 5px;">
                        <tr>
                            <td>Name: 
                                <asp:Literal ID="lName" runat="server"></asp:Literal><br />
                                HP: 
                                <asp:Literal ID="lHp" runat="server"></asp:Literal><br />
                                XP:<asp:Literal ID="lXp" runat="server"></asp:Literal><br />
                                Gold:
                                <asp:Literal ID="lGold" runat="server"></asp:Literal><br />
                            </td>
                            <td>
                                <br />
                                <asp:Image ID="imgIcon" runat="server" Height="50%" Width="50%" />
                            </td>
                        </tr>
                        <tr>
                            <td>Invetory
                                <asp:Literal ID="lInventoryCount" runat="server"></asp:Literal><br />
                               <%-- <asp:ListView ID="lvInventory" runat="server" DataSourceID="sdsInventory"></asp:ListView><br/>--%>
                                <asp:DropDownList ID="ddlInventory" runat="server" DataSourceID="sdsInventory" DataTextField="Description" DataValueField="Id">
                                </asp:DropDownList>
                                <asp:Button ID="btnDrop" runat="server" Text="Drop" Visible="False" />
                                <asp:SqlDataSource ID="sdsInventory" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"></asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="cp" style="text-align: center;" width="50%">
                    <asp:Table ID="tbGameMap" runat="server" CellPadding="5" GridLines="Both" HorizontalAlign="Center">
                    </asp:Table>
                    <br />
                    <div>
                        <table align="center" cellpadding="5">
                            <caption>Controls</caption>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnUpLeft" runat="server" Text="" Font-Size="Large" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnUp" runat="server" Text="" Font-Size="Large" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnUpRight" runat="server" Text="" Font-Size="Large" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnLeft" runat="server" Text="" Font-Size="Large" />
                                </td>
                                <td style="text-align: center;">&nbsp;
                                </td>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnRight" runat="server" Text="" Font-Size="Large" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnDownLeft" runat="server" Text="" Font-Size="Large" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnDown" runat="server" Text="" Font-Size="Large" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnDownRight" runat="server" Text="" Font-Size="Large" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td class="gp" style="text-align: center; vertical-align: top;" width="25%">
                    <div>
                        <br />
                        You are standing on
                        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label><br />
                        <br />
                        <div runat="server" visible="False" id="dItemsFound">
                            You notice something on the ground:<br />
                            <asp:Literal ID="lCantPickUp" runat="server" Visible="False" Text="You have too many items to pick anymore up!"></asp:Literal><br />
                            <asp:DropDownList ID="ddlMapItems" runat="server" DataSourceID="sdsMapItems" DataTextField="Description" DataValueField="Id">
                            </asp:DropDownList>
                            <asp:Button ID="btnPickUp" runat="server" Text="Pick Up" Visible="False" />
                            <asp:SqlDataSource ID="sdsMapItems" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"></asp:SqlDataSource>
                        </div>
                    </div>
                </td>
            </tr>
            <%-- <tr class="gameRow">
                <td colspan="2" align="center"></td>
            </tr>--%>
        </tbody>
    </table>
    <br />
    <h4 style="text-align: center;">World Map</h4>
    <asp:Table ID="tbWorldMap" runat="server" CellPadding="5"
        GridLines="Both" HorizontalAlign="Center">
    </asp:Table>
</asp:Content>
