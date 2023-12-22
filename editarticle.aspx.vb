
Imports System.IO
Imports System.Web.Script.Serialization

Partial Class editarticle
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

            txtarticletitle.Text = objArticle.articletitle
            txtarticleauthor.Text = objArticle.articleauthor
            txtarticlebody.Text = objArticle.articlebody
            hdnarticleimage.Value = objArticle.articleimage


        End If

    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs)
        Dim id As Int32 = Convert.ToInt32(Request("id"))

        Dim articletitle As String = txtarticletitle.Text

        Dim articleauthor As String = txtarticleauthor.Text

        Dim articlebody As String = txtarticlebody.Text

        Dim articleimage As String = hdnarticleimage.Value

        Dim jsonFilePath As String = Server.MapPath("/db/data.json")

        Dim obj_jsonData As New jsonData


        Dim jsonData As String = File.ReadAllText(jsonFilePath)
        obj_jsonData = serializer.Deserialize(Of jsonData)(jsonData)

        Dim objArticle As Article = (From v In obj_jsonData.articles Where v.id.Equals(id.ToString()) Select (v)).Take(1).Cast(Of Article).FirstOrDefault()

        objArticle.articletitle = articletitle
        objArticle.articleauthor = articleauthor
        objArticle.articlebody = articlebody
        objArticle.articleimage = articleimage
        objArticle.modifiedonutc = DateTime.UtcNow.ToString()

        jsonData = serializer.Serialize(obj_jsonData)

        File.WriteAllText(jsonFilePath, jsonData)


        Response.Write("<script type='text/javascript'>parent.ArticleEdited();</script>")
        Response.End()


    End Sub
End Class
