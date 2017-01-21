bgl.controller('MainController', ['$scope', 'GitupService', function ($scope, GitupService) {
	
	$scope.hideUserDetails = true;
	
	$scope.getUser = function() {		
        GitupService.getUser($scope.inputValue)
            .then(function successCallback(response) {
				debugger;
				$scope.user = response.data.User;
				$scope.repos = response.data.Repos;
				$scope.hideUserDetails = false;
            }, function errorCallback(response) {
                debugger;
				$scope.status = 'Unable to retrieve user: ' + error.message;
                console.log($scope.status);
            });
    }	
	
}]);
