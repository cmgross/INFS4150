Namespace CharlesGrossAssignment3
    Public Class GameUser
        Public Property Id As Integer
        Public Property Name As String
        Public Property Rloc As Integer
        Public Property Cloc As Integer
        Public Property Gold As Integer
        Public Property Health As Integer
        Public Property Exp As Integer
        Public Property Icon As String

        Public Shared Sub SaveCharacterToSession(gameUser As GameUser)
            HttpContext.Current.Session("GameUser") = gameUser
        End Sub

        Public Shared Function GetCharacterFromSession() As GameUser
            Return CType(HttpContext.Current.Session("GameUser"), GameUser)
        End Function
    End Class
End Namespace