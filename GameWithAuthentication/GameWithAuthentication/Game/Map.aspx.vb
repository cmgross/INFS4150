﻿Imports System.Drawing
Imports System.Data.OleDb
Imports System.Configuration
Imports GameWithAuthentication.GameWithAuthentication

Public Class Map
    Inherits System.Web.UI.Page
    Dim _map(9, 9) As Integer
    Dim _bigmap(9, 9, 1) As Integer
    Private _selectedCharacter As GameCharacter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetButtonArrows()
        If Not IsPostBack Then UpdateMap()
    End Sub

    Private Sub UpdateMap()
        Dim terrainDisplay = Session("terrainDisplay")
        If terrainDisplay Is Nothing Then Response.Redirect("Default.aspx") 'default wasn't visited first
        Dim terrainColor = Session("terrainColor")
        'Dim example = Session("map00") 'this is the ID of what the terrain should be, so do
        'Dim exampleTerrain = terrain(example - 1)
        'Dim exampleTerrainColor = terrainColor(example - 1)
        _selectedCharacter = GameCharacter.GetCharacterFromSession()

        Dim conn As New OleDbConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
        Dim cmd As OleDbCommand
        Dim read As OleDbDataReader
        Dim rows, cells, j, i, currentRow, currentColumn As Integer

        currentRow = Session("CurrentRow")
        currentColumn = Session("CurrentColumn")
        Dim currentMapId As String = Session("map" & currentRow & currentColumn)(1).ToString()

        Using conn
            conn.Open()
            'Set visited for this location, mapID is retrieved from session map of row/column combination
            Dim sql As String
            sql = "UPDATE [CharacterMap] SET [VISITED] = TRUE WHERE [CharacterId] = " + _selectedCharacter.Id.ToString() + " AND [MapId] = " + currentMapId + ";"
            cmd = New OleDbCommand(sql, conn)
            cmd.Connection = conn
            cmd.ExecuteNonQuery()

            'Then saved the player's location for the character. (auto-save rather than button)
            sql = "UPDATE [Character] SET [Row] = " + currentRow.ToString() + ", [Column] =" + currentColumn.ToString() + " WHERE [Id] = " + _selectedCharacter.Id.ToString() + ";"
            cmd = New OleDbCommand(sql, conn)
            cmd.Connection = conn
            cmd.ExecuteNonQuery()

            'populate/update big map with terrain types and visited, needs to happen every page load as player moves
            For j = 0 To 9
                For i = 0 To 9
                    Dim mapId As String = Session("map" & j & i)(1).ToString()
                    cmd = New OleDbCommand("SELECT * FROM [CharacterMap] WHERE [CharacterId] = " + _selectedCharacter.Id.ToString() + "AND [MapId] = " + mapId + ";", conn)
                    read = cmd.ExecuteReader()
                    read.Read()
                    _bigmap(j, i, 0) = Session("map" & j & i)(0) 'example: _bigmap(0,0,0)(0) = terrainId of 0
                    _bigmap(j, i, 1) = Convert.ToInt32(read.Item("Visited")) 'by default, true as int is -1 in VB, Int32 makes it 1
                Next
            Next
            read.Close()
            conn.Close()
        End Using

        'populate/update the 3x3 minimap, currentRow and currentColumn are where the player is standing, so we draw around them in the center
        For j = (currentRow - 1) To (currentRow + 1)
            Dim r As New TableRow()
            For i = (currentColumn - 1) To (currentColumn + 1)
                Dim c As New TableCell()
                Dim h As New HyperLink()
                If (j < 0 Or i < 0 Or j > 9 Or i > 9) Then 'beyond the map, draw as black/wall
                    c.BackColor = Color.Black
                    c.ForeColor = Color.Black
                    c.BorderColor = Color.Black
                    c.Text = "++++++++"
                ElseIf (j = currentRow And i = currentColumn And (_map(j, i) <> 999)) Then 'player is here
                    c.BackColor = Color.Yellow
                    Dim terrainId As Integer = _bigmap(j, i, 0) - 1
                    c.Text = terrainDisplay(terrainId)
                    lblInfo.Text = terrainDisplay(terrainId)
                ElseIf ((_map(j, i) = 999)) Then 'special item
                    c.BackColor = Color.Red
                    c.Text = "Stairs"
                Else 'regular terrain
                    Dim terrainId As Integer = _bigmap(j, i, 0) - 1
                    c.Text = terrainDisplay(terrainId)
                    c.BackColor = Color.FromName(terrainColor(terrainId))
                End If
                r.Cells.Add(c)
            Next
            tbGameMap.Rows.Add(r)
        Next

        'populate the world map
        rows = 10
        cells = 10

        For j = 0 To rows - 1
            Dim r As New TableRow()
            For i = 0 To cells - 1
                Dim c As New TableCell()
                Dim h As New HyperLink()
                If (j = currentRow And i = currentColumn) Then 'player is here
                    c.BackColor = Color.Yellow
                    h.Text = "You"
                    h.ForeColor = Color.Black
                ElseIf (_bigmap(j, i, 1) = 1) Then 'player is not here, but has visited
                    Dim terrainId As Integer = _bigmap(j, i, 0) - 1
                    h.Text = terrainDisplay(terrainId)
                    c.BackColor = Color.FromName(terrainColor(terrainId))
                    h.ForeColor = Color.Black
                Else 'player is not here and has not been here before
                    h.Text = "??????"
                    h.ForeColor = Color.DimGray
                    c.BackColor = Color.DimGray
                    c.BorderColor = Color.DimGray
                End If
                c.Controls.Add(h)
                r.Cells.Add(c)
            Next
            tbWorldMap.Rows.Add(r)
        Next
        GameCharacter.SaveCharacterToSession(_selectedCharacter)
    End Sub
    Private Sub SetButtonArrows()
        'from http://www.alanwood.net/unicode/arrows.html
        btnUpLeft.Text = Server.HtmlDecode("&#8598;")
        btnUp.Text = Server.HtmlDecode("&#8593;")
        btnUpRight.Text = Server.HtmlDecode("&#8599;")
        btnLeft.Text = Server.HtmlDecode("&#8592;")
        btnRight.Text = Server.HtmlDecode("&#8594;")
        btnDownLeft.Text = Server.HtmlDecode("&#8601;")
        btnDown.Text = Server.HtmlDecode("&#8595;")
        btnDownRight.Text = Server.HtmlDecode("&#8600;")
    End Sub

