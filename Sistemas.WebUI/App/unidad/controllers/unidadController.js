webApp.controller('unidadController', function ($location, sharedData, unidadService) {
    var vm = this;

    vm.unidades = [];
    vm.totalItems = 0;
    vm.usersPerPage = 10;

    getResultsPage(1);

    function pageChanged(newPage) {
        getResultsPage(newPage);
    };
    
    function edit(Id) {
        sharedData.value = Id;
        $location.path("/unidades/unidad");
    }

    function destroy(Id) {
        sharedData.value = Id;
        $location.path("/unidades/deleteunidad");
    }

    function getResultsPage(newPage) {

        var promise = unidadService.getPaginado(newPage);

            promise.then(function (results) {
                    vm.unidades = results.data.unidades;
                    vm.totalItems = results.data.count;
                },
            function (error) {
                alert(error.data.message);
            });
    };


    vm.edit = edit;
    vm.destroy = destroy;
    vm.pageChanged = pageChanged;

});