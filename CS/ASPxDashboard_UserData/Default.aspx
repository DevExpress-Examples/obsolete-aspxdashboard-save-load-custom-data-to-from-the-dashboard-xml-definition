<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPxDashboard_UserData.Default" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" 
    Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Scripts/UserData.js") %>"></script>
<body>
    <form id="form1" runat="server">
        <div id="popupContainer">
            <div id="textBoxContainer"></div>
        </div>
        <div id="formContainer" style="margin: 50px 80px 0 80px;"></div> 
        <div style="margin-top:50px;">
            <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" 
                ClientInstanceName="webDashboard"
                ClientSideEvents-BeforeRender="onBeforeRender" 
                ClientSideEvents-DashboardChanged="onDashboardChanged"
                OnCustomDataCallback="ASPxDashboard1_CustomDataCallback" 
                OnDashboardLoading="ASPxDashboard1_DashboardLoading"
                OnCustomJSProperties="ASPxDashboard1_CustomJSProperties"
                Height="800px" Width="100%">
            </dx:ASPxDashboard>
        </div>
    </form>
</body>
</html>