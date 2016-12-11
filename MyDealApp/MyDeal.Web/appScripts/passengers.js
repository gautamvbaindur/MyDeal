function displayPassengers() {
    $("#results").empty();
    var data = "";
    $.get('/pnl.txt', function (result) {
        data = result;
        var searchText = $("#recordText").val();
        $.post('http://localhost:54273/mydeal/pnl', { passengerList: data, searchText: searchText }, function (result) {
            $("#recordTemplate").tmpl(result).appendTo("#results");
        })
    });
}

function addPassengers(urlToCall) {
    var newPassenger = $("#recordText").val();
    if (!newPassenger){
        alert("please add a passenger");
        return;
    }
    $.post(urlToCall, { record: newPassenger }, function () {
        alert("passenger added successfully");
    });
}