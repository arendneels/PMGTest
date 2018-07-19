Imports System.Net
Imports System.Web.Http
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Controllers
    Public Class OrderController
        Inherits ApiController

        ' GET: api/Orders
        Public Function Orders() As IEnumerable(Of String)
            Return New String() {"value1", "value2"}
        End Function

        ' GET: api/Default1/5
        Public Function GetValue(ByVal id As Integer) As String
            Return "value"
        End Function


        Structure JSONList
            Dim id As Integer
            Dim new_order As Integer
        End Structure

        ' POST: api/Default1
        Public Sub PostValue(<FromBody()> ByVal input)
            Dim JSONEncode = JsonConvert.SerializeObject(input)
            System.Console.WriteLine("Log text")
            Dim jsonObject As Newtonsoft.Json.Linq.JObject =
                                        JsonConvert.DeserializeObject(JSONEncode)

            Dim JSONDecode() As JSONList = (
                                 From j In jsonObject
                                 Select New JSONList() With {.id = j("id"),
                                                             .new_order = j("new_order")
                                     }
                               ).ToArray()
            Dim result As Integer
            For Each tile In JSONDecode
                result = tile.id
            Next
        End Sub

        ' PUT: api/Default1/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Default1/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace