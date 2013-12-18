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
                return AppState.token.Key;
            });
        };
        
        service.validateToken = function (token) {
            var url = UrlServiceProvider.resolveUrl('Home/ValidateToken');
            AppState.showLoading = true;

            var request = $http.post(url, { token: token });

            return request.then(function (response) {
                AppState.showLoading = false;
                if (response.data.isValid) {
                    AppState.user = response.data.user;
                    AppState.token = response.data.token;
                    AppState.loggedIn = true;
                    return AppState.token.Key;
                } else {
                    throw "Invalid Token";
                }
            });
        };

        service.products = {};

        service.products.get = function () {
            var url = UrlServiceProvider.resolveUrl('Home/ListOfProducts');
            AppState.showLoading = true;

            var request = $http.get(url);

            return request.then(function (response) {
                AppState.showLoading = false;
                return response.data;
            });
        };

        return service;
    }]);
})();