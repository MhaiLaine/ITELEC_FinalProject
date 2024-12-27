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
            username: $scope.username,
            userPassword: $scope.userPassword
        };

        FinalProjectService.submitRegistration(registrationData).then(function (response) {
            if (response.data.success) {
                Swal.fire('Registration Successful!', '', 'success').then(() => {
                    $window.location.href = "/Home/LogInPage"; // Redirect to login page
                });
            } else {
                Swal.fire('Error!', response.data.message || 'Registration failed.', 'error');
            }
        }, function (error) {
            Swal.fire('Error!', error.message || 'An unexpected error occurred.', 'error');
        });
    };

    $scope.loginFunction = function () {
        var loginData = {
            username: $scope.username,
            userPassword: $scope.userPassword
        };

        FinalProjectService.loginFunction(loginData).then(function (response) {
            if (response.data.success) {
                Swal.fire('Login Successful!', '', 'success').then(() => {
                    $window.location.href = "/Home/WelcomePage"; // Redirect to welcome page
                });
            } else {
                Swal.fire('Error!', response.data.message || 'Invalid credentials.', 'error');
            }
        }, function (error) {
            Swal.fire('Error!', error.message || 'An unexpected error occurred.', 'error');
        });
    };

    $scope.cancelFunction = function () {
        $scope.firstName = null;
        $scope.lastName = null;
        $scope.userEmail = null;
        $scope.userPhone = null;
        $scope.username = null;
        $scope.userPassword = null;
    }

    // Welcome Page
    $scope.redirectToDashboard = function () {
        $window.location.href = "/Home/Dashboard1";
    };

    // Redirects
    $scope.redirectToManageFlashcards = function () {
        $window.location.href = "/Home/ManageFlashcardPage";
    };

    $scope.redirectToStudyFlashcards = function () {
        $window.location.href = "/Home/StudyFlashcardsPage";
    };

    // Dashboard - deck popup
    $scope.isPopupVisible = false;

    $scope.deckModel = {
        title: ''
    };

    $scope.openPopup = function () {
        $scope.isPopupVisible = true;
        $scope.deckModel.title = '';
    };

    $scope.closePopup = function () {
        $scope.isPopupVisible = false;
        $scope.deckModel.title = '';
    };

    $scope.saveDeck = function () {
        if (!$scope.deckModel.title) {
            Swal.fire('Error!', 'Deck title cannot be empty.', 'error');
            return;
        }

        var newDeck = {
            deckName: $scope.deckModel.title
        };

        FinalProjectService.saveDeck(newDeck).then(function (response) {
            if (response.data.success) {
                Swal.fire('Deck Saved!', 'Your deck has been added successfully.', 'success');
                $scope.loadDecks();
            } else {
                Swal.fire('Error!', response.data.message || 'Failed to save deck.', 'error');
            }
        }, function (error) {
            Swal.fire('Error!', error.message || 'An unexpected error occurred.', 'error');
        });
    };

    $scope.loadDecks = function () {
        $http.get("/Home/LoadDecks")
            .then(function (response) {
                $scope.decks = response.data;
            }, function (error) {
                console.error('Error loading decks:', error);
            });
    };

    $scope.goToManageFlashcards = function (deckID) {
        window.location.href = '/Home/ManageFlashcards/' + deckID;
    };

    $scope.loadUsers = function () {
        $http.get("/Home/loadUsers").then(function (response) {
            if (response.data) {
                $scope.userData = response.data;
            } else {
                Swal.fire('Error!', 'Failed to load users.', 'error');
            }
        }, function (error) {
            Swal.fire('Error!', error.message || 'An unexpected error occurred.', 'error');
        });
    };

    $scope.$on('$viewContentLoaded', function () {
        $scope.loadUsers();
    });

    // Update User Function
    $scope.updateUser = function (user) {
        var updateData = {
            userID: user.userID,
            deckID: user.deckID,
            firstName: user.firstName,
            lastName: user.lastName,
            username: user.username,
            userPhone: user.userPhone,
            userEmail: user.userEmail
        };

        userService.updateUser(updateData).then(function (response) {
            if (response.data.Success) {
                alert('User updated successfully!');
                $scope.getUsers(); // Reload the user list
            } else {
                alert('Error: ' + response.data.Message);
            }
        }, function (error) {
            alert('An error occurred: ' + error.statusText);
        });
    };

    // Delete User Function
    $scope.deleteUser = function (userID) {
        if (confirm("Are you sure you want to delete this user?")) {
            userService.deleteUser(userID).then(function (response) {
                if (response.data.Success) {
                    alert('User deleted successfully!');
                    $scope.getUsers(); // Reload the user list
                } else {
                    alert('Error: ' + response.data.Message);
                }
            }, function (error) {
                alert('An error occurred: ' + error.statusText);
            });
        }
    };

    //Get Users
    $scope.getUsers = function () {
        // Logic to fetch and populate users in $scope.userData
    };


    $scope.labels = ["August", "September", "October", "November", "December"];
    $scope.data = [2, 3, 0, 1, 3];





});
