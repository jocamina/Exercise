bgl.factory('GitupService', ['$http', function ($http) {

    var GitupService = {};

    GitupService.getUser = function (inputValue) {
		var filter = {inputValue: inputValue};

		return $http({
            method: 'GET',
            url: '/Home/GetUser',
            params: filter
        });
    };

    return GitupService;
}]);
