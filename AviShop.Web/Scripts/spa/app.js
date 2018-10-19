var myApp = angular.module('AviShop', []);

myApp.controller("thongBaoTruong", thongBaoTruong);
myApp.controller("thongBaoHocSinh", thongBaoHocSinh);
myApp.controller("thongBaoGiaoVien", thongBaoGiaoVien);

//declare
function thongBaoTruong($scope)
{
    $scope.message = "Day la thong bao cua truong";        
}

function thongBaoHocSinh($scope)
{
    $scope.message = "Day la thong bao cua hoc sinh";
}

function thongBaoGiaoVien($scope) {
    $scope.message = "Day la thong bao cua giao vien";
}