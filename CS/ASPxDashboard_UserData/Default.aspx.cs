using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.Web;
using System;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace ASPxDashboard_UserData {
    public partial class Default : System.Web.UI.Page {
        DashboardFileStorage dashboardStorage = new DashboardFileStorage(@"~/App_Data/Dashboards");
        string dateModified;
        string comment;
        string dashboardState;

        protected void Page_Load(object sender, EventArgs e) {
            // Sets a dashboard storage and loads the specified dashboard from this storage.
            ASPxDashboard1.SetDashboardStorage(dashboardStorage);
            ASPxDashboard1.InitialDashboardId = "dashboard2";
        }

        // Handles the CustomDataCallback event that is used to obtain custom data from the client side.
        // On the client side, the PerformDataCallback method is called to pass data and generate CustomDataCallback.
        protected void ASPxDashboard1_CustomDataCallback(object sender, CustomDataCallbackEventArgs e) {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic json = serializer.Deserialize<dynamic>(e.Parameter);
            string dashboardJson = json["dashboardJson"].ToString();
            string dateModified = json["dateModified"].ToString();
            string comment = json["comment"].ToString();
            string dashboardState = json["dashboardState"].ToString();

            XDocument dashboardDocument = DashboardJsonConverter.JsonToXml(dashboardJson);
            Dashboard dashboard = new Dashboard();
            dashboard.LoadFromXDocument(dashboardDocument);
            XElement userData = new XElement("Root", new XElement("DateModified", dateModified), new XElement("Comment", comment), new XElement("DashboardState", dashboardState));
            dashboard.UserData = userData;

            e.Result = ((IEditableDashboardStorage)dashboardStorage).AddDashboard(dashboard.SaveToXDocument(), dashboard.Title.Text);
        }

        // Creates a set of client side properties used to pass custom data loaded from UserData to the client side.
        protected void ASPxDashboard1_CustomJSProperties(object sender, CustomJSPropertiesEventArgs e) {
            e.Properties.Add("cpDateModified", dateModified);
            e.Properties.Add("cpComment", comment);
            e.Properties.Add("cpDashboardState", dashboardState);
        }

        // Obtains the custom data from the UserData element when loading a dashboard.
        protected void ASPxDashboard1_DashboardLoading(object sender, DashboardLoadingWebEventArgs e) {
            Dashboard dashboard = new Dashboard();
            dashboard.LoadFromXDocument(e.DashboardXml);
            XElement data = dashboard.UserData;
            if (data != null) {
                dateModified = data.Element("DateModified").Value;
                comment = data.Element("Comment").Value;  
                dashboardState = data.Element("DashboardState").Value;
            }
        }
    }
}