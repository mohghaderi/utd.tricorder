var DeltaCompress = {
    //Developer Note: Modify *Array functions with *ArrayObj together

    compArray: function (arr, findex) {
        if (DeltaCompress.preCheckArr(arr) == false)
            return arr;

        var tmp = 0;
        var prev = arr[0];
        for (var i = 1; i < arr.length; i++) {
            tmp = arr[i];
            arr[i] = arr[i] - prev;
            prev = tmp;
        }

        return arr;
    },

    decompArray: function (arr) {
        if (DeltaCompress.preCheckArr(arr) == false)
            return arr;

        for (var i = 1; i < arr.length; i++) {
            arr[i] = arr[i] + arr[i-1];
        }

        return arr;
    },

    preCheckArr: function (arr) {
        if (arr === undefined)
            return false;
        if (!(arr instanceof Array))
            return false;
        if (arr.length < 1)
            return false;
        var o = arr[0]; // isnumber
        return typeof o == "number" || (typeof o == "object" && o.constructor === Number);
    },


    compArrayObj: function (arr, pInx) {
        if (DeltaCompress.preCheckArrayObj(arr, pInx) == false)
            return arr;

        var tmp = 0;
        var prev = arr[0][pInx];
        for (var i = 1; i < arr.length; i++) {
            tmp = arr[i][pInx];
            arr[i][pInx] = arr[i][pInx] - prev;
            prev = tmp;
        }

        return arr;
    },

    decompArrayObj: function (arr, pInx) {
        if (DeltaCompress.preCheckArrayObj(arr, pInx) == false)
            return arr;

        for (var i = 1; i < arr.length; i++) {
            arr[i][pInx] = arr[i][pInx] + arr[i - 1][pInx];
        }

        return arr;
    },

    preCheckArrayObj: function (arr, pInx) {
        if (arr === undefined)
            return false;
        if (!(arr instanceof Array))
            return false;
        if (arr.length < 1)
            return false;
        var o = arr[0][pInx]; // isnumber
        return typeof o == "number" || (typeof o == "object" && o.constructor === Number);
    },

}