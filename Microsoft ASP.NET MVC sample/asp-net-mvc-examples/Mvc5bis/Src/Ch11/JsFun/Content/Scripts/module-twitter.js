GLOBALS.namespace("Widgets.Twitter");

GLOBALS.Widgets.Twitter = function () {
    var localUrlPattern = "http://www.e-tennis.net/corinto/social/tweets/",
        localWidget = "",
        localBuildWidget = function (items) {
            var numOfTweets = items.length;
            if (localSettings.maxTweets > 0)
                numOfTweets = Math.min(numOfTweets, localSettings.maxTweets);
            var buffer = "<table rules='rows'>";
            for (var i = 0; i < numOfTweets; i++) {
                buffer += "<tr><td>" + items[i].Title + "</td></tr>";
            }
            buffer += "</table>";
            localWidget = buffer;
        },
        localSettings = {
            maxTweets: 5,
            autoRefreshEvery: 0     // Not used at this time!
        };

    return {
        load: function (user, selector, settings) {
            if (settings != null)
                localSettings = settings;
            var localUrl = localUrlPattern + user;
            $.getJSON(localUrl)
                .done(function (data) {
                    localBuildWidget(data);
                    $(selector).html(localWidget);
                });
        },
        getHtml: function () {
            return localWidget;
        }
    };
} ();