angular.module('app', [])
    .controller('mastermindController', function($scope, $http, $filter){
       $scope.title = "Hello me"; 
       $scope.scores = [];
              
        setInterval(function() {
            $http.get('http://uc399925:5555/api/mastermind/Scors/')
            .then(function(result) {
                $scope.scores = result.data; 
            });
        }, 5000);
    });