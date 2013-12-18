(function () {
    'use strict';

    var app = angular.module('Learning.App1', [
        'Learning.Services',
        'ui.router',
        'sf.virtualScroll',
        'ngStorage'
    ]);

    app.factory('ApiResponseInterceptor', ['$q', '$location', 'AppState',
        function ($q, $location, AppState) {
            return {
                request: function (config) {
                    if (AppState.token && AppState.token.Key)
                        config.headers["X-Api-Token"] = AppState.token.Key;
                    
                    return config;
                },
                responseError: function (rejection) {
                    if (rejection.status === 401) {
                        $location.path('#/login');
                    }
                    return $q.reject(rejection);
                }
            };
        }]);

    //Http Intercpetor to check auth failures for xhr requests
    app.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.defaults.headers.common['X-Requested-With'] = "XMLHttpRequest";
        $httpProvider.interceptors.push('ApiResponseInterceptor');
    }]);

    app.run([function () {

    }]);
})();