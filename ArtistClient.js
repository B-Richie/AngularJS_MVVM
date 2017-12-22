var ArtistApp = angular.module('ArtistApp', [])

ArtistApp.controller('ArtistController', function ($scope, ArtistService) {

    getArtists();


    function getArtists() {
        ArtistService.getArtists()
        .then(function (response) {
            //debugger
            $scope.sortBy = 'ArtistName';
            $scope.reverse = false;
            $scope.artists = response.data;
            console.log($scope.artists);

        }, function () {
            console.log($scope.artists);
            alert("Error occurred");
        });
    }

    function insertArtist() {
        ArtistService.insertArtist()
        .then(function (artistData) {
            var artist = {
                ArtistName: $scope.ArtistName
            };
        }, function () {
            alert("Error inserting artist");
        });
    }
});


ArtistApp.factory('ArtistService', ['$http', function ($http) {

    var ArtistService = {};
    ArtistService.getArtists = function () {
        return $http.get('/Artist/GetArtists');
    };

    ArtistService.insertArtist = function () {
        $http.post('/Artist/InsertArtist', artistData);
    }
    return ArtistService;
}]);


