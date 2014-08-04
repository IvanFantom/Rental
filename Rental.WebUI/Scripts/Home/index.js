$(function () {
    'use strict';

    $.ajaxSetup({ cache: false });

    $('#advertReplaceTarget').on('click', 'a[data-alert]', function (e) {
        e.preventDefault();

        $.ajax({
            url: this.href,
            type: 'POST',
            success: function (result) {
                if (result.success) {
                    $('#alertReplaceTarget').load('/Home/ShowAlert');
                    $(result.replaceTarget).load(result.url);
                }
            }
        });
    });

    $('#advertReplaceTarget').on('click', 'a[data-modal]', function (e) {
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
                    $(result.replaceTarget).load(result.url);   // Load data from the server and place the returned HTML into the matched element
                }
            }
        });
    });

    $('#advertReplaceTarget').on('click', '.pagination-container a', function (e) {
        e.preventDefault();

        var $form = $('form.form-filter');
        var data = $form.serialize();
        data['page'] = $(this).val();

        if (this.href !== '') {
            $('#advertReplaceTarget').load(this.href, data);
        }
    });
});