// ---------------------- Window Global functions  ------------------------------
// This file is only because of maintenance purposes. It defines all global functions
// to do operations on all views of the system

function getLoginData() {
    return angular.element($("#AngularJSMainController")).scope().authentication;
}

function setFormValidations() {
    //$(document).ready(function () {
        $("form")
        //.on('init.form.bv', function (e, data) {
        //    data.bv.disableSubmitButtons(true);
        //})
        .bootstrapValidator({
            // Exclude only disabled fields
            // The invisible fields set by Bootstrap Multiselect must be validated
            excluded: ':disabled',
            // To use feedback icons, ensure that you use Bootstrap v3.1.0 or later
            feedbackIcons: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            }
            , submitButtons: null  // removing auto disable buttons from validator
        })
        .on('success.field.bv', function (e, data) {
            //var isValid = data.bv.isValid();
            //data.bv.disableSubmitButtons(!isValid);
        });
    //});
}

function isFormValid(formSelector, event) {
    var isValid = $(formSelector).data('bootstrapValidator').resetForm().validate().isValid();
    if (isValid === false) {
        if (event)
            event.preventDefault();
        $.notify(window.Msgs.validation.completeformbeforeproceeding, {
            type: 'danger',
            z_index: 9999
        });
    }
    return isValid;
}

function isValidContainer(containerSelector, event) {
    var form = $(containerSelector).closest("form");
    if (form) {
        var isValid = $(form).data('bootstrapValidator').resetForm().validate().isValidContainer(containerSelector)
        if (isValid === false) {
            if (event)
                event.preventDefault();
            $.notify(window.Msgs.validation.completeformbeforeproceeding, {
                type: 'danger',
                z_index: 9999
            });
        }
        return isValid;
    }
    else
        return true;
}

function resetFormValidation(formSelector, event) {
    var validator = $(formSelector).data('bootstrapValidator');
    //if (validator)
        validator.resetForm();
    if (event)
        event.preventDefault();
}


function addOnReady(fn) {
    if (documentIsReady) // if document was ready just run it; otherwise, put it in onready
        fn();
    else
        $(document).ready(fn);
}

var documentIsReady = false;

$(document).ready(function () {
    documentIsReady = true;
});

$(window).resize(function () {
    arrangeUI();
});

function arrangeUI() {
    var newHeight = $(window).innerHeight() - 60;
    //$('.page').css({ height: newHeight });
    $('.sidebar-wrapper').css({ height: newHeight });
    $('.page').css({ width: $(window).innerWidth() - $(".sidebar-wrapper").width() - 15 });
    $(".stickfooter").css({ bottom: 0 });
}


function initView() {

    setTimeout(function () {
        $('.page').css({ width: $(window).innerWidth() - $(".sidebar-wrapper").width() - 15 });
    }, 1);

    setFormValidations();
}

function CollapsePanel(panelId) { 
    //Inline function doesn't work in IE. That's why I made this function here
    $("#" + panelId).collapse('toggle');
}


function ShowMessage(msg, isError) {
    if (isError)
        return ShowError(msg);
    else
        return $.notify(msg, {
            type: 'success'
            , z_index: 9999
            , offset: { x:10, y: 50 }
            ,animate: {
		        enter: 'animated bounceIn',
		        exit: 'animated bounceOut'
            }
        });
}

function ShowError(msg) {
    return $.notify(msg, {
        type: 'danger'
        , delay: 0
    });
}

function ShowWarning(msg) {
    return $.notify(msg, {
        type: 'warning'
        , delay: 0
    });
}

function ShowProgress(msg) {
    return $.notify(msg, {
        type: 'info'
        , delay: 0
        , showProgressbar: true
    });
}

function ShowDialog(dialogId) {
    $('#' + dialogId).modal({
        show: true
    });
}

function CloseDialog(dialogId) {
    $('#' + dialogId).modal('hide');
}

// Load ComboBox for Select2
//function LoadComboBox(fieldName, comboData, selectedValue) {
//    $(function () {
//        var combo = $('[name=\'' + fieldName + '\']');
//        combo.select2("destroy");
//        var options = combo[0].parentNode.selectoptions;

//        $.map(comboData, function (obj) {
//            obj.id = obj.id || obj[options.valueField];
//            obj.text = obj.text || obj[options.labelField];

