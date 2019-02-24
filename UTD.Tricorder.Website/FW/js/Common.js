// prototype functions needed for basic js needs

if (typeof String.prototype.endsWith != 'function') {
    String.prototype.endsWith = function (suffix) {
        return this.indexOf(suffix, this.length - suffix.length) !== -1;
    };
}

if (typeof String.prototype.startsWith != 'function') {
    // see below for better implementation!
    String.prototype.startsWith = function (str) {
        return this.indexOf(str) == 0;
    };
}


/**
* Keeps all messages used in the framework. It can be used later to translate the application 
*/
var StringMsgs = {

    /**
    * Common string messages used in the application
    */
    Common : {
        ContactingServer: "Contacting server. Please wait...",
        Loading: "Loading ",
        Error: "Error",
        Successful: "Successful",
        Message: "Message"
    },

    /**
    * String messages used by framework only 
    */
    Framework: {
        ConfirmDelete_DialogTitle: "Delete Item",
        ConfirmDelete_Msg: "You are about to delete something. Are you sure?",
        EditForm_FormDataNotValid: "Form data is not valid. Please revise the form again before submit.",
        EditForm_SaveSuccessful: "Information Saved successfully.",
        EditForm_PasswordNotMatch: "Entered password and verify password should be the same.",
        RegisterForm_PleaseAgreeTermAndConditions: "Please agree terms and conditions to continue.",
        Grid_SelectOneRow: "No item is selected. Please select a row first.",
        General_OperationDoneSuccessfully: "Operation completed successfully.",

    }



};


