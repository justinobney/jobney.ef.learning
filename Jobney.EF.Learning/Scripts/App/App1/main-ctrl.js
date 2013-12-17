(function() {
    'use strict';

    var app = angular.module('Learning.App1');
    
    app.factory('AppState', [function () {
        return {
            showLoading: false
        };
    }]);

    app.controller('MainCtrl', ['$scope', 'AppState', function ($scope, AppState) {
        $scope.appState = AppState;
    }]);
})();