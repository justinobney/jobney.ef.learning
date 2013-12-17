(function () {
    'use strict';

    var app = angular.module('Learning.App1');

    app.controller('PayMeCtrl', ['$scope', 'AppState', function ($scope, AppState) {
        ctor();

        function ctor() {
            $scope.user = AppState.user;
            $scope.token = AppState.token;
        }

    }]);
})();