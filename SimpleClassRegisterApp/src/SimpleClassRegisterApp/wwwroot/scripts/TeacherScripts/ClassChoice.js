$(document).ready(function () {

    $("#class_list").change(function () {

        $.ajax({
            url: "/Teacher/AvailableSubjectsForClass",
            type: 'POST',
            dataType: "json",
            data: JSON.stringify($('#class_list').val()),
            contentType: 'application/json',
            success: function (response) {
                var $el = $("#subject_list");
                $el.empty();

                $.each(response, function (i, item) {
                    $el.append($('<option>', {
                        value: item.subjectID,
                        text: item.name
                    }));
                });
            }
        });
    });

    $("#submit").click(function () {

        $.ajax({
            url: "/Teacher/Marks",
            type: 'POST',
            dataType: "html",
            data: { classId: $('#class_list').val(), subjectId: $('#subject_list').val() },
            success: function (response) {
                $("#student_list").html(response);
            }
        });

    });

    $(document).on('click', '.addMark', function (evt) {

        $.ajax({
            url: "/Teacher/AddMarkShowModal",
            type: 'POST',
            dataType: "html",
            data: { subjectCardId: $(this).attr('id') },
            success: function (response) {
                $("#addMarkModal").html(response);
                $('#myModal').modal('show');
            }
        });

    });

    $(document).on('click', '#submitMark', function () {

        $.ajax({
            url: "/Teacher/AddMark",
            type: 'POST',
            data: { subjectCardId: $('#subjectCard').val(), grade: $('#garde_list').val() },
            success: function (response) {
                window.location.href = response;
            }
        });

    });

});