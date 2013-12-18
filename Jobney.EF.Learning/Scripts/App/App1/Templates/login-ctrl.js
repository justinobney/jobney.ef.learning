(function () {
    'use strict';

    var app = angular.module('Learning.App1');

    app.controller('LoginCtrl', ['$scope', '$state', '$localStorage', 'SampleService',
        function ($scope, $state, $localStorage, SampleService) {
            ctor();
            
            // view model actions
            $scope.login = function () {
                var viewModel = {
                    EmailAddress: $scope.emailAddress,
                    Password: $scope.password
                };

                SampleService.login(viewModel).then(loginSuccess, loginError);
            };

            // functions
            function ctor() {
                $scope.emailAddress = "admin@admin.com";
                $scope.password = "password";
                $scope.$storage = $localStorage;
                checkAuth();
            }

            function checkAuth() {
                if ($scope.$storage.authToken) {
                    SampleService.validateToken($scope.$storage.authToken).then(loginSuccess, loginError);
                }
            }

            function loginSuccess(authToken) {
                $scope.$storage.authToken = authToken;
                $state.transitionTo('payme');
            }

            function loginError() {
                alert(error);
            }
        }]);
})();