Imports System.Data.OleDb
Imports System.Configuration
Imports System.Data.SqlClient

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnNewGame_Click(sender As Object, e As EventArgs) Handles btnNewGame.Click
        Dim terrainRecords As Integer
        Dim terrain(0) As String
        Dim terrainImages(0) As String
        Using conn As New OleDbConnection(ConfigurationManager.ConnectionStrings("GameDB").ConnectionString)
            conn.Open()
            'populate terrain array and put into session
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT count(*) from Terrain;", conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            While reader.Read()
                terrainRecords = reader(0)
            End While
            reader.Close()
            ReDim terrain(terrainRecords - 1)
            ReDim terrainImages(terrainRecords - 1)

            cmd = New OleDbCommand("SELECT * from Terrain;", conn)
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                For i As Integer = 0 To terrainRecords - 1
                    reader.Read()
                    terrain(i) = reader.Item("Display")
                    terrainImages(i) = reader.Item("icon")
                Next
            End If
            reader.Close()

            Session("terrain") = terrain
            Session("terrainImages") = terrainImages

            'populate terrain map from database
            cmd = New OleDbCommand("SELECT * from maps;", conn)
            Dim read As OleDbDataReader = cmd.ExecuteReader()
            If read.HasRows Then
                For j = 0 To 9
                    For i = 0 To 9
                        read.Read()
                        Session("map" & j & i) = read.Item("Terrain")
                    Next
                Next
            Else
                For j = 0 To 9
                    For i = 0 To 9
                        Session("map" & j & i) = CInt(Math.Ceiling(Rnd() * 10)) - 1
                    Next
                Next
            End If
            read.Close()

            'get saved character's location and set it in the session
            cmd = New OleDbCommand("SELECT rloc, cloc from userchar where ID = 1;", conn)
            read = cmd.ExecuteReader()

            read.Read()
            Session("rows") = read.Item("rloc")
            Session("cols") = read.Item("cloc")
            read.Close()
            conn.Close()
        End Using

        'redirect to game page
        Response.Redirect("Map.aspx")
    End Sub
End Class