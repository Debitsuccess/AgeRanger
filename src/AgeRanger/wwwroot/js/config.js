var app = angular.module('peopleApp');

app.config(function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: "js/templates/list.html",
        controller: "peopleController"        
    })
    .when('/new', {
        templateUrl: "js/templates/new.html",
        controller: "peopleCreateController"        
    })
    .when('/edit/:id', {
        templateUrl: "js/templates/new.html",
        controller: "peopleEditController"
    })
    .otherwise({ redirectTo: '/' });
});

app.config(['$httpProvider', function ($httpProvider) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }
    $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';    
    $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
    $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
}]);
