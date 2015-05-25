
webApp.service("productoService", function ($http, confServer) {

    
    this.getProductos = function () {
        return $http.get(confServer.apiUrl + "/api/Producto");
    };

    
    this.getUnidades = function () {
        return $http.get(confServer.apiUrl + "/api/Unidad");
    };
      
        
    this.getProducto = function (id) {
        return $http.get(confServer.apiUrl + "/api/Producto/" + id);
    };

    this.getProductoDTO = function (id) {
        return $http.get(confServer.apiUrl + "/api/Producto/dto/" + id);
    };

    this.getPaginado = function (page) {
        return $http.get(confServer.apiUrl + "api/Producto/paging/" + page);
    };

    
    this.post = function (Producto) {
        var request = $http({
            method: "post",
            url: confServer.apiUrl + "api/Producto/",
            data: Producto
        });
        return request;
    };

    
    this.put = function (id, Producto) {
        var request = $http({
            method: "put",
            url: confServer.apiUrl + "api/Producto/" + id,
            data: Producto
        });
        return request;
    };

    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: confServer.apiUrl + "api/Producto/" + id
        });
        return request;
    };
});
