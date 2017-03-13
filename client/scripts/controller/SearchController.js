(function() {

    var app = angular.module("ageRanger");

    var SearchController = function($scope, ageranger, $routeParams, $location) {
        $scope.search = {};
        $scope.people = [];

        $scope.searchPeople = function (search) {
            ageranger.search(search).then(onComplete, onError);
        };

        var onComplete = function(data) {
            $scope.people = data;
        };

        var onError = function(reason) {
            $scope.error = "Could not fetch the data.";
        };
    };

    app.controller("SearchController", SearchController);

}());