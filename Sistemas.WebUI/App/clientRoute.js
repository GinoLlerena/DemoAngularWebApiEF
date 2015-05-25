
webApp.config(["$routeProvider", "$locationProvider", "$httpProvider", function ($routeProvider, $locationProvider, $httpProvider) {

    
    $routeProvider.when("/", {
        templateUrl: "/app/home/html/home.html"
    });

    $routeProvider.when("/unidades", {
        templateUrl: "/app/unidad/html/unidadList.html",
        controller: "unidadController",
        controllerAs: "vm"
    });

    $routeProvider.when("/unidades/unidad", {
        templateUrl: "/app/unidad/html/unidadForm.html",
        controller: "crudUnidadController",
        controllerAs: "vm"
    });

    $routeProvider.when("/unidades/deleteunidad", {
        templateUrl: "/app/unidad/html/deleteUnidadForm.html",
        controller: "crudUnidadController",
        controllerAs: "vm"
    });

    $routeProvider.when("/productos", {
        templateUrl: "/app/producto/html/productoList.html",
        controller: "productoController",
        controllerAs: "vm"
    });

    $routeProvider.when("/productos/producto", {
        templateUrl: "/app/producto/html/productoForm.html",
        controller: "crudProductoController",
        controllerAs: "vm"
    });
        
    $routeProvider.when("/productos/deleteproducto", {
        templateUrl: "/app/producto/html/deleteProductoForm.html",
        controller: "crudProductoController",
        controllerAs: "vm"
    });


    $routeProvider.when("/about", {
        templateUrl: "/app/home/html/about.html"
    });

    $routeProvider.otherwise({
        redirecTo: '/'
    });

    $locationProvider.html5Mode(true).hashPrefix('!');


}]);