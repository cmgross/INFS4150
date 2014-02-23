Imports System.Web.Services.Description

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtInt1.Text = ""
        txtInt2.Text = ""
        txtDouble1.Text = ""
        txtDouble2.Text = ""
        txtDouble3.Text = ""
        ddlOperations.SelectedIndex = 0
    End Sub

    Protected Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        If Page.IsValid Then
            Dim input As New Input
            input.MathOperation = ddlOperations.SelectedValue.ToString()
            input.Numbers.Add(CDec(txtInt1.Text))
            input.Numbers.Add(CDec(txtInt2.Text))
            input.Numbers.Add(CDec(txtDouble1.Text))
            input.Numbers.Add(CDec(txtDouble2.Text))
            input.Numbers.Add(CDec(txtDouble3.Text))
            input.SetInput(input)
            Response.Redirect("Results.aspx", False)
        End If
    End Sub
End Class