/**
* Utility functions to manage basic functions of the framework
*/
var Framework = {

    /**
    * loads the settings for framework. 
    */
    loadFrameworkPageSettings: function () {
        if (window.Ext) {
            Ext.EventManager.on(document, 'keydown', function (e, t) {
                if (e.getKey() == e.BACKSPACE && (!(t.tagName.toLowerCase() == 'textarea' || t.tagName.toLowerCase() == 'input') || t.disabled || t.readOnly)) {
                    e.stopEvent();
                }
                if (e.getKey() == e.ESC) {
                    e.stopEvent();
                }
            });

            var extControlsList = Ext.ComponentMgr.all.getArray();
            for (var i = 0; i < extControlsList.length; i++) {
                if (extControlsList[i].DoLayout)
                    extControlsList[i].DoLayout();
            }

        }
    },

    /**
    * gets a value from query string
    */
    getQueryString: function (urlVarName) {
        var urlHalves = String(document.location).split('?');
        var urlVarValue = '';
        if (urlHalves[1]) { var urlVars = urlHalves[1].split('&'); for (i = 0; i <= (urlVars.length); i++) { if (urlVars[i]) { var urlVarPair = urlVars[i].split('='); if (urlVarPair[0] && urlVarPair[1] && urlVarPair[0] == urlVarName) { urlVarValue = urlVarPair[1]; } } } }
        return urlVarValue;
    },

    addQueryString: function (url, pName, pValue) {
        if (pValue) {
            if (url.indexOf('?') > 0)
                return url + "&" + pName + "=" + pValue;
            else
                return url + "?" + pName + "=" + pValue;
        }
        else
            return url;
    },

    /**
    * finds the main window of the application recursively
    */
    getMainWindow: function() {

        var win = window;

        if (win.MainPageSignatureXWZ !== undefined)
            return win;
        if (win.parent.MainPageSignatureXWZ !== undefined)
            return win.parent;

        else {
            for (var i = 0; i <= 10; i++) {
                win = win["parent"];
                if (win.MainPageSignatureXWZ !== undefined)
                    return win;
            }
        }

        return win;
    },

    /**
    * Closes the opened window. It can close both ExtWindow and ModalDialogs
    */
    closeWindow: function (returnValue) {
        var winId = this.getQueryString("winid");
        var tabId = this.getQueryString("tabid");
        var isModelDialog = this.getQueryString("isModelDialog");
        if (winId)
        {
            ExtWindow.closeWindow(winId, returnValue);
            return true;
        }
        else if (tabId)
        {
            Framework.getMainWindow().MainPageUtils.removeTab(tabId, returnValue);
            return true;
        }
        else
        {
            if (isModelDialog) {
                window.returnValue = returnValue;
                window.close();
                return true;
            }
        }
        return false; // form is not closed, probably it's in an iframe or something
    },

    /**
    * Asks user to confirm deleting an item before delete
    */
    confirmDelete: function (deleteFunction, returnControl) {

        var msgSettings = {
            title: StringMsgs.Framework.ConfirmDelete_DialogTitle,
            msg: StringMsgs.Framework.ConfirmDelete_Msg,
            buttons: Ext.Msg.YESNO,
            fn: function (btn) {
                if (btn == 'yes')
                    deleteFunction();
                if (returnControl) // focus for the control after execution
                    if (returnControl.focus !== undefined)
                        returnControl.focus();
            }
        }

        if (returnControl)
            msgSettings.animEl = returnControl.id;

        return Ext.Msg.show(msgSettings);
    },

    /*
      Converts path started with ~/Path to path accessible form client
      WARNING: use this function in the same window that you need to access resource
      otherwise it resolves url for the window that you called it from
    */
    resolveClientUrl: function (url) {
        if (url.startsWith("~/") == false)
            return url;
        var baseUrl = Framework.privateGetBaseClientPath();
        return Framework.concatUrl(baseUrl, url.substr(2, url.length - 2));
    },

    concatUrl: function(url1, url2) {
        if (url1.endsWith('/') == true)
            return url1 + url2;
        else
            return url1 + "/" + url2;
    },

    privateGetBaseClientPath: function() {
        var currentjsPath = "fw/js/common.js"; // if function moved to another file, this needs to be updated
        // since framework common.js is one of the scripts in the document
        // we search all scripts and by removing the path, we get the root
        if (window.privateBaseClientPath)
            return window.privateBaseClientPath;
        else
        {
            var scripts = document.getElementsByTagName("script");
            for (var i = 0; i < scripts.length; i++)
            {
                src = scripts[i].src.toLowerCase();
                if (src.indexOf(currentjsPath) > -1)
                {
                    window.privateBaseClientPath = src.replace(currentjsPath, "");
                    return window.privateBaseClientPath;
                }
            }
        }
    },

    /**
     * Returns a random integer between min and max
     * Using Math.round() will give you a non-uniform distribution!
     */
    getRandomInt: function (min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    },

    /**
    * Shows edit form of an entity
    * e.entityInfo : entity information got from Json
    * e.entityFormParams : Keeps a json object of EntityFormParams
    * e.recordID : Current record that needs to be edited (if not setted, then it opens insert form)
    * e.returnFunction : if available, calls the return function after windows closed.
    */
    showEntityEditForm: function(sender, e) {

        var entityInfo = e.entityInfo;
        var url = this.__GetEntityFormUrl(entityInfo, e.entityFormParams);

        var winid = "win" + entityInfo.EntityName + Framework.getRandomInt(0, 10000);
        var left = (screen.width / 2) - (entityInfo.EditFormWidth / 2);
        var top = (screen.height / 2) - (entityInfo.EditFormWidth / 2);

        var title = entityInfo.EditFormTitle;
        var height = entityInfo.EditFormHeight;
        var width = entityInfo.EditFormWidth;

        // opening dialog based on its OpenMode
        var oMode = e.entityInfo.EditFormOpenMode;
        if (oMode == 0) // default
            oMode = 1; // extWindow

        if (oMode == 1) { // extWindow
            Framework.getMainWindow().ExtWindow.showModalDialog(
                winid, url, title, height, width, e.returnFunction);
        }
        else if (oMode == 2) { // browser dialog
            url = Framework.addQueryString(url, "isModelDialog", "true");
            var retValue = window.showModalDialog(url, e, "title.text:'';dialogHeight:" + entityInfo.EditFormHeight + "px ; dialogWidth:" + entityInfo.EditFormWidth + "px ; dialogLeft:" + left + "px ; dialogTop:" + top + "px;resizable:yes,center:yes;scroll:no;status:no");
            if (e.returnFunction) {
                var eRet = new Object();
                eRet.returnValue = retValue;
                afterCloseFN(this, eRet);
            }
        }
        else if (oMode == 4) // none
        {
            return null;
        }
        else //new tab
        {
            var mainWin = Framework.getMainWindow(); // if it has no tab, we open in a new ext window
            if (mainWin.MainPageUtils)
                mainWin.MainPageUtils.addTab(winid, url, title, e.returnFunction);
            else
                mainWin.ExtWindow.showModalDialog(
                    winid, url, title, height, width, e.returnFunction);
        }


    },

    __GetEntityFormUrl: function (entityInfo, entityFormParams) {

        var isInsert = true;
        if (entityFormParams.RecordID)
            isInsert = false;

        var url = Framework.resolveClientUrl(entityInfo.EditFormUrl);
        if (isInsert)
            url = Framework.resolveClientUrl(entityInfo.InsertFormUrl);

        url = Framework.privateReplaceParam(url, "{EntityName}", entityInfo.EntityName);
        url = Framework.privateReplaceParam(url, "{AdditionalDataKey}", entityInfo.AdditionalDataKey);
        url = Framework.privateReplaceParam(url, "{MasterEntityName}", entityFormParams.MasterEntityName);
        url = Framework.privateReplaceParam(url, "{MasterAdditionalDataKey}", entityFormParams.MasterAdditionalDataKey);
        url = Framework.privateReplaceParam(url, "{MasterRecordID}", entityFormParams.MasterRecordID);
        url = Framework.privateReplaceParam(url, "{ParentIDInTree}", entityFormParams.ParentIDInTree);
        url = Framework.privateReplaceParam(url, "{RecordID}", entityFormParams.RecordID);
        url = Framework.privateReplaceParam(url, "{IsReadOnly}", entityFormParams.IsReadOnly);

        return url;
    },

    privateReplaceParam: function (url, paramName, paramValue) {
        if (paramValue === undefined)
            paramValue = "";
        if (paramValue == null)
            paramValue = "";

        return url.replace(paramName, paramValue);
    },



    /**
    * Masks an Ext Control. It makes the control disabled for the user
    */
    Mask: function (ctrl, text) {
        if (text)
            ctrl.body.mask(text, "x-mask-loading");
        else
            ctrl.body.mask();
    },

    /**
    * UnMasks an Ext Masked control. It makes the disabled control enabled for the user
    */
    UnMask: function (ctrl) {
        ctrl.body.unmask();
    },

    /*
      redirects the selected page to the selected url
    */
    redirectTo: function (newUrl, win) {
        newUrl = Framework.resolveClientUrl(newUrl);
        if (win === undefined)
            win = window;
        win.location.href = newUrl;
    },


    /* clicks on a button */
    buttonClick: function (btn) {
        //btn.btnEl.dom.click();
        btn.fireEvent('click', btn);
        //btn.handler.call(btn.scope, btn, Ext.EventObject);
    },

    __DirectEventAjaxSuccess: function (response, result, e_control, e_eventType, e_action, e_extraParams, e) {

        if (result.extraParamsResponse.successMsg === undefined)
            successMessage = StringMsgs.Framework.General_OperationDoneSuccessfully;
        else
            successMessage = result.extraParamsResponse.successMsg;

        Framework.notifyMessage(successMessage, StringMsgs.Common.Message);
    },

    __DirectEventAjaxFailure: function (response, result, e_control, e_eventType, e_action, e_extraParams, e) {
        Framework.showError(result.errorMessage);
    },


    notifyMessage: function (msg, title) {
        Ext.net.Notification.show({
            iconCls: 'icon-information',
            hideDelay: 3000,
            html: msg,
            title: title,
            alignToCfg: {
                offset: [-20, 20],
                position: 'tr-tr'
            },
            showFx: {
                args: [{ duration: 2000 }],
                fxName: 'fadeIn'
            },
            hideFx: {
                args:
                [
                    {
                        duration: 2000,
                        endOpacity: 0.25
                    }
                ],
                fxName: 'fadeOut'
            },
        });
    },

    showError: function(errorMessage) {
        Ext.Msg.alert(StringMsgs.Common.Error, errorMessage);
    },

    getDirectMethodAjaxConfig: function (successMessage, successFunction, failureFunction) {

        var ajaxConfig = {
            success: function (response, result, e_control, e_eventType, e_action, e_extraParams, e) {
                Framework.notifyMessage(successMessage, StringMsgs.Common.Message);
                if (successFunction)
                    successFunction(result);
            },
            failure: function (response, result, e_control, e_eventType, e_action, e_extraParams, e) {
                Framework.showError(response);
                if (failureFunction)
                    failureFunction(e);
            },
            eventMask: {
                showMask: true,
                minDelay: 500
            }
        };

        return ajaxConfig;
    }

}


if (window.Ext) {
    Ext.apply(Ext.form.VTypes, {
        passwordCompare: function (val, field) {
            if (!val) {
                return;
            }

            var verify = App.VerifyPasswordTextBox.getValue() == App.PasswordTextBox.getValue();
            if (verify == false)
                field.vtypeText = StringMsgs.Framework.EditForm_PasswordNotMatch;
            else
                field.vtypeText = "";

            return verify;
        }
    });
}


