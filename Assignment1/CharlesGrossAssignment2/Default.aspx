<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="CharlesGrossAssignment2._Default" %>

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
                <label class="inputLabel">Whole Number 1</label>
                <asp:TextBox ID="txtInt1" runat="server" class="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvInt1" CssClass="validator"
                    runat="server" ControlToValidate="txtInt1" Display="Dynamic"
                    ErrorMessage="Whole Number 1 is a required field."></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvInt1" runat="server" CssClass="validator"
                    ControlToValidate="txtInt1" Display="Dynamic"
                    ErrorMessage="Whole Number 1 must range from 1 to 100."
                    MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator><br />

                <label class="inputLabel">Whole Number 2</label>
                <asp:TextBox ID="txtInt2" runat="server" class="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvInt2" CssClass="validator"
                    runat="server" ControlToValidate="txtInt2" Display="Dynamic"
                    ErrorMessage="Whole Number 2 is a required field."></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvInt2" runat="server" CssClass="validator"
                    ControlToValidate="txtInt2" Display="Dynamic"
                    ErrorMessage="Whole Number 2 must range from 1 to 100."
                    MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator><br />

                <label class="inputLabel">Decimal Number 1</label>
                <asp:TextBox ID="txtDouble1" runat="server" class="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDouble1" CssClass="validator"
                    runat="server" ControlToValidate="txtDouble1" Display="Dynamic"
                    ErrorMessage="Decimal Number 1 is a required field."></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvDouble1" runat="server" CssClass="validator"
                    ControlToValidate="txtDouble1" Display="Dynamic"
                    ErrorMessage="Decimal Number 1 must range from 1 to 50."
                    MaximumValue="50" MinimumValue="1" Type="Double"></asp:RangeValidator><br />

                <label class="inputLabel">Decimal Number 2</label>
                <asp:TextBox ID="txtDouble2" runat="server" class="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDouble2" CssClass="validator"
                    runat="server" ControlToValidate="txtDouble2" Display="Dynamic"
                    ErrorMessage="Decimal Number 2 is a required field."></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvDouble2" runat="server" CssClass="validator"
                    ControlToValidate="txtDouble2" Display="Dynamic"
                    ErrorMessage="Decimal Number 2 must range from 1 to 50."
                    MaximumValue="50" MinimumValue="1" Type="Double"></asp:RangeValidator><br />

                <label class="inputLabel">Decimal Number 3</label>
                <asp:TextBox ID="txtDouble3" runat="server" class="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDouble3" CssClass="validator"
                    runat="server" ControlToValidate="txtDouble3" Display="Dynamic"
                    ErrorMessage="Decimal Number 3 is a required field."></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvDouble3" runat="server" CssClass="validator"
                    ControlToValidate="txtDouble3" Display="Dynamic"
                    ErrorMessage="Decimal Number 3 must range from 1 to 50."
                    MaximumValue="50" MinimumValue="1" Type="Double"></asp:RangeValidator><br />

                <label class="inputLabel">Math Operation</label>
                <asp:DropDownList ID="ddlOperations" runat="server" class="entry">
                    <asp:ListItem>Sum</asp:ListItem>
                    <asp:ListItem>Average</asp:ListItem>
                    <asp:ListItem>Product</asp:ListItem>
                </asp:DropDownList><br />
                <asp:Button ID="btnCalculate" runat="server" Text="Calculate" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CausesValidation="False" />
            </div>
        </form>
    </section>

</body>
</html>
