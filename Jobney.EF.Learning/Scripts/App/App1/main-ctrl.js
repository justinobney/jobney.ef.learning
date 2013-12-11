(function() {
    'use strict';

    var app = angular.module('Learning.App1');

    app.controller('MainCtrl', ['$scope', 'SampleService', function ($scope, SampleService) {
        $scope.title = SampleService.foo();
    }]);
})();