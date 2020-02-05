$(document).ready(function () {
    GetWeatherData();
});

function GetWeatherData() {
    var urlParams = new URLSearchParams(window.location.search);

    var dataObj = {
        ZipCode: urlParams.get('zipcode')
    }

    $.ajax({
        url: myApp.Urls.baseUrl + 'Home/GetWeatherData',
        type: 'POST',
        data: dataObj,
        dataType: 'json',
        success: function (data) {
            if (data != null) {

                var msg = ""
                
                msg = msg + "<img src='" + myApp.Urls.baseUrl + "img/" + data["IMG_URL"] + "' height='100' width='100' style='padding: 10px 10px 10px 10px'>";
                msg = msg + "<table>";
                msg = msg + "<tr><td align=left class='TDproperty'>City: </td><td class='TDValue'>" + data["City"] + "</td>";
                msg = msg + "<tr><td align=left class='TDproperty'>State: </td><td class='TDValue'>" + data["State"] + "</td>";
                msg = msg + "<tr><td align=left class='TDproperty'>Weather: </td><td class='TDValue'> " + data["WeatherType"] + "</td>";
                msg = msg + "<tr><td align=left class='TDproperty'>Temperature: </td><td class='TDValue'>" + data["Temperature"] + " F</td>";
                msg = msg + "<tr><td align=left class='TDproperty'>Humidity: </td><td class='TDValue'>" + data["Humidity"] + " %</td>";
                msg = msg + "<tr><td align=left class='TDproperty'>DewPoint: </td><td class='TDValue'>" + data["DewPoint"] + " </td>";
                msg = msg + "<tr><td align=left class='TDproperty'>Pressure: </td><td class='TDValue'>" + data["Pressure"] + " in</td>";
                msg = msg + "<tr><td align=left class='TDproperty'>WindSpeed: </td><td class='TDValue'>" + data["WindSpeed"] + " " + data["WindDirection"] + " mph</td>";


                msg = msg + "</table>";

                $('#WeatherData').html(msg);
            }
        },
        error: function (request, error) {
            alert("Error: " + JSON.stringify(error));
        },
        complete: function () {

        }
    });
}