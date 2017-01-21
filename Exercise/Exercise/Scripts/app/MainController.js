bgl.controller('MainController', ['$scope', 'GitupService', function ($scope, GitupService) {
	
	$scope.getUser = function() {
		$scope.inputValue;
        GitupService.getUser()
            .success(function (user) {
                $scope.user = user;
            })
            .error(function (error) {
                $scope.status = 'Unable to retrieve user: ' + error.message;
                console.log($scope.status);
            });
    }	

}]);
