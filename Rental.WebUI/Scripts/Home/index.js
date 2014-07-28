$(function () {
    'use strict';

    $.ajaxSetup({ cache: false });

    $("a[data-modal]").on("click", function (e) {
        $('#advertModalContent').load(this.href, function () {
            $('#advertModal').modal({
                keyboard: true
            }, 'show');
        });
        return false;
    });

    $('form.form-filter').submit(function (e) {
        e.preventDefault();
        var data = $(this).serialize();

        $.ajax({
            url: this.action,
            type: this.method,
            data: data,
            success: function (result) {
                if (result.success) {
                    $('#replaceTarget').load(result.url);   // Load data from the server and place the returned HTML into the matched element
                }
            }
        });
    });
});