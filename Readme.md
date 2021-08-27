<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128579977/17.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T520934)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Dashboard for Web Forms - How to save/load the custom data to/from the dashboard XML definition

<p>This example demonstrates how to save the custom data related to a dashboard to the dashboard XML definition and how to load this data later. In this example, the standard 'Save' menu item removed from the <a href="https://documentation.devexpress.com/#Dashboard/CustomDocument117444">Web Dashboard menu</a>. A new 'Save As' menu item allows end-users to add a custom comment appended to the dashboard XML definition. Moreover, the current <a href="https://documentation.devexpress.com/#Dashboard/CustomDocument118733">dashboard state</a> and modified date is added to the XML definition. </p>
<p>You can load dashboards containing custom data using the 'Open' menu item. A comment and modified date form the selected dashboard is displayed within the form at the top of the web page. The loaded dashboard state is applied to the dashboard using a client-side API.<br>The following API is used to implement these capabilities

* The <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboard_GetDashboardControltopic">ASPxClientDashboard.GetDashboardControl</a> method is called within the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboard_BeforeRendertopic">ASPxClientDashboard.BeforeRender</a> event handler to customize the standard Web Dashboard menu.<br>- The <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboard_PerformDataCallbacktopic">ASPxClientDashboard.PerformDataCallback</a> client-side method is used to pass the custom data to the server side. On the server side, the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebASPxDashboard_CustomDataCallbacktopic">ASPxDashboard.CustomDataCallback</a> event is used to obtain and parse these values. These values are saved to the dashboard XML definition using the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardCommonDashboard_UserDatatopic">Dashboard.UserData</a> property.
* The <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebASPxDashboard_DashboardLoadingtopic">ASPxDashboard.DashboardLoading</a> event is handled to obtain the custom data from the UserData element when loading a dashboard.<br>- The <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebASPxDashboard_CustomJSPropertiestopic">ASPxDashboard.CustomJSProperties</a> server-side event is used to pass the custom data obtained to the client side.
* The <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboard_DashboardChangedtopic">ASPxClientDashboard.DashboardChanged</a> event is handled to display custom data related to the selected dashboard. Moreover, the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboard_SetDashboardStatetopic">SetDashboardState</a> method applies the dashboard state.</p>

<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/ASPxDashboard_UserData/Default.aspx) (VB: [Default.aspx](./VB/ASPxDashboard_UserData/Default.aspx))
* [Default.aspx.cs](./CS/ASPxDashboard_UserData/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/ASPxDashboard_UserData/Default.aspx.vb))
* [UserData.js](./CS/ASPxDashboard_UserData/Scripts/UserData.js) (VB: [UserData.js](./VB/ASPxDashboard_UserData/Scripts/UserData.js))
<!-- default file list end -->

## Documentation

- [Extensions Overview](https://docs.devexpress.com/Dashboard/117543/web-dashboard/ui-elements-and-customization/extensions-overview)
- [Manage Dashboard State](https://docs.devexpress.com/Dashboard/118733/web-dashboard/aspnet-web-forms-dashboard-control/manage-dashboard-state?p=netframework)

## More Examples

- [Dashboard for Web Forms - Custom Properties](https://github.com/DevExpress-Examples/asp-net-web-forms-dashboard-custom-properties-sample)
