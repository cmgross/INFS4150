Imports System.Data.OleDb

Namespace GameWithAuthentication
    Public Class GameCharacter
        Public Property Id As Integer
        Public Property Name As String
        Public Property Rloc As Integer
        Public Property Cloc As Integer
        Public Property Gold As Integer
        Public Property Health As Integer
        Public Property Exp As Integer
        Public Property Icon As String

        Public Sub New()

        End Sub

        Public Sub New(ByVal characterId As String)
            Dim query As String = "SELECT * FROM [userchar] WHERE ID = " + characterId + ";"
            Using conn As New OleDbConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
                conn.Open()
                Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Id = characterId
                    Name = reader.Item("CName")
                    Rloc = reader.Item("rloc")
                    Cloc = reader.Item("cloc")
                    Gold = reader.Item("gold")
                    Exp = reader.Item("exp")
                    Health = reader.Item("health")
                    Icon = reader.Item("icon")
                End While
                reader.Close()
            End Using
        End Sub

        Public Sub Save(ByVal user As String)
            Using conn As New OleDbConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
                Dim sql As String
                If (Id = 0) Then 'new character: insert
                    sql = "INSERT INTO userchar (CName,rloc,cloc,gold,exp,health,icon,[user]) VALUES ('" + Name + "',0,0,0,0,5,'" + Icon + "','" + user + "');"
                Else 'existing character: update, only updates Name and Icon for now
                    sql = "UPDATE userchar SET CName = '" + Name + "', icon = '" + Icon + "' WHERE ID = " + Id.ToString() + ";"
                End If
                conn.Open()
                Dim cmd = New OleDbCommand(sql, conn)
                cmd.Connection = conn
                cmd.ExecuteNonQuery()
                conn.Close()
            End Using
        End Sub

        Public Shared Sub SaveCharacterToSession(gameCharacter As GameCharacter)
            HttpContext.Current.Session("GameCharacter") = gameCharacter
        End Sub

        Public Shared Function GetCharacterFromSession() As GameCharacter
            Return CType(HttpContext.Current.Session("GameCharacter"), GameCharacter)
        End Function
    End Class
End Namespace