///#source 1 1 /app/js/main.js
angular.module('app', []);
///#source 1 1 /app/js/appController.js
angular.module('app').controller('AppController', [
    '$scope',
    '$http',
    'api',
    function($scope, $http, api) {
        $scope.options = {
            apiUrl: 'http://petstore.swagger.wordnik.com/api/api-docs',
            apiName: 'Petstore'
        };

        $scope.discover = function(apiUrl, apiKey) {
            apiUrl += apiKey ? '?api_key=' + apiKey : '';
            $http.get(apiUrl).then(
                function(response) {
                    $scope.discovered = response.data;
                },
                function(error) {
                    $scope.discovered = error;
                }
            );
        };

        $scope.process = function(options) {
            api.postProcessorJob({
                options: options
            });
        };
    }
]);
///#source 1 1 /app/js/api.js
angular.module('app').factory('api', [
    '$http',
    function($http) {
        function returnResponseData(response) {
            return response.data;
        }

        return {
            getProcessors: function() {
                return $http.get('api/processors').then(returnResponseData);
            },

            postProcessorJob: function(job) {
                return $http.post('api/processors/jobs', job).success(
                    function(data, status, headers) {
                        var octetStreamMime = "application/octet-stream";

                        // Get the headers
                        headers = headers();

                        // Get the filename from the x-filename header or default to "download.bin"
                        var filename = headers["x-filename"] || "download.bin";

                        // Determine the content type from the header or default to "application/octet-stream"
                        var contentType = headers["content-type"] || octetStreamMime;

                        // Get the blob url creator
                        var urlCreator = window.URL || window.webkitURL || window.mozURL || window.msURL;
                        if (urlCreator) {
                            // Try to use a download link
                            var link = document.createElement("a");
                            if ("download" in link) {
                                // Prepare a blob URL
                                var blob = new Blob([data], {
                                    type: contentType
                                });
                                var url = urlCreator.createObjectURL(blob);
                                link.setAttribute("href", url);

                                // Set the download attribute (Supported in Chrome 14+ / Firefox 20+)
                                link.setAttribute("download", filename);

                                // Simulate clicking the download link
                                var event = document.createEvent('MouseEvents');
                                event.initMouseEvent('click', true, true, window, 1, 0, 0, 0, 0, false, false, false, false, 0, null);
                                link.dispatchEvent(event);

                                console.log("Download link Success");
                            } else {
                                // Prepare a blob URL
                                // Use application/octet-stream when using window.location to force download
                                var blob = new Blob([data], {
                                    type: octetStreamMime
                                });
                                var url = urlCreator.createObjectURL(blob);
                                window.location = url;

                                console.log("window.location Success");
                            }
                        } else {
                            console.log("Not supported");
                        }
                    }
                );
            }
        }
    }
]);
