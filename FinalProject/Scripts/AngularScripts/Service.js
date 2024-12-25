app.service("FinalProjectService", function ($http) {

    this.submitRegistration = function (registrationData) {
        var response = $http({
            method: "POST",
            url: "/Home/AddUser", // Endpoint to add user to the database in HomeController.cs
            data: registrationData
        });
        return response;
    };

    this.loginFunction = function (loginData) {
        return $http({
            method: "POST",
            url: "/Home/LoginUser", // Endpoint to validate user credentials
            data: loginData
        });
    };

    this.loadUsers = function () {
        var response = $http({
            method: "GET",
            url: "/Home/LoadUsers" // Endpoint to load all users
        });
        return response;
    };


    this.saveDeck = function (newDeck) {
        var response = $http({
            method: "POST",
            url: "/Home/AddDeck",
            data: newDeck
        });
        return response;
    };


    this.loadDecks = function () {
        return $http({
            method: "GET",
            url: "/Home/loadDecks"
        });
    };

});
