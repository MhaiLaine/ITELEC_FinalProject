app.controller("FinalProjectController", function ($scope, $window) {

    $scope.userEmailPattern = /^[a-zA-Z0-9._%+-]{1,64}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    var userCredentials = [];

    // Play music once the view is loaded
    $scope.$on('$viewContentLoaded', function () {
        const audio = document.querySelector('audio');
        audio.play().catch(err => console.log('Autoplay blocked:', err));
    });

    // 1. Main menu 
        $scope.redirectToRegistration = function () {
            $window.location.href = "/Home/RegistrationPage";
        };

        $scope.redirectToLogIn = function () {
            $window.location.href = "/Home/LogInPage";
        };


    // 2. Registration Page
        $scope.submitRegistration = function () {
            var registrationData = {
                FirstName: $scope.firstName,
                LastName: $scope.lastName,
                userEmail: $scope.userEmail,
                userPhone: $scope.userPhone,
                Username: $scope.username,
                Password: $scope.userPassword
            };

            //search info if already existing
            // Search (any name). (key value)
            //querying through the array / searching
            var newUserSearch = userCredentials.find(searchUser =>
                searchUser.FirstName === $scope.firstName &&
                searchUser.LastName === $scope.lastName ||
                searchUser.username === $scope.username
            );

            //need iverify na ung next inputs ay walang katulad sa mga existing values previously stored sa array
            //if may laman / katulad di siya undefined

            //if undefined - push data in array
            if (newUserSearch === undefined) {
                userCredentials.push(registrationData);

                ////convert array to JSON string para sa session Storage ng browser
                //var sessionString = JSON.stringify(userCredentials);

                ////after magsave sa array -> store in temporary browser storage
                //sessionStorage.setItem("credentials", sessionString); //key = "credentials" ; yung converted string yung value


                var postData = RegistrationApplicationService.threeFunc(registrationData);
                postData.then(function (ReturnedData) {
                    var userFirstName = ReturnedData.data.FirstName;
                    var userLastName = ReturnedData.data.LastName;
                    var useruserEmail = ReturnedData.data.userEmail;
                    var useruserPhone = ReturnedData.data.userPhone;
                    var userPassword = ReturnedData.data.Password;
                    var userUsername = ReturnedData.data.username;
                });

                // Swal.fire shows login credentials
                Swal.fire({
                    title: "Login Credentials",
                    html: `Username: ${registrationData.username} <br> Password: ${registrationData.Password}`,
                    icon: "success",
                    timer: 8000,
                    timerProgressBar: true,
                    didOpen: () => {
                        Swal.showLoading();
                    }
                }).then((result) => {
                    // Redirect to Login after Swal.fire closes 
                    if (result.dismiss === Swal.DismissReason.timer || result.isConfirmed) {
                        window.location.href = "/Home/LogInPage";
                    }
                });

            } else {
                Swal.fire({
                    icon: "error",
                    title: "Error",
                    text: "User already exists!",
                });
                $scope.cancelFunction();
            }
        };


        $scope.cancelFunction = function () {
            $scope.firstName = null;
            $scope.lastName = null;
            $scope.userEmail = null;
            $scope.userPhone = null;
            $scope.username = null;
            $scope.userPassword = null;
        }



 

    // 3. Login Page
        $scope.loginFunction = function () {
        // Get credentials from sessionStorage
        var storedCredentials = sessionStorage.getItem("credentials");

        /* If credentials were saved in sessionStorage, they are retrieved then converted back to array and stored in userCredentials.
        If not, userCredentials is an empty array, meaning no users are registered yet.*/
        var userCredentials = storedCredentials ? JSON.parse(storedCredentials) : [];

        // Retrieve username and password input
        var enteredusername = $scope.username;
        var enteredPassword = $scope.userPassword;

        // Find the user in the credentials array
        var userExists = userCredentials.find(userSearch =>
            userSearch.username === enteredusername && // Use entered username
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