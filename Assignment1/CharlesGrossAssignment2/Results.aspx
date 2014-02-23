<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Results.aspx.vb" Inherits="CharlesGrossAssignment2.Results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Charles Gross Assignment #2</title>
    <link href="Styles/Main.css" rel="stylesheet" />
</head>
<body>
    <header>
        <h1>Charles Gross Assignment #2</h1>
        <h4>Put in numbers, pick an operation and math them!</h4>
    </header>
    <section>
        <form id="form1" runat="server">
            <div>
                <label class="resultsLabel">Your original numbers:</label><asp:Label ID="lblOriginalNumbers" runat="server" Text="" CssClass="entry"></asp:Label><br />
                <label class="resultsLabel">The highest value:</label><asp:Label ID="lblMax" runat="server" Text="" CssClass="entry"></asp:Label><br />
                <label class="resultsLabel">The lowest value:</label><asp:Label ID="lblMin" runat="server" Text="" CssClass="entry"></asp:Label><br />
                <asp:Label ID="lblOperation" runat="server" Text="" CssClass="resultsLabel"></asp:Label><asp:Label ID="lblOperationResult" runat="server" Text="" CssClass="entry"></asp:Label><br />
                <br />
                <asp:Button ID="btnStartOver" runat="server" Text="Start Over" PostBackUrl="~/Default.aspx" /><br />
                <br />

                <h3>Extra Credit</h3>
                <asp:Button ID="btnOriginalOrder" runat="server" Text="Original Order" />
                <asp:Button ID="btnSmallest" runat="server" Text="Smallest to Largest" />
                <asp:Button ID="btnLargest" runat="server" Text="Largest to Smallest" />
                <br />
                <br />
                <label class="resultsLabel">Extra Credit Result:</label><asp:Label ID="lblResults" runat="server" Text="" CssClass="entry"></asp:Label>
            </div>
        </form>
    </section>
</body>
</html>
