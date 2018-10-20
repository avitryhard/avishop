var myApp = angular.module('AviShop', []);

myApp.controller('myController', myController);
myApp.service('validatorService', validatorService);
myApp.directive('aviShopDirective', aviShopDirective);

myController.$inject = ['$scope', 'validatorService'];

function myController($scope, validatorService) {  
    $scope.checkNumber = function () {
        validatorService.checkNumber($scope.num);
    }
    $scope.num = 1;
}

function validatorService($window) {
    return {
        checkNumber : checkNumber
    }
    function checkNumber(input) {
        if (input % 2 == 0)
            window.alert("Day la so chan");
        else window.alert("Day la so le");
    }
}

function aviShopDirective() {
    return {
        restrict: "A",
        templateUrl: "/Scripts/spa/AviShopDirective.html"
    }
}