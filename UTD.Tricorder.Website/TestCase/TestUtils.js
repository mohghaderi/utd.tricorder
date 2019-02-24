/*
  Utility functions that are helpful in many test cases
*/
var TestUtils = {

    MIN_BYTE: -128,
    MAX_BYTE: 127,
    MIN_INT16: -32768,
    MAX_INT16: 32767,
    MIN_INT32: -2147483648,
    MAX_INT32: 2147483647,
    MIN_INT64: "–9223372036854775808",
    MAX_INT64: "9223372036854775807",
    MIN_DATE: new Date(1753, 1, 1), // TODO: Fix MIN_DATE
    MAX_DATE: new Date(9999, 12, 31), // TODO: Fix MAX_DATE
    MIN_FLOAT: -3.402823e38,
    MAX_FLOAT: 3.40282347E38,
    MIN_DOUBLE: -3.402823e38,   //TODO: Fix MIN_DOUBLE
    MAX_DOUBLE: 3.40282347E38,  //TODO: Fix MAX_DOUBLE



    /*
        Check if a page contains a certain script
        This function only searchs using indexOf so searchSrcContain
        should be complete enough to prevent a mismatch

        TestPageDocument: TestPage.document
        searchSrcContain: like Common.js or even a complete path.
    */
    checkPageContainsScript: function (TestPageDocument, searchSrcContain) {

        var scripts = TestPageDocument.getElementsByTagName("script");
        for (var i = 0; i < scripts.length; i++) {
            src = scripts[i].src;
            if (src.indexOf(searchSrcContain) > -1) {
                return true;
            }
        }
        return false;
    },

    /*
     Generates a new Guid
     Copied from : http://stackoverflow.com/questions/105034/how-to-create-a-guid-uuid-in-javascript
    */
    newGuid: function(){
        var d = new Date().getTime();
        var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
            var r = (d + Math.random()*16)%16 | 0;
            d = Math.floor(d/16);
            return (c=='x' ? r : (r&0x7|0x8)).toString(16);
        });
        return uuid;
    },

    /*
        Generates a random string by len and charSet
        copied from: http://stackoverflow.com/questions/1349404/generate-a-string-of-5-random-characters-in-javascript
        charSet: is a string of characters. if not provided it uses A-Z,a-z,0-9 without special chars
    */
    generateRandomString: function(len, charSet) {
        charSet = charSet || 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        var randomString = '';
        for (var i = 0; i < len; i++) {
            var randomPoz = Math.floor(Math.random() * charSet.length);
            randomString += charSet.substring(randomPoz,randomPoz+1);
        }
        return randomString;
    },

    /*
        Generates a random number between min and max
    */
    randomNumber: function(min, max)
    {
        return Math.floor(Math.random() * (max - min + 1) + min);
    },

    randomByte: function(){
        return this.randomNumber(this.MIN_BYTE, this.MAX_BYTE);
    },

    randomInt16: function () {
        return this.randomNumber(this.MIN_INT16, this.MAX_INT16);
    },

    randomInt32: function () {
        return this.randomNumber(this.MIN_INT32, this.MAX_INT32);
    },

    randomInt64: function () {
        // range can not be a number (–9223372036854775808, 9223372036854775807) 19 chars
        var randomLen1 = this.randomByte(0, 10);
        var randomLen2 = this.randomByte(0, 9);
        var randomSign = this.randomByte(0, 1);
        var s1 = this.generateRandomString(randomLen1, "0123456789");
        var s2 = this.generateRandomString(randomLen2, "123456789");
        if (randomSign == 0)
            return s1 + s2;
        else
            return "-" + s1 + s2;
    },

    /*
        TODO: This function should be revised
    */
    randomDouble: function () {
        return Math.random();
    },
    /*
        TODO: This function should be revised
    */
    randomFloat: function () {
        return Math.random();
    },

    /*
        randomDate(new Date(2012, 0, 1), new Date())
    */
    randomDateTime: function (start, end) {
        if (start === undefined)
            start = this.MIN_DATE;
        if (end === undefined)
            end = this.MAX_DATE;

        return new Date(start.getTime() + Math.random() * (end.getTime() - start.getTime()))
    }

}