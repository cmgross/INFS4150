Option Infer On

Public Class Results
    Inherits System.Web.UI.Page
    Private _input As Input

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _input = Input.GetInput()
        If Not IsPostBack Then
            lblOriginalNumbers.Text = ConvertToString(_input.Numbers)
            lblMax.Text = GetMatches(_input.Numbers.Max(), _input.Numbers)
            lblMin.Text = GetMatches(_input.Numbers.Min(), _input.Numbers)
            lblOperation.Text = _input.MathOperation + ":"
            lblOperationResult.Text = DoMath(_input.Numbers, _input.MathOperation)
        End If

    End Sub

    Protected Function ConvertToString(numbers As List(Of Decimal)) As String
        Return String.Join(",", numbers)
    End Function

    Protected Function GetMatches(matchId As Decimal, numbers As List(Of Decimal)) As String
        'find matches for max or min that is passed to function, then see how many numbers in the list are equal to that number, and handle the tie by showing both numbers and a tie indicator
        Dim matches As List(Of Decimal) = numbers.Where(Function(number) number = matchID).ToList()
        If matches.Count = 1 Then Return matchID.ToString()

        Dim builder As New StringBuilder
        builder.Append(ConvertToString(matches))
        builder.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Looks like we have a tie!")
        Return builder.ToString()
    End Function

    Protected Function DoMath(numbers As List(Of Decimal), operation As String) As String
        Select Case operation
            Case "Sum"
                Return numbers.Sum().ToString()
            Case "Average"
                Return numbers.Average().ToString()
            Case "Product"
                Dim productResult As Decimal = 1
                For Each number As Decimal In numbers
                    productResult = productResult * number
                Next
                Return productResult.ToString()
            Case Else
                Return String.Empty
        End Select
    End Function

    Protected Sub btnOriginalOrder_Click(sender As Object, e As EventArgs) Handles btnOriginalOrder.Click
        lblResults.Text = ConvertToString(_input.Numbers)
    End Sub

    Protected Sub btnSmallest_Click(sender As Object, e As EventArgs) Handles btnSmallest.Click
        Dim smallestToLargest As List(Of Decimal) = _input.Numbers.OrderBy(Function(num) num).ToList()
        lblResults.Text = ConvertToString(smallestToLargest)
    End Sub

    Protected Sub btnLargest_Click(sender As Object, e As EventArgs) Handles btnLargest.Click
        Dim largestToSmallest As List(Of Decimal) = _input.Numbers.OrderByDescending(Function(num) num).ToList()
        lblResults.Text = ConvertToString(largestToSmallest)
    End Sub
End Class