﻿//var DeltaCompressTests = {

//    StartTest: function () {

        describe("DeltaCompress.compArrayDecompArray(Arr)", function () {
            it("passes if it compresses and decompresses an array successfully", function () {
                var a = GetArray();
                var aCopy = GetArray();
                DeltaCompress.compArray(aCopy);
                DeltaCompress.decompArray(aCopy);
                for(var i =0; i< a.length; i++)
                    expect(a[i]).toEqual(aCopy[i]);
            });
        });

        describe("DeltaCompress.compArrayObjDecompArrayObj(Arr, pInx)", function () {
            it("passes if it compresses and decompresses an array of objects successfully", function () {
                var a = GetArrayObj();
                var aCopy = GetArrayObj();
                var pInx = 0;
                DeltaCompress.compArrayObj(aCopy, pInx);
                DeltaCompress.decompArrayObj(aCopy, pInx);
                for (var i = 0; i < a.length; i++)
                    expect(a[i][pInx]).toEqual(aCopy[i][pInx]);
            });
        });

        

//    }

//}

        function GetArray() {
            return [517, 511, 508, 1023, 507, 507, 506, 1022, 505, 505, 505, 505, 505, 505, 505, 505, 506, 506, 506, 1022, 507, 507, 507, 508, 507, 507, 507, 1023, 507, 508, 509, 509, 510, 510, 510, 1022, 510, 510, 511, 1023, 511, 512, 512, 513, 513, 514, 515, 1023, 516, 517, 518, 1023, 519, 520, 520, 520, 521, 521, 521, 520, 520, 519, 519, 518, 518, 517, 1023, 514, 512, 511, 509, 508, 506, 505, 504, 504, 503, 503, 1022, 502, 502, 502, 1022, 502, 502, 502, 1022, 502, 502, 502, 1022, 502, 503, 503, 1023, 503, 503, 503, 1023, 503, 503, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 505, 505, 504, 504, 504, 504, 504, 504, 504, 504, 504, 504, 505, 505, 504, 504, 1023, 503, 504, 504, 505, 505, 505, 505, 505, 505, 505, 505, 505, 505, 505, 505, 505, 505, 505, 505, 505, 505, 505, 505, 505, 505, 506, 506, 1022, 506, 506, 506, 1022, 507, 507, 507, 508, 508, 508, 508, 1023, 507, 507, 507, 1023, 507, 506, 506, 506, 506, 506, 1022, 506, 506, 506, 1022, 506, 506, 506, 1022, 506, 506, 506, 1022, 506, 506, 505, 1023, 501, 501, 505];
        }

        function GetArrayObj() {
            return [
                    /* May 2006 */
                    [1147651200000, 67.79],
                    [1147737600000, 64.98],
                    [1147824000000, 65.26],
                    [1147910400000, 63.18],
                    [1147996800000, 64.51],
                    [1148256000000, 63.38],
                    [1148342400000, 63.15],
                    [1148428800000, 63.34],
                    [1148515200000, 64.33],
                    [1148601600000, 63.55],
                    [1148947200000, 61.22],
                    [1149033600000, 59.77],
                    /* Jun 2006 */
                    [1149120000000, 62.17],
                    [1149206400000, 61.66],
                    [1149465600000, 60.00],
                    [1149552000000, 59.72],
                    [1149638400000, 58.56],
                    [1149724800000, 60.76],
                    [1149811200000, 59.24],
                    [1150070400000, 57.00],
                    [1150156800000, 58.33],
                    [1150243200000, 57.61],
                    [1150329600000, 59.38],
                    [1150416000000, 57.56],
                    [1150675200000, 57.20],
                    [1150761600000, 57.47],
                    [1150848000000, 57.86],
                    [1150934400000, 59.58],
                    [1151020800000, 58.83],
                    [1151280000000, 58.99],
                    [1151366400000, 57.43],
                    [1151452800000, 56.02],
                    [1151539200000, 58.97],
                    [1151625600000, 57.27],
                    /* Jul 2006 */
                    [1151884800000, 57.95],
                    [1152057600000, 57.00],
                    [1152144000000, 55.77],
                    [1152230400000, 55.40],
                    [1152489600000, 55.00],
                    [1152576000000, 55.65],
                    [1152662400000, 52.96],
                    [1152748800000, 52.25],
                    [1152835200000, 50.67],
                    [1153094400000, 52.37],
                    [1153180800000, 52.90],
                    [1153267200000, 54.10],
                    [1153353600000, 60.50],
                    [1153440000000, 60.72],
                    [1153699200000, 61.42],
                    [1153785600000, 61.93],
                    [1153872000000, 63.87],
                    [1153958400000, 63.40],
                    [1154044800000, 65.59],
                    [1154304000000, 67.96]
            ];
        }


TestSimpleJavaScriptFile("/FW/js/DeltaCompress.js");