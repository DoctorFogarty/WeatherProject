var validzip = false;

$(document).ready(function () {
    document.getElementById('zipcode').focus();
});

$(document).keydown(function (e) {
    if (e.keyCode == 13) {
        ValidateZipCode();
    }
});


function ValidateZipCode() {
    var dataObj = {
        ZipCode: $('#zipcode').val()
    }

    $.ajax({
        url: myApp.Urls.baseUrl + 'Home/ValidateZipCode',
        type: 'POST',
        data: dataObj,
        dataType: 'json',
        success: function (data) {
            if (data) {
                validzip = true;
            } else {
                $('#msg').html('ZipCode invalid!');
            }

        },
        error: function (request, error) {
            alert("Error: " + JSON.stringify(error));
        },
        complete: function () {
            if (validzip) {
                window.location = myApp.Urls.baseUrl + 'Home/Weather?zipcode=' + $('#zipcode').val();
            }
        }
    });
}

