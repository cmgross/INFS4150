Imports GameWithAuthentication.GameWithAuthentication

Public Class Character
    Inherits Page
    Private _selectedUser As GameCharacter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If IsPostBack Then Return
        Dim characterId As String = Request.QueryString("characterId")

        If (characterId Is Nothing) Then 'this is a new character creation

        Else 'this an existing character to edit, they should also be in session
            _selectedUser = GameCharacter.GetCharacterFromSession()
        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'GameCharacter.SaveCharacterToSession(_selectedUser) 'this method takes the selected character and saves it into session.
        'If new, insert, else update
        Response.Redirect("Default.aspx", False)
    End Sub

End Class