Imports GameWithAuthentication.GameWithAuthentication

Namespace Game
    Public Class Success
        Inherits System.Web.UI.Page
        Private _selectedCharacter As GameCharacter

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            _selectedCharacter = GameCharacter.GetCharacterFromSession()
            If (_selectedCharacter Is Nothing) Then Response.Redirect("Default.aspx", False) 'you visited this page first, or something went wrong with selection
            lName.Text = _selectedCharacter.Name
            imgIcon.ImageUrl = "~/Images/" + _selectedCharacter.Icon
            lHp.Text = _selectedCharacter.Health
            lGold.Text = _selectedCharacter.Gold
            lExp.Text = _selectedCharacter.Exp
            lRow.Text = _selectedCharacter.Rloc
            lCol.Text = _selectedCharacter.Cloc
        End Sub
    End Class
End Namespace