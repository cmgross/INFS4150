Public Class Input
    Public MathOperation As String
    Public Numbers As List(Of Decimal)

    Public Sub New()
        Numbers = New List(Of Decimal)
    End Sub

    Public Shared Sub SetInput(input As Input)
        HttpContext.Current.Session("Input") = input
    End Sub

    Public Shared Function GetInput() As Input
        Return CType(HttpContext.Current.Session("Input"), Input)
    End Function

End Class
