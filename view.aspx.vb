Imports System.IO
Imports System.Web.Script.Serialization

Partial Class view
    Inherits System.Web.UI.Page

    Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim id As Int32 = Convert.ToInt32(Request("id"))

        Dim jsonFilePath As String = Server.MapPath("/db/data.json")

        Dim obj_jsonData As New jsonData


        Dim jsonData As String = File.ReadAllText(jsonFilePath)
        obj_jsonData = serializer.Deserialize(Of jsonData)(jsonData)

        Dim objArticle As Article = (From v In obj_jsonData.articles Where v.id.Equals(id.ToString()) Select (v)).Take(1).Cast(Of Article).FirstOrDefault()


        litarticletitle.Text = objArticle.articletitle
        litarticleauthor.Text = objArticle.articleauthor
        litarticlebody.Text = objArticle.articlebody

        If objArticle.articleimage & "" <> "" Then
            divimage.Visible = True
            imgarticle.ImageUrl = objArticle.articleimage
        End If

        Page.Title = litarticletitle.Text

    End Sub

End Class
