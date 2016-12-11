function customShorten(urlToCall) {

    var regexPattern = '^http(s?)\:\/\/(www\.mydeal\.com\.au)(/?)';

    var enteredUrl = $('#longUrlText').val();

    if (enteredUrl && new RegExp(regexPattern).test(enteredUrl)) {
        $.get(urlToCall, { longUrl: enteredUrl }, function (result) {
            $('#shorterURLResult').text("");
            $('#shorterURLResult').append('<a href="' + result + '" target="_blank">' + result + '</a>');
        });
    } else {
        alert('enter valid url');
    }
}