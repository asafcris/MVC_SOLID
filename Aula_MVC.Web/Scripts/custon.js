$(function () {
    var displayMessage = function (message, msgType) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
        toastr[msgType](message);
    };

    if ($('#success').val()) {
        displayMessage($('#success').val(), 'success');
    }
    if ($('#info').val()) {
        displayMessage($('#info').val(), 'info');
    }
    if ($('#warning').val()) {
        displayMessage($('#warning').val(), 'warning');
    }
    if ($('#error').val()) {
        displayMessage($('#error').val(), 'error');
    }
});