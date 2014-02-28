Imports System.Data

Public Class _Default
    Inherits Page

    Public Class GameUser
        Public Property Id As Integer
        Public Property Name As String
        Public Property Rloc As Integer
        Public Property Cloc As Integer
        Public Property Gold As Integer
        Public Property Health As Integer
        Public Property Exp As Integer
        Public Property Icon As String
    End Class

    Private _selectedUser As GameUser

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'TODO switch to SelectedIndexChange method
        If Not IsPostBack Then ddlUsers.DataBind()
        _selectedUser = GetSelectedUser()
        lGold.Text = _selectedUser.Gold
        lExp.Text = _selectedUser.Exp
        imgIcon.ImageUrl = "Images/" + _selectedUser.Icon 'TODO find icons for characters as same size, and put in db and images folder
    End Sub

    Private Function GetSelectedUser() As GameUser 'TODO refactor this ugh
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
        'TODO Load control into session variables
        'TODO Use bootswatch - superhero
    End Sub
End Class