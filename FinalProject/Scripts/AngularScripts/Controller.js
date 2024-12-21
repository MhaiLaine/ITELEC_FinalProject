app.controller("FinalProjectController", function ($scope, FinalProjectService, $window, $http) {

    $scope.userEmailPattern = /^[a-zA-Z0-9._%+-]{1,64}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    var userCredentials = [];

    // Play music once the view is loaded
    $scope.$on('$viewContentLoaded', function () {
        const audio = document.querySelector('audio');
        audio.play().catch(err => console.log('Autoplay blocked:', err));
    });

    // Main menu
    $scope.redirectToRegistration = function () {
        $window.location.href = "/Home/RegistrationPage";
    };

    $scope.redirectToLogIn = function () {
        $window.location.href = "/Home/LogInPage";
    };

    // Registration Page
        $scope.submitRegistration = function () {
            var registrationData = {
                firstName: $scope.firstName,
                lastName: $scope.lastName,
                userEmail: $scope.userEmail,
                userPhone: $scope.userPhone,
                username: $scope.firstName + '.' + $scope.lastName, // Auto-generate username
                userPassword: $scope.userPassword
            };

            console.log('Registration Data:', registrationData); // Debugging step

            // Ensure $http service is injected in your controller if not already.
            $http.post('/Home/AddUser', registrationData)
                .then(function (response) {
                    console.log('API Response:', response); // Debugging step

                    if (response.data.success) {
                        Swal.fire('Registration Successful!', '', 'success').then(() => {
                            // Redirect to login page after success
                            $window.location.href = "/Home/LogInPage";
                        });
                    } else {
                        Swal.fire('Error saving user data', response.data.message, 'error');
                    }
                })
                .catch(function (error) {
                    console.error('Error saving user data:', error);
                    Swal.fire('Error saving user data', '', 'error');
                });
        };


        // Login Function
    $scope.loginFunction = function () {
        var loginData = {
            username: $scope.username,
            password: $scope.userPassword
        };

        // Log the login data for debugging
        console.log('Login Data:', loginData);

        // Call the login service to validate credentials
        FinalProjectService.login(loginData).then(function (response) {
            // Handle success or failure based on the response from the server
            if (response.data.success) {
                Swal.fire('Login Successful!', '', 'success').then(() => {
                    // Redirect to dashboard if login is successful
                    $window.location.href = "/Home/Dashboard1";
                });
            } else {
                // Show the error message if login fails
                Swal.fire(response.data.message, '', 'error');
            }
        }).catch(function (error) {
            console.error('Error during login:', error);
            Swal.fire('Error during login', '', 'error');
        });
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




    // load chart
    //$scope.loadChartFunc = function () {
    //    angular.module("app", ["chart.js"]).controller("BarCtrl", function ($scope) {
    //        $scope.labels = ['2006', '2007', '2008', '2009', '2010', '2011', '2012'];
    //        $scope.series = ['Series A', 'Series B'];

    //        $scope.data = [
    //            [65, 59, 80, 81, 56, 55, 40],
    //            [28, 48, 40, 19, 86, 27, 90]
    //        ];
    //    });
    //};


});


