(function () {
    // Defining a connection to the server hub.
    var myHub = $.connection.mainHub;

    $.connection.hub.connectionSlow(function () {
        //notifyUserOfConnectionProblem(); // Your function to notify user.
        //ShowWarning("Your internet connection is slow.");
    });

    var tryingToReconnect = false;


    $.connection.hub.reconnecting(function () {
        tryingToReconnect = true;
        //notifyUserOfTryingToReconnect(); // Your function to notify user.
    });

    $.connection.hub.reconnected(function () {
        tryingToReconnect = false;
    });

    $.connection.hub.disconnected(function () {
        if (tryingToReconnect) {
            //notifyUserOfDisconnect(); // Your function to notify user.
            // automatically start the connection again
            setTimeout(function () {
                $.connection.hub.start({ transport: ['webSockets', 'longPolling'] });
            }, 1000); // Restart connection after 5 seconds.
        }
    });


    //= angular.element("#MobileAppCallBackControllerDiv").scope();

    myHub.client.Send = function (fnName, paramsJson) {

        // Developer Note: Change this parser with NotificationReceiver.handlePayload function
        // parsing payload here
        //var p = { fnName: fnName, params: null }
        var params = null;
        if (paramsJson)
            params = JSON.parse(paramsJson);

        console.log("signalr message received", params);

        mobileAppCallBack.callback(fnName, params);

    }

    // WebRtc video
    myHub.client.receiveSignal = function (callingConnectionId, data) {
        console.log("signalr receiveSignal", data);
        var iwindow = $("#VideoMeetingIFrame")[0].contentWindow;
        if (iwindow.isLoaded)
        {
            iwindow.clientStartVideoCall(callingConnectionId, data);
        }
        //iwindow.WebRtcApp.WebRtcVideo.connectionManager.newSignal(callingConnectionId, data);
    };

    myHub.client.clientStartVideoCall = function (callingConnectionId, callLogId) {
        console.log("signalr clientStartVideoCall", callingConnectionId);
        var iwindow = $("#VideoMeetingIFrame")[0].contentWindow;
        if (iwindow.isLoaded) {
            iwindow.clientStartVideoCall(callingConnectionId);
        }
        else
        {
            setTimeout(function () {
                if (!iwindow.isLoaded)
                    console.error("Error: iFrame content is not available");
                iwindow.clientStartVideoCall(callingConnectionId);
            }, 4000);
        }
        //iwindow.WebRtcApp.WebRtcVideo.initiateOffer(callingConnectionId);
    };





    // Setting logging to true so that we can see whats happening in the browser console log. [OPTIONAL]
    $.connection.hub.logging = true;

    // Start the hub
    $.connection.hub.start({ transport: ['webSockets', 'longPolling'] }).done(function () {
        connected = true;
    });



    //// This is the client method which is being called inside the MainHub (C# code)
    //myHub.client.PhoneRing = function (p) {
    //    // Set the received serverTime in the span to show in browser
    //    mobileAppCallBack.callBack({ fnName: "PhoneRing", params: JSON.parse(p) });
    //};


}());

