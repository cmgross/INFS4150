<%@ Page Title="Nilbog Map" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Map.aspx.vb" Inherits="TerrainMap.Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" class="gameTable" border>
        <tbody class="gameBody">
            <tr class="gameRow">
                <td class="cp" style="text-align: center;">
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
                <td class="gp" style="text-align: center; vertical-align: top;">
                    <div>
                        You are standing on <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                    </div>
                </td>
            </tr>
            <tr class="gameRow">
                <td colspan="2" align="center">
                    <h4>World Map</h4>
                    <asp:Table ID="tbWorldMap" runat="server" CellPadding="5"
                        GridLines="Both" HorizontalAlign="Center">
                    </asp:Table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