//            return obj;
//        });

//        //var options2 = options;
//        options.data = comboData;
//        var s2 = combo.select2(options);
//        combo.val(selectedValue).trigger('change');
//    })
//}

function LoadComboBox(fieldName, comboData, selectedValue) {
    var combo = $('[name=\'' + fieldName + '\']')[0].selectize;
    combo.clear();
    combo.load(function (callback) {
        callback(comboData);
        if (selectedValue) {
            combo.setValueAngular(selectedValue);
        }
    });
}


//function LoadComboBox(fieldName, comboData, selectedValue) {
//    $(function () {
//        var combo = $('[name=\'' + fieldName + '\']')[0].selectize;
//        combo.clear();
//        combo.clearOptions();
//        combo.renderCache = {};

//        combo.load(function (callback) {
//            console.log("set callback data")
//            callback(comboData);
//            if (selectedValue) {
//                combo.setValueAngular(selectedValue);
//            }
//        });
//    })
//}


/* --------------  Wizard (http://bootsnipp.com/snippets/featured/form-wizard-and-validation)  ---------------------------------  */
function SetupWizard() {

    var navListItems = $('div.setup-panel div a'),
            allWells = $('.setup-content'),
            allNextBtn = $('.nextBtn');

    allWells.hide();
    navListItems.attr("disabled", "disabled");

    navListItems.click(function (e) {
        e.preventDefault();
        var pageId = $(this).attr('href');
        var $target = $(pageId),
                $item = $(this);

        if (!$item.hasClass('disabled')) {
            navListItems.removeClass('btn-primary').addClass('btn-default');
            $item.addClass('btn-primary');
            $item.removeAttr("disabled");
            allWells.hide();
            $target.show();
            //$target.find('input:eq(0)').focus();
            $('#wizardControl').data("pageId", pageId.replace("#", ""));
            resetFormValidation($('#wizardControl').find("form")); // reset all validations for next page
        }
    });

    allNextBtn.click(function () {
        WizardGotoNextPage()
    });

    $('div.setup-panel div a.btn-primary').trigger('click');
    setFormValidations();
    //WizardGotoNextPage();
}

function WizardGotoNextPage() {
    var curPageId = $('#wizardControl').data("pageId");
    //var newPageId = "";
    //if (curPageId)
    //{
    //    var pageIndex = Number(curPageId.replace("step-", "")) + 1;
    //    newPageId = "step-" + pageIndex;
    //}
    //else
    //{
    //    newPageId = "step-1";
    //    $('#wizardControl').data("pageId", newPageId);
    //}

    //var curStep = $(this).closest(".setup-content"),
    //curStepBtn = curStep.attr("id"),
    nextStepWizard = $('div.setup-panel div a[href="#' + curPageId + '"]').parent().next().children("a");
    //curInputs = curStep.find("input[type='text'],input[type='url']"),

    isValid = true;
    isValid = isValidContainer('#' + curPageId)

    //$(".form-group").removeClass("has-error");
    //for (var i = 0; i < curInputs.length; i++) {
    //    if (!curInputs[i].validity.valid) {
    //        isValid = false;
    //        $(curInputs[i]).closest(".form-group").addClass("has-error");
    //    }
    //}

    if (isValid)
        nextStepWizard.removeAttr('disabled').trigger('click');
    else
        nextStepWizard.attr('disabled', 'disabled');
}

//function setupFileUpload() {

//    $.ajaxSetup({
//        accepts: "json",
//        beforeSend: function (xhr) {
//            xhr.setRequestHeader("Accept", "application/json");
//        }
//    });

//    $('#fileupload').fileupload({
//        dataType: "xml",
//        add: function (e, data) {
//            var file, types;
//            types = /(\.|\/)(gif|jpe?g|png)$/i;
//            file = data.files[0];
//            if (types.test(file.type) || types.test(file.name)) {
//                data.context = $(tmpl("template-upload", file));
//                $('#fileupload').append(data.context);
//                data.form.find('#content-type').val(file.type);

//                //https://github.com/blueimp/jQuery-File-Upload/wiki/Upload-directly-to-S3

