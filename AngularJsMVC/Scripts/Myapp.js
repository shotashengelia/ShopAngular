/// <reference path="angular.js" />
/// <reference path="angular.min.js" />
/// <reference path="angular-route.min.js" />


//var app = angular.module("myapp", []);
var app = angular.module("Myapp", []);

const defaultProductModel = {
    Name: "",
    Price: "",
    Amount: "",
    CategoryId: "",
    CategoryName: ""
}

app.controller("Myapp", function myfunction($scope, $http) {

    $scope.SaveCategory = function myfunction() {
        //$http({
        //    method: 'POST',
        //    url: '/Home/Category',
        //    data: $scope.InsertCategory
        //}).success(function () {
        //    $scope.InsertCategory = null;
        //    alert('Data Inserted!');
        //}).error(function () {
        //    alert('Data Insert Failed!');
        //});
        $http.post("/Home/InsertCategory", { name: $scope.ProductModel.CategoryName }).then(function (response) {
            if (response.data.success) {
                //toastr.success(response.data.result);
                $scope.ProductModel.CategoryName = "";
            } else {
                console.log(response.data.result);
            }
        }, function (data) {

        });
    }

    $scope.ProductModel = {};

    function renewProductModel() {
        var model;
        angular.copy(model, defaultProductModel);
        $scope.ProductModel = model;
    }
    renewProductModel();
    

    $scope.SaveProduct = function () {
        $http.post("/Home/InsertProduct", $scope.ProductModel).then(function (response) {
                if (response.data.success) {
                    renewProductModel();
                }
                else {
                    console.log(response.data.result);
                }
            });
    }

    $scope.GetCategory = function () {

        $scope.getcategory=[];

        $http.post("/Home/GetCategory").then(function (response) {
            if (response.data.success) {
                $scope.getcategory = response.data
            }
        })
    }
})
