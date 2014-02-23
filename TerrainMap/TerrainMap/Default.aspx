<%@ Page Title="Welcome" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="TerrainMap._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Troll 2 2: Return to Nilbog</h1>
        <p class="lead">Troll 2 2: Return to Nilbog picks up where the movie ended, as young Joshua returns to Nilbog to save his family from the Goblin's curse!</p>

    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Start New Game</h2>
            <p>
                Start a new game in Nilbog!
            </p>
            <p>
                <asp:Button ID="btnNewGame" runat="server" Text="New Game" CssClass="btn btn-primary btn-lg" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Load Game</h2>
            <p>
                Saving and loading games is not yet implemented.
            </p>
           <p>
               <asp:Button ID="btnLoadGame" runat="server" Text="Load Game" Enabled="False" CssClass="btn btn-primary btn-lg disabled" />
           </p>
        </div>
    </div>

</asp:Content>
