(function () {
    'use strict';

    var app = angular.module('Learning.App1');

    app.controller('LoginCtrl', ['$scope', '$state', 'SampleService', function ($scope, $state, SampleService) {
        $scope.login = function () {
            $state.transitionTo('payme');
        };
    }]);
})();