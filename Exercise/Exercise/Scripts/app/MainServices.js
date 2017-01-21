bgl.factory('GitupService', ['$http', function ($http) {

    var GitupService = {};

    GitupService.getUser = function (filter) {
        return $http({
            method: 'GET',
            url: '/Home/GetUser',
            params: filters
        });
    };

    return GitupService;
}]);
