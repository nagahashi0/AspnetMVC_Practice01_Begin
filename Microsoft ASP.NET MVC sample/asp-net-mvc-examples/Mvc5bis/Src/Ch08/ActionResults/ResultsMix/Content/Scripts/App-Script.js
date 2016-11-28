
function downloadCountries(area) {
    $("#listOfCountries").empty(); 

    $.getJSON("/home/getcountries", { area: "EMEA" },
            function (data) { _displayCountries(data); });
}

function downloadCountriesJsonp() {
    $("#listOfCountries").empty();

    _displayCountries(__jsonListOfCountries);
}

function downloadCountriesJsonpJquery(area) {
    $("#listOfCountries").empty();

    // [param]=? tells jQuery this is going to be a JSONP call. All jQuery does
    // is: create a <script> tag on the fly and make it query for url + dynamically generated function name.
    // Function name points to callback code specified in the call.
    $.getJSON("/home/getcountriesjsonp?callback=?", { area: "NA" },
            function (data) { _displayCountries(data); });
}

function _displayCountries(data) {
    // Get the reference to the drop-down list 
    var listbox = $("#listOfCountries")[0];
    
    // Fill the list
    for (var i = 0; i < data.length; i++) {
        var country = data[i];
        var option = new Option(country.Name, country.Code);
        listbox.add(option);
    };
}

var __jsonListOfCountries;
function _cacheForLater(data) {
    __jsonListOfCountries = data; 
}
