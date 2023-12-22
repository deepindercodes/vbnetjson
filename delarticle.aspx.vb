
Imports System.IO
Imports System.Web.Script.Serialization

Partial Class delarticle
    Inherits System.Web.UI.Page


    Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsPostBack = False Then

            Dim id As Int32 = Convert.ToInt32(Request("id"))

            Dim obj_jsonData As New jsonData

            Dim objArticles As New List(Of Article)

            Dim jsonFilePath As String = Server.MapPath("/db/data.json")

            Dim jsonData As String = File.ReadAllText(jsonFilePath)
            obj_jsonData = serializer.Deserialize(Of jsonData)(jsonData)

            Dim objArticle As Article = (From v In obj_jsonData.articles Where v.id.Equals(id.ToString()) Select (v)).Take(1).Cast(Of Article).FirstOrDefault()

            obj_jsonData.articles.Remove(objArticle)

            jsonData = serializer.Serialize(obj_jsonData)

            File.WriteAllText(jsonFilePath, jsonData)

            Response.Redirect("/")

        End If

    End Sub

End Class
