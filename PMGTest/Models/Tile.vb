Imports MySql.Data.MySqlClient
Imports PMGTest.HomeController

Public Class Tile
    Public id As Integer
    Public color_id As Integer
    Public name As String
    Public color_hex As String
    Public order As Integer
    Public lang As String

    'Default language = nl
    Public Sub New(Optional new_lang As String = "nl")
        lang = new_lang
    End Sub

    Function GetById(id As Integer)
        'Query
        Dim ConnString As String = "server=localhost;user=root;password=;port=3306;database=pmg_db;sslmode=none"
        Dim conn As New MySqlConnection(ConnString)
        Dim result = New List(Of Tile)
        Try
            conn.Open()
            Dim Sql As String =
                "SELECT tiles.id, tilestranslations.name, colors.hex, tiles.new_order, tilestranslations.lang " &
                "FROM tiles " &
                "INNER JOIN tilestranslations ON tiles.id = tilestranslations.tile_id  " &
                "INNER JOIN colors ON tiles.color_id = colors.id " &
                "WHERE tiles.id = " & id
            Dim cmd As New MySqlCommand(Sql, conn)
            Dim rdr As MySqlDataReader = cmd.ExecuteReader()

            While rdr.Read()
                Dim tile = New Tile()
                tile.id = rdr(0)
                tile.name = rdr(1)
                tile.color_hex = rdr(2)
                tile.order = rdr(3)
                tile.lang = rdr(4)
                result.Add(tile)
            End While
            rdr.Close()
        Catch ex As MySqlException
        End Try
        Return result
    End Function

    Function All(tilesLang As String, page As Integer) As IEnumerable(Of Tile)
        'Default language english in case language is invalid
        If tilesLang <> "nl" And tilesLang <> "fr" And tilesLang <> "en" Then
            tilesLang = "en"
        End If
        Dim tilesPerPage = 12
        Dim ConnString As String = "server=localhost;user=root;password=;port=3306;database=pmg_db;sslmode=none"
        Dim conn As New MySqlConnection(ConnString)
        Dim result = New List(Of Tile)
        Try
            conn.Open()
            Dim Sql As String =
                "SELECT tiles.id, tilestranslations.name, colors.hex, tiles.new_order, tilestranslations.lang " &
                "FROM tiles " &
                "INNER JOIN tilestranslations ON tiles.id = tilestranslations.tile_id  " &
                "INNER JOIN colors ON tiles.color_id = colors.id " &
                "WHERE tilestranslations.lang='" & tilesLang & "' " &
                "LIMIT " & tilesPerPage & " OFFSET " & (page - 1) * tilesPerPage & ";"
            Dim cmd As New MySqlCommand(Sql, conn)
            Dim rdr As MySqlDataReader = cmd.ExecuteReader()

            While rdr.Read()
                Dim tile = New Tile()
                tile.id = rdr(0)
                tile.name = rdr(1)
                tile.color_hex = rdr(2)
                tile.order = rdr(3)
                result.Add(tile)
            End While
            rdr.Close()
        Catch ex As MySqlException
        End Try
        Return result
    End Function

    Function CountTotal() As Integer
        Dim ConnString As String = "server=localhost;user=root;password=;port=3306;database=pmg_db;sslmode=none"
        Dim conn As New MySqlConnection(ConnString)
        Dim result = New Integer
        Try
            conn.Open()
            Dim Sql As String =
                "SELECT COUNT(*) FROM tiles"
            Dim cmd As New MySqlCommand(Sql, conn)
            Dim rdr As MySqlDataReader = cmd.ExecuteReader()

            While rdr.Read()
                result = rdr(0)
            End While
            rdr.Close()
        Catch ex As MySqlException
        End Try
        Return result
    End Function

    'Create function
    Function Create(nl As String, en As String, fr As String, color_id As Integer, new_order As Integer)
        'Query
        Dim ConnString As String = "server=localhost;user=root;password=;port=3306;database=pmg_db;sslmode=none"
        Dim conn As New MySqlConnection(ConnString)
        Try
            conn.Open()
            Dim Sql As String = "INSERT INTO tiles (color_id, new_order) " &
                "VALUES (" & color_id & ", " & new_order & ")"
            Dim cmd As New MySqlCommand(Sql, conn)
            cmd.ExecuteNonQuery()

            Dim Sql2 As String = "INSERT INTO tilestranslations (tile_id, lang , name) " &
                "VALUES (" & cmd.LastInsertedId & ", 'nl', '" & nl & "'); " &
                "INSERT INTO tilestranslations (tile_id, lang , name) " &
                "VALUES (" & cmd.LastInsertedId & ", 'en', '" & en & "'); " &
                "INSERT INTO tilestranslations (tile_id, lang , name) " &
                "VALUES (" & cmd.LastInsertedId & ", 'fr', '" & fr & "');"
            Dim cmd2 As New MySqlCommand(Sql2, conn)
            cmd2.ExecuteNonQuery()
        Catch ex As MySqlException
        End Try

    End Function

    Function Update(id As Integer, nl As String, en As String, fr As String, color_id As Integer)
        'Query
        Dim ConnString As String = "server=localhost;user=root;password=;port=3306;database=pmg_db;sslmode=none"
        Try
            Dim conn As New MySqlConnection(ConnString)
            conn.Open()
            Dim Sql As String = "UPDATE tiles SET color_id = " & color_id & " " &
                "WHERE id = " & id
            Dim cmd As New MySqlCommand(Sql, conn)
            cmd.ExecuteNonQuery()

            Dim Sql2 As String = "UPDATE tilestranslations SET name = '" & nl & "' " &
                "WHERE tile_id = " & id & " AND lang = 'nl'; " &
                "UPDATE tilestranslations SET name = '" & fr & "' " &
                "WHERE tile_id = " & id & " AND lang = 'fr'; " &
                "UPDATE tilestranslations SET name = '" & en & "' " &
                "WHERE tile_id = " & id & " AND lang = 'en';"
            Dim cmd2 As New MySqlCommand(Sql2, conn)
            cmd2.ExecuteNonQuery()


        Catch ex As MySqlException
        End Try
    End Function

    Function ChangeOrder(array As List(Of ChangeOrderClass))
        'Query
        Dim ConnString As String = "server=localhost;user=root;password=;port=3306;database=pmg_db;sslmode=none"
        Try
            Dim conn As New MySqlConnection(ConnString)
            conn.Open()
            Dim Sql As String
            For Each element In array
                Sql = Sql & "UPDATE tiles SET new_order = " & element.new_order & " " &
                "WHERE id = " & element.id & ";"
            Next
            Dim cmd As New MySqlCommand(Sql, conn)
            cmd.ExecuteNonQuery()

        Catch ex As MySqlException
        End Try
    End Function

End Class