//                $.ajax({
//                    url: "/documents",
//                    type: 'POST',
//                    dataType: 'json',
//                    data: { doc: { title: data.files[0].name } },
//                    async: false,
//                    success: function (retdata) {
//                        // after we created our document in rails, it is going to send back JSON of they key,
//                        // policy, and signature.  We will put these into our form before it gets submitted to amazon.
//                        $('#file_upload').find('input[name=key]').val(retdata.key);
//                        $('#file_upload').find('input[name=policy]').val(retdata.policy);
//                        $('#file_upload').find('input[name=signature]').val(retdata.signature);
//                    }

//                });


//                return data.submit();
//            } else {
//                return alert("" + file.name + " is not a gif, jpeg, or png image file");
//            }
//        },
//        progress: function (e, data) {
//            var progress;
//            if (data.context) {
//                progress = parseInt(data.loaded / data.total * 100, 10);
//                return data.context.find('.bar').css('width', progress + '%');
//            }
//        },
//        done: function (e, data) {
//            var content, domain, file, path, to;
//            file = data.files[0];
//            to = $('#fileupload').data('post');
//            content = {};

//            var location = $(data.result).find("Location")[0].textContent;
//            content[$('#fileupload').data('as')] = decodeURIComponent(location);
//            $.post(to, content, function (data, statusText, xhr) {
//                $.get(xhr.getResponseHeader("location"), function (data2) {
//                    $("#uploadedPaintings").append($(tmpl("template-painting", data2)));
//                });
//            });
//            if (data.context) {
//                return data.context.remove();
//            }
//        },
//        fail: function (e, data) {
//            alert("" + data.files[0].name + " failed to upload.");
//            console.log("Upload failed:");
//            return console.log(data);
//        }
//    });

//}

// IMPORTANT NOTICE: You have to declare the callback as a global function
// outside of $(document).ready()

function remoteValidateSingleField(value, validator, $field) {
    var $scope = angular.element($field).scope();
    if ($($field).prop("data-remote-value") == value) {
        if ($scope.timer !== 0)
        {
            clearTimeout($scope.timer);
            $scope.timer = 0;
        }

        return {
            valid: Boolean($field.prop("data-remote-result")),
            message: $($field).prop("data-remote-error")
        };
    }

    var waitTime = 1500;
    var time = (new Date).getTime();
    if ($scope.lastChecked === undefined)
        $scope.lastChecked = time;

    if (time - $scope.lastChecked < waitTime) // checking only every two seconds
    {
        if ($scope.timer !== 0)
        {
            clearTimeout($scope.timer);
            $scope.timer = 0;
        }
    }
    $scope.lastChecked = time;

    var remoteFunction = $field.attr("data-remote-function"); 
    $scope.timer = setTimeout(function () {
        $scope.ExecInline(remoteFunction, value,
            function (p) {
                $field.prop("data-remote-value", value);
                $field.prop("data-remote-result", true);
                $field.prop("data-remote-error", "");
                $(validator.$form).bootstrapValidator('revalidateField', $field);
            }, function (p) { // we have error in the server
                $field.prop("data-remote-value", value);
                $field.prop("data-remote-result", false);
                $field.prop("data-remote-error", window.Msgs.validation.errortitle + ": " + p.response.errorMessage);
                $(validator.$form).bootstrapValidator('revalidateField', $field);
            }
            );
    }, waitTime);

    return true;
}


//function ShowViewNeedPanel(controllerDiv, needsArray) {
//    if (needsArray) {
//        var cardTemplate = $("#viewNeedTemplate").html();
//        var msg = $("<div>",
//            {
//                'class': "alert alert-warning",
//                'role': "alert"
//            });
//        for (var i = 0; i < needsArray.length; i++) {
            
//            var p = $("<p>");
//            var icon = $("<i>", { "class": "fa fa-exclamation-triangle" });
//            var a = $("<a href=''>")
//                .prop("FulfillView", needsArray[i].FulfillView)
//                .on("click", function (e) {
//                    e.preventDefault();
//                    var $scope = angular.element(controllerDiv).scope();
//                    $scope.OpenUrl(a.prop("FulfillView"));
//                });
//            //a.FulfillView = needsArray[i].FulfillView;
//            var span = $("<span>");
//            span.text("   " + needsArray[i].Message);

