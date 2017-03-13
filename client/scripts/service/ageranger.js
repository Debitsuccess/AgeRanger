(function(){
    
    var ageranger = function($http){

      var search = function (search) {
          return $http({
              method: 'GET',
              params : search,
              url: 'http://localhost:65117/api/search',
              headers: {
                  'Content-Type': 'application/json; charset=UTF-8'
              }
          }).then(function (response) {
              return response.data;
          });
      };

      var getPeople = function(){
            return $http.get("http://localhost:65117/api/people")
                        .then(function (response) {
                            return response.data;
                        });
      };

      var getPerson = function(id){
            return $http.get("http://localhost:65117/api/person/" + id)
                .then(function (response) {
                    return response.data;
                });
      };

        var createPerson = function (person) {
            console.log(person);

            return $http({
                method: 'POST',
                data: JSON.stringify(person),
                url: 'http://localhost:65117/api/person',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8'
                }
            }).then(function (response) {
                return response.data;
            });
        };

        var updatePerson = function (id, person) {
            console.log(person);

            return $http({
                method: 'Put',
                data: JSON.stringify(person),
                url: 'http://localhost:65117/api/person/'+ id,
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8'
                }
            }).then(function (response) {
                return response.data;
            });
        };

      return {
          getPeople: getPeople,
          getPerson: getPerson,
          createPerson:createPerson,
          updatePerson: updatePerson,
          search: search
      };
        
    };
    
    var module = angular.module("ageRanger");

    module.factory("ageranger", ageranger);
    
}());