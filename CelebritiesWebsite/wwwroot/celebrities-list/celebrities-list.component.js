angular.module('celebritiesList')
    .component('celebritiesList', {
        templateUrl: 'celebrities-list/celebrities-list.template.html',
        controller: ['$http',
            function CelebritiesListController($http) {
                var self = this;

                self.$onInit = function () {
                    $http.get('api/celebrities').then(function (response) {
                        self.celebrities = response.data;
                    });
                };

                self.addCelebrity = function (celebrity) {
                    $http.post('api/celebrities', celebrity).then(function (response) {
                        self.celebrities.push(response.data);
                    });
                }

                self.updateCelebrity = function (celebrity) {
                    $http.put('api/celebrities/' + celebrity.id, celebrity).then(function () {
                        var celebrityIndex = self.celebrities.findIndex(function (item) {
                            return item.id === celebrity.id;
                        });
                        self.celebrities[celebrityIndex] = celebrity;
                    });
                }

                self.deleteCelebrity = function (celebrityId) {
                    $http.delete('api/celebrities/' + celebrityId).then(function () {
                        var celebrityIndex = self.celebrities.findIndex(function (item) {
                            return item.id === celebrityId;
                        });
                        self.celebrities.splice(celebrityIndex, 1);
                    });
                }

            }
        ]
    });