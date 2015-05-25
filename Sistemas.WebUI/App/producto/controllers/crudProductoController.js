webApp.controller("crudProductoController", function ($location, sharedData, productoService) {

    var vm = this;
    var unidades = [];
    
    if (sharedData.value > 0) {
        productoService.getProducto(sharedData.value).then(function (results) {
            vm.producto = results.data;
        },
        function (error) {
            alert(error.data.message);
        });
    }
    else {
        vm.producto = {};
        vm.producto.id = 0;
    }

    function save() {
        var Producto = {
            Id: vm.producto.id,
            Nombre: vm.producto.nombre,
            UnidadId: vm.producto.unidadID,
            Precio: vm.producto.precio
        };

        var promise;

        if (sharedData.value > 0) 
            promise = productoService.put(sharedData.value, Producto);
        else
            promise = productoService.post(Producto);

        promise.then(function (pl) {
                    $location.path("/productos");
                },
              function (errorPl) {
                  vm.error = 'Falló al grabar el Producto.', errorPl;
              });
    };

    function destroy() {
        var promise = productoService.delete(sharedData.value);
        promise.then(function (pl) {
                    $location.path("/productos");
                },
              function (errorPl) {
                  $scope.error = 'Falló en la eliminación del Producto', errorPl;
              });
    };

    productoService.getUnidades()
                .then(function (results) {
                    vm.unidades = results.data;
                },
                function (error) {
                    alert(error.data.message);
                });
    
    function cancel() {
        $location.path("/productos");
    };

    vm.cancel = cancel;
    vm.save = save;
    vm.destroy = destroy;

});