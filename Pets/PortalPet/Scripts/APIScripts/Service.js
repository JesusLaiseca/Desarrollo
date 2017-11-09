app.service("APIService", function ($http, $location) {

    var urlBase = "http://localhost/Charlie/Pets/api/Veterinario";

    this.getSubs = function () {
        //Aquí habria que direccionar par el control Veterinario de la Web API - Pets
        return $http.get(urlBase)
    }

    this.addSubs = function (veterinario) {

        $http.post(urlBase, veterinario).success(function (data) {
            //$location.path('/Index');
        }).error(function (data) {
            console.log(data);
            $scope.error = "Something wrong when adding new veterinary " + data.ExceptionMessage;
        });
    }


    this.deleteSubs = function (id) {
        $http.delete(urlBase + '/' + id).success(function (data) {
            //$location.path('/');
            
        }).error(function (data) {
            $scope.error = "An error has occured while deleting veterinary! " + data;
        });
    };


    this.editSubs = function (id) {
        return $http.get(urlBase + "/" + id);
    };


    this.updatedSubs = function (obj) {


        $http.put(urlBase, obj).success(function (data) {
            //$location.path('/Index');
        }).error(function (data) {
            console.log(data);
            $scope.error = "An Error has occured while Saving veterinary " + data.ExceptionMessage;
        });
    }
});