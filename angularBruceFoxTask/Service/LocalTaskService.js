myApp.service('LocalTaskService', function ($http) {
    this.fetchTasks = function () {
        return $http.get('http://localhost:50969/api/TaskRecords')
    }
})