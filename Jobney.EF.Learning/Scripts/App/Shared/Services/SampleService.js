(function () {
    'use strict';

    var app = angular.module('Learning.Services');

    app.factory('SampleService', ['$http', 'UrlServiceProvider', 'AppState', function ($http, UrlServiceProvider, AppState) {
            var service = {};
            
            service.login = function (loginViewModel) {
                var url = UrlServiceProvider.resolveUrl('Home/Login');
                AppState.showLoading = true;

                var request = $http.post(url, loginViewModel);

                return request.then(function (response) {
                    AppState.showLoading = false;
                    AppState.user = response.data.user;
                    AppState.token = response.data.token;
                    AppState.loggedIn = true;
                });
            };

            return service;
        }]);
})();