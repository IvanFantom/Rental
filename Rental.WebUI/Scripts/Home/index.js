$(function () {
    'use strict';

    $.ajaxSetup({ cache: false });

    $('#replaceTarget').on('click', 'a[data-alert]', function (e) {
        e.preventDefault();

        $.ajax({
            url: this.href,
            type: 'POST',
            success: function (result) {
                if (result.success) {
                    $('#alertReplaceTarget').load(result.url);
                }
            }
        });
    });

    $('#replaceTarget').on('click', 'a[data-modal]', function (e) {
        $('#advertModalContent').load(this.href, function () {
            $('#advertModal').modal({
                keyboard: true
            }, 'show');
        });
        return false;
    });

    $('#advertFilterForm').on('submit', 'form.form-filter', function (e) {
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

    $('#replaceTarget').on('click', '.pagination-container a', function (e) {
        e.preventDefault();

        var $form = $('form.form-filter');
        var data = $form.serialize();
        data['page'] = $(this).val();

        if (this.href !== '') {
            $('#replaceTarget').load(this.href, data);
        }
    });
});