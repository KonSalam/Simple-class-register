
$(document).ready(function () {

    $(document).on('click', '#submitMark', function (evt) {

        $.ajax({
            url: "/Teacher/AddMark",
            type: 'POST',
            data: { grade: $('#garde_list').val(), subjectCardId: $('#grade_list').val() },
            success: function (response) {
            }
        });

    });

});