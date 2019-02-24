
entityControllerFactory.create("DailyActivityChart", "CalorieChart", function ($scope, sParams) {

    $scope.getBaseChartConfig = function (data1, data2, data3) {
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
                    text: 'kilo calories'
                }
            },

            title: {
                text: 'Daily Calorie'
            },

            subtitle: {
                text: '' // dummy text to reserve space for dynamic subtitle
            },

            series: [{
                name: 'Calorie Burn',
                data: data1,
                //pointStart: Date.UTC(2004, 3, 1),
                //pointInterval: 3600 * 1000,
                tooltip: {
                    valueDecimals: 1,
                    valueSuffix: 'kcal'
                }
            }, {
                name: 'Calorie Taken',
                data: data2,
                //pointStart: Date.UTC(2004, 3, 1),
                //pointInterval: 3600 * 1000,
                tooltip: {
                    valueDecimals: 1,
                    valueSuffix: 'kcal'
                }
            }, {
                name: 'Calorie Sum',
                data: data3,
                //pointStart: Date.UTC(2004, 3, 1),
                //pointInterval: 3600 * 1000,
                tooltip: {
                    valueDecimals: 1,
                    valueSuffix: 'kcal'
                }
            }]

        };
    }

    $scope.init = function () {

        $scope.ExecInline("GetByUserID"
            , { UserID: $scope.CurrentUserID }
            , function (p) {

                var data = p.response.data;

                var data1 = [];
                var data2 = [];
                var data3 = [];

                var items = data;
                for(var i = 0; i < items.length; i++) {
                    var item = items[i];
                    var time = item["DateUnix"] * 1000;
                    data1.push([time, item["CalorieBurn"]]);
                    data2.push([time, item["CalorieTaken"]]);
                    data3.push([time, item["CalorieSum"]]);
                }

                var chartConfig = $scope.getBaseChartConfig(data1, data2, data3);
                var containerId = "caloriechart";
                $('#' + containerId).highcharts("StockChart", chartConfig);
                $scope.chart = $('#' + containerId).highcharts();
            });
    }



});