//            a.append(span);
//            p.append(icon);
//            p.append(a);
//            msg.append(p);
//        }

//        //var template = cardTemplate.replace("{0}", msg.html());
//        $(controllerDiv).html("").append(msg);

//    }
//}


function FindRelatedDiv (controllerName) {
    var ctrl = $("#" + controllerName + "Frm");
    if (ctrl.length == 0)
        ctrl = $("#" + controllerName + "ControllerDiv");

    if (ctrl.length > 0)
        return ctrl.first();
    else
        return null;
}


function ShowViewNeedPanel(controllerDiv, needsArray) {
    if (needsArray) {
        var msg = $("<div>",
            {
                'class': "alert alert-warning",
                'role': "alert"
            });
        for (var i = 0; i < needsArray.length; i++) {

            var p = $("<p>");
            var icon = $("<i>", { "class": "fa fa-exclamation-triangle" });
            var a = $("<a href=''>")
                .prop("FulfillView", needsArray[i].FulfillView)
                .on("click", function (e) {
                    e.preventDefault();
                    var $scope = angular.element(controllerDiv).scope();
                    $scope.OpenPath(a.prop("FulfillView"));
                });
            //a.FulfillView = needsArray[i].FulfillView;
            var span = $("<span>");
            span.text("   " + needsArray[i].Message);

            a.append(span);
            p.append(icon);
            p.append(a);
            msg.append(p);
        }

        //var template = cardTemplate.replace("{0}", msg.html());
        $(controllerDiv).cover(msg);

    }
}

// backspace prevention
function confirmBackspaceNavigations () {
    // http://stackoverflow.com/a/22949859/2407309
    var backspaceIsPressed = false;
    $(document).keydown(function (event) {
        if (event.which === 8) {
            backspaceIsPressed = true;
        }
    });
    $(document).keyup(function (event) {
        if (event.which === 8) {
            backspaceIsPressed = false;
        }
    });
    $(window).on("'beforeunload", function () {
        if (backspaceIsPressed) {
            backspaceIsPressed = false;
            return "Are you sure you want to leave this page?";
        }
    });
} // confirmBackspaceNavigations



function isCordovaApp() {
    if (window.cordovaAppVersion) {
        return true;
    }
    return false;
}

function openExternal(url) {
    window.open(url, "_blank");
}

function angularRouteChangeSuccess() {
    // this function should be empty. It is overwritten by Cordova apps to detect page changes
}

// Global Setting for bootstrap notify

function setBootstrapNotifyDefaults() {
    var placement = null;
    if (window.AppSettings.isrtl) {
        placement = {
            from: "top",
            align: "left"
        };
    }
    else {
        placement = {
            from: "top",
            align: "right"
        };
    }
    $.notifyDefaults({
        z_index: 9999,
        placement: placement,
        offset: { x: 10, y: 50 }
    });
}

window.gotoMainPage = function() {
    var mainPage = location.protocol + "//" + location.host;
    window.location.href = mainPage;
}


//function injectIframeComponents(iframe) {

//    console.log("injectIframeComponents");

//    var iwindow = iframe.contentWindow;
//    if (iframe.contentWindow) {
//        iwindow.navigator = window.navigator;
//        iwindow.cordova = window.cordova;
//        iwindow.cordovaAppVersion = window.cordovaAppVersion;
//        iwindow.$.connection = window.$.connection;

//        // Setting WebRtc App to load video media
//        if (iwindow.WebRtcApp) {
//            iwindow.WebRtcApp.WebRtcVideo = iwindow.WebRtcApp.WebRtcVideo(iwindow.WebRtcApp.ConnectionManager);


//            var $scope = angular.element("#CallLogVideoMeetingControllerDiv").scope();
//            if ($scope.IsCaller)
//                iwindow.WebRtcApp.WebRtcVideo.run($scope.MasterID);
//            else
//                iwindow.WebRtcApp.WebRtcVideo.run();

//        }
//        ////////////////////////////////////////////////

//        iwindow.$('#mainloading').remove();
//        iwindow.$('#mainloading-mask').fadeOut({ remove: true });


//        // cordova support for later
//        if (iwindow.onDeviceReady)
//            iwindow.onDeviceReady();
//    }
//    //var doc = iframe.contentDocument || iframe.contentWindow.document;

//}


