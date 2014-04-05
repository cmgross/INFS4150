Imports System.Data.OleDb

Namespace GameWithAuthentication
    Public Class GameCharacter
        Public Property Id As Integer
        Public Property CharacterName As String
        Public Property Row As Integer
        Public Property Column As Integer
        Public Property Gold As Integer
        Public Property Hp As Integer
        Public Property Xp As Integer
        Public Property Icon As String

        Public Sub New()

        End Sub

        Public Sub New(ByVal characterId As String)
            Dim query As String = "SELECT * FROM [Character] WHERE Id = " + characterId + ";"
            Using conn As New OleDbConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
                conn.Open()
                Dim cmd As OleDbCommand = New OleDbCommand(query, conn)
                Dim reader As OleDbDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Id = characterId
                    CharacterName = reader.Item("CharacterName")
                    Row = reader.Item("Row")
                    Column = reader.Item("Column")
                    Gold = reader.Item("Gold")
                    Xp = reader.Item("Xp")
                    Hp = reader.Item("Hp")
                    Icon = reader.Item("Icon")
                End While
                reader.Close()
            End Using
        End Sub

        Public Sub Save(ByVal userName As String)
            Using conn As New OleDbConnection(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
                Dim sql As String
                If (Id = 0) Then 'new character: insert
                    sql = "INSERT INTO [Character] ([CharacterName],[Row],[Column],[Gold],[Xp],[Hp],[Icon],[UserName]) VALUES ('" + CharacterName + "',0,0,0,0,5,'" + Icon + "','" + userName + "');"
                Else 'existing character: update, only updates Name and Icon for now
                    sql = "UPDATE [Character] SET [CharacterName] = '" + CharacterName + "', [Icon] = '" + Icon + "' WHERE Id = " + Id.ToString() + ";"
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