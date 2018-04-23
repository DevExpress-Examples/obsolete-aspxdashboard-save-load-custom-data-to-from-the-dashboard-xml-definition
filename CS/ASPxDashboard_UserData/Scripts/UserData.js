function onBeforeRender(sender, e) {
    // Gets an underlying part of the ASPxClientDashboard control and removes the 'Save' item from a standard menu. 
    var innerControl = sender.GetDashboardControl();
    var toolbox = innerControl.findExtension("toolbox");
    toolbox.removeMenuItem("save");

    // Specifies which actions will be performed on clicking a custom menu item (which is added below using addMenuItem).
    var clickAction = function () {
        // Creates a popup that will display a text box allowing end-users to specify a comment to be appended to the dashboard XML file.
        var popup = $("#popupContainer").dxPopup({
            title: "Save As",
            visible: true,
            width: 600,
            height: 200,
            onShown: function () {
                $("#textBoxContainer").dxTextBox({
                    placeholder: 'Enter any comment...',
                    showClearButton: true
                });
            },
            toolbarItems: [{
                toolbar: "bottom",
                widget: "dxButton",
                location: "after",
                options: {
                    text: "Save",
                    onClick: saveButtonAction
                }
            }, {
                toolbar: "bottom",
                widget: "dxButton",
                location: "after",
                options: {
                    text: "Cancel",
                    onClick: cancelButtonAction
                }
            }]
        });
        popup.show();
    }

    // Passes the custom data (a comment, a modified date and a current dashboard state) to the server side.
    // On the server side, the CustomDataCallback event is used to obtain and parse these values.
    var saveButtonAction = function () {
        var params = {
            dashboardJson: JSON.stringify(innerControl.dashboard().getJSON()),
            dateModified: new Date(Date.now()).toLocaleString(),
            comment: $("#textBoxContainer").dxTextBox("instance").option("text"),
            dashboardState: webDashboard.GetDashboardState()
        }
        sender.PerformDataCallback(JSON.stringify(params));
        $("#popupContainer").dxPopup("instance").hide();
        toolbox.menuVisible(false);
    }

    var cancelButtonAction = function () {        
        $("#popupContainer").dxPopup("instance").hide();
        toolbox.menuVisible(false);
    }

    // Adds a menu item that will be used to perform a custom saving routine.
    toolbox.addMenuItem(new DevExpress.Dashboard.DashboardMenuItem("save-as-item", "Save As", 108, 0, clickAction));
}

function onDashboardChanged(sender, e) {
    // Displays the custom data contained in the UserData element. 
    // Note that CustomJSProperties event is used to pass data from the server to client side.
    var form = $("#formContainer").dxForm({
        formData: {
            modified: webDashboard.cpDateModified,
            comment: webDashboard.cpComment
        },
        items: ["modified", "comment"],
        readOnly: true
    });
    // Applies a dashboard state obtained from the UserData element.
    if(webDashboard.cpDashboardState !=null)
        webDashboard.SetDashboardState(webDashboard.cpDashboardState);
}