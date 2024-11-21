app.controller("FinalProjectController", function ($scope, $window) {


    // 1. Main menu 
        $scope.redirectToRegistration = function () {
            $window.location.href = "/Home/RegistrationPage";
        };

        $scope.redirectToLogIn = function () {
            $window.location.href = "/Home/LogInPage";
        };


    // 2. Registration Page
        $scope.submitRegistration = function () {
            $window.location.href = "/Home/LogInPage";
        };


    // 3. Login Page
    $scope.loginFunction = function () {
        // Get credentials from sessionStorage
        var storedCredentials = sessionStorage.getItem("credentials");

        /* If credentials were saved in sessionStorage, they are retrieved then converted back to array and stored in userCredentials.
        If not, userCredentials is an empty array, meaning no users are registered yet.*/
        var userCredentials = storedCredentials ? JSON.parse(storedCredentials) : [];

        // Retrieve username and password input
        var enteredUsername = $scope.username;
        var enteredPassword = $scope.userPassword;

        // Find the user in the credentials array
        var userExists = userCredentials.find(userSearch =>
            userSearch.Username === enteredUsername && // Use entered username
            userSearch.Password === enteredPassword // Use entered password
        );

        if (userExists) {
            // If user is found, proceed to dashboard or home page
            window.location.href = "/Home/Dashboard1";
        } else {
            // If no match, display error message
            Swal.fire({
                icon: "error",
                title: "Error",
                text: "Invalid Username or Password!",
            });
            $scope.dataLoading = false;
        }
    };




    // 4.Welcome Page
    $scope.redirectToDashboard = function () {
        $window.location.href = "/Home/Dashboard1";
    };



    // 5.


    $scope.redirectToManageFlashcards = function () {
        $window.location.href = "/Home/ManageFlashcardPage";
    };



    $scope.redirectToStudyFlashcards = function () {
        $window.location.href = "/Home/StudyFlashcardsPage";
    };




});