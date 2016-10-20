/// <reference path="c:\users\steven tran\documents\visual studio 2015\Projects\angularBruceFox\angularBruceFoxTask\App/App.js" />

myApp.controller('TaskController', function ($scope, $http, LocalTaskService) {
    $scope.tasks = [];
    $scope.task = {};

    GetTasks();
    function GetTasks(){
        LocalTaskService.fetchTasks().then(function (data) {
            $scope.tasks = data.data
        });
    }

    $scope.getSingleData = function (task) {
        $http.get('http://localhost:50969/api/TaskRecords/' + task.Task_Id).success(function (data) {
            $scope.task = data;
            $scope.task.Due_Date = new Date($scope.task.Due_Date);
        })
        .error(function () {
            swal('Oops...', 'Something went wrong.', 'error');
        });
    }

    $scope.add = function () {
        $http.post('http://localhost:50969/api/TaskRecords', this.task).success(function (data) {
            $scope.tasks.push(data);
            swal('Sweet!', 'Task was added successfully.', 'success');
            ClearFields();
        }).error(function (data) {
            swal('Oops...', 'Something went wrong.', 'error');
        });
    };

    $scope.update = function (task) {
        $http.put('http://localhost:50969/api/TaskRecords/' + task.Task_Id, task).success(function (data) {
            swal('Sweet!', 'Task was updated successfully.', 'success');
            GetTasks();
            ClearFields();
        }).error(function (data) {
            $scope.error = "An Error has occured while updating! " + data;
        });
    };

    $scope.delete = function (task) {
        swal({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then(function () {
            $http.delete('http://localhost:50969/api/TaskRecords/' + task.Task_Id).success(function (data) {
                GetTasks();
            }).error(function (data) {
                $scope.error = "An error has occured while deleting! " + data;
            });
            swal(
              'Sweet!',
              'Your file has been deleted.',
              'success'
            );
        })
    };

    $scope.ClearFields2 = function () {
        $scope.task.Quote_Type = "";
        $scope.task.Quote_Number = "";
        $scope.task.Contact = "";
        $scope.task.Task_Record = "";
        $scope.task.Due_Date = "";
        $scope.task.Task_Type = "";
    }

    ClearFields
    function ClearFields() {
        $scope.task.Quote_Type = "";
        $scope.task.Quote_Number = "";
        $scope.task.Contact = "";
        $scope.task.Task_Record = "";
        $scope.task.Due_Date = "";
        $scope.task.Task_Type = "";
    }
})