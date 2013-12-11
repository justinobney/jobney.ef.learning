(function() {
    'use strict';

    var app = angular.module('Learning.Services');

    app.factory('SampleService', [function () {
        var service = {};

        service.foo = function () {
            return 42;
        };

        return service;
    }]);
})();