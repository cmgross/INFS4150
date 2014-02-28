Imports System.Data
Imports CharlesGrossAssignment3.CharlesGrossAssignment3

Public Class _Default
    Inherits Page
    Private _selectedUser As GameUser

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then ddlUsers.DataBind()
        _selectedUser = GetSelectedUser()
        lName.Text = _selectedUser.Name
        lHp.Text = _selectedUser.Health
        lGold.Text = _selectedUser.Gold
        lExp.Text = _selectedUser.Exp
        imgIcon.ImageUrl = "Images/" + _selectedUser.Icon
    End Sub

    Private Function GetSelectedUser() As GameUser
        Dim uid As String = "ID =" & ddlUsers.SelectedValue
        Dim userTable As DataView = CType(sdsUsers.Select(DataSourceSelectArguments.Empty), DataView)
        userTable.RowFilter = uid
        Dim userRow As DataRowView = CType(userTable(0), DataRowView)
        Dim gameUser As New GameUser
        gameUser.Id = userRow("ID")
        gameUser.Name = userRow("CName")
        gameUser.Rloc = userRow("rloc")
        gameUser.Cloc = userRow("cloc")
        gameUser.Gold = userRow("gold")
        gameUser.Exp = userRow("exp")
        gameUser.Health = userRow("health")
        gameUser.Icon = userRow("icon")
        Return gameUser
    End Function

    Protected Sub btnSelectCharacter_Click(sender As Object, e As EventArgs) Handles btnSelectCharacter.Click
        GameUser.SaveCharacterToSession(_selectedUser) 'this method takes the selected user and saves it into session.
        Response.Redirect("Success.aspx", False)
    End Sub
End Class