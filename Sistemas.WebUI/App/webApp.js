"use strict";

var webApp = angular.module('webApp', ['ngRoute',  'ui.bootstrap', 'angularUtils.directives.dirPagination', 'angular-loading-bar']);

webApp.constant("confServer", {
    "apiUrl": "http://localhost:49528/"
});

webApp.factory("sharedData", function () { return { value: 0 } });

