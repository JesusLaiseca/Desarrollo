app.controller('APIController', function ($scope, $location, APIService) {

    function getAll() {
        var servCall = APIService.getSubs();
        servCall.then(function (d) {
            $scope.subscriber = d.data;
        }, function (error) {
            $log.error('Oops! Something went wrong while fetching the data.')
        })
    }

    $scope.cargapagina = function () {
        getAll();
    }

    $scope.AddVete = function () {

        var veterinario = {
            nombre: $scope.nombre,
            especialidad: $scope.especialidad,
        };

       APIService.addSubs(veterinario);

    }


    $scope.deleteVete = function (id) {
        APIService.deleteSubs(id);
        getAll();
    }

    $scope.editVete = function (id) {

        var servCall = APIService.editSubs(id);
        servCall.then(function (d) {
            $scope.id = d.data.id;
            $scope.nombre = d.data.nombre;
            $scope.especialidad = d.data.especialidad;

        }, function (error) {
            $log.error('Oops! Something went wrong while fetching the data.')
        })
    }

    $scope.updateVete = function () {

        var obj = {
            id: $scope.id,
            nombre: $scope.nombre,
            especialidad: $scope.especialidad,
        };

        APIService.updatedSubs(obj);

    }

})