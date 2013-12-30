(function () {
    'use strict';

    var app = angular.module('Learning.App1');

    app.factory('AppState', [function () {
        return {
            showLoading: false,
            loggedIn: false
        };
    }]);
})();