<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Map.aspx.vb" Inherits="GameWithAuthentication.Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" class="gameTable" border>
        <tbody class="gameBody">
            <tr class="gameRow">
                <td width="25%">
                    <table>
                        <tr>
                            <td>Name: 
                                <asp:Literal ID="lName" runat="server"></asp:Literal><br />
                                HP: 
                                <asp:Literal ID="lHp" runat="server"></asp:Literal><br />
                                XP:<asp:Literal ID="lXp" runat="server"></asp:Literal><br />
                                Gold:
                                <asp:Literal ID="lGold" runat="server"></asp:Literal><br />
                            </td>
                             <td><br/>
                                <asp:Image ID="imgIcon" runat="server" Height="50%" Width="50%" />
                            </td>
                            </tr>
                        <tr>
                            <td>Inventory goes here<br />
                                Inventory drop button goes here<br />
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
                        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label><br /><br/>
                        Items found in world go here<br />
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
