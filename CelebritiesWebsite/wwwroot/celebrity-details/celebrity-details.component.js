angular.module('celebrityDetails')
    .component('celebrityDetails', {
        templateUrl: 'celebrity-details/celebrity-details.template.html',
        bindings: {
            celebrity: '<',
            isNew: '<',
            onUpdate: '&',
            onDelete: '&'
        },
        controller: [
            function CelebrityDetailsController() {
                var self = this;

                self.$onInit = function () {
                    self.celebrityToUpdate = angular.copy(self.celebrity);
                };

                self.refresh = function () {
                    self.celebrityToUpdate = angular.copy(self.celebrity);
                }

                self.save = function () {
                    self.onUpdate({ celebrity: self.celebrityToUpdate });
                    if (self.isNew) {
                        self.celebrityToUpdate = {};
                    }
                }

                self.delete = function () {
                    self.onDelete({ celebrityId: self.celebrityToUpdate.id });
                }

            }
        ]
    });