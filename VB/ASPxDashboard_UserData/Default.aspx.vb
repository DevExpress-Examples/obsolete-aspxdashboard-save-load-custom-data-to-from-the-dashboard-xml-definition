Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports DevExpress.Web
Imports System
Imports System.Web.Script.Serialization
Imports System.Xml.Linq

Namespace ASPxDashboard_UserData
    Partial Public Class [Default]
        Inherits System.Web.UI.Page

        Private dashboardStorage As New DashboardFileStorage("~/App_Data/Dashboards")
        Private dateModified As String
        Private comment As String
        Private dashboardState As String

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Sets a dashboard storage and loads the specified dashboard from this storage.
            ASPxDashboard1.SetDashboardStorage(dashboardStorage)
            ASPxDashboard1.InitialDashboardId = "dashboard2"
        End Sub

        ' Handles the CustomDataCallback event that is used to obtain custom data from the client side.
        ' On the client side, the PerformDataCallback method is called to pass data and generate CustomDataCallback.
        Protected Sub ASPxDashboard1_CustomDataCallback(ByVal sender As Object, ByVal e As CustomDataCallbackEventArgs)
            Dim serializer As New JavaScriptSerializer()
            Dim json As Object = serializer.Deserialize(Of Object)(e.Parameter)
            Dim dashboardJson As String = json("dashboardJson").ToString()
            Dim dateModified As String = json("dateModified").ToString()
            Dim comment As String = json("comment").ToString()
            Dim dashboardState As String = json("dashboardState").ToString()

            Dim dashboardDocument As XDocument = DashboardJsonConverter.JsonToXml(dashboardJson)
            Dim dashboard As New Dashboard()
            dashboard.LoadFromXDocument(dashboardDocument)
            Dim userData As New XElement("Root", New XElement("DateModified", dateModified), New XElement("Comment", comment), New XElement("DashboardState", dashboardState))
            dashboard.UserData = userData

            e.Result = DirectCast(dashboardStorage, IEditableDashboardStorage).AddDashboard(dashboard.SaveToXDocument(), dashboard.Title.Text)
        End Sub

        ' Creates a set of client side properties used to pass custom data loaded from UserData to the client side.
        Protected Sub ASPxDashboard1_CustomJSProperties(ByVal sender As Object, ByVal e As CustomJSPropertiesEventArgs)
            e.Properties.Add("cpDateModified", dateModified)
            e.Properties.Add("cpComment", comment)
            e.Properties.Add("cpDashboardState", dashboardState)
        End Sub

        ' Obtains the custom data from the UserData element when loading a dashboard.
        Protected Sub ASPxDashboard1_DashboardLoading(ByVal sender As Object, ByVal e As DashboardLoadingWebEventArgs)
            Dim dashboard As New Dashboard()
            dashboard.LoadFromXDocument(e.DashboardXml)
            Dim data As XElement = dashboard.UserData
            If data IsNot Nothing Then
                dateModified = data.Element("DateModified").Value
                comment = data.Element("Comment").Value
                dashboardState = data.Element("DashboardState").Value
            End If
        End Sub
    End Class
End Namespace