(function () {
    'use strict';

    var app = angular.module('Learning.Services');

    app.factory('SampleService', [function () {
            var service = {};
            
            service.login = function () {
                return 42;
            };

            return service;
        }]);
})();