
Imports System.IO
Imports System.Web.Script.Serialization

Partial Class addnewarticle
    Inherits System.Web.UI.Page

    Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        diverror.Visible = False
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)

        Dim articletitle As String = txtarticletitle.Text

        Dim articleauthor As String = txtarticleauthor.Text

        Dim articlebody As String = txtarticlebody.Text

        Dim articleimage As String = hdnarticleimage.Value

        Dim articleExists As Boolean = False

        Dim obj_jsonData As New jsonData

        Dim objArticles As New List(Of Article)

        Dim jsonFilePath As String = Server.MapPath("/db/data.json")

        Dim pk As Int32 = 1

        If File.Exists(jsonFilePath) Then

            Dim jsonData As String = File.ReadAllText(jsonFilePath)
            obj_jsonData = serializer.Deserialize(Of jsonData)(jsonData)
            pk = Convert.ToInt32(obj_jsonData.pk)

            pk = pk + 1

            '//Checking if the article already exists or not

            For Each objarticle As Article In obj_jsonData.articles

                If objarticle.articletitle.Equals(articletitle) Then
                    articleExists = True
                End If

            Next

            objArticles = obj_jsonData.articles

        End If

        If articleExists = True Then

            lblerror.Text = "Article Already Exists."
            diverror.Visible = True

        Else

            Dim objArticle As New Article

            objArticle.id = pk.ToString()
            objArticle.articletitle = articletitle
            objArticle.articleauthor = articleauthor
            objArticle.articlebody = articlebody
            objArticle.articleimage = articleimage
            objArticle.createdonutc = DateTime.UtcNow.ToString()
            objArticle.status = "E"

            obj_jsonData.pk = pk.ToString()

            objArticles.Add(objArticle)
            obj_jsonData.articles = objArticles

            Dim jsonData As String = serializer.Serialize(obj_jsonData)

            File.WriteAllText(jsonFilePath, jsonData)

            Response.Write("<script type='text/javascript'>parent.newArticleAdded();</script>")
            Response.End()

        End If

    End Sub

End Class
