(function () {
    'use strict';

    var app = angular.module('Learning.App1');

    app.config(['$stateProvider', '$urlRouterProvider', 'UrlServiceProvider',
        function ($stateProvider, $urlRouterProvider, UrlServiceProvider) {
            var resolve = UrlServiceProvider.resolveUrl;

            $stateProvider.state('login', {
                templateUrl: resolve('scripts/app/app1/templates/login.html'),
                //controller: 'LoginController',
                url: '/login'
            });

            $stateProvider.state('home', {
                'abstract': true,
                templateUrl: resolve('scripts/app/app1/templates/layout.html')
            });

            $stateProvider.state('home.index', {
                url: '/home',
                views: {
                    "home-navigation": {
                        template: resolve('scripts/app/app1/templates/layout.html')
                    },
                    "home-content": {
                        template: resolve('scripts/app/app1/templates/layout.html')
                    }
                }
            });

            $urlRouterProvider
              .otherwise('/login');

        }]);

    //app.run([function () {}]);
})();