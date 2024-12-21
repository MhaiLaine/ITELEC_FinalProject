app.service("FinalProjectService", function ($http) {

    this.submitRegistration = function (registrationData) {
        var response = $http({
            method: "post",
            url: "/Home/AddUser", // Endpoint to add user to the database in HomeController.cs
            data: registrationData
        });
        return response;
    };

    this.login = function (loginData) {
        var response = $http({
            method: "post",
            url: "/Home/ValidateUser", // Endpoint to validate user credentials
            data: loginData
        });
        return response;
    };

    this.loadUsers = function () {
        var response = $http({
            method: "get",
            url: "/Home/LoadUsers" // Endpoint to load all users
        });
        return response;
    };
});
