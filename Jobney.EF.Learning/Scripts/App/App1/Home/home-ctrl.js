(function () {
    'use strict';

    var app = angular.module('Learning.App1');

    app.controller('HomeCtrl', ['$scope', '$timeout', 'SampleService', function ($scope, $timeout, SampleService) {
        $scope.book = {
            lines: _.times(25, function (n) { return n; }),
            total: 1000
        };

        $scope.scrollModel = {
            highWater: 90,
            lowWater: 30
        };
        
        $scope.getLines = function() {
            return $scope.book.lines;
        };
        
        var loadMoreThrottled = _.throttle(loadMore, 250, {
            leading: true,
            trailing: true
        });
        
        $scope.loadMore = loadMoreThrottled;

        ctor();
        
        function ctor() {
            $scope.$watch(isAtEnd, loadMoreThrottled);
        }

        function isAtEnd() {
            if ($scope.loading)
                return false;
            
            var sm = $scope.scrollModel;
            var offSet = 50;
            var closeToEnd = sm.firstVisible + sm.visible + offSet > sm.total;
            var endOfData = sm.total == $scope.book.total;
            var hasInitialized = !!sm.total;
            console.log(closeToEnd,endOfData);
            return hasInitialized && closeToEnd && !endOfData;
        }
        
        function loadMore() {
            if ($scope.loading)
                return;

            $scope.loading = true;
            
            $timeout(function () {
                var sm = $scope.scrollModel;
                var endOfData = sm.total >= $scope.book.total;

                if (!endOfData)
                    _.times(25, function (n) { $scope.book.lines.push(1); });

                $scope.loading = false;
            });
        }
    }]);
})();