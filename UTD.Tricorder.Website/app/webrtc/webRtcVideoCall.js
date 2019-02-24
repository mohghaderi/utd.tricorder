var WebRtcApp = WebRtcApp || {};

WebRtcApp.WebRtcVideo = (function (connectionManager) {
    var _mediaStream,
     _hub = $.connection.hub,
    _run = function (callLogId) {
        // if callLogId provided it starts the video communication with the user right away
        // Ask the user for permissions to access the webcam and mic
        getUserMedia(
        {
            // Permissions to request
            video: true,
            audio: true
        },
        function (stream) { // succcess callback gives us a media stream

            // Now we have everything we need for interaction, so fire up SignalR
            var hub = $.connection.mainHub;

            var _callbacks = {// Connection Manager Callbacks
                onReadyForStream: function (connection) {
                    // The connection manager needs our stream
                    // todo: not sure I like this
                    connection.addStream(_mediaStream);
                },
                onStreamAdded: function (connection, event) {
                    console.log('binding remote stream to the partner window');

                    // Bind the remote stream to the partner window
                    var otherVideo = document.querySelector('#partnerwebcamvideo');
                    attachMediaStream(otherVideo, event.stream); // from adapter.js
                },
                onStreamRemoved: function (connection, streamId) {
                    // todo: proper stream removal.  right now we are only set up for one-on-one which is why this works.
                    console.log('removing remote stream from partner window');

                    // Clear out the partner window
                    var otherVideo = document.querySelector('#partnerwebcamvideo');
                    otherVideo.src = '';
                }
            };

            // Initialize our client signal manager, giving it a signaler (the SignalR hub) and some callbacks
            console.log('initializing connection manager');
            connectionManager.initialize(hub.server, _callbacks.onReadyForStream, _callbacks.onStreamAdded, _callbacks.onStreamRemoved);

            // Store off the stream reference so we can share it later
            _mediaStream = stream;

            // Load the stream into a video element so it starts playing in the UI
            console.log('playing my local video feed');
            var videoElement = document.querySelector('#localwebcamvideo');
            attachMediaStream(videoElement, _mediaStream);

            if (callLogId)
                hub.server.serverStartVideoCall(callLogId);
        },
        function (error) { // error callback
            ShowError('<h4>Failed to get hardware access!</h4> Do you have another browser type open and using your cam/mic?<br/><br/>You were not connected to the server, because I didn\'t code to make browsers without media access work well. <br/><br/>Actual Error: ' + JSON.stringify(error));
        }
    ); // end get user media
    }, // end run function

    _stop = function () {

        console.log("web rtc stop called");

        connectionManager.closeAllConnections();
        if (_mediaStream)
        {
            _mediaStream.getAudioTracks().forEach(function (track) {
                track.stop();
            });

            _mediaStream.getVideoTracks().forEach(function (track) {
                track.stop();
            });
        }

        try {
            // Clear out the video windows
            var otherVideo = document.querySelector('#partnerwebcamvideo');
            otherVideo.pause();
            otherVideo.src = '';
            var videoElement = document.querySelector('#localwebcamvideo');
            otherVideo.pause();
            videoElement.src = '';

            otherVideo.parentNode.removeChild(otherVideo);
            videoElement.parentNode.removeChild(videoElement);
        } catch (e) {

        } 
    },

    _initiateOffer = function (connectionId) {
        // Callee accepted our call, let's send them an offer with our video stream
        if (_mediaStream) // we already made a media stream to offer
            connectionManager.initiateOffer(connectionId, _mediaStream);
    }

    var socket = $.connection.mainHub;

    // Hub Callback: WebRTC Signal Received
    socket.client.receiveSignal = function (callingConnectionId, data) {
        console.log("signalr receiveSignal", data);
        connectionManager.newSignal(callingConnectionId, data);
    };

    socket.client.clientStartVideoCall = function (callingConnectionId, callLogId) {
        console.log("signalr clientStartVideoCall", callingConnectionId);
        _initiateOffer(callingConnectionId);
    };

    return {
        connectionManager: connectionManager,
        run: _run, // Starts webrtc video
        stop: _stop, // stops video
        initiateOffer: _initiateOffer, // sends video to the partner
        getStream: function () { // Temp hack for the connection manager to reach back in here for a stream
            return _mediaStream;
        }
    };

});



