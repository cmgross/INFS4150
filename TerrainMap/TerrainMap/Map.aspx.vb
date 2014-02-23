Imports System.Data.OleDb

Public Class Map
    Inherits System.Web.UI.Page
    'declare global variables
    Dim _map(9, 9) As Integer
    Dim _bigmap(9, 9, 2) As Integer
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO:
        'Debug why movement arrows don't seem to work
        'Redo database for Terrain to be fewer terrain types and have a color instead of an image
        'Utilize terrain background colors for the tiles http://www.hiddentriforce.com/wp-content/uploads/2011/09/legend-of-zelda-map.png
        SetButtonArrows()
        Dim terrain = Session("terrain")
        Dim terrainImages = Session("terrainImages")
        Dim example = Session("map00") 'this is the ID of what the terrain should be, so do
        Dim exampleTerrain = terrain(example - 1)
        Dim exampleTerrainFile = terrainImages(example - 1)

        Dim conn As New OleDbConnection(ConfigurationManager.ConnectionStrings("GameDB").ConnectionString)
        Dim rows, cells, j, i, rvalue, cvalue As Integer

        'populate/update big map with terrain types and visited, needs to happen every page load as player moves
        'Set visited for this location, rvalue and cvalue are current player location
        'Then saved the player's location for the character. (auto-save rather than button)
        Using conn
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT * from maps;", conn)
            conn.Open()
            Dim read As OleDbDataReader = cmd.ExecuteReader()
            If read.HasRows Then
                For j = 0 To 9
                    For i = 0 To 9
                        read.Read()
                        _bigmap(j, i, 0) = read.Item("Terrain")
                        _bigmap(j, i, 1) = read.Item("visited")
                    Next
                Next
            Else
                For j = 0 To 9
                    For i = 0 To 9
                        _bigmap(j, i, 0) = CInt(Math.Ceiling(Rnd() * 10)) - 1
                    Next
                Next
            End If
            read.Close()
            Dim sql As String
            sql = "Update maps set visited = 1 where row =" + Session("rows").ToString() + " and col = " + Session("rows").ToString() + ";"
            cmd = New OleDbCommand(sql, conn)
            cmd.Connection = conn
            cmd.ExecuteNonQuery()
            sql = "Update userchar set rloc = " + Session("rows").ToString() + " , cloc =" + Session("rows").ToString() + " where ID = 1;"
            cmd = New OleDbCommand(sql, conn)
            cmd.Connection = conn
            cmd.ExecuteNonQuery()
            conn.Close()
        End Using

        'populate/update the 3x3 minimap, rvalue and cvalue are where the player is standing, so we draw around them in the center
        rvalue = Session("rows")
        cvalue = Session("cols")

        For j = (rvalue - 1) To (rvalue + 1)
            Dim r As New TableRow()
            For i = (cvalue - 1) To (cvalue + 1)
                Dim c As New TableCell()
                Dim h As New HyperLink()
                If (j < 0 Or i < 0 Or j > 9 Or i > 9) Then 'beyond the map, draw as black/wall
                    c.BackColor = Drawing.Color.Black
                    c.ForeColor = Drawing.Color.Black
                    c.BorderColor = Drawing.Color.Black
                    c.Text = "++++++++"
                ElseIf (j = rvalue And i = cvalue And (_map(j, i) <> 999)) Then 'player is here
                    c.BackColor = Drawing.Color.Yellow
                    ''c.Text = (terrain(Session("map" & j & i)))
                    c.Text = (terrain(_bigmap(j, i, 0)))
                    lblInfo.Text = (terrain(_bigmap(j, i, 0)))
                ElseIf ((_map(j, i) = 999)) Then 'special item
                    c.BackColor = Drawing.Color.YellowGreen
                    c.Text = "Stairs"
                    '_bigmap(j, i, 1) = 1
                Else 'regular terrain
                    c.Text = (terrain(Session("map" & j & i)))
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
                If (j = rvalue And i = cvalue) Then 'player is here
                    c.BackColor = Drawing.Color.Yellow
                    'h.Text = _terrain(_bigmap(j, i, 0))
                    h.Text = "You"
                ElseIf (_bigmap(j, i, 1) = 1) Then 'player is not here, but has visited
                    h.Text = terrain(_bigmap(j, i, 0))
                Else 'player is not here and has not been here before
                    h.Text = "??????"
                    h.ForeColor = Drawing.Color.DimGray
                    c.BackColor = Drawing.Color.DimGray
                    c.BorderColor = Drawing.Color.DimGray
                End If
                c.Controls.Add(h)
                r.Cells.Add(c)
            Next
            tbWorldMap.Rows.Add(r)
        Next


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
        rvalue = Session("rows")
        cvalue = Session("cols")
        If (rvalue > 0) Then rvalue = rvalue - 1
        If (cvalue > 0) Then cvalue = cvalue - 1
        Session("rows") = rvalue
        Session("cols") = cvalue
    End Sub
    Protected Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("rows")
        cvalue = Session("cols")
        If (rvalue > 0) Then rvalue = rvalue - 1
        Session("rows") = rvalue
        Session("cols") = cvalue
    End Sub

    Protected Sub btnUpRight_Click(sender As Object, e As EventArgs) Handles btnUpRight.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("rows")
        cvalue = Session("cols")
        If (rvalue > 0) Then rvalue = rvalue - 1
        If (cvalue < 9) Then cvalue = cvalue + 1
        Session("rows") = rvalue
        Session("cols") = cvalue
    End Sub

    Protected Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("rows")
        cvalue = Session("cols")
        If (cvalue > 0) Then cvalue = cvalue - 1
        Session("rows") = rvalue
        Session("cols") = cvalue
    End Sub

    Protected Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("rows")
        cvalue = Session("cols")
        If (cvalue < 9) Then cvalue = cvalue + 1
        Session("rows") = rvalue
        Session("cols") = cvalue
    End Sub

    Protected Sub btnDownLeft_Click(sender As Object, e As EventArgs) Handles btnDownLeft.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("rows")
        cvalue = Session("cols")
        If (rvalue < 9) Then rvalue = rvalue + 1
        If (cvalue > 0) Then cvalue = cvalue - 1
        Session("rows") = rvalue
        Session("cols") = cvalue
    End Sub

    Protected Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("rows")
        cvalue = Session("cols")
        If (rvalue < 9) Then rvalue = rvalue + 1
        Session("rows") = rvalue
        Session("cols") = cvalue
    End Sub

    Protected Sub btnDownRight_Click(sender As Object, e As EventArgs) Handles btnDownRight.Click
        Dim rvalue, cvalue As Integer
        rvalue = Session("rows")
        cvalue = Session("cols")
        If (rvalue < 9) Then rvalue = rvalue + 1
        If (cvalue < 9) Then cvalue = cvalue + 1
        Session("rows") = rvalue
        Session("cols") = cvalue
    End Sub
#End Region



End Class