
Imports System.IO
Imports System.Web.Script.Serialization

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsPostBack = False Then

            Dim obj_jsonData As New jsonData

            Dim objArticles As New List(Of Article)

            Dim jsonFilePath As String = Server.MapPath("/db/data.json")

            Dim jsonData As String = File.ReadAllText(jsonFilePath)
            obj_jsonData = serializer.Deserialize(Of jsonData)(jsonData)

            reparticles.DataSource = obj_jsonData.articles
            reparticles.DataBind()

        End If

    End Sub

End Class
