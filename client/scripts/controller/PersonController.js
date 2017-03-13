(function() {

    var app = angular.module("ageRanger");

    var PersonController = function($scope, ageranger, $routeParams,$location) {
        $scope.Person = {};

        $scope.add = function () {
            ageranger.createPerson($scope.Person).then(onComplete, onError);
        };

        var onComplete = function(data) {
            console.log(data);
            $location.url("/person/"+data.id);
        };

        var onError = function(reason) {
            $scope.error = "Could not fetch the data.";
        };
    };

    app.controller("PersonController", PersonController);

}());