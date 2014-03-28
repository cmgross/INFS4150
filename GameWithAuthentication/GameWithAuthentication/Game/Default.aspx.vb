Imports GameWithAuthentication.GameWithAuthentication

Namespace Game
    Public Class _Default
        Inherits Page
        Private _selectedUser As GameCharacter

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not IsPostBack Then ddlCharacters.DataBind()
            If IsPostBack Then Return
            If (ddlCharacters.SelectedValue = "") Then
                btnSelectCharacter.Visible = False
                btnEditCharacter.Visible = False
                dNoCharacters.Visible = True
            Else
                btnSelectCharacter.Visible = True
                btnEditCharacter.Visible = True
                dNoCharacters.Visible = False
                CharacterSelected()
            End If
        End Sub

        Private Sub CharacterSelected()
            _selectedUser = New GameCharacter(ddlCharacters.SelectedValue)
            lName.Text = _selectedUser.Name
            lHp.Text = _selectedUser.Health
            lGold.Text = _selectedUser.Gold
            lExp.Text = _selectedUser.Exp
            imgIcon.ImageUrl = "~/Images/" + _selectedUser.Icon
            GameCharacter.SaveCharacterToSession(_selectedUser)
        End Sub
        Protected Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As SqlDataSourceSelectingEventArgs) Handles sdsCharacters.Selecting
            e.Command.Parameters("uname").Value = Page.User.Identity.Name
        End Sub

        Protected Sub btnEditCharacter_Click(sender As Object, e As EventArgs) Handles btnEditCharacter.Click
            Dim characterId As String = ddlCharacters.SelectedValue
            Response.Redirect("Character.aspx?characterId=" + characterId, False)
        End Sub

        Protected Sub btnSelectCharacter_Click(sender As Object, e As EventArgs) Handles btnSelectCharacter.Click
            Response.Redirect("Success.aspx", False)
        End Sub

        Protected Sub ddlCharacters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCharacters.SelectedIndexChanged
            CharacterSelected()
        End Sub
    End Class
End Namespace