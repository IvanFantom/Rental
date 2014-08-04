$(function () {
    'use strict';

    $.ajaxSetup({ cache: false });

    $('#advertReplaceTarget, #reservedAdvertsReplaceTarget').on('click','a[data-modal]', function (e) {
        $('#advertModalContent').load(this.href, function () {
            $('#advertModal').modal({
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });

    function bindForm(dialog) {
        $(dialog).on('submit', 'form', function (e) {
            e.preventDefault();
            var data = $(this).serialize();

            $.ajax({
                url: this.action,
                type: this.method,
                data: data,
                success: function (result) {
                    if (result.success) {
                        $('#advertModal').modal('hide');
                        $(result.replaceTarget).load(result.url);   // Load data from the server and place the returned HTML into the matched element
                    } else {
                        $('#advertModalContent').html(result);
                        bindForm();
                    }
                }
            });
        });
    }
});