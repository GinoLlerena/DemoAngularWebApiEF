webApp.controller('productoController', function ($location, sharedData, productoService) {
    var vm = this;

    vm.productos = [];
    vm.totalUsers = 0;
    vm.usersPerPage = 10;

    getResultsPage(1);

    function edit(Id) {
        sharedData.value = Id;
        $location.path("/productos/producto");
    }

    function destroy(Id) {
        sharedData.value = Id;
        $location.path("/productos/deleteproducto");
    }

    function getResultsPage(newPage) {
        productoService.getPaginado(newPage).then(function (results) {
            vm.productos = results.data.productos;
            vm.totalUsers = results.data.count;
        },
            function (error) {
                alert(error.data.message);
            });
    };

    vm.destroy = destroy;
    vm.edit = edit;
    vm.getResultsPage = getResultsPage;
});