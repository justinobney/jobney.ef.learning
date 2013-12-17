﻿(function() {
    'use strict';

    var app = angular.module('Learning.App1');
    
    app.factory('AppState', [function () {
        return {
            showLoading: false,
            loggedIn: false
        };
    }]);

    app.controller('MainCtrl', ['$scope', '$state', 'AppState', function ($scope, $state, AppState) {
        $scope.appState = AppState;

        $scope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
            AppState.showLoading = true;
            if (toState.data && toState.data.authorize && !AppState.loggedIn) {
                event.preventDefault();
                $state.transitionTo('denied');
            }
        });
        
        $scope.$on('$stateChangeSuccess', function () {
            AppState.showLoading = false;
        });
    }]);
})();