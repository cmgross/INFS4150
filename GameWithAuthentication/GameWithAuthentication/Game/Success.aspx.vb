Imports GameWithAuthentication.GameWithAuthentication
Imports System.Data.OleDb
Imports System.Configuration

Namespace Game
    Public Class Success
        Inherits System.Web.UI.Page
        Private _selectedCharacter As GameCharacter

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If (IsPostBack) Then Return
            _selectedCharacter = GameCharacter.GetCharacterFromSession()
            If (_selectedCharacter Is Nothing) Then Response.Redirect("Default.aspx", False) 'you visited this page first, or something went wrong with selection
            lName.Text = _selectedCharacter.CharacterName
            imgIcon.ImageUrl = "~/Images/" + _selectedCharacter.Icon
            lHp.Text = _selectedCharacter.Hp
            lGold.Text = _selectedCharacter.Gold
            lExp.Text = _selectedCharacter.Xp
            lRow.Text = _selectedCharacter.Row
            lCol.Text = _selectedCharacter.Column
        End Sub

        Protected Sub btnEnterGame_Click(sender As Object, e As EventArgs) Handles btnEnterGame.Click
            _selectedCharacter = GameCharacter.GetCharacterFromSession()

            Dim terrainDisplay(9) As String 'We do not allow more than 9 terrain types
            Dim terrainColor(9) As String 'We do not allow more than 9 terrain colors

            Using conn As New OleDbConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
                conn.Open()
                'populate terrain array and put into session
                Dim cmd = New OleDbCommand("SELECT * FROM [Terrain];", conn)
                Dim reader = cmd.ExecuteReader()
                If reader.HasRows Then
                    For i As Integer = 0 To 9
                        reader.Read()
                        terrainDisplay(i) = reader.Item("Display")
                        terrainColor(i) = reader.Item("TileColor")
                    Next
                End If
                'populate terrain map from database
                cmd = New OleDbCommand("SELECT * FROM [Map];", conn)
                reader = cmd.ExecuteReader()
                For j = 0 To 9
                    For i = 0 To 9
                        reader.Read()
                        Session("map" & j & i) = reader.Item("Terrain") 'This stores the TerrainID for a given row and location
                    Next
                Next
                reader.Close()
                conn.Close()
            End Using

            Session("terrainDisplay") = terrainDisplay 'this is an array of terrain text like Dirt, Grass, etc
            Session("terrainColor") = terrainColor ' this is an array of terrain tile colors like Green, Grey, etc

            'get saved character's location and set it in the session
            'TODO We can just set the session character's location to the character and save every time they move, using update method
            Session("CurrentRow") = _selectedCharacter.Row
            Session("CurrentColumn") = _selectedCharacter.Column


            'redirect to game page
            Response.Redirect("Map.aspx")
        End Sub
    End Class
End Namespace