Namespace GameWithAuthentication
    Public Class GameCharacter
        Public Property Id As Integer
        Public Property Name As String
        Public Property Rloc As Integer
        Public Property Cloc As Integer
        Public Property Gold As Integer
        Public Property Health As Integer
        Public Property Exp As Integer
        Public Property Icon As String

        Public Shared Sub SaveCharacterToSession(gameCharacter As GameCharacter)
            HttpContext.Current.Session("GameCharacter") = gameCharacter
        End Sub

        Public Shared Function GetCharacterFromSession() As GameCharacter
            Return CType(HttpContext.Current.Session("GameCharacter"), GameCharacter)
        End Function
    End Class
End Namespace