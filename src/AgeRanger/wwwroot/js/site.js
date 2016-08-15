var app = angular.module('peopleApp', ['ngResource', 'ngRoute']);

app.controller('peopleController', function ($scope, peopleFactory, $window) {
    $scope.people = [];
    
    $scope.people = peopleFactory.getPeople().then(function (peopleData) {
                
        console.log('Refreshing List of people.');

        $scope.people = peopleData.data;

        console.log($scope.people.length);

        
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
});

app.controller('peopleEditController', function ($scope, $routeParams, peopleFactory, $window) {   
    peopleFactory.getPerson($routeParams.id).then(function(personData) {
        $scope.person = personData.data;
    });    
    $scope.updatePerson = function () {        
        peopleFactory.updatePerson($scope.person);
        $scope = $scope.$new(true);
        $window.location.href('/');    
    }
});

app.controller('peopleCreateController', function ($scope, peopleFactory, $window) {
    $scope.person = {};
    $scope.updatePerson = function () {
        peopleFactory.insertPerson($scope.person);
        $scope = $scope.$new(true);
        $window.location.href('/');
    }
});