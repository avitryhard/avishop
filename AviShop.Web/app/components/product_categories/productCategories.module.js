(function () {
    angular.module('avishop.product_categories', ['avishop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: "/product_categories",
            templateUrl: "app/components/product_categories/productCategoryListView.html",
            controller: "productCategoryListController"
        }).state('add_product_categories', {
            url: "/add_product_categories",
            templateUrl: "app/components/product_categories/productCategoryAddView.html",
            controller: "productCategoryAddController"
        }).state('edit_product_categories', {
            url: "/edit_product_categories/:id",
            templateUrl: "app/components/product_categories/productCategoryEditView.html",
            controller: "productCategoryEditController"
        });
    }
})();