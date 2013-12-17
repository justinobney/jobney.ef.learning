(function () {
    'use strict';

    var app = angular.module('Learning.App1');

    app.config(['$stateProvider', '$urlRouterProvider', 'UrlServiceProvider',
        function ($stateProvider, $urlRouterProvider, UrlServiceProvider) {
            var resolve = UrlServiceProvider.resolveUrl;

            $stateProvider.state('login', {
                templateUrl: resolve('scripts/app/app1/templates/login.html'),
                url: '/login'
            });
            
            $stateProvider.state('denied', {
                template: 'denied',
                url: '/denied'
            });
            
            $stateProvider.state('payme', {
                templateUrl: resolve('scripts/app/app1/templates/secret/payme.html'),
                url: '/payme',
                data: {
                    authorize: true
                }
            });

            $stateProvider.state('home', {
                'abstract': true,
                templateUrl: resolve('scripts/app/app1/templates/home/layout.html')
            });

            $stateProvider.state('home.index', {
                url: '/home',
                views: {
                    "home-navigation": {
                        templateUrl: resolve('scripts/app/app1/templates/home/log.html')
                    },
                    "home-content": {
                        templateUrl: resolve('scripts/app/app1/templates/home/list.html')
                    }
                }
            });

            $urlRouterProvider
              .otherwise('/login');

        }]);

    //app.run([function () {}]);
})();