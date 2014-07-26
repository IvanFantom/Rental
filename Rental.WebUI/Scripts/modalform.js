$(function() {
    'use strict';

    $.ajaxSetup({ cache: false });

    $("a[data-modal]").on("click", function(e) {
        $('#advertModalContent').load(this.href, function() {
            $('#advertModal').modal({
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });

    function bindForm(dialog) {
        $('form', dialog).submit(function (e) {
            e.preventDefault();
            var data = $(this).serialize();

            $.ajax({
                url: this.action,
                type: this.method,
                data: data,
                success: function(result) {
                    if (result.success) {
                        $('#advertModal').modal('hide');
                        $('#replaceTarget').load(result.url);   // Load data from the server and place the returned HTML into the matched element
                    } else {
                        $('#advertModalContent').html(result);
                        bindForm();
                    }
                }
            });
        });
    }
});