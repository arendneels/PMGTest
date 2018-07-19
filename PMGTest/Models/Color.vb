Imports MySql.Data.MySqlClient

Public Class Color
    Public id
    Public hex

    Function All() As IEnumerable(Of Color)
        'Query
        Dim ConnString As String = "server=localhost;user=root;password=;port=3306;database=pmg_db;sslmode=none"
        Dim conn As New MySqlConnection(ConnString)
        Dim result = New List(Of Color)
        Try
            conn.Open()
            Dim Sql As String = "SELECT * FROM colors"
            Dim cmd As New MySqlCommand(Sql, conn)
            Dim rdr As MySqlDataReader = cmd.ExecuteReader()

            While rdr.Read()
                Dim color = New Color()
                color.id = rdr(0)
                color.hex = rdr(1)
                result.Add(color)
            End While
            rdr.Close()
        Catch ex As MySqlException
        End Try
        Return result
    End Function
End Class
