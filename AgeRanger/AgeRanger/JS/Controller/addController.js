(function () {
    'use strict';
    var app = angular.module('AgeRangerApp');
    app.controller('addController', function ($scope, $http, $location) {
        
        $scope.addPeople = function()
        {
           
            $http({
                method: 'Post',
                url: '/people',
                data: $scope.people
            }).then(function successCallback(response) {
                alert("Success! We will go to home page.")
                $location.path("#/")

            }, function errorCallback(response) {
                $location.path("#/Error")
            });
        }
        $scope.people = 
            {
                firstName: "",
                lastName: "",
                age: 0
            }
    });



})();
