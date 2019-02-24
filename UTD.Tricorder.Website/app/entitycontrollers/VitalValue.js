
entityControllerFactory.create("VitalValue", "PainLevelForm", function ($scope, sParams) {

    BaseControllers.AddEditFormServices($scope, sParams);

    //http://wbotelhos.com/raty
    $scope.dataValueRatyOptions = {
        //cancelOff: 'cancel-off.png',
        //cancelOn: 'cancel-on.png',
        path: "../../Content/Images/smiley/",
        starHalf: 'mood0.png',
        starOff: 'mood0.png',
        starOn: 'mood6.png',
        number: 10,
        target: '#precision-hint',
        targetKeep: true,
        hints: ['1', '2', '3', '4', '5'],
        size: 60
    };

    $scope.onBeforeInsert = function () {
        $scope.model.PersonID = $scope.CurrentUserID;
        $scope.model.VitalTypeID = 4; //pain level
        $scope.model.IsManualEntry = true;
    }


});



entityControllerFactory.create("VitalValue", "PainLevelChart", function ($scope, sParams) {

    $scope.getBaseChartConfig = function(data) {
        return chartConfig = {
            chart: {
                zoomType: 'x'
            },

            rangeSelector: {
                buttons: [{
                    type: 'day',
                    count: 1,
                    text: '1d'
                }, {
                    type: 'day',
                    count: 3,
                    text: '3d'
                }, {
                    type: 'week',
                    count: 1,
                    text: '1w'
                }, {
                    type: 'month',
                    count: 1,
                    text: '1m'
                }, {
                    type: 'month',
                    count: 3,
                    text: '3m'
                }, {
                    type: 'month',
                    count: 6,
                    text: '6m'
                }, {
                    type: 'year',
                    count: 1,
                    text: '1y'
                }, {
                    type: 'all',
                    text: 'All'
                }],
                selected: 3
            },

            yAxis: {
                title: {
                    text: 'pain'
                }
            },

            title: {
                text: 'Pain levels'
            },

            subtitle: {
                text: '' // dummy text to reserve space for dynamic subtitle
            },

            series: [{
                name: 'Pain level',
                data: data,
                //pointStart: Date.UTC(2004, 3, 1),
                //pointInterval: 3600 * 1000,
                tooltip: {
                    valueDecimals: 1,
                    valueSuffix: 'p'
                }
            }]

        };
    }

    $scope.init = function () {

        $scope.ExecInline("GetAllChartDataJson"
            , { UserID: $scope.CurrentUserID, VitalTypeID: 4 }
            , function (p) {
                
                var data = p.response.data;

                DeltaCompress.decompArrayObj(data, 0);
                //DeltaCompress.decompArrayObj(data, 1);
                for (var i = 0; i < data.length; i++)
                    data[i][0] = data[i][0] * 1000; // convert to milliseconds

                var chartConfig = $scope.getBaseChartConfig(data);
                var containerId = "painlevelchart";
                $('#' + containerId).highcharts("StockChart", chartConfig);
                $scope.chart = $('#' + containerId).highcharts();
            });
    }


});
