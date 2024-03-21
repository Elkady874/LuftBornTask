angular.module('Index', [])
    .controller('IndexController', ['$http', '$scope', function ($http, $scope) {
        var selectedItem;
        
         $scope.newItem = { Description: "", Done: false }
        $scope.toDos = [

        ];

        function isTableItem(event) {
            return event.target.nodeName == 'TD' || event.target.nodeName == 'TR'
        }
        function selectRow(event, id) {


            if (isTableItem(event)) {
                selectedItem = $scope.toDos.find(e => e.id == id);
                var myEl = document.querySelectorAll(`[data-id="${id}"]`);
                myEl.forEach(Element => Element.classList.add("highlight"))
                selectedItem.edit = true;
            }
        }

        function UnSelectRow(event) {
            var previouslySelected = document.querySelectorAll(`[data-id="${selectedItem.id}"]`);
            previouslySelected.forEach(Element => Element.classList.remove("highlight"))
            selectedItem.edit = false;

        }


        $scope.highLight = function (event) {
            let id = event.target.getAttribute('data-id');

            if (selectedItem && selectedItem.id != id && isTableItem(event)) {
                UnSelectRow(event);

            }
            selectRow(event, id);


        }




        //  $http.get('https://localhost:7223/api/ToDo/2' )
        $scope.edit = function () {
            console.log($scope.selectedStatus)
            $http({
                method: 'PUT',
                url: `https://localhost:7223/api/ToDo/EditToDo?Id=${selectedItem.id}&Description=${selectedItem.description}&Done=${selectedItem.done} `
            }).then(function (response) {

            });
        }



        $scope.add = function () {
            console.log($scope.newItem)
            $http({
                method: 'POST',
                url: `https://localhost:7223/api/ToDo/AddToDoItems`,
                data: $scope.newItem

            }).then(function (response) {

                if (response.status == 200) {

                    $scope.toDos.push({
                        id:-1,
                        description: $scope.newItem.Description,
                        done: false,
                        edit: false,


                    })

                }

            });
        }



        $scope.delete = function () {
            $http({
                method: 'DELETE',
                url: `https://localhost:7223/api/ToDo/RemoveToDo?itemId=${selectedItem.id}`
            }).then(function (response) {



                if (response.status == 200) {

                    const index = $scope.toDos.findIndex(e => e.id == selectedItem.id);
                    $scope.toDos.splice(index, 1);

                }

            });


        }

        $http({
            method: 'GET',
            url: 'https://localhost:7223/api/ToDo/GetToDoItems'
        }).then(function (response) {
            response.data.forEach(
                item => $scope.toDos.push({
                    id: item.id,
                    description: item.description,
                    done: item.done,
                    edit: false,


                })

            )

        });



    }])