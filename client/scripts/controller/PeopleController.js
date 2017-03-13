(function() {

    var app = angular.module("ageRanger");

    var PeopleController = function($scope, ageranger, $routeParams, $location) {

        $scope.edit = function (id) {
            $location.url("/edit/person/"+id);
        };

        var onComplete = function(data) {
            $scope.people = data;
        };

        var onError = function(reason) {
            $scope.error = "Could not fetch the data.";
        };

        ageranger.getPeople().then(onComplete, onError);
    };

    app.controller("PeopleController", PeopleController);

}());