#Region "MovementButtons"
    Protected Sub btnUpLeft_Click(sender As Object, e As EventArgs) Handles btnUpLeft.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("CurrentRow")
        cvalue = Session("CurrentColumn")
        If (rvalue > 0) Then rvalue = rvalue - 1
        If (cvalue > 0) Then cvalue = cvalue - 1
        Session("CurrentRow") = rvalue
        Session("CurrentColumn") = cvalue
        UpdateMap()
    End Sub
    Protected Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("CurrentRow")
        cvalue = Session("CurrentColumn")
        If (rvalue > 0) Then rvalue = rvalue - 1
        Session("CurrentRow") = rvalue
        Session("CurrentColumn") = cvalue
        UpdateMap()
    End Sub

    Protected Sub btnUpRight_Click(sender As Object, e As EventArgs) Handles btnUpRight.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("CurrentRow")
        cvalue = Session("CurrentColumn")
        If (rvalue > 0) Then rvalue = rvalue - 1
        If (cvalue < 9) Then cvalue = cvalue + 1
        Session("CurrentRow") = rvalue
        Session("CurrentColumn") = cvalue
        UpdateMap()
    End Sub

    Protected Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("CurrentRow")
        cvalue = Session("CurrentColumn")
        If (cvalue > 0) Then cvalue = cvalue - 1
        Session("CurrentRow") = rvalue
        Session("CurrentColumn") = cvalue
        UpdateMap()
    End Sub

    Protected Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("CurrentRow")
        cvalue = Session("CurrentColumn")
        If (cvalue < 9) Then cvalue = cvalue + 1
        Session("CurrentRow") = rvalue
        Session("CurrentColumn") = cvalue
        UpdateMap()
    End Sub

    Protected Sub btnDownLeft_Click(sender As Object, e As EventArgs) Handles btnDownLeft.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("CurrentRow")
        cvalue = Session("CurrentColumn")
        If (rvalue < 9) Then rvalue = rvalue + 1
        If (cvalue > 0) Then cvalue = cvalue - 1
        Session("CurrentRow") = rvalue
        Session("CurrentColumn") = cvalue
        UpdateMap()
    End Sub

    Protected Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("CurrentRow")
        cvalue = Session("CurrentColumn")
        If (rvalue < 9) Then rvalue = rvalue + 1
        Session("CurrentRow") = rvalue
        Session("CurrentColumn") = cvalue
        UpdateMap()
    End Sub

    Protected Sub btnDownRight_Click(sender As Object, e As EventArgs) Handles btnDownRight.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("CurrentRow")
        cvalue = Session("CurrentColumn")
        If (rvalue < 9) Then rvalue = rvalue + 1
        If (cvalue < 9) Then cvalue = cvalue + 1
        Session("CurrentRow") = rvalue
        Session("CurrentColumn") = cvalue
        UpdateMap()
    End Sub
#End Region
End Class