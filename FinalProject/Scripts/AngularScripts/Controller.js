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

    //redirects
    $scope.redirectToManageFlashcards = function () {
        $window.location.href = "/Home/ManageFlashcardPage";
    };



    $scope.redirectToStudyFlashcards = function () {
        $window.location.href = "/Home/StudyFlashcardsPage";
    };


    //Dashboard - deck popup
    // Popup visibility state
    $scope.isPopupVisible = false;

    // Model for deck title input
    $scope.deckModel = {
        title: ''
    };

    // Function to open popup
    $scope.openPopup = function () {
        $scope.isPopupVisible = true;
        $scope.deckModel.title = ''; // Clear the input
    };

    // Function to close popup
    $scope.closePopup = function () {
        $scope.isPopupVisible = false;
        $scope.deckModel.title = ''; // Clear the input
    };

    // Function to save deck
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
                $scope.loadDecks(); // Reload the decks after saving
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
        window.location.href = '/Home/ManageFlashcards/' + deckID;  // Navigate to the correct URL with deckID
    };


    //$scope.goToManageFlashcards = function (deckID) {
    //    window.location.href = `/home/manageflashcardpage?deckID=${deckID}`;
    //};



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


