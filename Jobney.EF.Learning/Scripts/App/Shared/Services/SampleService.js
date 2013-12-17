(function () {
    'use strict';

    var app = angular.module('Learning.Services');

    app.factory('SampleService', ['$q', '$timeout', '$state', '$http', 'AppState',
        function ($q, $timeout, $state, $http, AppState) {
            var service = {};

            var state = {
                loggedIn: false
            };

            service.login = function () {
                return 42;
            };

            service.isLoggedIn = function () {
                var deferred = $q.defer();
                AppState.showLoading = true;
                $timeout(function () {
                    AppState.showLoading = false;
                    deferred.resolve(state.loggedIn);
                    //$state.transitionTo('login');
                }, 1000);
                return deferred.promise;
            };

            return service;
        }]);
})();