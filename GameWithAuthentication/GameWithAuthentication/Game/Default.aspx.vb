Imports System.Data
Imports GameWithAuthentication.GameWithAuthentication

Namespace Game
    Public Class _Default
        Inherits Page
        Private _selectedUser As GameCharacter

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not IsPostBack Then ddlCharacters.DataBind()
            _selectedUser = GetSelectedUser()
            lName.Text = _selectedUser.Name
            lHp.Text = _selectedUser.Health
            lGold.Text = _selectedUser.Gold
            lExp.Text = _selectedUser.Exp
            imgIcon.ImageUrl = "~/Images/" + _selectedUser.Icon
        End Sub

        Protected Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles sdsCharacters.Selecting
            e.Command.Parameters("uname").Value = Page.User.Identity.Name
        End Sub

        Private Function GetSelectedUser() As GameCharacter
            Dim uid As String = "ID =" & ddlCharacters.SelectedValue
            Dim characterTable As DataView = CType(sdsCharacters.Select(DataSourceSelectArguments.Empty), DataView)
            characterTable.RowFilter = uid
            Dim userCharacter As DataRowView = CType(characterTable(0), DataRowView)
            Dim gameCharacter As New GameCharacter
            gameCharacter.Id = userCharacter("ID")
            gameCharacter.Name = userCharacter("CName")
            gameCharacter.Rloc = userCharacter("rloc")
            gameCharacter.Cloc = userCharacter("cloc")
            gameCharacter.Gold = userCharacter("gold")
            gameCharacter.Exp = userCharacter("exp")
            gameCharacter.Health = userCharacter("health")
            gameCharacter.Icon = userCharacter("icon")
            Return gameCharacter
        End Function

        Protected Sub btnSelectCharacter_Click(sender As Object, e As EventArgs) Handles btnSelectCharacter.Click
            GameCharacter.SaveCharacterToSession(_selectedUser) 'this method takes the selected character and saves it into session.
            Response.Redirect("Success.aspx", False)
        End Sub
    End Class
End Namespace