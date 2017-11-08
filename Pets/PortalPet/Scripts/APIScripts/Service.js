app.service("APIService", function ($http) {
    this.getSubs = function () {
        //Aquí habria que direccionar par el control Veterinario de la Web API - Pets
        return $http.get("api/Veterinario")
    }
});