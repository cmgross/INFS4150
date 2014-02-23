Public Class _Default
    Inherits Page

    Dim _map(9, 9) As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        FillMap()
        lblMessage.Visible = False
        lblMessage.Text = ""

        Dim j, i, rvalue, cvalue As Integer

        If Request.QueryString("r") IsNot Nothing Then
            rvalue = Request.QueryString("r")
        Else
            rvalue = 0
        End If

        If Request.QueryString("c") IsNot Nothing Then
            cvalue = Request.QueryString("c")
        Else
            cvalue = 0
        End If

        For j = (rvalue - 1) To (rvalue + 1)
            Dim r As New TableRow()
            For i = (cvalue - 1) To (cvalue + 1)
                Dim c As New TableCell()
                Dim h As New HyperLink()
                If (j < 0 Or i < 0 Or j > 9 Or i > 9) Then 'wall, end of map
                    c.BackColor = Drawing.Color.Black
                    c.ForeColor = Drawing.Color.Black
                    h.Text = "++++++++"
                    h.ForeColor = Drawing.Color.Black
                ElseIf (j = rvalue And i = cvalue) Then 'player location
                    If (_map(j, i) = 999) Then 'you are at stairs
                        c.BackColor = Drawing.Color.YellowGreen
                        h.Text = "I'm Here"
                        lblMessage.Visible = True
                        lblMessage.Text = "You've arrived at some stairs!"
                    ElseIf (_map(j, i) = 777) Then
                        c.BackColor = Drawing.Color.Purple
                        h.Text = "I'm Here with a grue"
                        lblMessage.Visible = True
                        lblMessage.Text = "It is pitch black. You are likely to be eaten by a grue."
                    Else
                        c.BackColor = Drawing.Color.Yellow
                        h.Text = "I'm Here"
                    End If
                    h.NavigateUrl = "http:/Default.aspx?r=" & j & "&c=" & i
                ElseIf ((_map(j, i) = 999)) Then 'feature 1
                    c.BackColor = Drawing.Color.YellowGreen
                    h.Text = "Stairs"
                    h.NavigateUrl = "http:/Default.aspx?r=" & j & "&c=" & i
                ElseIf ((_map(j, i) = 777)) Then 'feature 2, show label with message!
                    c.BackColor = Drawing.Color.Purple
                    h.Text = "Grue"
                    h.NavigateUrl = "http:/Default.aspx?r=" & j & "&c=" & i
                Else
                    h.Text = "Unknown"
                    h.NavigateUrl = "http:/Default.aspx?r=" & j & "&c=" & i
                End If
                c.Controls.Add(h)
                r.Cells.Add(c)
            Next
            Table1.Rows.Add(r)
        Next
    End Sub

    Private Sub FillMap()
        Dim j As Integer
        Dim i As Integer

        'fill map and add two features
        For j = 0 To 9
            For i = 0 To 9
                If (j = 5 And i = 7) Then
                    _map(j, i) = 999 'stairs!
                ElseIf (j = 3 And i = 3) Then
                    _map(j, i) = 777 'a grue!
                Else
                    _map(j, i) = (j * 10) + i
                End If
            Next
        Next
    End Sub
End Class