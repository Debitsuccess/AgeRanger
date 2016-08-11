(function () {
    'use strict';
    var app = angular.module('AgeRangerApp');
    app.controller('searchController', function ($scope, $http, $location) {
        
        $scope.people =
            {
                FirstName: "",
                LastName: "",
            }

        $scope.peopleList = new Array();

        $scope.searchByFName = function () {
            $http({
                method: 'GET',
                url: '/people',
                params: {
                    'firstname': $scope.people.FirstName
                }
            }).then(function successCallback(response) {
                $scope.peopleList = response.data;
            }, function errorCallback(response) {
                $location.path("#/Error")
            });                
        }

        $scope.searchByLName = function () {
            $http({
                method: 'GET',
                url: '/people',
                params: {
                    'lastname': $scope.people.LastName
                }
            }).then(function successCallback(response) {
                $scope.peopleList = response.data;
            }, function errorCallback(response) {
                $location.path("#/Error")
            });
        }
    });



})();
