var AirBridgePrototype = {

    _pipeBusy: false,
    sendPipe: [],
    sendTimer: null,



    callJavaScript: function (msg) {
        try {
            this.log("callJavaScript" + msg);
            this._resetPipe();

            var o = JSON.parse(decodeURIComponent(msg));
            var fnName = o.fnName;
            var params = o.params;

            var fn = this._findJsFunction(fnName);
            if (fn != null)
                fn(params);
            else
                this.log("callJavaScript " + "function not found");
        } catch (e) {
            this.log("callJavaScript.error: " + e.message);
        }
    },

    _findJsFunction: function (fnName) {
        if (fnName) {
            fnNameArray = fnName.split('.');
            var tmpFn = window[fnNameArray[0]];
            for (var i = 1; i < fnNameArray.length; i++) {
                if (fnNameArray[i])
                    tmpFn = tmpFn[fnNameArray[i]];
                if (tmpFn === undefined)
                    return null;
            }
            return tmpFn;
        }
        return null;
    },

    callAir: function (fnName, parameters) {
        var msgJson = JSON.stringify({ fnName: fnName, params: parameters });
        var self = this;
        this.log("callAir" + fnName + msgJson);

        this.sendPipe.push(msgJson);
        if (this.sendTimer == null)
        {
            this.log("callAir timer is null");

            //this._sendFromPipe(self);
            this.sendTimer = setInterval(function () { self._sendFromPipe(self) }, 10);
        }

    },

    _sendFromPipe: function(bridge) {
        this.log("_sendFromPipe " + bridge.getIsPipeBusy());
        this.log("_sendFromPipe pipe length:" + bridge.sendPipe.length);

        if (bridge.getIsPipeBusy() == false) {

            //bridge.setPipeBusy(true);
            if (bridge.sendPipe.length > 0)
            {
                var msg = bridge.sendPipe.shift();
                this._sendMessage(msg);
                this.setIsPipeBusy();
            }
            //bridge.setPipeBusy(false);

            if (bridge.sendPipe.length == 0) {
                this.log("_sendFromPipe kill timer");
                clearInterval(bridge.sendTimer);
                bridge.sendTimer = null;
            }

        }
    },

    _sendMessage: function(msg) {
        //window.location.hash = "airscript:" + escape(msg);
        window.location = "airscript:" + encodeURIComponent(msg);
        //throw "airscript://" + escape(msg);
        //window.document.title = "airscript:" + escape(msg);
        //window.location = "http://airscript/?msg=" + escape(msg);
    },

    _resetPipe: function() {
        window.document.title = "";
    },

    getIsPipeBusy: function () {
        return  this._pipeBusy;
        //if (window.document.title.indexOf("airscript:"))
        //if (window.location.href.indexOf("airscript:") > -1)
        ////if (window.location.href.indexOf("http://airscript/?msg=") > -1)
        //    return true;
        //else
        //    return false;
    },

    setIsPipeBusy: function (val) {
        this._pipeBusy = val;
    },

    airAck: function(val) { // acknowledgement from air that received the message, and now js can send another message if needed
        this.setIsPipeBusy(false);
    },


    log: function (msg) {
        var logFn = window["log"];
        if (logFn !== undefined)
            window["log"]("js:" + msg);
    }


}

var AirBridgeClass = new Object();
AirBridgeClass.prototype = AirBridgePrototype;

var airBridge = Object.create(AirBridgePrototype);