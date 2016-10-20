/// <reference path="c:\users\steven tran\documents\visual studio 2015\Projects\angularBruceFox\angularBruceFoxTask\scripts/angular.min.js" />

var myApp = angular.module('myModule', ['angularUtils.directives.dirPagination', 'ngRoute']);

myApp.config(function ($routeProvider) {
    $routeProvider.
    when('/Tasks', {
        templateUrl: '../View/TaskPage.html',
        controller: 'TaskController'
    }).
    when('/MyTask', {
        templateUrl: '../View/MyTask.html',
        controller: 'TaskController'
    }).
    otherwise({
        redirectTo: '/Tasks'
    });
})