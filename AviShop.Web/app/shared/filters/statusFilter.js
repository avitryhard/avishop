(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            return (input == true ? 'Kích hoạt' : 'Khóa');
            
        }
    });
})(angular.module('avishop.common'));