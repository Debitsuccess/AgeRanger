(function(){
    
    var app = angular.module("ageRanger", ["ngRoute"]);
    
    app.config(function($routeProvider){
        $routeProvider
            .when("/people", {
                templateUrl: "people.html",
                controller: "PeopleController"
            })
            .when("/person", {
                templateUrl: "person.html",
                controller: "PersonController"
            })
            .when("/person/:id", {
                templateUrl: "personview.html",
                controller: "PersonViewController"
            })
            .when("/edit/person/:id", {
                templateUrl: "editperson.html",
                controller: "PersonEditController"
            })
            .when("/search", {
                templateUrl: "search.html",
                controller: "SearchController"
            })
            .otherwise({redirectTo:"/people"});
    });
    
}());