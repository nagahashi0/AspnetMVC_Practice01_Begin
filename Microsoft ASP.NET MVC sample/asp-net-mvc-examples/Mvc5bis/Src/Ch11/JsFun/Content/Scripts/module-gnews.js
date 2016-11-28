GLOBALS.namespace("GoogleNews");

GLOBALS.GoogleNews = function () {
    var localUrl = "'https://ajax.googleapis.com/ajax/services/search/news?v=1.0&q=barack%20obama'";  //"http://ajax.googleapis.com/ajax/services/feed/load?v=1.0&num=8&q=http%3A%2F%2Fnews.google.com%2Fnews%3Foutput%3Drss",
    localWidget = "",
        localBuildWidget = function (data) {
            var buffer = "<table rules='rows'>";
            var numOfArticles = data.responseData.entries.length;
            alert(numOfArticles);
            if (localSettings.numArticles > 0)
                numOfArticles = Math.min(numOfArticles, localSettings.numArticles);

            numOfArticles = 4;
            for (var i = 0; i < numOfArticles; i++) {
                buffer += "<tr><td>" + data.responseData.entries[i].Title + "</td></tr>";
            }
            buffer += "</table>";
            localWidget = buffer;
        },
        localSettings = {
            numArticles: 5,
            autoRefreshEvery: 0
        };

    return {
        load: function (selector, settings) {
            localSettings = settings;
            alert(localUrl);
            $.getJSON(localUrl)
                .done(function (data) {
                    alert(data);
                    localBuildWidget(data);
                    $(selector).html(localWidget);
                })
                .fail(function (xhr, status, t) {
                    alert(xhr.statusCode().text);
                });
        },
        getHtml: function () {
            return localWidget;
        }
    };
} ();