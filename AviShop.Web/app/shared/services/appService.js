/// <reference path="/assets/admin/libs/angular/angular.js" />

(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http'];

    function apiService($http) {
        return {
            get : get
        }

        function get(url, params, success, failed) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failed(error);
            });
        }
    }
})(angular.module('avishop.common'));