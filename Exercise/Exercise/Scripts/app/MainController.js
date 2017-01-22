bgl.controller('MainController', ['$scope', 'GitupService', function ($scope, GitupService) {
	
	$scope.hideUserDetails = true;
	$scope.hideErrorMessage = true;
	$scope.hideNoUsersFound = true;
	
	$scope.getUser = function() {
		
		if (!$scope.inputValue) {
			return;
		}
		
        GitupService.getUser($scope.inputValue)
            .then(function successCallback(response) {
				if (response.data.Err) {
					$scope.hideErrorMessage = false;
					$scope.hideUserDetails = true;
					$scope.hideNoUsersFound = true;
					return;
				}
				
				if (!response.data.User) {
					$scope.hideNoUsersFound = false;
					$scope.hideErrorMessage = true;
					return;
				}
				
				$scope.user = response.data.User;
				$scope.repos = response.data.Repos;
				$scope.hideUserDetails = false;
				$scope.hideErrorMessage = true;
				$scope.hideNoUsersFound = true;
            
			}, function errorCallback(response) {
				$scope.status = 'Unable to retrieve user: ' + error.message;
                console.log($scope.status);
            });
    }
	
	$scope.onInputKeyPress = function(keyEvent) {
		if (keyEvent.which === 13) {
			$scope.getUser();
		}
	}
	
	
}]);
