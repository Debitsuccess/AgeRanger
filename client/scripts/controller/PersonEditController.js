(function() {

    var app = angular.module("ageRanger");

    var PersonEditController = function($scope, ageranger, $routeParams) {

        $scope.message = '';

        var onComplete = function(data) {
            $scope.person = data;
        };

        var onUpdate = function(data) {
            $scope.message = "Update Successful.";
        };

        var onError = function(reason) {
            $scope.message = "Error occurred.";
        };

        $scope.Edit = function () {
            ageranger.updatePerson($routeParams.id, $scope.person).then(onUpdate, onError);
        };

        ageranger.getPerson($routeParams.id).then(onComplete, onError);
    };

    app.controller("PersonEditController", PersonEditController);

}());