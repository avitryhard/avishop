var myApp = angular.module('AviShop', []);

myApp.controller('myController', myController);
myApp.service('Validator', Validator);

myController.$inject = ['$scope', 'Validator'];

function myController($scope, Validator) {  
    $scope.checkNumber = function () {
        Validator.checkNumber($scope.num);
    }
    $scope.num = 1;
}

function Validator($window) {
    return {
        checkNumber : checkNumber
    }
    function checkNumber(input) {
        if (input % 2 == 0)
            window.alert("Day la so chan");
        else window.alert("Day la so le");
    }
}