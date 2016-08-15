angular.module('peopleApp')
    .factory('peopleFactory', ['$http', '$resource', function ($http, $q) {
        var urlBase = '/api/people';
        var dataFactory = {};              
        dataFactory.getPeople = function () {
            return $http.get(urlBase + '?_=' + new Date().getTime());
        };
        dataFactory.getPerson = function (id) {
            return $http.get(urlBase + '/' + id);
        };
        dataFactory.getPeopleByName = function (name) {
            return $http.get(urlBase + '/GetByName/' + name)
        };
        dataFactory.insertPerson = function (person) {
            return $http.post(urlBase, person);
        };
        dataFactory.updatePerson = function (person) {
            return $http.put(urlBase + '/' + person.id, person)
        };
        dataFactory.deletePerson = function (id) {
            return $http.delete(urlBase + '/' + id);
        };
        return dataFactory;
    }])
