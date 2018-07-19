Imports System.IO
Imports System.Runtime.Remoting.Contexts
Imports System.Web.Script.Serialization
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index(Optional lang As String = "unset", Optional page As Integer = 1) As ActionResult
        If lang = "unset" Then
            'Improve by using system language instead of universal default language
            Return Redirect("/en/tegels/1")
        End If

        Dim tile As New Tile()
        ViewData("Tiles") = tile.All(lang, page)
        ViewData("TileCount") = tile.CountTotal()
        Dim color As New Color()
        ViewData("Colors") = color.All()

        ViewData("lang") = lang
        ViewData("page") = page
        Return View()
    End Function

    <HttpPost()>
    Function Create(ByVal collection As FormCollection) As ActionResult
        Dim nl = collection("nl")
        Dim en = collection("en")
        Dim fr = collection("fr")
        Dim color_id = collection("color_id")
        Dim tile = New Tile()
        Dim new_order = tile.CountTotal() + 1
        tile.Create(nl, en, fr, color_id, new_order)

        'Redirect back
        Return Redirect(Request.UrlReferrer.ToString())
    End Function

    <Serializable>
    Public Class ChangeOrderClass
        Public Property id() As String
            Get
                Return m_id
            End Get
            Set
                m_id = Value
            End Set
        End Property
        Private m_id As Integer
        Public Property new_order() As String
            Get
                Return m_new_order
            End Get
            Set
                m_new_order = Value
            End Set
        End Property
        Private m_new_order As Integer
    End Class

    <HttpPost()>
    Sub changeorder()
        Dim req = Request.InputStream
        req.Seek(0, SeekOrigin.Begin)
        Dim json = New StreamReader(req).ReadToEnd()
        Dim jss As New JavaScriptSerializer
        Dim o = jss.Deserialize(Of List(Of ChangeOrderClass))(json)
        Dim tile = New Tile
        tile.ChangeOrder(o)
    End Sub

    Function Edit(lang As String, ByVal id As Integer) As ActionResult
        ViewData("lang") = lang
        Dim tile As New Tile()
        ViewData("Tiles") = tile.GetById(id)
        Dim color As New Color()
        ViewData("Colors") = color.All()
        Return View()
    End Function

    <HttpPost()>
    Function Edit(lang As String, ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim nl = collection("nl")
        Dim en = collection("en")
        Dim fr = collection("fr")
        Dim color_id = collection("color_id")
        Dim tile As New Tile
        tile.Update(id, nl, en, fr, color_id)
        Dim url = "/" & lang & "/tegels/1"

        Return Redirect(url)

    End Function

End Class
