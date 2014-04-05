Imports GameWithAuthentication.GameWithAuthentication

Public Class Character
    Inherits Page
    Private _selectedUser As GameCharacter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then ddlImages.DataBind()
        If IsPostBack Then Return
        Dim characterId As String = Request.QueryString("characterId")

        If (characterId Is Nothing) Then 'this is a new character creation
            lPageAction.Text = "Create a new character"
            lHp.Text = "5"
            lExp.Text = "0"
            lGold.Text = "0"
            imgIcon.ImageUrl = "~/Images/" + ddlImages.SelectedItem.Text
        Else 'this an existing character to edit, they should also be in session
            lPageAction.Text = "Edit your character"
            _selectedUser = GameCharacter.GetCharacterFromSession()
            txtName.Text = _selectedUser.CharacterName
            lHp.Text = _selectedUser.Hp
            lExp.Text = _selectedUser.Xp
            lGold.Text = _selectedUser.Gold
            imgIcon.ImageUrl = "~/Images/" + _selectedUser.Icon
            ddlImages.SelectedItem.Text = _selectedUser.Icon
        End If
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim characterId As String = Request.QueryString("characterId")
        If (characterId Is Nothing) Then 'this is a new character creation 
            _selectedUser = New GameCharacter
        Else
            _selectedUser = GameCharacter.GetCharacterFromSession()
        End If
        _selectedUser.CharacterName = txtName.Text
        _selectedUser.Hp = lHp.Text
        _selectedUser.Xp = lExp.Text
        _selectedUser.Gold = lGold.Text
        _selectedUser.Icon = ddlImages.SelectedItem.Text
        _selectedUser.Save(Page.User.Identity.Name)
        GameCharacter.SaveCharacterToSession(_selectedUser)
        Response.Redirect("Default.aspx", False)
    End Sub

    Protected Sub ddlImages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlImages.SelectedIndexChanged
        imgIcon.ImageUrl = "~/Images/" + ddlImages.SelectedItem.Text
    End Sub
End Class