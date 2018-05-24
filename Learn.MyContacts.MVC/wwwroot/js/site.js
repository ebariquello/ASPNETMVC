// Write your JavaScript code.

$(document).ready(function () {
    $(".digit").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            $("#errorMsgNumber").html("Número Apenas").show().fadeOut("slow");
            return false;
        }
    });
});
