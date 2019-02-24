//var WebRtcApp = {};

//(function () {

//    var session;

//    var socket = $.connection.mainHub;

//    socket.client.receiveSignal = function (callingConnectionId, data) {
//        console.log("signalr receiveSignal", data);
//        session.receiveMessage(JSON.parse(data));
//    };

//    socket.client.clientStartVideoCall = function (callingConnectionId, callLogId) {

//        console.log("signalr clientStartVideoCall", callingConnectionId);
//        WebRtcApp.WebRtcVideo.call();

//        session.on('sendMessage', function (data) {
//            hub.server.SendSignal(JSON.stringify(data), callingConnectionId);
//        });

//        session.call();
//    };


//    WebRtcApp.WebRtcVideo = {
//        run: function (callLogId) {

//            var isInitiator = false;
//            if (callLogId)
//                isInitiator = true;

//            var config = {
//                isInitiator: isInitiator,
//                turn: {
//                    host: 'turn:192.158.29.39:3478?transport=tcp',
//                    username: '28224511:1379330808',
//                    password: 'JZEOEt2V3Qb0y27GRntt2u2PAYA='
//                },
//                streams: {
//                    audio: true,
//                    video: true
//                }
//            };

//            session = new cordova.plugins.phonertc.Session(config);
//            cordova.plugins.phonertc.setVideoView({
//                container: document.querySelector('#localwebcamvideo'),
//                local: {
//                    position: [0, 0],
//                    size: [100, 100]
//                }
//            });

//            if (callLogId)
//                hub.server.serverStartVideoCall(callLogId);
//        },

//        stop: function () {

//        }

//    };

//});




