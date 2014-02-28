Imports CharlesGrossAssignment3.CharlesGrossAssignment3

Public Class Success
    Inherits System.Web.UI.Page
    Private _selectedUser As GameUser

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _selectedUser = GameUser.GetCharacterFromSession()
        If (_selectedUser Is Nothing) Then Response.Redirect("Default.aspx", False) 'you visited this page first, or something went wrong with selection
        lName.Text = _selectedUser.Name
        imgIcon.ImageUrl = "Images/" + _selectedUser.Icon
        lHp.Text = _selectedUser.Health
        lGold.Text = _selectedUser.Gold
        lExp.Text = _selectedUser.Exp
        lRow.Text = _selectedUser.Rloc
        lCol.Text = _selectedUser.Cloc
    End Sub
End Class