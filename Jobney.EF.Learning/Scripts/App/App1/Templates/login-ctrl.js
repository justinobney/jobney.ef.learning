(function () {
    'use strict';

    var app = angular.module('Learning.App1');

    app.controller('LoginCtrl', ['$scope', '$state', 'SampleService', function ($scope, $state, SampleService) {

        // view model properties
        $scope.emailAddress = "admin@admin.com";
        $scope.password = "password";

        // view model actions
        $scope.login = function () {
            var viewModel = {
                EmailAddress: $scope.emailAddress,
                Password: $scope.password
            };
            
            SampleService.login(viewModel).then(loginSuccess, loginError);
        };

        // functions
        function loginSuccess() {
            $state.transitionTo('payme');
        }
        
        function loginError() {
            alert(error);
        }
    }]);
})();