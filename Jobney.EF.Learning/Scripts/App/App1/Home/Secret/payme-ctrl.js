(function () {
    'use strict';

    var app = angular.module('Learning.App1');

    app.controller('PayMeCtrl', ['$scope', 'AppState', 'SampleService', function ($scope, AppState, SampleService) {
        ctor();

        function ctor() {
            $scope.user = AppState.user;
            $scope.token = AppState.token;

            SampleService.products.get().then(function (data) {
                $scope.products = data;
            });
        }

    }]);
})();