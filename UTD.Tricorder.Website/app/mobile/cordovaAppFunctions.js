
var cordovaApp = {
    registerPushNotification: function() {
        
        //Unregister the previous token because it might have become invalid. Unregister everytime app is started.
        window.plugins.pushNotification.unregister(successHandler, errorHandler);

        if (intel.xdk.device.platform == "Android") {
            //register the user and get token
            window.plugins.pushNotification.register(
            successHandler,
            errorHandler,
            {
                //senderID is the project ID
                "senderID": "95752695319",
                //callback function that is executed when phone recieves a notification for this app
                "ecb": "onNotification"
            });
        }
        else if (intel.xdk.device.platform == "iOS") {
            //register the user and get token
            window.plugins.pushNotification.register(
            tokenHandler,
            errorHandler,
            {
                //allow application to change badge number
                "badge": "true",
                //allow application to play notification sound
                "sound": "true",
                //register callback
                "alert": "true",
                //callback function name
                "ecb": "onNotificationAPN"
            });
        }
    },


        //app given permission to receive and display push messages in Android.
    successHandler :function (result) {
        console.log('push notification result = ' + result);
    },

    //app denied permission to receive and display push messages in Android.
    errorHandler: function (error) {
        console.log('push notification error = ' + error);
    },

    //App given permission to receive and display push messages in iOS
    tokenHandler: function (result) {
        // Your iOS push server needs to know the token before it can push to this device
        // here is where you might want to send the token to your server along with user credentials.
        console.log('push notification device token = ' + result);
        tokenID = result;
    },

    //fired when token is generated, message is received or an error occured.
    onNotification: function(e) 
    {
        switch( e.event )
        {
            //app is registered to receive notification
            case 'registered':
                if(e.regid.length > 0)
                {
                    // Your Android push server needs to know the token before it can push to this device
                    // here is where you might want to send the token to your server along with user credentials.
                    console.log('push notification registration id = '+e.regid);
                    tokenID = e.regid;
                }
                break;

            case 'message':
                //Do something with the push message. This function is fired when push message is received or if user clicks on the tile.
                console.log('push notification message = '+e.message+' msgcnt = '+e.msgcnt);
                onNotificationAPN(JSON.parse(e.message));
                break;

            case 'error':
                console.log('GCM error = '+e.msg);
                break;

            default:
                console.log('An unknown GCM event has occurred');
                break;
        }
    },

    //callback fired when notification received in iOS
    onNotificationAPN: function (event) 
    {
        if ( event.alert )
        {
            //do something with the push message. This function is fired when push message is received or if user clicks on the tile.
            alert(event.alert);
        }

        if ( event.sound )
        {
            //play notification sound. Ignore when app is in foreground.
            var snd = new Media(event.sound);
            snd.play();
        }

        if ( event.badge )
        {
            //change app icon badge number. If app is in foreground ignore it.
            window.plugins.pushNotification.setApplicationIconBadgeNumber(successHandler, errorHandler, event.badge);
        }
    }




}

