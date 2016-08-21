var app = angular.module('peopleApp', ['ngResource', 'ngRoute']);

app.controller('peopleController', ['$scope','peopleFactory','$window', function ($scope, peopleFactory, $window) {
    $scope.people = [];
    
    $scope.people = peopleFactory.getPeople().then(function (peopleData) {              
        $scope.people = peopleData.data;        
    });

    $scope.editRow = function (id) {
        $window.location.href('#/edit/' + id);
    }

    $scope.filterPeople = function () {             
        peopleFactory.getPeopleByName($scope.searchKeyword).then(function (peopleData) {
            if ($scope.searchKeyword.length == 0)
                $window.location.href('/');
            $scope.people = peopleData.data;
        });
    }
}]);

app.controller('peopleEditController', ['$scope', '$routeParams', 'peopleFactory', '$window',
    function ($scope, $routeParams, peopleFactory, $window) {
    peopleFactory.getPerson($routeParams.id).then(function(personData) {
        $scope.person = personData.data;
    });    
    $scope.updatePerson = function () {        
        peopleFactory.updatePerson($scope.person).then(function(response) {
            $scope = $scope.$new(true);
            $window.location.href('/');
        });        
    }
}]);

app.controller('peopleCreateController', ['$scope','peopleFactory','$window',function ($scope, peopleFactory, $window) {
    $scope.person = {};
    $scope.updatePerson = function () {
        peopleFactory.insertPerson($scope.person).then(function(response) {
            $scope = $scope.$new(true);
            $window.location.href('/');
        });        
    }
}]);