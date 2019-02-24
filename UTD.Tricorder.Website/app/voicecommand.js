var recognition;
var voiceCommandStarted = false;
var voiceCommandNotify;

function setupVoiceRecognition()
{
    if (!recognition) {
        try {
            var speechRecognition = webkitSpeechRecognition;
            recognition = new speechRecognition();
        } catch (e) {
            ShowError("Please use Google Chrome for voice commands.");
            return false;
        }
    }
    else
        return true; // already setuped

    recognition.onstart = function () {
        $("#voicecommandmicrophoneicon").addClass("recordingblink");
        console.log("voice command started.");
        voiceCommandNotify = $.notify("Voice command activated", {
            type: 'info'
            , delay: 0
            , allow_dismiss: true
            , onClose: function () {
                recognition.stop();
            }
        });

        voiceCommandStarted = true;
    }

    recognition.onend = function () {
        $("#voicecommandmicrophoneicon").removeClass("recordingblink");
        console.log("voice command end.");
        voiceCommandStarted = false;
        if (voiceCommandNotify)
            voiceCommandNotify.update('message', "Voice command ended.");
        setTimeout(function () {
            voiceCommandNotify.close();
            voiceCommandNotify = null;
        }, 1000);
    }

    recognition.onerror = function (event) {
        console.log("voice command error.");
        console.log(event);
        if (voiceCommandNotify)
            voiceCommandNotify.update('message', "Voice command error!");

    }

    recognition.onresult = function (event) {
        var interimTranscript = "";
        var finalTranscript = "";

        for (var i = event.resultIndex; i < event.results.length; ++i) {
            if (event.results[i].isFinal) {
                finalTranscript += event.results[i][0].transcript;
            } else {
                interimTranscript += event.results[i][0].transcript;
            }
        }

        if (voiceCommandNotify)
            voiceCommandNotify.update("message", "{{" + interimTranscript + "}}");

        var sendKeys = finalTranscript;
        console.log("final:" + finalTranscript);
        console.log("interim:" + interimTranscript);

        var command = finalTranscript.toLowerCase().trim();
        if (command === "next") {
            jQuery.focusNext();
        }
        else if (command === "click") {
            $(document.activeElement).click();
        }
        else if (command === "select") {
            // select something from list 
        }
        else {
            if (command === "backspace")
                sendKeys = "{backspace}";
            if (command === "backspace backspace")
                sendKeys = "{backspace} {backspace}";
            if (command === "backspace backspace backspace")
                sendKeys = "{backspace} {backspace} {backspace}";
            if (command === "new line")
                sendKeys = "{enter}";


            if (document.activeElement) {
                var tag = document.activeElement.tagName.toLowerCase();
                if (tag === "input" || tag === "textarea")
                    $(document.activeElement).sendkeys(sendKeys);
                //sendKeys(document.activeElement, final_transcript);
            }
        }

    };

    // jquery trigger doesn't work for typing
    //function sendKeys(el, keys)
    //{
    //    var e = $(el);
    //    for (i = 0; i < keys.length; i++) {
    //        e.trigger({ type: 'keypress', which: keys.charCodeAt(i), keyCode: keys.charCodeAt(i) });
    //    }
    //    e.trigger({ type: 'keypress', which: 13, keyCode: 13 });
    //}
    return true;
}


function startVoiceCommand() {

    if (setupVoiceRecognition()) {
        if (voiceCommandStarted === false) {
            recognition.continuous = true;
            recognition.interimResults = true;
            recognition.lang = "en-US";
            recognition.start();
            console.log("start voice recognition");
        }
        else {
            recognition.stop();
            console.log("stop voice recognition");
        }
    }
}
