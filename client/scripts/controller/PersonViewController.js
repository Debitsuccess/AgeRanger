(function() {

    var app = angular.module("ageRanger");

    var PersonViewController = function($scope, ageranger, $routeParams, $location) {

        var onComplete = function(data) {
            console.log(data);
            $scope.person = data;
        };

        var onError = function(reason) {
            $scope.error = "Could not fetch the data.";
        };

        ageranger.getPerson($routeParams.id).then(onComplete, onError);

        $scope.Edit = function (person) {
            $location.url("/edit/person/"+$routeParams.id);
        }
    };

    app.controller("PersonViewController", PersonViewController);

}());