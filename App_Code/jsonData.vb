Imports Microsoft.VisualBasic

Public Class jsonData
    Public Property pk As String
    Public Property articles As List(Of Article)
End Class


Public Class Article
    Public Property id As String
    Public Property articletitle As String
    Public Property articleauthor As String
    Public Property articlebody As String
    Public Property articleimage As String
    Public Property createdonutc As String
    Public Property modifiedonutc As String
    Public Property status As String
End Class